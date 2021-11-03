using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
	public class CSpine
	{
		public string[] Files;		// 遍歷檔案

		// CBETA 特有的
		public string[] BookID;     // 書, 例如 T
		public string[] VolNum;     // 冊數, 例如 01
		public string[] Vol;		// 冊
		public string[] Sutra;		// 經
		public string[] Juan;		// 卷

		public int Count = 0;		// 資料筆數

		// 建構式, 載入文件
		public CSpine(string sFile)
		{
			if(!File.Exists(sFile)) {
				throw new Exception($"Spine 文件不存在：{sFile}");
			}

			Files = File.ReadAllLines(sFile);
			Count = Files.Length; 
			
			if(Count == 0) {
				throw new Exception($"Spine 文件沒有資料：{sFile}");
			}
		}

		// 由經卷去找 XML 檔名
		public string CBGetFileNameBySutraNumJuan(String sBookID, String sVol, String sSutraNum, String sJuan = "")
		{
			int iIndex = CBGetSpineIndexBySutraNumJuan(sBookID, sVol, sSutraNum, sJuan);
			return CBGetFileNameBySpineIndex(iIndex);
		}

		// 由經卷去找 Spine 的 Index , 也可以不指定卷
		public int CBGetSpineIndexBySutraNumJuan(String sBookID, String sVol, String sSutraNum, String sJuan = "")
		{
			// 傳回標準的經號格式
			sSutraNum = CCBSutraUtil.getStandardSutraNumberFormat(sSutraNum);

			// 這二組是為了使用者沒寫經號的 abc... 先自動幫他們加上的
			int iSutraLen = sSutraNum.Length;

			int iJuan = 0;
			if(sJuan != "") iJuan = Convert.ToInt32(sJuan); // 先取得卷數的數字

			bool bFindBook = false;

			for(int i = 0; i < BookID.Length; i++) {
				if(BookID[i] == sBookID) {
					bFindBook = true;

					string sThisSutra = Sutra[i];
					string sMySutra = sSutraNum;

					if(Sutra[i].Length == 5) {
						// 標準經號是 5 位
						sThisSutra = Sutra[i].ToLower();

						if(iSutraLen == 4) {
							// 輸入只有 4 位, 例如 0123 , 但實際經號是 0123a
							// 所以比對前 4 位就好, 因為使用者可能不知道經號有 abc...
							sMySutra = sSutraNum + "a";
						} else {
							sMySutra = sSutraNum.ToLower();
						}
					}

					// 雙方都是 4 位數, 就不用管
					// 輸入是 5 位數, 目前是 4 數位, 肯定不合, 也不用管

					if(sThisSutra == sMySutra) {
						if(sVol == "" || Convert.ToInt32(VolNum[i]) == Convert.ToInt32(sVol)) {
							if(sJuan == "" || Convert.ToInt32(Juan[i]) == iJuan) {
								return i;
							}
						}
					}
					// 底下取消, 因為有些經號是 a 開頭, 因此經號不一定有順序
					//else if(sThisSutra > sMySutra)
					//	// 經號超過了
					//	return -1;

				} else if(bFindBook) {
					// 曾經找到此書, 但現在又不同書了, 表示找完了
					return -1;
				}
			}

			return -1;
		}
		
		// 由 Spine 的 Index 去找 XML 檔名
		public string CBGetFileNameBySpineIndex(int iIndex)
		{
			if(iIndex == -1) {
				return "";
			} else {
				return Files[iIndex];
			}
		}
	}
}
