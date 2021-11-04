using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    public class CSearchWord
    {
        int[] lastK1;
        string Word;            // 要分析的字
        List<string> Tokens;        // 拆解開來的 token
        CWordData[] WordData;     // 每一個 token 的資料
        public CInt2List FoundPos;     // 儲存找到的位置

        CMainIndex MainIndex;
        CWordIndex WordIndex;
        CFileList BuildFileList;

        public bool Success;           // 本物件有沒有宣告成功

        // 建構式
        public CSearchWord (CMainIndex mIndex , CWordIndex wIndex , CFileList bFileList , string sWord)
        {
            MainIndex = mIndex;
            WordIndex = wIndex;
            BuildFileList = bFileList;

            Success = true;   // 本物件有沒有宣告成功
            Word = sWord;
            
            //WordData = 0;       // 初值宣告為 0     
            FoundPos = new CInt2List(); // 各檔找到的數量
            Tokens = new List<string>();

            if(ParseToken()) {        // 先將要搜尋的字串拆成一個一個的 token
                // 若 parse 失敗, 就不用配置空間了
                CreatTokenSpace();  // 配置每一個 token 的空間
            } else {
                Success = false;
            }
        }

        // 分析程式
        // 若分析到最後, 沒有可搜尋的字, 例如只輸入標點, 傳回 false

        bool ParseToken()
        {
            // 先拆解出 Token
            string sTmp = Word;
            while(sTmp.Length > 0) {
                // 取回一個字(或一個單字, 組字式, &xxx;)的長度
                int iLen = CWordTool.GetFirstTokenLength(sTmp, true, true, true);
                string sToken = sTmp.Substring(0, iLen);
                sTmp = sTmp.Remove(0, iLen);

                if(iLen > 1) {
                    Tokens.Add(sToken);    // extb, 組字, ...
                } else {
                    // 檢查此字是不是標點也不是空白( 問號可以)
                    CWordTool.EWordType wtType = CWordTool.GetWordType(sToken[0]);
                    if(sToken == "?" || (wtType != CWordTool.EWordType.wtPunc && wtType != CWordTool.EWordType.wtSpace))
                        Tokens.Add(sToken);
                }
            }
            if(Tokens.Count == 0) {
                return false;
            }
            return true;
        }
        
        // 配置每一個 token 的空間
        void CreatTokenSpace()
        {
            int iCount = Tokens.Count;
            int iBufferSize;

            CWordData.MainIndex = MainIndex;
            CWordData.WordIndex = WordIndex;
            CWordData.BuildFileList = BuildFileList;

            WordData = new CWordData[iCount];
            for(int i=0; i<iCount; i++) {
                WordData[i] = new CWordData();
            }

            // 設定靜態成員

            for(int i = 0; i < iCount; i++) {
                int iIndex = WordIndex.GetOffset(Tokens[i]);

                if(iIndex >= 0)     // 此字有在索引檔中
                {
                    int iOffset = WordIndex.WordOffset[iIndex];
                    if(iIndex == WordIndex.WordCount - 1)                  // 最後一筆
                        iBufferSize = (int) MainIndex.Size - iOffset;
                    else
                        iBufferSize = WordIndex.WordOffset[iIndex + 1] - iOffset;  // ???? 有待檢查最後一筆
                    WordData[i].Initial(iOffset, iBufferSize);
                } else {         // 此字不在索引檔中
                    WordData[i].ZeroIt();       // 建一個全部都是 0 的 worddata
                }
            }
        }

        // 搜尋某個檔案檔案
        public void Search(int iFileNum)
        {
            //int iFound = 0;                     // 判斷有沒有找到資料
            FoundPos.ClearAll();
            lastK1 = new int[Tokens.Count];
            int iHead;  // 第一個的位置
            int iLastHead;

            /*
            # 由主索引檔讀入資料
            # 找第一個字
            # 找第二個字
            # ...全找到了
            # 檢查合不合格?
            # 繼續.....
            */
            
            // 初值化
            lastK1 = Enumerable.Repeat(0, Tokens.Count).ToArray();

            unsafe {
                for(int i = 0; i < WordData[0].WordCount[iFileNum]; i++)    // 先用最笨的方法, 由第一個 token 的串列, 每一個都去試
                {
                    iHead = WordData[0].WordPos[iFileNum][i]; // 第一個的位置
                    iLastHead = iHead;

                    int iFound = 1;         // 如果只找一個字, 就是找到了.
                    for(int j = 1; j < Tokens.Count; j++) {
                        if(Tokens[j] == "?") {   // 萬用字元
                            iLastHead++;
                            continue;
                        }

                        iFound = 0;
                        for(int k = lastK1[j]; k < WordData[j].WordCount[iFileNum]; k++) {
                            if(WordData[j].WordPos[iFileNum][k] <= iLastHead) {

                            } else if(WordData[j].WordPos[iFileNum][k] > iLastHead + 1) {        // 超過了
                                iFound = -1;        // 提前出局
                                lastK1[j] = k;
                                break;
                            } else if(WordData[j].WordPos[iFileNum][k] == iLastHead + 1) {
                                iLastHead += 1;
                                iFound = 1;
                                lastK1[j] = k;            // 先暫存至 lastK1
                                break;
                            }
                        }

                        if(iFound == 0) {    // 沒找到
                            return;
                        } else if(iFound < 0) {   // 提前出局
                            break;
                        }
                    }

                    if(iFound == 1) { // 找到一組了	???? 這個長度以後若有用到萬用字元, 可能會變
                        FoundPos.Add(iHead, iLastHead);        // 找到一組
                    }
                }
            }
        }
    }
}
