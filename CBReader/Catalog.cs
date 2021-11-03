using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    public class CCatalog
	{
		public string[] ID;         // 藏經代碼
		public string[] Bulei;      // 部類
		public string[] Part;       // 部別
		public string[] Vol;        // 冊數
		public string[] SutraNum;   // 經號
		public string[] JuanNum;    // 卷數
		public string[] SutraName;  // 經名
		public string[] Byline;     // 作譯者

		// 建構式, 傳入檔案, 初值化
		public CCatalog(string sFile)
        {
			if(!File.Exists(sFile)) {
				throw new Exception($"Catalog 文件不存在：{sFile}");
			}

			string[] slCatalog = File.ReadAllLines(sFile);
			int iCount = slCatalog.Length;

			if(iCount == 0) {
				throw new Exception($"Catalog 文件沒有資料：{sFile}");
			}

			ID = new string[iCount];         // 藏經代碼
			Bulei = new string[iCount];      // 部類
			Part = new string[iCount];       // 部別
			Vol = new string[iCount];        // 冊數
			SutraNum = new string[iCount];   // 經號
			JuanNum = new string[iCount];    // 卷數
			SutraName = new string[iCount];  // 經名
			Byline = new string[iCount];     // 作譯者

			for(int i = 0; i < iCount; i++) {
				string[] slItems = slCatalog[i].Split(',');

				// A , 事彙部類 , , 091 , 1057 , 2 , 新譯大方廣佛華嚴經音義 , 唐 慧菀述
				// A , 事彙部類 , , 097 , 1267 , 2 , 大唐開元釋教廣品歷章(第3卷 - 第4卷) , 唐 玄逸撰
				// A , 事彙部類 , , 098 , 1267 , 15 , 大唐開元釋教廣品歷章(第5卷 - 第20卷) , 唐 玄逸撰
				// A , 事彙部類 , , 110 , 1490 , 2 , 天聖釋教總錄 , 宋 惟淨等編修

				if(slItems.Length == 8) {
					ID[i] = slItems[0].Trim();         // 藏經代碼
					Bulei[i] = slItems[1].Trim();      // 部類
					Part[i] = slItems[2].Trim();       // 部別
					Vol[i] = slItems[3].Trim();        // 冊數
					SutraNum[i] = slItems[4].Trim();   // 經號
					JuanNum[i] = slItems[5].Trim();    // 卷數
					SutraName[i] = slItems[6].Trim();  // 經名
					Byline[i] = slItems[7].Trim();     // 作譯者
				}
			}
		}
		
		// 取得 Catalog 的編號
		public int FindIndexBySutraNum(string sBook, string sVol, string sSutraNum)
		{
			return FindIndexBySutraNum(sBook, Convert.ToInt32(sVol), sSutraNum);
		}
		
		// 取得 Catalog 的編號
		public int FindIndexBySutraNum(string sBook, int iVol, string sSutraNum)
		{
			for(int i = 0; i < ID.Length; i++) {
				if(ID[i] == sBook && SutraNum[i] == sSutraNum) {
					if(Convert.ToInt32(Vol[i]) == iVol) {
						return i;
					}
				}
			}
			return -1;
		}
	}
}
