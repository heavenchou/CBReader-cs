using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
	public class CBookData
    {
		public string[] ID;				// 藏經代碼
		public string[] VolCount;       // 冊數的位數
		public string[] VerName;        // 版本名稱, 例如大正藏是【大】
		public string[] BookName;       // 中文名稱
		public string[] BookEngName;	// 英文名稱
		public int Count = 0;

		// 建構式, 傳入檔案
		public CBookData(string sFile)
        {
			if(!File.Exists(sFile)) {
				throw new Exception($"BookData 文件不存在：{sFile}");
			}

			string[] sBookData = File.ReadAllLines(sFile);
			
			Count = sBookData.Length;

			if(Count == 0) {
				throw new Exception($"BookData 文件沒有資料：{sFile}");
			}

			ID = new string[Count];
			VolCount = new string[Count];
			VerName = new string[Count];
			BookName = new string[Count];
			BookEngName = new string[Count];

			for(int i = 0; i < Count; i++) {
				string[] slItems = sBookData[i].Split(',');

				if(slItems.Length >= 5) {
					ID[i] = slItems[0].Trim();
					VolCount[i] = slItems[1].Trim();
					VerName[i] = slItems[2].Trim();
					BookName[i] = slItems[3].Trim();
					BookEngName[i] = slItems[4].Trim();
				}
			}
		}

		// 傳入 T, 傳回其在 TStringList 的 Index , 沒有則傳回 -1
		public int GetBookIndex(string sBook)
		{
			for(int i = 0; i < ID.Length; i++) {
				if(ID[i] == sBook)
					return i;
			}
			return -1;
		}

		// 傳入 T, 1 , 傳回 "T01" 這種標準的冊數
		public string GetFullVolString(string sBook, string sVol)
		{
			sVol = GetNormalVolNumString(sBook, sVol);
			sVol = sBook + sVol;
			return sVol;
		}

		// 傳入 T, 1 , 傳回 "01" 這種標準的冊數
		public string GetNormalVolNumString(string sBook, string sVol)
		{
			int iVol = Convert.ToInt32(sVol);
			int iVolLen = GetVolLen(sBook); // 取得指定藏經的冊數位數, 例如大正藏是 2 位數
			int iMyLen = sVol.Length;

			if(iMyLen < iVolLen) {
				sVol = string.Concat(Enumerable.Repeat("0", iVolLen - iMyLen)) + sVol;
			} else if(iMyLen > iVolLen) {
				sVol = sVol.Remove(0, iMyLen - iVolLen);
			}
			return sVol;
		}

		// 取得指定藏經的冊數位數, 例如大正藏是 2 位數
		int GetVolLen(string sBook)
		{
			int i = GetBookIndex(sBook);
			if(i >= 0) {
				return Convert.ToInt32(VolCount[i]);
			} else {
				return 0; // 找不到傳回 0
			}
		}

		// 傳入 T, 傳回 "【大】" 版本名稱 , 找不到傳回空字串
		public string GetVerName(String sBook)
		{
			int i = GetBookIndex(sBook);
			if(i >= 0) {
				return VerName[i];
			} else { 
				return ""; // 找不到傳回空字串
			}
		}

		// 傳入 T, 傳回 "大正新脩大藏經" 版本名稱 , 找不到傳回空字串
		public string GetBookName(String sBook)
		{
			int i = GetBookIndex(sBook);
			if(i >= 0) {
				return BookName[i];
			} else {
				return ""; // 找不到傳回空字串
			}
		}

		// 由 bookdata 做出 map , 傳入 "T" , 傳回 "【大】"
		// 這是要傳給全文檢索用的
		public Dictionary<string, string> BookToVerNameMap()
        {
			Dictionary<string, string> map = new Dictionary<string, string>();
			for(int i = 0; i < ID.Length; i++) {
				map.Add(ID[i], VerName[i]);
			}
			return map;
		}
	}
}
