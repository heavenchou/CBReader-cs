using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    public static class CCBSutraUtil
    {
		// 傳回標準的經號格式, "0001" 或 "0001a"
		// 空字串傳回空字串
		// 純數字補成 4 位數
		// 開頭是 A，B 的嘉興藏補成 4 位數
		// 最末是英文字母的補成 5 位數
		// 超過則切掉前面的
		// 但若第一位是非數字則保留
		// ex. 12 -> 0012
		//     34a -> 0034a
		//     A12 -> A0012
		//     1234 -> 1234
		//     1234b -> 1234b
		//     123456 -> 3456
		//     123456c -> 3456c
		//     A0012 -> A012

		public static string getStandardSutraNumberFormat(string sSutraNum)
		{
			if(sSutraNum == "") { return ""; }

			string sJPre = "";

			// 處理嘉興藏的 A, B經號, 以及 a 開頭的非正文典藉
			if(sSutraNum[0] == 'A' || sSutraNum[0] == 'a' || sSutraNum[0] == 'B') {
				sJPre = sSutraNum[0].ToString();
				sSutraNum = sSutraNum.Remove(0, 1);
			}

			int iMyLen = sSutraNum.Length;
			int iStdLen;
			char cLast = sSutraNum.Last();
			if(cLast >= '0' && cLast <= '9') {
				iStdLen = 4;    // 最後一個字是數字, 要填 0 直至四位數
			} else {
				iStdLen = 5; 
			}

			if(iMyLen > iStdLen) {
				sSutraNum = sSutraNum.Substring(iMyLen - iStdLen, iStdLen);
			} else if(iMyLen < iStdLen) {
				sSutraNum = string.Concat(Enumerable.Repeat("0", iStdLen - iMyLen))  + sSutraNum;
			}

			// 再次處理嘉興藏
			if(sJPre != "") {
				sSutraNum = sSutraNum.Remove(0, 1);
				sSutraNum = sJPre + sSutraNum;
			}
			return sSutraNum;
		}

		// 取得標準 4 位數的頁碼

		// 空字串變成 0001
		// 少於 4 位補成 4 位數
		// 超過 4 位數切掉前面的
		// 但若第一位是非數字則保留
		// ex. a01 -> a001
		//     a000001 -> a001

		public static string getStandardPageFormat(string sPage)
		{
			if(sPage == "") { return "0001"; }
			int iPageLen = sPage.Length;
			if(iPageLen == 4) { return sPage; }

			char c = sPage[0];

			if(c >= '0' && c <= '9') {
				// 全部都數字, 補上 0 直至 4 位數
				int i = Convert.ToInt32(sPage);
				i = i % 10000;
				sPage = string.Format("{0:0000}", i);
			} else {
				// 第一個字是英文字母
				sPage = sPage.Remove(0, 1);

				// 全部都數字, 補上 0 直至 3 位數
				int i = Convert.ToInt32(sPage);
				i = i % 1000;
				sPage = string.Format("{0}{1:000}", c, i);
			}
			return sPage;
		}

		// 取得標準 1 位數的欄

		// 空字串變成 a
		// 超過 1 位數切掉前面的
		// 數字則依序改成英文
		// ex. 0 -> a , 1 -> a , 2 -> b , 3 -> c ...

		public static string getStandardColFormat(string sCol)
		{
			if(sCol == "") { return "a"; }

			if(sCol.Length > 1) {
				sCol = sCol.Last().ToString();
			}
			sCol = sCol.ToLower();

			if(sCol == "0") { return "a"; }
			if(sCol[0] >= '0' && sCol[0] <= '9') {
				char c = (char) (sCol[0] - '1' + 'a');
				sCol = c.ToString();
			}
			return sCol;
		}

		// 取得標準 2 位數的行數

		// 空字串變成 01
		// 少於 2 位補成 2 位數
		// 超過 2 位數切掉前面的
		// ex. 1 -> 01
		//     123 -> 23

		public static string getStandardLineFormat(string sLine)
		{
			if(sLine == "") { return "01"; }

			int iLineLen = sLine.Length;

			if(iLineLen == 1) { return "0" + sLine; }
			if(iLineLen == 2) { return sLine; }
			sLine = sLine.Substring(iLineLen - 2);
			return sLine;
		}
	}
}
