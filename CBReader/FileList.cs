using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Monster
{
    public class CFileList
    {
		public string FileName;        // 檔名
		public int FileCount;          // 檔案數目
		public int FileCountBit;       // 檔案數目 / 32 之後的整數

		public string[] Strings;       // 檔名陣列
		public string[] Book;          // 找出藏經 'T'(大正), 'X'(卍續)
		public int[] VolNum;           // 算出冊數
		public string[] SutraNum;      // 算出經號
		public int[] JuanNum;          // 算出卷號
		public bool[] SearchMe;        // 判斷要不要檢索

        // 建構式
        public CFileList(string sFileName)
        {
            FileName = sFileName;
        }

        // 讀入資料
        public bool Initial()
        {
			if(!File.Exists(FileName)) {
				return false;
            }
			string[] sLines = File.ReadAllLines(FileName, Encoding.UTF8);

			FileCount = sLines.Length;
			if(FileCount <= 0) {
				return false;
            }

			FileCountBit = FileCount / 32;
			if(FileCount % 32 > 0) FileCountBit++;

			// 開啟一個空間

			Strings = new string[FileCount];
			Book = new string[FileCount];
			VolNum = new int[FileCount];
			SutraNum = new string[FileCount];
			JuanNum = new int[FileCount];
			SearchMe = new bool[FileCount];

			// 逐一讀入

			for(int i = 0; i < FileCount; i++)
			{
				//fsIn.getline(buff,sizeof(buff));
				//Strings[i] = buff;
				Strings[i] = sLines[i];

				// 有一種情況, 傳入的資料是
				// XML/T/T01/T01n0001_001.xml , 0001a10
				// 後面有該卷的行首, 所以要去除
				int iPos = Strings[i].IndexOf(',');

				if(iPos >= 0) {
					Strings[i] = Strings[i].Substring(0, iPos);
				}
				Strings[i] = Strings[i].Trim();

				// 分析檔名

				// 檔名是
				// XML/T/T01/T01n0001_001.xml
				// XML/C/C056/C056n1163_001.xml
				// XML/ZW/ZW01/ZW01na001_001.xml
				// XML/J/J01/J01nA042_001.xml

				string bigString = Strings[i];
				string littlestring = @"[\/\\]([a-zA-Z]+)(\d+)[\/\\]\D+(\d+n)?(.{5})_?(\d{3})\.";

				Match match = Regex.Match(bigString, littlestring);

				// 找到了
				if(match.Success) {
                    GroupCollection mygrps = match.Groups;
                    Book[i] = mygrps[1].Value;
					VolNum[i] = Convert.ToInt32(mygrps[2].Value);
					SutraNum[i] = mygrps[4].Value;
					JuanNum[i] = Convert.ToInt32(mygrps[5].Value);
					SearchMe[i] = true;
				}

				if(SutraNum[i][4] == '_')
				{
					SutraNum[i] = SutraNum[i].Substring(0,4);		// 沒有別本
				}
			}
			return true;
		}

		// 取消全部的檢索
		public void NoneSearch()   
        {
			for(int i = 0; i < FileCount; i++) {
				SearchMe[i] = false;
			}
		}

		// 檢索這一經的這些卷
		public void SearchThisSutra(string sBook, string sSutraNum, int iStartJuan = 0, int iEndJuan = 0)  
        {
			if(iEndJuan == 0) {
				iEndJuan = iStartJuan;
			}
			if(iStartJuan == 0) {
				iEndJuan = int.MaxValue;
			}

			for(int i = 0; i < FileCount; i++) {
				if(Book[i] == sBook && SutraNum[i] == sSutraNum && JuanNum[i] >= iStartJuan && JuanNum[i] <= iEndJuan) {
					SearchMe[i] = true;
				}
			}
		}

		// 檢索這一冊的這些經
		public void SearchThisVol(string sBook, int iVolNum, int iStartSutra = 0, int iEndSutra = 0)   
        {
			if(iEndSutra == 0) {
				iEndSutra = iStartSutra;
			}
			if(iStartSutra == 0) {
				iEndSutra = int.MaxValue;
			}

			for(int i = 0; i < FileCount; i++) {
				int iSutraTmp;                  // 取出經號
				string sSutraTmp = SutraNum[i];
				
				// 暫時為嘉興藏解套, 及 a 開頭的經號, 讓它能被檢索
				if(sSutraTmp[0] == 'A' || sSutraTmp[0] == 'B' || sSutraTmp[0] == 'a') {
					sSutraTmp = sSutraTmp.Remove(0, 1);
				} 
				if(sSutraTmp.Length == 5) {
					iSutraTmp = Convert.ToInt32(sSutraTmp.Substring(0, 4));
				} else {
					iSutraTmp = Convert.ToInt32(sSutraTmp);
				}

				if(Book[i] == sBook && VolNum[i] == iVolNum && iSutraTmp >= iStartSutra && iSutraTmp <= iEndSutra) {
					SearchMe[i] = true;
				}
			}
		}

		// 檢索這部藏經的這些冊
		public void SearchThisBook(string sBook, int iStartVol = 0, int iEndVol = 0)   
        {
			if(iEndVol == 0) {
				iEndVol = iStartVol; 
			}
			if(iStartVol == 0) {
				iEndVol = int.MaxValue;
			}

			for(int i = 0; i < FileCount; i++) {
				if(Book[i] == sBook && VolNum[i] >= iStartVol && VolNum[i] <= iEndVol) {
					SearchMe[i] = true;
				}
			}
		}
    }
}
