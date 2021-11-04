using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    public class CBitList
	{
		public int iByte = 0;               // 計算用的, 某一個 byte
		public int iBit = 0;                // 計算用的, 某一個 bit
		public uint Mask = 0;				// 用來遮罩某一個 bit 的工具

		public int FileCount = 0;           // 檔案數目
		public int FileCountBit = 0;        // 檔案數目 / 32 之後的整數
		public unsafe int* Head;            // 開頭的指標
		public bool HasMemory = false;		// 是否有自己 new 一個空間?
		
		// 建構函式
		public CBitList()
        {
        }

		// 設定初值
		public void Initial(int iFileCount)
		{
			FileCount = iFileCount;

			FileCountBit = FileCount / 32;
			if(FileCount % 32 > 0) {
				FileCountBit++;
			}
		}

		// 設定初值
		public void Initial(int iFileCount, int iFileCountBit)
		{
			FileCount = iFileCount;
			FileCountBit = iFileCountBit;
		}

		// 計算出 byte 及 bit
		public void GetByteBit(int iNum)
		{
			iByte = iNum / 32;
			iBit = iNum % 32;
		}

		/* 好像不用了
		
		// 將某一個 bit 設定為 1
		void  SetBit(int iIndex)
		{

		}
		
		// 將某一個 bit 設定為 0
		void ClearBit(int iIndex)
		{

		}
		*/

		// 取得某一個 bit 的資料
		public int GetBit(int iIndex)
		{
			GetByteBit(iIndex);
			Mask = 1;
			Mask <<= iBit;
			unsafe {
				if((Head[iByte] & (uint)Mask) > 0) {
					return 1;
				} else {
					return 0;
				}
			}
		}
	}
}
