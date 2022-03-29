using Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
	class CHighlight
    {
		string HTMLSource = "";                     // 來源字串

		CPostfixStack PostfixStack = new CPostfixStack();      // 運算用的

		// 搜尋字串中 "詞" 的數量, 例如 菩薩 * 羅漢 = 2 個詞
		int FoundPosCount = 0;                  // FoundPos 的數量

		// 儲存找到的位置 (這是忽略標點的位置)
		// 每一個詞都要有一個記錄位置的空間, 這是一個二維陣列
		// 例 : 菩薩 + 羅漢
		// FoundPos[0] 是 "菩薩" 的位置, FoundPos[1] 是 "羅漢" 的位置.
		// FoundPos[0]->Int2s->Items[n] 表示是第n個菩薩的位置, 頭尾位置就是其 TPoint(x,y)
		// TmyInt2List ** FoundPos;
		CInt2List[] FoundPos;

		// 例如某字對應到真實的是組字 [金*本],
		// pair 內容就是 '['位置及字串長度 5
		//map<int, pair<System::WideChar*, int>> PosToReal;  // Pos 轉成不忽略標點的真實位置
		Dictionary<int, (int, int)> PosToReal = new Dictionary<int, (int, int)>();

		// 這三個是要塗色用的重要資料, 記錄每一個字對應了哪些定位, 連結, 塗色
		// 定位, 後面接 vector , 三組一個單位, 分別是 第 x 組, 第 y 次出現, 下一次出現 (最後則回到 0)
		// map<System::WideChar*, vector<int>> mpWordAnchor;
		Dictionary<int, List<int>> mpWordAnchor = new Dictionary<int, List<int>>();
		// 連結, 每個字只有一組,
		//map<System::WideChar*, pair<int, int>> mpWordLink;
		Dictionary<int, (int, int)> mpWordLink = new Dictionary<int, (int, int)>();
		// 塗色, 每個字都可能好幾個顏色
		//map<System::WideChar*, vector<int>> mpWordClass;
		Dictionary<int, List<int>> mpWordClass = new Dictionary<int, List<int>>();
		// 每一個字的長度, 例如組字式就會比較長
		//map<System::WideChar*, int> mpWordLength;
		Dictionary<int, int> mpWordLength = new Dictionary<int, int>();

		// 每一個詞都有一個串列, 這是要記錄目前已畫線的串列是畫到什麼地方了.

		List<int> FoundPosIndex = new List<int>();
		CMonster SearchEngine;   // 全文檢索引擎

		public CHighlight(CMonster seSearchEngine)
        {
			SearchEngine = seSearchEngine;
			PosToReal[0] = (0, 0);   // 如果傳入 0 , 也傳回 0, 這在最後一筆塗色之後會用到
		}

		// 處理塗色
        public string AddHighlight(string sSource) 
        {
			HTMLSource = sSource;

			GetAllFoundPos();       // 將所有的詞的範圍都找出來
			FindTheRange();         // 將合乎要求的範圍找出來 (經過布林運算了)

			if (SearchEngine.OKSentence.Contains("*") ||
			   SearchEngine.OKSentence.Contains("+") ||
			   SearchEngine.OKSentence.Contains("-")) {
				KeepRangePos();         // 將每一個詞符合最終位置的留下來.
			}

			// 把每一個字要定位、塗色與連結的資料都記錄下來, 包括重疊的字
			GetEveryWordInfo();
			return MakeHighlight();
		}

		// 將所有的詞的位置先找到
		void GetAllFoundPos()
		{
			// 搜尋字串中 "詞" 的數量, 例如 菩薩 * 羅漢 = 2 個詞
			FoundPosCount = SearchEngine.SearchWordList.Count;

			// 每一個詞都要有一個記錄位置的空間, 這是一個二維陣列
			FoundPos = new CInt2List[FoundPosCount];

			for (int i = 0; i < FoundPosCount; i++) {
				FoundPos[i] = new CInt2List();      // 宣告一個空間
				GetOneFoundPos(i);                  // 取得每一個詞的位置
			}
		}

		// 將某個詞的位置先找到
		void GetOneFoundPos(int iNum)
        {
			/*
				1.過濾標記及標記, 直到第一個字出現
				2.判斷是不是目前要找的字.
				3.是就記錄, 並繼續找
				4.不是就記錄, 並繼續找

				matching = 0;		// 是否在比對中
				pos = 0				// 字數
				pFindWord = Tag;	// Tag 是要比對的字串

				while(*point)
				{
					// 移除標記及標點

					wiile(*point)
					{
						if (tag) skip tag and continue;
						if (sign) skip sign and continue;
						break;
					}

					pos++;

					if(*point == *pFindWord)	// 找到字
					{
						if(!matching)
						{
							matching = 1;
							postmp = pos;
							pointtmp = point;
						}
						point++;
						pFindWord++;

						if(!pFindWord)	// 找到並結束
						{
							postmp is the answer;
							matching = 0;
							pFindWord = Tag;
						}
					}
					else		// 沒找到
					{
						if(matching)
						{
							matching = 0;
							point = pointtmp;
							pos = postmp;
							pFindWord = Tag;
						}
						point++;
					}
				}
			*/

			string sWord = SearchEngine.SearchWordList[iNum];
			bool bMatching = false;     // 判斷是否在比對中
			int iPos = -1;      // 去掉標記及標點之後的字數, 第一個字由 0 開始 (初值為0是因為一開始還可能不是字, 是標記或標點)
			int iPosTmp = 0;
			int pPoint = 0;     // 遊走在 HTMLSource 的指標
			int pPointTmp = 0;
			int i1stWordLen = 0;    // 第一個字的長度, 要記起來

			// 處理缺字用的
			int pDesPoint = 0;
			int pUniPoint = 0;
			int iDesLen = 0;
			int iUniLen = 0;

			int pFindWord = 0; // sWord.c_str();        // 要塗色的字
			pFindWord = NextFindPoint(sWord, pFindWord);   // 移到下一個可以查詢的字

			// 例如搜尋 "雜阿含 + 阿含" , 這個字串會出現在 HTML 最上方.
			// 第二組的 "阿含" 必須在第一組之後, 以免重疊
			// 例如雜阿含的位置是 (1~3) , 所以 "阿含" 的 iPos 必須 > 3
			// 所以要先找出上一組第一筆的結束位置

			int iAfterThisPos = 0;
			if (iNum > 0) {
				(int x, int y) tpPtr = FoundPos[iNum - 1].Int2s[0];
				iAfterThisPos = tpPtr.y;
			}

			// 先移至 <div id='SearchHead'> 的地方

			pPoint = HTMLSource.IndexOf("<div id='SearchHead'>");
			if(pPoint >= 0) {
				pPoint += 21;
            } else {
				CGlobalMessage.push("沒找到指定標記，程式要再檢查處理");
			}

			// =====================================================
			// 開始分析

			while (pPoint < HTMLSource.Length) {
				// 移除標記及標點
				int iTagNum = 0;
				bool bShowError = false;    // 有沒有錯誤訊息? 如果有就設為 true, 就不用一直秀
				while (pPoint < HTMLSource.Length) {
					// 特殊狀況, 遇到行首標記
					// if (wcsncmp(pPoint, u"<span class='linehead'>", 23) == 0 ||
					// 	   wcsncmp(pPoint, u"<span class='parahead'>", 23) == 0)
					if (StrHas(HTMLSource, pPoint, "<span class='linehead'") ||
						StrHas(HTMLSource, pPoint, "<span class='parahead'")) {
						// <span class="linehead">GA009n0008_p0003a01║</span>
						// <span class="linehead">ZS01n0001_p0001a01║</span>
						// <span class="linehead">ZW01n0001_p0001a01║</span>
						// <span class="linehead">A001n0001_p0001a01║</span>
						// <span class="linehead">T30n1579_p0279a10║</span>
						// <span class="parahead">[0279a09] </span>

						// 有時是 <span class='linehead' style='display:none'>

						int iDisplay = 0;   // 加上 display:'none' 的位移
						if (HTMLSource[pPoint + 22] == ' ' && HTMLSource[pPoint + 23] == 's') {
							iDisplay = 21;
						}

						if (HTMLSource[pPoint + 23 + iDisplay] == '[') {
							pPoint += 40 + iDisplay;
						} else if (HTMLSource[pPoint + 36 + iDisplay] == 'p') {
							pPoint += 52 + iDisplay;
						} else if (HTMLSource[pPoint + 35 + iDisplay] == 'p') {
							pPoint += 51 + iDisplay;
						} else if (HTMLSource[pPoint + 34 + iDisplay] == 'p') {
							pPoint += 50 + iDisplay;
						} else if (HTMLSource[pPoint + 33 + iDisplay] == 'p') {
							pPoint += 49 + iDisplay;
						} else if (HTMLSource[pPoint + 32 + iDisplay] == 'p') {
							pPoint += 48 + iDisplay;
						} else {
							if (!bShowError) {
								CGlobalMessage.push("LineHead Error : Please call Heaven!");
								bShowError = true;
							}
							pPoint += 49;
						}
						continue;
					}

					// 處理缺字
					if (StrHas(HTMLSource, pPoint, "<span class='gaiji'")) {
						AnalysisGiajiTag(pPoint, pDesPoint, pUniPoint, ref iDesLen, ref iUniLen); // 處理缺字標記
					}

					// 1.遇到標記, 要額外處理

					if (HTMLSource[pPoint] == '<') {
						iTagNum++;      // 因為標記有巢狀, 所以要計數
						pPoint++;
						continue;
					}

					if (HTMLSource[pPoint] == '>') {
						iTagNum--;
						pPoint++;
						continue;
					}

					if (iTagNum > 0 && pPoint < HTMLSource.Length) {
						pPoint++;
						continue;
					}

					// 2.星號 [＊]
					if (StrHas(HTMLSource, pPoint, "[＊]")) {
						pPoint += 3;
						continue;
					}

					// 3.純數字 [01] , 這在卍續藏出現
					if (HTMLSource[pPoint] == '[') {
						int pTmp = pPoint;
						pPoint++;

						if (StrHas(HTMLSource, pPoint, "P.")) {  // 南傳有 [P.nn] 的 PTS 頁碼
							pPoint += 2;
						} else if (HTMLSource[pPoint] == 'A') {              // CBETA 自訂校注是 [Axx]
							pPoint++;
						}

						if (HTMLSource[pPoint] >= '0' && HTMLSource[pPoint] <= '9') {
							while (HTMLSource[pPoint] >= '0' && HTMLSource[pPoint] <= '9') {
								pPoint++;
							}
							if (HTMLSource[pPoint] == ']') {
								pPoint++;
								continue;
							}
						}
						pPoint = pTmp;
					}

					// 4.校勘數字 [<a id="a0001005" ....<..巢狀..>. >5</a>]
					// ???? 這個新版的會改
					if (HTMLSource[pPoint] == '[') {
						int pTmp = pPoint;
						pPoint++;

						if (HTMLSource[pPoint] == '<') {
							// 有巢狀的標記, 不能這樣用
							//while(*pPoint != '>' && *pPoint) pPoint++;

							int iTagNumTmp = 1;
							while (iTagNumTmp > 0 && pPoint < HTMLSource.Length) {
								pPoint++;
								if (HTMLSource[pPoint] == '>') { 
									iTagNumTmp--; 
								}
								if (HTMLSource[pPoint] == '<') {
									iTagNumTmp++;
								}
							}

							if (HTMLSource[pPoint] == '>') {
								pPoint++;
								// 卍續藏校注有 [科XX] or [標XX] or [解XX]
								//if (wcsncmp(pPoint, u'科', 1) == 0)
								if (HTMLSource[pPoint] == '科') {
									pPoint += 1;
								}
								//else if (wcsncmp(pPoint, L'標', 1) == 0)
								else if (HTMLSource[pPoint] == '標') {
									pPoint += 1;
								}
								//else if (wcsncmp(pPoint, L'解', 1) == 0)
								else if (HTMLSource[pPoint] == '解') {
									pPoint += 1;
								}

								while (HTMLSource[pPoint] >= '0' && HTMLSource[pPoint] <= '9') {
									pPoint++;
								}

								if (HTMLSource[pPoint] == '＊')	{
									pPoint += 1;
								}
								if (StrHas(HTMLSource, pPoint, "</a>]")) {
									pPoint += 5;
									continue;
								}
							}
						}
						pPoint = pTmp;
					}

					// 5.忽略標點符號

					if (CWordTool.GetWordType(HTMLSource[pPoint]) == CWordTool.EWordType.wtPunc) {
						if (HTMLSource[pPoint] != '[') { // 組字式不忽略
							pPoint++;
							continue;
						}
					}

					// 6.忽略空白

					if (CWordTool.GetWordType(HTMLSource[pPoint]) == CWordTool.EWordType.wtSpace) {
						pPoint++;
						continue;
					}

					// 表示都沒有要過濾的了
					break;
				}

				if (pPoint >= HTMLSource.Length) {
					break;        // 如果結束就跳出迴圈
				}

				iPos++;                 // 又找到一個真正的字了
				
				// 傳回下一個字的長度, 可能是ext-b中文=2, 組字>2, 中英數符號1

				// 待比對的字的長度
				int iThisWordLen = CWordTool.GetFirstTokenLength(HTMLSource, pPoint, true, true, true);
				// 要查詢的字的長度
				int iFindWordLen = CWordTool.GetFirstTokenLength(sWord, pFindWord, true, true, true);

				if (sWord[pFindWord] == '?') { 		// 萬用字元
					PosToReal[iPos] = (pPoint, iThisWordLen);
					// 這時 bMarching 一定是 true
					pPoint += iThisWordLen;
					pFindWord++;
				} else if (iPos > iAfterThisPos &&
					((StrnCmp(HTMLSource, pPoint, sWord, pFindWord, iThisWordLen) && iThisWordLen == iFindWordLen) ||
					 (iDesLen == iFindWordLen && StrnCmp(HTMLSource, pDesPoint, sWord, pFindWord, iDesLen)) ||
					 (iUniLen == iFindWordLen && StrnCmp(HTMLSource, pUniPoint, sWord, pFindWord, iUniLen)))) {
					// 找到了 (包括缺字中的組字式或unicode)
					PosToReal[iPos] = (pPoint, iThisWordLen);

					if (!bMatching) {              // 目前是第一個字
						i1stWordLen = iThisWordLen;
						bMatching = true;
						iPosTmp = iPos;         // 目前位置記起來
						pPointTmp = pPoint;     // 目前位置記起來
					}

					pPoint += iThisWordLen;
					pFindWord += iFindWordLen;
					pFindWord = NextFindPoint(sWord, pFindWord);   // 移到下一個可以查詢的字

					if (pFindWord >= sWord.Length) {        // 比對完全結束, 恭禧!!!
						bMatching = false;
						FoundPos[iNum].Add(iPosTmp, iPos);  // 將找到的位置存起來 (頭, 尾)
						pFindWord = NextFindPoint(sWord, 0);       // 要塗色的字
					}
				} else {   // 找不到
					if (bMatching) {
						bMatching = false;
						pPoint = pPointTmp;
						iPos = iPosTmp;
						pFindWord = NextFindPoint(sWord, 0);       // 要塗色的字
						pPoint += i1stWordLen;
					} else {
						pPoint += iThisWordLen;
					}
				}
				iDesLen = 0;    // 要歸零
				iUniLen = 0;
			}
		}

		// 將合乎要求的範圍找出來 (經過布林運算了), 傳回找到的組數
		void FindTheRange()
		{
			/*
			###################################
			# 練習計算機運算
			#
			# 原則
			#  如果是數字, 如果有運算符號, 且層數都一樣, 就運算, 結果推入 query stack
			#  如果是數字, 如果有運算符號, 如果層數不一樣, 推入 query stack
			#  如果是數字, 沒有運算符號, 推入 query stack
			#
			#  如果是運算符號, 推入 op stack , 且記錄目前層數
			#
			#  如果是左括號, 目前層數 + 1
			#  如果是右括號, 層數 - 1 , 並且運算
			###################################
			*/

			PostfixStack.Initial();
			string sPatten;
			string sOKSentence = SearchEngine.OKSentence;  // 暫存的字串		// 儲存找到的位置

			// 目前第幾個字串? 例如 (S&S)|S  (佛陀&阿難)|布施  佛陀是第 0 個
			int iPattenNum = 0;

			//while (sOKSentence.Length())
			for (int i = 0; i < sOKSentence.Length; i++) {
				sPatten = sOKSentence.Substring(i, 1);     // 取出 patten

				if (SearchEngine.OpPatten.Contains(sPatten)) {         // 如果是運算符號的話
					PostfixStack.PushOp(sPatten);
				} else {
					// ???? 加速的方法, 如果是 and 就只算前一個有結果的, 如果是 or 就只查前一個是沒找到的
					// ???? 加速的方法, 如果不統計次數, 有找到就算數, 那麼速度會更快

					// 處理一個字

					// 第一組先取出來, 因為第一組只是示範, 不能列入計算  (舊的判斷法)

					// 底下是新方法
					// 不只第一組了... 因為搜尋字串可能是 "舍利 - 舍利弗" , 所以 "舍利" 會在 html 一開始就出現二次
					// 所以判斷法要改成 在最後一組的最後一個字之前出現的, 所有的 "舍利" 都要先取出來

					(int x, int y) tpPtrLast = FoundPos[FoundPosCount - 1].Int2s[0]; // html 上方示範字串最後一組的位置, 如   "舍利 ! 舍利弗" , 表示 "舍利弗" 那一組
					int iLastPos = tpPtrLast.y; // "舍利 - 舍利弗" , "弗" 的位置, 此位置之前的都要先移除.

					List<(int x, int y)> vSavePtr = new List<(int x, int y)>();  // 要把刪除的記錄先存下來, 最後再存回去
					vSavePtr.Clear();

					// 每個詞的第一組一定要移除並記錄起來
					var tpPtr = FoundPos[iPattenNum].Int2s[0];
					FoundPos[iPattenNum].Int2s.RemoveAt(0);
					vSavePtr.Add(tpPtr);

					// 再移除重複的
					while (FoundPos[iPattenNum].Int2s.Count > 0) {
						// 再次取出第一組
						tpPtr = FoundPos[iPattenNum].Int2s[0];
						// 位置比最後一個詞的第一組的最後一個字還小, 就要移除.
						// 舍利 - 舍利弗 => 比 "弗" 還小的就不要計算, 那不是經文
						if (tpPtr.x <= iLastPos) {
							FoundPos[iPattenNum].Int2s.RemoveAt(0);
							vSavePtr.Add(tpPtr);
						} else {
							break;
						}
					}

					sPatten = SearchEngine.SearchWordList[iPattenNum];    // 取出某一筆字串
					PostfixStack.PushQuery(FoundPos[iPattenNum], sPatten);

					// 再把刪掉的各組放回去
					for (int j = vSavePtr.Count; j > 0; j--) {
						tpPtr = vSavePtr[j - 1];
						FoundPos[iPattenNum].Int2s.Insert(0, tpPtr);
					}

					iPattenNum++;
				}
			}
			// ???? 這是組數, 不是筆數, 例如 佛陀 near 阿難 可能算是 1 組
			//return (PostfixStack->QueryStack[0]->Int2s->Count);
		}

		// 將每一個詞符合最終位置的留下來.
		void KeepRangePos()
		{
			// 每一個詞都要處理
			for (int i = 0; i < SearchEngine.SearchWordList.Count; i++) {
				// 每一個詞的每一個範圍都要比較

				int jj = FoundPos[i].Int2s.Count - 1; // 由後面來, 刪除才不會破壞序列
				for (int j = jj; j > 0; j--)                    // j=0 不處理, 因為第一組是示範, 一定要留著.
				{
					bool bInRange = false;  // 判斷有沒有在範圍之中
					var tpPtr = FoundPos[i].Int2s[j];
					int x = tpPtr.x;

					// 判斷有沒有在結果的範圍之中
					for (int k = 0; k < PostfixStack.QueryStack[0].Int2s.Count; k++) {
						var tpPtr1 = PostfixStack.QueryStack[0].Int2s[k];
						if (x >= tpPtr1.x && x <= tpPtr1.y) {
							// 找到了就跳出來
							bInRange = true;
							break;
						}
					}

					if (!bInRange) {   // 沒找到, 所以要刪除
						FoundPos[i].Int2s.RemoveAt(j);
					}
				}
			}
		}

		// 把每一個字要定位、塗色與連結的資料都記錄下來, 包括重疊的字
		// 例如第一組詞 AB , 第二組詞 BC , 內文是 "ABC"
		// 則 A: 記錄定位 <a name="0_0" href="#0_1"></a> ,這裡的 href 可以留給程式找下一個連結
		//    A: 記錄 class word0 , 連結下一個點.
		//    B: 記錄 class word0 , 連結下一個點.
		// 第二詞的
		//    B: 記錄定位 <a name="1_0" href="#1_1"></a>
		//    B: 記錄 class word1 (重覆 class) , 因為已有連結, 就不設定連結了.
		//    C: 記錄 class word0 , 連結下一個點.

		// 做法 : 第一組 (ABC... 其實是 RealPos 真實位置)
		// map 定位[A] => 0_0
		// map 連結[A] => 0_1
		// map 連結[B] => 0_1
		// map 塗色[A] => word0
		// map 塗色[B] => word0
		// 第二組
		// map 定位[B] => 1_0
		// map 連結[B] => 0_1
		// map 連結[C] => 0_1
		// map 塗色[B] => word1
		// map 塗色[C] => word1

		// 實作
		// 這三個是要塗色用的重要資料, 記錄每一個字對應了哪些定位, 連結, 塗色

		// 定位, 後面接 vector , 二組一個單位, 分別是 第 x 組, 第 y 次出現
		// map <wchar_t *, vector<int>> mpWordAnchor;

		// 連結, 每個字只有一組,
		// map <wchar_t *, pair<int,int>> mpWordLink;

		// 塗色, 每個字都可能好幾個顏色
		// map <wchar_t *, vector<int>> mpWordClass;

		// 每一個字的長度, 例如組字式就會比較長
		// map <wchar_t *, int> mpWordLength;

		// 記錄每一字的定位、連結、塗色
		void GetEveryWordInfo()
		{
			mpWordAnchor.Clear();
			mpWordLink.Clear();
			mpWordClass.Clear();
			mpWordLength.Clear();

			// 每一個詞依次處理
			for (int i = 0; i < SearchEngine.SearchWordList.Count; i++) {
				// 每一個詞所有出現的地方
				for (int j = 0; j < FoundPos[i].Int2s.Count; j++) {
					// i 是第 n 個詞, j 是出現第 j 次
					var tpPtr = FoundPos[i].Int2s[j];

					// 1. 一個詞出現, 先定位, 找出此詞第一個字的真實位置
					int wc = PosToReal[tpPtr.x].Item1;

					int iNext = j + 1;    // 這是下一次出現的次序, 若下一個是最後, 就回到 0
					if (iNext == FoundPos[i].Int2s.Count) {
						iNext = 0;
					}

					if (!mpWordAnchor.ContainsKey(wc)) {
						mpWordAnchor[wc] = new List<int>();
					}
					mpWordAnchor[wc].Add(i);  // 先推入第 i 個詞
					mpWordAnchor[wc].Add(j);  // 再推入第 j 次出現
					mpWordAnchor[wc].Add(iNext);  // 再推入第 j 次出現

					int iMod = i % 5;   // 塗色的順序 class = "SearchWord x" 的那個 x

					// 每次出現的詞首至詞尾
					for (int k = tpPtr.x; k <= tpPtr.y; k++) {
						// 此詞每個字的真實位置
						var word = PosToReal[k];
						wc = word.Item1;

						// 2. 每個字都要記錄下一個連結, 這只能記錄一次
						if (!mpWordLink.ContainsKey(wc)) {
							mpWordLink[wc] = (i, iNext);
						}

						// 3. 每個字都要記錄塗色的流水序
						if (!mpWordClass.ContainsKey(wc)) {
							mpWordClass[wc] = new List<int>();
						}
						mpWordClass[wc].Add(iMod);

						// 4. 記錄此字的長度 (組字式就比較長了)
						mpWordLength[wc] = word.Item2;
					}
				}
			}
		}

		// 新版, 可以處理重疊的字的塗色與連結
		// 實際塗色
		string MakeHighlight()
		{
			/*
				新的邏輯

				1.開啟暫存空間
				2.逐字處理
				3.若此字有定位, 就處理定位, 有連結、塗色, 也一一處理
			*/

			List<char> vOutput = new List<char>();
			int pPoint = 0; // HTMLSource->FirstChar();     // 遊走在 HTMLSource 的指標

			while (pPoint < HTMLSource.Length) {
				// 判斷要不要定位
				if (mpWordAnchor.ContainsKey(pPoint)) {
					// 定位, 後面接 vector , 三組一個單位, 分別是 第 x 組, 第 y 次出現, 下一次出現 (最後則回到 0)
					// map <wchar_t *, vector<int>> mpWordAnchor;
					AddWordAnchor(vOutput, pPoint);
				}

				// 判斷要不要塗色與連結
				if (mpWordLink.ContainsKey(pPoint)) {
					// 連結, 每個字只有一組,
					// map <wchar_t *, pair<int,int>> mpWordLink;
					// 塗色, 每個字都可能好幾個顏色
					// map <wchar_t *, vector<int>> mpWordClass;
					AddWordLink(vOutput, pPoint);

					// 將此字填上去

					// 每一個字的長度, 例如組字式就會比較長
					int iLen = mpWordLength[pPoint];

					for (int i = 0; i < iLen; i++) {
						vOutput.Add(HTMLSource[pPoint]);
						pPoint++;
					}

					// 結束

					vOutput.Add('<');
					vOutput.Add('/');
					vOutput.Add('a');
					vOutput.Add('>');
				} else {
					vOutput.Add(HTMLSource[pPoint]);
					pPoint++;
				}
			}

			return string.Concat(vOutput);
		}

		// 某個要塗色的詞, 加上定位 name 的標記讓人連結, 指出是第 iNum 詞第 iTime 次出現
		// 並留下下個連結的位置, 此屬性可留給 javascript 應用
		// <a name="Search_iNum_iTime" href="#Search_iNum_iNext"></a>
		// 傳入的 vector 三組一個單位, 分別是 第 x 組, 第 y 次出現, 下一次出現 (最後則回到 0)
		void AddWordAnchor(List<char> vOutput, int pPoint)
		{
			var vData = mpWordAnchor[pPoint];
			for (int i = 0; i < vData.Count; i += 3) {
				string sTag = "<a name='Search_" + vData[i].ToString() + "_" +
						vData[i+1].ToString() + "' href='Search_" + vData[i].ToString() +
						"_" + vData[i+2].ToString() + "'></a>";
				foreach (char c in sTag) {
					vOutput.Add(c);
				}
			}
		}

		// 加上連結及塗色的 class , 例如:
		// <a href="#Search_x_y" class="SearchWord1 SearchWord2 SearchWord3...">
		// 連結, 每個字只有一組,
		// map <wchar_t *, pair<int,int>> mpWordLink;
		// 塗色, 每個字都可能好幾個顏色
		// map <wchar_t *, vector<int>> mpWordClass;
		void AddWordLink(List<char> vOutput, int pPoint)
		{
			int iNum = mpWordLink[pPoint].Item1;    // 第幾個詞組
			int iTime = mpWordLink[pPoint].Item2;  // 連結到第幾次出現

			// 先設定連結 <a href="

			string sTag = $"<a href='#Search_{iNum}_{iTime}' class='";

			// 設定 class

			var vClass = mpWordClass[pPoint];

			for (int i = 0; i < vClass.Count; i++) {
				int iMod = vClass[i];

				if (i > 0) {
					sTag += " ";   // 第一個不用空格
				}
				sTag = sTag + $"SearchWord{iMod}";
			}

			sTag = sTag + "'>";
			foreach (char c in sTag) {
				vOutput.Add(c);
			}
		}

		// 移到下一個可以查詢的字
		// 例如查詢的字串是 "ABC XYA 如是，我聞"
		// 目前指標可能在空白或標點，要往下一個可查詢的字移到動

		//int NextFindPoint(strnig str, int pFindWord)
		int NextFindPoint(string str, int pFindWord)
		{
			while (true) {
				if (pFindWord >= str.Length) {
					return pFindWord;   // 到底了
				}
				if (str[pFindWord] == '?') {
					return pFindWord;   // 問號是可以的
				}

				// 取出下一個字的長度
				int iLen = CWordTool.GetFirstTokenLength(str, pFindWord, true, true, true);

				if (iLen > 1) {
					return pFindWord; // 長度 > 1 => ext-b, 組字, 標記, 英文單字 &xxx;
				}

				CWordTool.EWordType wtType = CWordTool.GetWordType(str[pFindWord]);

				if (wtType == CWordTool.EWordType.wtSpace || wtType == CWordTool.EWordType.wtPunc) {
					pFindWord++;
				} else {
					return pFindWord;
				}
			}
		}

		// 分析一個 <span class="gaiji"....> 標記
		void AnalysisGiajiTag(int pPoint, int pDesPoint, int pUniPoint, ref int iDesLen, ref int iUniLen)
		{
			// <span class="gaiji" data-des="[組字式]" data-uni="xx" data-nor="xx" data-noruni="xx">

			// 先取出整個 Tag

			int iTagLen = 1;
			int pTmp = pPoint;
			while (HTMLSource[pTmp] != '>') {
				iTagLen++;
				pTmp++;
			}
			string sTag = HTMLSource.Substring(pPoint, iTagLen);
			pPoint = pTmp + 1;

			int iPos;
			// 先找有沒有組字式
			iPos = sTag.IndexOf("data-des");
			iDesLen = 0;
			pDesPoint = 0;
			if (iPos >= 0) {
				pDesPoint = iPos + 10;  // 指到組字式的 [ 字
				pTmp = pDesPoint;
				while (sTag[pTmp] != '\'') {
					iDesLen = iDesLen + 1;
					pTmp++;
				}
			}
			// 再找有沒有 Unicode
			iPos = sTag.IndexOf("data-uni");
			iUniLen = 0;
			pUniPoint = 0;
			if (iPos >= 0) {
				pUniPoint = iPos + 10;  // 指到 Unicode
				pTmp = pUniPoint;
				while (sTag[pTmp] != '\'') {
					iUniLen = iUniLen + 1;
					pTmp++;
				}
			}
		}

		bool StrHas(string s1, int p1, string s2)
		{
			return StrnCmp(s1, p1, s2, 0, s2.Length);
		}

		bool StrnCmp(string s1, int p1, string s2, int p2, int len)
		{
			if (string.Compare(s1, p1, s2, p2, len) == 0) {
				return true;
			} else {
				return false;
			}
		}
	}
}
