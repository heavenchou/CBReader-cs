using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    // 這個物件是二組 Int 的列表所組合出來的, 每一組表示某一字的範圍
    public class CInt2List
	{
		public List<(int x, int y)> Int2s;		// 裡面放 TPoint 物件, 每一個 point 表示某一詞的範圍
		int NearNum = 30;				// Near 運算的範圍
		int BeforeNum = 30;             // Before 運算的範圍

		public string SearchString = "";	// 搜尋的字串, 一開始可能是 "佛陀" 這種詞, 在運算後可能變成 "(佛陀+羅漢)" 這種運算結果. 這其實是為 ! 運算設計的
		
		// 建構函式
		public CInt2List()
        {
			Int2s = new List<(int x, int y)>();
		}
		
		// 全部清掉
		public void ClearAll()
		{
			Int2s.Clear();
		}

		//void __fastcall operator=(TmyInt2List* ilTarget);		// 運算子多載
		//void __fastcall operator&=(TmyInt2List* ilTarget);		// 運算子多載
		//void __fastcall operator|=(TmyInt2List* ilTarget);		// 運算子多載


		// 加入一筆資料
		public void Add((int, int) tpNew)
		{
			Int2s.Add(tpNew);
		}

		// 加入一筆資料 
		public void Add(int x, int y)
		{
			Int2s.Add((x, y));
		}

		// 刪除某一筆資料      
		public void Delete(int iNum)
		{
			Int2s.RemoveAt(iNum);
		}

		// 將資料 copy 過來
		public void Copy(CInt2List ilTarget)
        {
			Int2s = new List<(int x, int y)>();
			foreach (var item in ilTarget.Int2s) {
				Int2s.Add(item);
			}
        }

		// 若二者都有資料, 就二者合併        
		public void AndIt(CInt2List ilTarget)
        {
			// 只要有一個人是 0 , 就玩不下去了

			string sSearchString = "(" + SearchString + "&" + ilTarget.SearchString + ")";     // 變成 "(word1&word2)"
			if(Int2s.Count == 0 || ilTarget.Int2s.Count == 0) {
				ClearAll();
			} else {  
				//接下來就要將二人合併了
				OrIt(ilTarget);
			}
			SearchString = sSearchString;     // 變成 "(word1&word2)"
		}

		// 二者合併
		public void OrIt(CInt2List ilTarget)
		{
			int iIndex = 0;     // 移動中的指標
			(int x, int y) tpPtr1, tpPtr2;

			string sSearchString = "(" + SearchString + "," + ilTarget.SearchString + ")";     // 變成 "(word1,word2)"
			if(Int2s.Count == 0) {   // 我自己沒有資料
				Copy(ilTarget);
				SearchString = sSearchString;
				return;
			}

			if(ilTarget.Int2s.Count == 0) {     // 對方沒有資料
				SearchString = sSearchString;
				return;
			}

			for(int i = 0; i < ilTarget.Int2s.Count; i++) {
				tpPtr1 = Int2s[iIndex];
				tpPtr2 = ilTarget.Int2s[i];
				while(tpPtr2.x >= tpPtr1.x) {
					iIndex++;
					if(iIndex == Int2s.Count) break;
					tpPtr1 = Int2s[iIndex];
				}
				Int2s.Insert(iIndex, tpPtr2);
			}
			SearchString = sSearchString;
		}

		// 若二者靠近至某一個程度, 則變成一個範圍        
		public void NearIt(CInt2List ilTarget)
		{
			NearNum = 30;
			string sSearchString = "(" + SearchString + "+" + ilTarget.SearchString + ")";     // 變成 "(word1+word2)"

			// 沒資料就結束
			if(Int2s.Count == 0 || ilTarget.Int2s.Count == 0) {
				ClearAll();
				SearchString = sSearchString;
				return;
			}

			List<(int x, int y)> tlResult = new List<(int x, int y)>();     // 放結果用的
			(int x, int y) tpPtr1, tpPtr2;

			for(int i = 0; i < Int2s.Count; i++) {
				for(int j = 0; j < ilTarget.Int2s.Count; j++) {
					tpPtr1 = Int2s[i];
					tpPtr2 = ilTarget.Int2s[j];

					// 找到一組
					if((tpPtr2.x - tpPtr1.y <= NearNum) && (tpPtr1.x - tpPtr2.y <= NearNum)) {
						(int x, int y) tpNew = (Math.Min(tpPtr1.x, tpPtr2.x), Math.Max(tpPtr1.y, tpPtr2.y));
						tlResult.Add(tpNew);
					} else {
						if(tpPtr2.x - tpPtr1.y > NearNum) {
							break;  // 找不到了, 換下一組
						}
					}
				}
			}

			ClearAll();
			Int2s = tlResult;           // 換成成果
			SearchString = sSearchString;
		}

		// 同 Near , 不過只能在其後面, 也就是有順序的      
		public void BeforeIt(CInt2List ilTarget)
		{
			BeforeNum = 30;
			string sSearchString = "(" + SearchString + "*" + ilTarget.SearchString + ")";     // 變成 "(word1*word2)"

			// 沒資料就結束
			if(Int2s.Count == 0 || ilTarget.Int2s.Count == 0) {
				ClearAll();
				SearchString = sSearchString;
				return;
			}

			List<(int x, int y)> tlResult = new List<(int x, int y)>();     // 放結果用的
			(int x, int y) tpPtr1, tpPtr2;

			for(int i = 0; i < Int2s.Count; i++) {
				for(int j = 0; j < ilTarget.Int2s.Count; j++) {
					tpPtr1 = Int2s[i];
					tpPtr2 = ilTarget.Int2s[j];

					// 找到一組
					if((tpPtr2.x - tpPtr1.x > 0) && (tpPtr2.x - tpPtr1.y <= BeforeNum)) {
						(int x, int y) tpNew = (tpPtr1.x, Math.Max(tpPtr1.y, tpPtr2.y));
						tlResult.Add(tpNew);
					} else {
						if(tpPtr2.x - tpPtr1.y > BeforeNum) {
							break;    // 找不到了, 換下一組
						}
					}
				}
			}

			ClearAll();
			Int2s = tlResult;           // 換成成果
			SearchString = sSearchString;
		}

		// 排除某一個詞, 例如  舍利-舍利弗 表示只要找舍利, 但不要找到舍利弗
		public void ExcludeIt(CInt2List ilTarget)
		{
			// 做法 :
			// 先找這個詞的詞距 , 例如 舍利-舍利弗 詞距為 0 , 而 羅漢!阿羅漢 則詞距為 1 (第一個詞在第二個詞的位置)
			// 再分別搜尋這二個詞 , 搜尋後再處理,
			// 例如舍利 找到  1, 10, 20, 30 , 而舍利弗找到 1, 20 , 表示這二組要移除

			//int iExcludeNum = (ilTarget->SearchString.AnsiPos(SearchString) - 1)/2; // 詞距

			// 可惜這一段也沒用了
			//int iExcludeNum = MyAnsiPos(SearchString , ilTarget->SearchString) - 1; // 詞距, 減一是希望由 0 算起

			string sSearchString = "(" + SearchString + "-" + ilTarget.SearchString + ")";     // 變成 "(word1!word2)"

			if(Int2s.Count == 0)   // 我自己沒有資料
			{
				ClearAll();
				SearchString = sSearchString;
				return;
			}

			if(ilTarget.Int2s.Count == 0)     // 對方沒有資料, 或二個詞根本沒有相同處
			{
				SearchString = sSearchString;
				return;
			}

			(int x, int y) tpPtr1, tpPtr2;

			for(int i = 0; i < Int2s.Count; i++) {
				tpPtr1 = Int2s[i];

				for(int j = 0; j < ilTarget.Int2s.Count; j++) {
					tpPtr2 = ilTarget.Int2s[j];

					// 找到重複的 , 這一組要刪除
					// if((tpPtr1->x - tpPtr2->x == iExcludeNum)) // 這是舊的方法, 要換成 tpPtr1 與 tpPtr2 不在彼此範圍中
					if(((tpPtr1.x >= tpPtr2.x) && (tpPtr1.y <= tpPtr2.y)) || ((tpPtr1.x <= tpPtr2.x) && (tpPtr1.y >= tpPtr2.y))) {
						Delete(i);
						i--;
						break;
					}
					if(tpPtr2.x > tpPtr1.y) { // 不用再找了, 找不到的.
						break;
					}
				}
			}

			SearchString = sSearchString;
		}

		// 單元測試檢測用的
		public string toString()
		{
			string sOut = "[";
			for(int i=0; i<Int2s.Count; i++) { 
				if (i != 0) {
					sOut += ",";
				}
				sOut += "(" + Int2s[i].x.ToString() + "," + Int2s[i].y.ToString() + ")";
			}
			sOut += "]";
			return sOut;
		}
	}
}
