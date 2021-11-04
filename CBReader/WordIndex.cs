using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    public class CWordIndex
    {
		public string FileName;			// 檔名
		public int WordCount;			// 檔案數目
		public string[] StringList;		// 檔名陣列的指標
		public int[] WordOffset;		// 每一個字的位移資料

		// 建構函式
		public CWordIndex(String sFileName)
		{
			FileName = sFileName;
		}

		// 讀入資料
		public bool Initial()
        {
			// 讀入資料

			if(!File.Exists(FileName)) {
				return false;
			}

			StringList = File.ReadAllLines(FileName, Encoding.UTF8);

			WordCount = StringList.Length;
			if(WordCount <= 0) {
				return false;
			}

			// 開啟一個空間

			WordOffset = new int[WordCount];

			// StringList->Sort();
			for(int i = 0; i < StringList.Length; i++) {
				string sLine = StringList[i];
				int iPos = sLine.IndexOf("=");
				StringList[i] = sLine.Substring(0,iPos);					// 取前面的字
				WordOffset[i] = Convert.ToInt32(sLine.Substring(iPos+1));	// 取後面的 Offset
			}
			return true;
		}

		// 傳入一個 token , 傳回其在 last index 的 offset
		public int GetOffset(String sToken)
		{
			for(int i = 0; i < StringList.Length; i++) {
				if(sToken == StringList[i])
					return i;
			}
			return -1;
		}
	}
}
