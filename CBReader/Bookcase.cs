using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    public class CBookcase
	{
		public string BookcaseDir = "";	// 書櫃的目錄
		public List<CSeries> Books;		// 所有套書的指標
		public CSeries CBETA;			// 專指向 CBETA 的指標
		
		// 建構式, 載入所有的書櫃
		public CBookcase(string sDir)
		{
			// 檢查書櫃目錄是否存在

			if(!Directory.Exists(sDir)) {
				throw new Exception($"書櫃目錄不存在：{sDir}");
			}

			BookcaseDir = sDir;     // 書櫃的目錄
			Books = new List<CSeries>();

			// 取得書櫃中的所有書籍目錄
			string[] dirs = Directory.GetDirectories(BookcaseDir);
			if(dirs.Length == 0) {
				throw new Exception($"書櫃目錄沒有資料：{sDir}");
			}

			// 逐一記錄
			foreach(string dir in dirs) {
				// 嘗試建立套書物件
				CSeries s = new CSeries(dir);
				if(s.NavFile != "") {
					Books.Add(s);   // 至少要找到導覽文件 NavFile
					if(s.ID == "CBETA" || s.ID == "SEELAND") {
						CBETA = s;
					}
				}
			}

			if(Books.Count == 0) {
				throw new Exception($"書櫃目錄沒有可讀取的資料：{sDir}");
			}
		}
	}
}
