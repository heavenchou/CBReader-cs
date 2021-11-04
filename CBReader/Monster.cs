using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    public class CMonster
    {
        string FileListFileName;        // file list 檔名
        string WordIndexFileName;       // word index 檔名
        string MainIndexFileName;       // 主要的 index 的檔名
        string OpPatten = "()&,+*-";    // 運算用的 Patten

        List<string> SearchWordList;    // 存放每一個檢索的詞, 日後塗色會用到
        public CIntList FileFound;      // 存放每一檔找到的數量

        int FileHintCount = 0;          // 找到有資料的檔案的數量, 例如有 5 個檔案有找到, 此數值為 5
        CPostfixStack PostfixStack;     // 運算用的
        string SearchSentence = "";     // 主要搜尋的字串
        string OKSentence;              // 已經分析過的, 例如 佛陀 & 阿難 變成 S&S
        int MaxSearchWordNum = 0;       // 檢索詞中最多可出現的字串數,   "佛陀 & 阿羅漢" 就算 2 個

        List<CSearchWord> swWord;       // 每一個檢索字串的指標, 最多 20 個, 例如 "佛陀 & 阿羅漢" 就算 2 個

        // 底下三個都改成對外公開的
        CFileList BuildFileList;        // build file list;
        CWordIndex WordIndex;           // build file list;
        CMainIndex MainIndex;           // Last index file
    
        // 建構式
        public CMonster(string sFileList, string sWordIndex, string sMainIndex)
        {
            FileListFileName = sFileList;
            WordIndexFileName = sWordIndex;
            MainIndexFileName = sMainIndex;

            SearchWordList = new List<string>();   // 存放每一個檢索的詞, 日後塗色會用到
            //MaxSearchWordNum = 20;              // 檢索詞中最多可出現的字串數,   "佛陀 & 阿羅漢" 就算 2 個
            swWord = new List<CSearchWord>();  // ???? 這可以改成 vector

            BuildFileList = new CFileList(FileListFileName);
            BuildFileList.Initial();
            WordIndex = new CWordIndex(WordIndexFileName);
            WordIndex.Initial();
            MainIndex = new CMainIndex(MainIndexFileName);

            PostfixStack = new CPostfixStack();
            FileFound = new CIntList(BuildFileList.FileCount);	// 存放每一檔找到的結果
        }

        // 尋找一個字串, 應該要傳回一個檔案串, 表示哪些檔案有
        // 若運算失敗, 傳回 false
        public bool Find(string sSentence, bool bHasSearchRange)
        {
            bool bResult = true;
            FileFound.ClearAll();       // 每一檔找到的數量歸 0
            SearchWordList.Clear();
            OKSentence = "";            // 全部歸 0
            FileHintCount = 0;
            SearchSentence = sSentence;

            if(AnalysisSentence(sSentence)) {     // 分析, 並產生 OKSentence
                for(int i = 0; i < BuildFileList.FileCount; i++) {
                    int iResult;
                    if(!bHasSearchRange || BuildFileList.SearchMe[i]) {
                        iResult = FindOneFile(i);   // 搜尋單一檔案, 並傳回結果
                    } else {
                        iResult = 0;
                    }

                    if(iResult == -1) {
                        bResult = false;        // 運算失敗了
                        FileFound.Total = 0;    // 當成沒找到
                        break;
                    }
                    if(iResult > 0) {
                        FileHintCount++;
                    }
                    FileFound.Ints[i] = iResult;
                    FileFound.Total = FileFound.Total + iResult;
                }
            } else {
                bResult = false;
            }

            // 結束時, 將 swWord 釋放掉

            swWord.Clear();
            return bResult;
        }

        //-------------------------------------------------------
        // 先分析一下要搜尋的字串, 產生 OKSentence
        //
        // 如果輸入的字串是 (佛陀 & 阿難) | 布施
        // 最後會變成
        // (S&S)|S        S 表示一個字串, 存在  SearchWordList 之中
        // 傳回 false 表示有問題, 例如只搜尋標點
        bool AnalysisSentence(string sSentence)
        {
            SearchWordList.Clear();
            String sPatten;

            // 目前第幾個字串? 例如 (S&S)|S  (佛陀&阿難)|布施  佛陀是第 0 個
            int iPattenNum = 0;

            while(sSentence.Length > 0) {
                (sPatten, sSentence) = CutPatten(sSentence);
                sSentence = sSentence.TrimStart();
                if((sPatten.Length == 1) && (OpPatten.IndexOf(sPatten[0]) >= 0 )) {     // 如果是運算符號的話
                    //PostfixStack->PushOp(sPatten);
                    OKSentence += sPatten;
                } else {
                    // 處理一個字
                    SearchWordList.Add(sPatten);    // 先記錄起來
                    swWord.Add(new CSearchWord(MainIndex, WordIndex, BuildFileList, sPatten));   // 將此字準備好
                    if(!swWord[iPattenNum].Success) {
                        return false;
                    }
                    OKSentence += "S";
                    iPattenNum++;
                }
            }
            return true;
        }

        // 自傳入的參數中取出 Patten , 並傳回取出 Patten 的原字串
        (string, string) CutPatten(string sString)
        {
            String sTmp = sString.TrimStart();

            // OpPatten = "&,+*()-";
            if(sTmp.Length > 0 && OpPatten.IndexOf(sTmp[0]) >= 0) {      // 找到運算符號
                sString = sTmp.Substring(1);
                return (sTmp.Substring(0, 1), sString);
            } else {
                // 找出下一個 patten 的位置或結束
                // 有組字式要跳過去 [xxxx]
                int iPoint = 0;
                int iInDes = 0;    // 是否在組字式中? 若是則 > 0 (考慮巢狀)
                while(iPoint < sTmp.Length) {
                    if(OpPatten.IndexOf(sTmp[iPoint]) >= 0 && iInDes == 0) {
                        sString = sTmp.Substring(iPoint);
                        return (sTmp.Substring(0, iPoint).TrimEnd(), sString);
                    } else if(sTmp[iPoint] == '[') {
                        iInDes++;
                    } else if(sTmp[iPoint] == ']') {
                        iInDes--;
                    }
                    iPoint++;
                }
                return (sTmp.TrimEnd(), "");
            }
        }

        // 尋找一個字串, 應該要傳回一個檔案串, 表示哪些檔案有
        int FindOneFile(int iFileNum)
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
            string sOKSentence = OKSentence;    // 暫存的字串

            // 目前第幾個字串? 例如 (S&S)|S  (佛陀&阿難)|布施  佛陀是第 0 個
            int iPattenNum = 0;

            //while (sOKSentence.Length())
            for(int i = 0; i < OKSentence.Length; i++) {
                sPatten = sOKSentence.Substring(i, 1);     // 取出 patten
                if(OpPatten.IndexOf(sPatten[0]) >= 0) {       // 如果是運算符號的話
                    PostfixStack.PushOp(sPatten);
                } else {
                    // ???? 加速的方法, 如果是 and 就只算前一個有結果的, 如果是 or 就只查前一個是沒找到的
                    // ???? 加速的方法, 如果不統計次數, 有找到就算數, 那麼速度會更快

                    // 處理一個字

                    sPatten = SearchWordList[iPattenNum];  // 取出某一筆字串
                    swWord[iPattenNum].Search(iFileNum);           // 只在某個檔搜尋
                    PostfixStack.PushQuery(swWord[iPattenNum].FoundPos, sPatten);
                    iPattenNum++;
                }
            }
            // ???? 這是組數, 不是筆數, 例如 佛陀 near 阿難 可能算是 1 組
            // return (PostfixStack->QueryStack[0]->Int2s->Count);
            return (PostfixStack.GetResult());
        }

        // 秀出成果 iStartNnum : 起始筆數, iListCount : 列出筆數
        // string ShowResult(int iStartNum, int iListCount) {}
    }
}
