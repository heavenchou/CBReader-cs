using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CBReader
{
	/* 資料結構

	Vol{"T01"} -> 指向 2 TStringList

	1. PageLine 記錄頁欄行 : 0001a01 , 0010b10 , .......
	2. SerialNo 記錄在 Spine 的第 n 行 (流水號)

	Spine 要記錄每一卷

	XML/T/T01/T01n0001_001.xml , T01, 0001, 001

	要查 T01 的 0100a01 在哪一經哪一卷? 查詢方式為:

	1. 知道是 T01
	2. 在 Vol{"T01"}->PageLine 裡面找到 0100a01 之前是哪一筆 (假設第 5 筆)
	3. 找 Vol{"T01"}->SerialNo[5] = xx (假設在 Spine 的第 120 筆)

	4. 找 Spine->Vol[120] = "T01" , 找到在 T01
	5. 找 Spine->Sutra[120] = "0002" , 找到在第 5 經
	6. 找 Spine->Juan[120] = "03" , 找到在第 3 卷

	*/
	public class CJuanLine
	{
		public struct SPageLineSerialNo
		{
			public List<string> PageLine;
			public List<int> SerialNo;
		}
		public Dictionary<string, SPageLineSerialNo> Vol = new Dictionary<string, SPageLineSerialNo>();
		Regex re = new Regex(@"[\/]([A-Z]+)(\d+)n(.{4,5}?)_?(...)\.xml");

		// 建構式, 載入文件
		public CJuanLine(CSpine Spine)
        {
			Spine.BookID = new string[Spine.Count];
			Spine.VolNum = new string[Spine.Count];
			Spine.Vol = new string[Spine.Count];
			Spine.Sutra = new string[Spine.Count];
			Spine.Juan = new string[Spine.Count];

			for(int i = 0; i < Spine.Count; i++) {
				// 傳入的內容類似
				// XML/T01/T01n0001_001.xml , 0001a01

				string sLine = Spine.Files[i];

				string[] da= sLine.Split(',');

				Spine.Files[i] = da[0].Trim();

				string sBookID, sVolNum, sSutra, sJuan;
				(sBookID, sVolNum, sSutra, sJuan) = GetBookVolSutraJuan(Spine.Files[i]);

				string sVol = sBookID + sVolNum;
				// 記錄每一經的冊, 經, 卷
				Spine.BookID[i] = sBookID;
				Spine.VolNum[i] = sVolNum;
				Spine.Vol[i] = sVol;
				Spine.Sutra[i] = sSutra;
				Spine.Juan[i] = sJuan;

				// 如果是新的一冊, 就設定其 map
				if(!Vol.ContainsKey(sVol)) {
					SPageLineSerialNo plsn = new SPageLineSerialNo();
					plsn.PageLine = new List<string>();
					plsn.SerialNo = new List<int>();
					Vol[sVol] = plsn;
				}

				// 記錄每一冊各經各卷的 頁欄行
				Vol[sVol].PageLine.Add(da[1].Trim());
				Vol[sVol].SerialNo.Add(i);
			}
		}

		// 傳入檔名, 找出書,冊,經,卷
		public (string, string, string, string) GetBookVolSutraJuan(string sFile)
		{
			Match m = re.Match(sFile);
			if(m.Success) {
				GroupCollection g = m.Groups;
				return (g[1].Value, g[2].Value, g[3].Value, g[4].Value);
			} else {
				return ("", "", "", "");
			}
		}

		// 由冊頁欄行找 Spine 的 Index
		public int CBGetSpineIndexByVolPageColLine(string sBook, string sVol = "", string sPage = "", string sCol = "", string sLine = "")
		{
			string sFullVol = sBook + sVol;		// 此時 sVol 要是標準的位數才行
			SPageLineSerialNo plPageLine;
			if(Vol.ContainsKey(sFullVol)) {
				plPageLine = Vol[sFullVol];
			} else {
				return -1;
			}

			// 要組合出標準的 頁欄行

			sPage = CCBSutraUtil.getStandardPageFormat(sPage);		// 處理頁
			sCol = CCBSutraUtil.getStandardColFormat(sCol);			// 欄
			sLine = CCBSutraUtil.getStandardLineFormat(sLine);		// 行
			string sPageLine = sPage + sCol + sLine;

			// 比對方法
			// 因為頁碼有些是有 abc 在前面
			// 通常 abc 會在最前面, 類似序, xyz 在最後面, 類似跋
			// 所以 a001 改成 1a001
			//      0001 改成 20001
			//      z001 改成 2z001
			// 這樣就可以比較大小了

			string sNewPageLine = GetNewPageLine(sPageLine);

			int cCount = plPageLine.PageLine.Count;
			for(int i = 0; i < cCount; i++) {
				string sNowPageLine = GetNewPageLine(plPageLine.PageLine[i]);

				if(string.Compare(sNewPageLine , sNowPageLine) < 0) {
					if(i == 0) {
						return plPageLine.SerialNo[i];
					} else {
						return plPageLine.SerialNo[i - 1];
					}
				}
			}
			return plPageLine.SerialNo[cCount - 1];
		}

		// 新的行首, 最前面 a-m 則在字首加 "1" , 其他則加 "2"
		public string GetNewPageLine(string sPageLine)
		{
			if(sPageLine[0] >= 'a' && sPageLine[0] <= 'm') {
				sPageLine = "1" + sPageLine;
			} else {
				sPageLine = "2" + sPageLine;
			}
			return sPageLine;
		}
	}
}
