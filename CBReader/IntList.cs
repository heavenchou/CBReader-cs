using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
	public class CIntList
	{
		int FileCount;                  // 檔案數目
		public int[] Ints;                      // 開頭的指標
		public int Total = 0;

		public CIntList(int iFileCount)      // 建構函式
		{
			FileCount = iFileCount;
			Ints = new int[FileCount];
		}
		public void ClearAll()         // 全部清掉
        {
			Ints = Enumerable.Repeat(0, FileCount).ToArray();
			Total = 0;
		}
	}
}
