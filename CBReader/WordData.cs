using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    /*
    每一個字在 taisho.ndx 中的資料結構
    主要有三個區塊
    [一檔一個bit，用來表示此檔是否有此字]
    [告知某檔有此字是出現幾次？]
    [每一次出現的位置]

    假設「中」這個字在五個檔案中, 只有125檔出現.

    FileCount = 5; (五個檔案)
    Word = 中 (某一個字)

    第一區塊
    3,3,0,0,5 (9300) (這個方法太佔空間了, 10000 個字, 10000 個檔, 大概佔 200 M)
    or
    1,1,0,0,1 (1162) (每一個 bit 代表一個檔案, 0 表示此檔案沒有這個字, 1 表示這個檔案有此字)
    第二區塊
    3,3,5

    WordCount[0] = 3     這是額外產生的空間
    WordCount[1] = 3
    WordCount[2] = 0
    WordCount[3] = 0
    WordCount[4] = 5
    第三區塊
    10,20,30             (第一個檔出現 3 次)
    100,200,300          (第二個檔出現 3 次)
    111,222,333,444,555  (第五個檔出現 5 次)

    WordPos[0][0],WordPos[0][1],WordPos[0][2]......
    WordPos[1][0],WordPos[1][1],WordPos[1][2]......
    WordPos[2][0]
    WordPos[3][0]
    WordPos[4][0],WordPos[4][1],WordPos[4][2],WordPos[4][3],WordPos[4][4]......

    */
    public class CWordData
    {
        //int[] Buffer;       // 每一個字所佔的大量空間, 用來包含底下的東西 (舊版還沒解壓縮的)
		unsafe int* pBuffer;
        int[] Buffer1;      // 每一個字所佔的大量空間, 用來包含底下的東西 (新版已解壓縮的)

		public static CMainIndex MainIndex;
		public static CWordIndex WordIndex;
		public static CFileList BuildFileList;

		public int FileCount;        // 檔案個數

        CBitList FileListBit;        // 指向一串數字, 每一個 bit 代表一個檔案的情況

		/* 每一個檔案所含有此字的數量, 這個不能使用 buffer 的空間,
           因為 buffer 裡面只有該檔有資料才會有
           所以這個空間要另外產生 */
		public int[] WordCount;

		public unsafe int*[] WordPos;        // 這個空間要另外產生

        public CWordData()
        {
            FileCount = BuildFileList.FileCount;
            FileListBit = new CBitList();
        }

        // 初值化
		// iOffset 是 MainIndex 的位移
		// iBufferSize 是要由 MainIndex 讀取的空間
        unsafe public void Initial(int iOffset, int iBufferSize)
		{
			int iTotalDataCount = 0;            // 此檔有幾個這個字

			WordCount = new int[FileCount]; // 儲存每一個檔案所包含此字的數量
			WordPos = new int*[FileCount]; // 實際資料的陣列
			byte[] Buffertmp = new byte[iBufferSize];
			//Buffer = Buffertmp;
			fixed(byte* tmpB = Buffertmp) {
				pBuffer = (int*) tmpB;
			}

			MainIndex.FileStream.Seek(iOffset, System.IO.SeekOrigin.Begin);
			MainIndex.FileStream.Read(Buffertmp, 0, iBufferSize);
			FileListBit.Initial(FileCount, BuildFileList.FileCountBit);
			FileListBit.Head = pBuffer;

			int* ipTmp = pBuffer + BuildFileList.FileCountBit;
			for(int i = 0; i < FileCount; i++) {
				if(FileListBit.GetBit(i) > 0) {
					WordCount[i] = *ipTmp;              // 該檔有此字, 則讀取資料
					iTotalDataCount += WordCount[i];    // 此檔有幾個這個字
					ipTmp++;
				} else {
					WordCount[i] = 0;
				}
			}

			/* --------------- 舊版開始 ---------------

			WordPos[0] = ipTmp;

			for(int i=1; i<FileCount; i++)
				WordPos[i] = WordPos[i-1] + WordCount[i-1];

			//--------------- 舊版結束 --------------- */

			///* ----------- 新版 ----------------
			
			Buffer1 = new int[iTotalDataCount];
			//unsigned char * cpNewTmp = (unsigned char *) Buffer1;	// 讓這個指標等於新的空間的開頭
			//unsigned char* cpOldTmp = (unsigned char*) ipTmp;     // 讓這個指標等於舊的空間的開頭
			
			fixed (int* tmpB = Buffer1) {
				WordPos[0] = tmpB;
			}
			byte* cpOldTmp = (byte*) ipTmp;

			byte ucTmp1, ucTmp2, ucTmp3, ucTmp4;
						
			for(int i = 0; i < FileCount; i++)      // 檔案數目
			{
				if(i > 0) {
					WordPos[i] = WordPos[i - 1] + WordCount[i - 1];       // 設定 WordPos 的位置
				}

				for(int j = 0; j < WordCount[i]; j++) {          // 準備解壓縮每一個檔此字的列表
					ucTmp1 = *cpOldTmp;     // 取出一個 byte

					if(ucTmp1 == 0)         // 這是四位數, 因為第一個 byte 是 0
					{
						ucTmp1 = cpOldTmp[1];
						ucTmp2 = cpOldTmp[2];
						ucTmp3 = cpOldTmp[3];
						ucTmp4 = cpOldTmp[4];

						WordPos[i][j] = (int)((uint) ucTmp1 * 16777216);                   // 0x 01 00 00 00
						WordPos[i][j] = WordPos[i][j] + (int)((uint) ucTmp2 * 65536);      // 0x 01 00 00
						WordPos[i][j] = WordPos[i][j] + (int)((uint) ucTmp3 * 256);        // 0x 01 00
						WordPos[i][j] = WordPos[i][j] + (int)((uint) ucTmp4);              // 0x 01

						if(j != 0) {
							WordPos[i][j] += WordPos[i][j - 1];          // 因為壓縮的資料是每一個資料的差數.
						}

						cpOldTmp += 5;      // 移到下一個

					} else if(ucTmp1 >= 192) {		// 三位數 0x 11000000

						ucTmp1 -= 192;
						ucTmp2 = cpOldTmp[1];
						ucTmp3 = cpOldTmp[2];

						WordPos[i][j] = (int)((uint) ucTmp1 * 65536);						// 0x 01 00 00
						WordPos[i][j] = WordPos[i][j] + (int)((uint) ucTmp2 * 256); 		// 0x 01 00
						WordPos[i][j] = WordPos[i][j] + (int)((uint) ucTmp3);               // 0x 01
						if(j != 0) {
							WordPos[i][j] += WordPos[i][j - 1];         // 因為壓縮的資料是每一個資料的差數.
						}

						cpOldTmp += 3;		// 移到下一個

					} else if(ucTmp1 >= 128) {		// 二位數 0x 10000000

						ucTmp1 -= 128;
						ucTmp2 = cpOldTmp[1];

						WordPos[i][j] = (int)((uint) ucTmp1 * 256);				// 0x 01 00
						WordPos[i][j] = WordPos[i][j] + (int)((uint) ucTmp2);       // 0x 01
						if(j != 0) {
							WordPos[i][j] += WordPos[i][j - 1];         // 因為壓縮的資料是每一個資料的差數.
						}

						cpOldTmp += 2;		// 移到下一個

					} else {                    // 一位數 \x 01000000

						ucTmp1 -= 64;
						WordPos[i][j] = (int)((uint) ucTmp1);     // 0x 01
						if(j != 0) {
							WordPos[i][j] += WordPos[i][j - 1];          // 因為壓縮的資料是每一個資料的差數.
						}
						cpOldTmp += 1;      // 移到下一個
					}
				}
			}

			// 留著底下程式, 免得記憶體被提前回收

			var tmp = Buffertmp[0];
			Buffertmp = null;

			//------------- 新版結束 --------------- */

		}

		// 初值化, 全部填 0
		unsafe public void ZeroIt()
		{
			WordCount = new int[FileCount]; // 儲存每一個檔案所包含此字的數量
			WordPos = new int*[FileCount];  // 實際資料的陣列

			int iSize = BuildFileList.FileCountBit + 5;    // 多 5 個, 夠了吧!

			byte[] BufferTmp = new byte[iSize * 4];      // 一個 int 的空間 4 byte
			fixed ( byte* t = BufferTmp) {

				pBuffer = (int*) t;
				for(int i = 0; i < iSize; i++) {
					pBuffer[i] = 0;                      // buffer 全清為 0
				}
			}

			FileListBit.Initial(FileCount, BuildFileList.FileCountBit);
			FileListBit.Head = pBuffer;

			int* ipTmp = pBuffer + BuildFileList.FileCountBit;
			ipTmp++;
			for(int i = 0; i < FileCount; i++) {
				WordCount[i] = 0;           // 每一檔出現字數, 清為 0
				WordPos[i] = ipTmp;         // 所以每一字的位置也是 0
			}
		}
    }
}
