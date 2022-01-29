using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
	/*
	判斷總類的用法
	1. 如果是 Alpha (英文) 就記錄下來
	2. 如果是其他, 就表示記錄的英文拼成一個字
	3. 空白, 標點不用檢索
	4. 數字, 文字逐一記錄檢索
	*/

	// 處理字的總類
	public static class CWordTool
    {
		public enum EWordType
		{
			wtSpace,	// 不用索引, 當成空白
			wtPunc,     // 標點
			wtNumber,   // 數字
			wtAlpha,    // 英文字
			wtWord      // 文字
		}

		// 取得此字的屬性
		public static EWordType GetWordType(char cWord)
		{
			/*
			48X 00-2F
			10N 0030 (000048) : 0 - 0039 (000057) : 9
			 7P 003A (000058) : : - 0040 (000064) : @
			26A 0041 (000065) : A - 005A (000090) : Z
			 6P 005B (000091) : [ - 0060 (000096) : `
			26A 0061 (000097) : a - 007A (000122) : z
			69P 007B (000123) : { - 00BF (000191) : ¿
			  A 00C0 (000192) : À - 023F (000575) : ȿ
			  W 0240 (000576) : ɀ - 02B8 (000696) : ʸ
			  P 02B9 (000697) : ʹ - 0362 (000866) : ͢
			  W 0363 (000867) : ͣ - 1DFF (007679) : ᷿
			  A 1E00 (007680) : Ḁ - 1EFF (007935) : ỿ
			  W 1F00 (007936) : ἀ - 2FFF (012287) : ⿿
			  P   2010 - 205E
			  S   2000 - 200F , 2028 - 202F, 205F - 206F
				3000 (012288) : 　- 303F (012351) : 〿
				P		　 : 3000 - 。 : 3002
				W	〃 : 3003 - 〇 : 3007
				P	〈 : 3008 - 〟 : 301F
				W	〠 : 3020 - 〩 : 3029
				P		〪 : 302A - 〰 : 3030
				W	〱 : 3031 - 〿 : 303F
			  W 3040 (012352) : ぀ - 33FF (013311) : ㏿
			  C 3400 (013312) : 㐀 - FE0F (065039) : ️
			  P FE10 (065040) : ︐ - FE1F (065055) : ︟
			  W FE20 (065056) : ︠ - FE2F (065071) : ︯
			  P FE30 (065072) : ︰ - FE6F (065135) : ﹯
			  W FE70 (065136) : ﹰ - FF00 (065280) : ＀
			  P FF01 (065281) : ！ - FF0F (065295) : ／
			  N FF10 (065296) : ０ - FF19 (065305) : ９
			  P FF1A (065306) : ： - FF20 (065312) : ＠
			  A FF21 (065313) : Ａ - FF3A (065338) : Ｚ
			  P FF3B (065339) : ［ - FF40 (065344) : ｀
			  A FF41 (065345) : ａ - FF5A (065370) : ｚ
			  P FF5B (065371) : ｛ - FF65 (065381) : ･
			  W FF66 (065382) : ｦ - FFFF (065535) : ￿
			*/

			// 最常見的在前面會比較快
			if(cWord >= 0x3400 && cWord <= 0xFE0F) return EWordType.wtWord;    // 漢字
			// else if(cWord >= 0x3000 && cWord <=0x303F) return EWordType.wtPunc; // 常見標點
			else if(cWord >= 0x3000 && cWord <= 0x3002) return EWordType.wtPunc; // P　 : 3000 - 。 : 3002
			else if(cWord >= 0x3003 && cWord <= 0x3007) return EWordType.wtWord; // W 〃 : 3003 - 〇 : 3007
			else if(cWord >= 0x3008 && cWord <= 0x301F) return EWordType.wtPunc; // P 〈 : 3008 - 〟 : 301F
			else if(cWord >= 0x3020 && cWord <= 0x3029) return EWordType.wtWord; // W 〠 : 3020 - 〩 : 3029
			else if(cWord >= 0x302A && cWord <= 0x3030) return EWordType.wtPunc; // P  〪 : 302A - 〰 : 3030
			else if(cWord >= 0x3001 && cWord <= 0x303F) return EWordType.wtWord; // W 〱 : 3031 - 〿 : 303F

			else if(cWord >= 0xFF01 && cWord <= 0xFF0F) return EWordType.wtPunc;  // 常見標點
			else if(cWord >= 0xFF1A && cWord <= 0xFF20) return EWordType.wtPunc;  // 常見標點
			else if(cWord >= 0x0061 && cWord <= 0x007A) return EWordType.wtAlpha;  // a-z
			else if(cWord >= 0x0041 && cWord <= 0x005A) return EWordType.wtAlpha;  // A-Z
			else if(cWord >= 0xFF10 && cWord <= 0xFF19) return EWordType.wtNumber; // ０-９
			else if(cWord >= 0x0030 && cWord <= 0x0039) return EWordType.wtNumber; // 0-9
			else if(cWord >= 0x00C0 && cWord <= 0x023F) return EWordType.wtAlpha;  // 拉丁字母擴充
			else if(cWord >= 0x1E00 && cWord <= 0x1EFF) return EWordType.wtAlpha;  // 拉丁字母擴充附加
			// -----
			else if(cWord <= 0x002F) return EWordType.wtSpace;
			//else if(cWord >= 0x0030 && cWord <=0x0039) return EWordType.wtNumber;
			else if(cWord >= 0x003A && cWord <= 0x0040) return EWordType.wtPunc;
			//else if(cWord >= 0x0041 && cWord <=0x005A) return EWordType.wtAlpha;
			else if(cWord >= 0x005B && cWord <= 0x0060) return EWordType.wtPunc;
			//else if(cWord >= 0x0061 && cWord <=0x007A) return EWordType.wtAlpha;
			else if(cWord >= 0x007B && cWord <= 0x00BF) return EWordType.wtPunc;
			//else if(cWord >= 0x00C0 && cWord <=0x023F) return EWordType.wtAlpha;
			else if(cWord >= 0x0240 && cWord <= 0x02B8) return EWordType.wtWord;
			else if(cWord >= 0x02B9 && cWord <= 0x0362) return EWordType.wtPunc;
			else if(cWord >= 0x0363 && cWord <= 0x1DFF) return EWordType.wtWord;
			//else if(cWord >= 0x1E00 && cWord <=0x1EFF) return EWordType.wtAlpha;

			// 空格先處理
			else if(cWord >= 0x2000 && cWord <= 0x200F) return EWordType.wtSpace;
			else if(cWord >= 0x2028 && cWord <= 0x202F) return EWordType.wtSpace;
			else if(cWord >= 0x205F && cWord <= 0x206F) return EWordType.wtSpace;
			// 標點其次
			else if(cWord >= 0x2010 && cWord <= 0x205E) return EWordType.wtPunc;
			// 其他是文字
			else if(cWord >= 0x1F00 && cWord <= 0x2FFF) return EWordType.wtWord;

			//else if(cWord >= 0x3000 && cWord <=0x303F) return EWordType.wtPunc;
			else if(cWord >= 0x3040 && cWord <= 0x33FF) return EWordType.wtWord;
			//else if(cWord >= 0x3400 && cWord <=0xFE0F) return EWordType.wtWord;
			else if(cWord >= 0xFE10 && cWord <= 0xFE1F) return EWordType.wtPunc;
			else if(cWord >= 0xFE20 && cWord <= 0xFE2F) return EWordType.wtWord;
			else if(cWord >= 0xFE30 && cWord <= 0xFE6F) return EWordType.wtPunc;
			else if(cWord >= 0xFE70 && cWord <= 0xFF00) return EWordType.wtWord;
			//else if(cWord >= 0xFF01 && cWord <=0xFF0F) return EWordType.wtPunc;
			//else if(cWord >= 0xFF10 && cWord <=0xFF19) return EWordType.wtNumber;
			//else if(cWord >= 0xFF1A && cWord <=0xFF20) return EWordType.wtPunc;
			else if(cWord >= 0xFF21 && cWord <= 0xFF3A) return EWordType.wtAlpha;
			else if(cWord >= 0xFF3B && cWord <= 0xFF40) return EWordType.wtPunc;
			else if(cWord >= 0xFF41 && cWord <= 0xFF5A) return EWordType.wtAlpha;
			else if(cWord >= 0xFF5B && cWord <= 0xFF65) return EWordType.wtPunc;
			//else if(cWord >= 0xFF66) return EWordType.wtWord;
			else return EWordType.wtWord;
		}

		// 取得此字串第一個字的長度, 有 :
		// ext-b,<標記>,[組字],&格式;,英文單字,其他單字(漢字,空白,符號,數字)
		// 例 :
		// u"字串測試" => 傳回 1 , 也就是 "字"
		// u"𠄣古" => 傳回 2 , 也就是 "𠄣" , 因為這是 ext-b 佔二個字元
		// "<p>TEST" => 傳回 3 , 也就是 "<p>", 傳回整個標記
		//     不過這是參數 bIsTag = true 的情況, 否則只傳回 1 表示 <
		// "This is a book" => 傳回 4 , 也就是 "This" , 表示一個單字
		//     不過這是參數 bIsAlpha = true 的情況, 否則只傳回 1 表示 T
		// "[金*本]" => 傳回 5 , 也就是 "[金*本]" , 表示一個組字式
		//     不過這是參數 bIsDes = true 的情況, 否則只傳回 1 表示 [

		public static int GetFirstTokenLength(string wtIndex, bool bIsTag, bool bIsAlpha, bool bIsDes)
        {
			if(wtIndex == "") { return 0; }
			// 取出一個字或一個標記
			if(wtIndex[0] >= 0xD800 && wtIndex[0] <= 0xDFFF) {
				// 處理 Ext-B 以上的 Unicode
				return 2;
			} else if(wtIndex[0] == '<' && bIsTag == true) {
				// 若是格式為 XML 或 HTML 才要處理標記
				int iEnd = wtIndex.IndexOf('>');
				if(iEnd == -1) {
					return 1;       // 結束了還沒遇到 > 標記, 所以還是傳回 <
				} else {
					return iEnd + 1;	// 標記
				}
			} else if(wtIndex[0] == '&')	{   // &.....;
				int iEnd = wtIndex.IndexOf(';');
				if(iEnd == -1) { 
					return 1; 
				} else {
					string s = wtIndex.Substring(1, iEnd);	// 第一個 & 先不取
					int iPos = s.IndexOf('&');
					if(iPos >= 0) { return 1; }	// 還有 & , 表示有雙重 & 就不是 &...;
					if(iEnd > 50) { return 1; } // 太長也不是
					return iEnd + 1;
                }
			} else if(wtIndex[0] == '[' && bIsDes == true) {
				// 傳回組字式
				for(int i = 0; i < wtIndex.Length; i++) {
					// 數字或英文就不是組字式了
					if(GetWordType(wtIndex[i]) == EWordType.wtAlpha) {
						return 1;
					} else if(GetWordType(wtIndex[i]) == EWordType.wtNumber) {
						return 1;
					}
					// 太長也不是組字式
					if(i > 100) { return 1; }
					if(wtIndex[i] == ']') { return i+1; }
				}
				return 1;	// 結束了還沒遇到 ] 標記, 所以還是傳回 [
			} else if((GetWordType(wtIndex[0]) == EWordType.wtAlpha) && bIsAlpha == true) {
				// 一組英文字, 要找到非英文字才算中止
				for(int i = 0; i < wtIndex.Length; i++) {
					if(GetWordType(wtIndex[i]) != EWordType.wtAlpha) {
						return i;
					}
				}
				return wtIndex.Length;
			} else {
				// 一般文字
				return 1;
			}
		}


		public static int GetFirstTokenLength(string wtIndex, int pIndex, bool bIsTag, bool bIsAlpha, bool bIsDes)
		{
			if (pIndex >= wtIndex.Length) { return 0; }
			// 取出一個字或一個標記
			if (wtIndex[pIndex] >= 0xD800 && wtIndex[pIndex] <= 0xDFFF) {
				// 處理 Ext-B 以上的 Unicode
				return 2;
			} else if (wtIndex[pIndex] == '<' && bIsTag == true) {
				// 若是格式為 XML 或 HTML 才要處理標記
				int iEnd = wtIndex.IndexOf('>', pIndex);
				if (iEnd == -1) {
					return 1;       // 結束了還沒遇到 > 標記, 所以還是傳回 <
				} else {
					return iEnd - pIndex + 1;    // 標記
				}
			} else if (wtIndex[pIndex] == '&') {   // &.....;
				int iEnd = wtIndex.IndexOf(';', pIndex);
				if (iEnd == -1) {
					return 1;
				} else {
					string s = wtIndex.Substring(pIndex + 1, iEnd - pIndex);  // 第一個 & 先不取
					int iPos = s.IndexOf('&');
					if (iPos >= 0) { return 1; }    // 還有 & , 表示有雙重 & 就不是 &...;
					if (iEnd > 50) { return 1; } // 太長也不是
					return iEnd - pIndex + 1;
				}
			} else if (wtIndex[pIndex] == '[' && bIsDes == true) {
				// 傳回組字式
				for (int i = pIndex; i < wtIndex.Length; i++) {
					// 數字或英文就不是組字式了
					if (GetWordType(wtIndex[i]) == EWordType.wtAlpha) {
						return 1;
					} else if (GetWordType(wtIndex[i]) == EWordType.wtNumber) {
						return 1;
					}
					// 太長也不是組字式
					if (i - pIndex > 100) { return 1; }
					if (wtIndex[i] == ']') { return i - pIndex + 1; }
				}
				return 1;   // 結束了還沒遇到 ] 標記, 所以還是傳回 [
			} else if ((GetWordType(wtIndex[pIndex]) == EWordType.wtAlpha) && bIsAlpha == true) {
				// 一組英文字, 要找到非英文字才算中止
				for (int i = pIndex; i < wtIndex.Length; i++) {
					if (GetWordType(wtIndex[i]) != EWordType.wtAlpha) {
						return i - pIndex;
					}
				}
				return wtIndex.Length - pIndex;
			} else {
				// 一般文字
				return 1;
			}
		}
	}
}

/*
48X 00-2F
10N 0030 (000048) : 0 - 0039 (000057) : 9
 7P 003A (000058) : : - 0040 (000064) : @
26A 0041 (000065) : A - 005A (000090) : Z
 6P 005B (000091) : [ - 0060 (000096) : `
26A 0061 (000097) : a - 007A (000122) : z
69P 007B (000123) : { - 00BF (000191) : ¿
  A 00C0 (000192) : À - 023F (000575) : ȿ
  W 0240 (000576) : ɀ - 02B8 (000696) : ʸ
  P 02B9 (000697) : ʹ - 0362 (000866) : ͢
  W 0363 (000867) : ͣ - 1DFF (007679) : ᷿
  A 1E00 (007680) : Ḁ - 1EFF (007935) : ỿ
  W 1F00 (007936) : ἀ - 2FFF (012287) : ⿿
  P 3000 (012288) : 　- 303F (012351) : 〿
  W 3040 (012352) : ぀ - 33FF (013311) : ㏿
  C 3400 (013312) : 㐀 - FE0F (065039) : ️
  P FE10 (065040) : ︐ - FE1F (065055) : ︟
  W FE20 (065056) : ︠ - FE2F (065071) : ︯
  P FE30 (065072) : ︰ - FE6F (065135) : ﹯
  W FE70 (065136) : ﹰ - FF00 (065280) : ＀
  P FF01 (065281) : ！ - FF0F (065295) : ／
  N FF10 (065296) : ０ - FF19 (065305) : ９
  P FF1A (065306) : ： - FF20 (065312) : ＠
  A FF21 (065313) : Ａ - FF3A (065338) : Ｚ
  P FF3B (065339) : ［ - FF40 (065344) : ｀
  A FF41 (065345) : ａ - FF5A (065370) : ｚ
  P FF5B (065371) : ｛ - FF65 (065381) : ･
  W FF66 (065382) : ｦ - FFFF (065535) : ￿

Yap 的版本
module.exports="48 10N7 26A6 26A   69 23A1 31A1 136A3488 20N12 128T3648 256A256 112P3600 352C16 15I2 63P192C768 27648C14336 257S8191 512P1025 1P6 2P2 1P1 1P11 2P3 1P65 1P2 2P154 ";

Unicode 範圍
【0020-007F】 Basic Latin 基本拉丁字母
【00A0-00FF】 Latin-1 Supplement 拉丁字母補充-1
【0100-017F】 Latin Extended-A 拉丁字母擴充-A
【0180-023F】 Latin Extended-B 拉丁字母擴充-B

【0250-02AF】 IPA Extensions 國際音標擴充
【02B0-02EF】 Spacing Modifier Letters 空格修飾字元
【0300-036F】 Combining Diacritical Marks 組合音標附加符號
【0370-03FF】 Greek and Coptic 希臘字母
【0400-04FF】 Cyrillic 西里爾字母
【0500-052F】 Cyrillic Supplement 西里爾字母補充
【0530-058F】 Armenian 亞美尼亞文
【0590-05FF】 Hebrew 希伯來文
【0600-06FF】 Arabic 基本阿拉伯文
【0700-074F】 Syriac 敘利亞文
【0750-077F】 Arabic Supplement 阿拉伯文補充
【0780-07BF】 Thaana 塔納文
【07C0-07FF】 N’Ko

【0900-097F】 Devanagari 天城體梵文字母
【0980-09FF】 Bengali 孟加拉國文
【0A00-0A7F】 Gurmukhi 古爾穆基文
【0A80-0AFF】 Gujarati 古吉拉特文
【0B00-0B7F】 Oriya 奧里亞文
【0B80-0BFF】 Tamil 泰米爾文
【0C00-0C7F】 Telugu 泰盧固文
【0C80-0CFF】 Kannada 卡納達文
【0D00-0D7F】 Malayalam 馬拉亞拉姆文
【0D80-0DFF】 Sinhala 僧伽羅文
【0E00-0E7F】 Thai 泰文
【0E80-0EFF】 Lao 寮國文；寮國文
【0F00-0FFF】 Tibetan 藏文
【1000-109F】 Myanmar 緬甸文
【10A0-10FF】 Georgian 喬治亞文
【1100-11FF】 Hangul Jamo 諺文字母
【1200-137F】 Ethiopic 衣索比亞文
【1380-139F】 Ethiopic Supplement 衣索比亞文補充
【13A0-13FF】 Cherokee 切羅基文
【1400-167F】 Unified Canadian Aboriginal Syllabics 加拿大土著統一音節文字
【1680-169F】 Ogham 歐甘文
【16A0-16FF】 Runic 北歐古文
【1700-171F】 Tagalog 他加祿文
【1720-173F】 Hanunoo 哈努諾文
【1740-175F】 Buhid 布希德文
【1760-177F】 Tagbanwa 塔格巴努亞文
【1780-17FF】 Khmer 高棉文
【1800-18AF】 Mongolian 蒙古文
【1900-194F】 Limbu 林布文
【1950-197F】 Tai Le 傣哪文；德巨集傣文
【1980-19DF】 New Tai Lue 新傣仂文
【19E0-19FF】 Khmer Symbols 高棉符號
【1A00-1A1F】 Buginese 布吉文
【1B00-1B7F】 Balinese 巴利文
【1D00-1D7F】 Phonetic Extensions 音標擴充
【1D80-1DBF】 Phonetic Extensions Supplement 音標擴充補充
【1DC0-1DFF】 Combining Diacritical Marks Supplement 組合音標附加符號
【1E00-1EFF】 Latin Extended Additional 拉丁字母擴充附加
【1F00-1FFF】 Greek Extended 希臘文擴充
【2000-206F】 General Punctuation 一般標點符號
【2070-209F】 Superscripts and Subscripts 下標及上標
【20A0-20CF】 Currency Symbols 貨幣符號
【20D0-20FF】 Combining Diacritical Marks for Symbols 符號用組合附加符號
【2100-214F】 Letterlike Symbols 似字母符號
【2150-218F】 Number Forms 數字形式
【2190-21FF】 Arrows 箭頭符號
【2200-22FF】 Mathematical Operators 數學運算符號
【2300-23FF】 Miscellaneous Technical 混合專門符號
【2400-243F】 Control Pictures 控制圖像
【2440-245F】 Optical Character Recognition 光學字元識別
【2460-24FF】 Enclosed Alphanumerics 括號字母數字
【2500-257F】 Box Drawing 製表符
【2580-259F】 Block Elements 區塊組件
【25A0-25FF】 Geometric Shapes 幾何形狀
【2600-26FF】 Miscellaneous Symbols 混合什錦符號
【2700-27BF】 Dingbats 什錦符號
【27C0-27EF】 Miscellaneous Mathematical Symbols-A 混合數學符號-A
【27F0-27FF】 Supplemental Arrows-A 補充性箭頭符號-A
【2800-28FF】 Braille Patterns 盲文；盲人點字
【2900-297F】 Supplemental Arrows-B 補充性箭頭符號-B
【2980-29FF】 Miscellaneous Mathematical Symbols-B 混合數學符號-B
【2A00-2AFF】 Supplemental Mathematical Operators 補充性數學運算符號
【2B00-2BFF】 Miscellaneous Symbols and Arrows 混合什錦符號和箭頭符號
【2C00-2C5F】 Glagolitic 格拉戈爾字母
【2C60-2C7F】 Latin Extended-C 拉丁字母擴充-C
【2C80-2CFF】 Coptic 科普特文
【2D00-2D2F】 Georgian Supplement 喬治亞文補充
【2D30-2D7F】 Tifinagh 提非納格字母
【2D80-2DDF】 Ethiopic Extended 衣索比亞文擴充
【2E00-2E7F】 Supplemental Punctuation 補充性標點符號
【2E80-2EFF】 CJK Radicals Supplement 中日韓部首補充
【2F00-2FDF】 Kangxi Radicals 康熙部首
【2FF0-2FFF】 Ideographic Description Characters 漢字結構描述字元
【3000-303F】 CJK Symbols and Punctuation 中日韓符號和標點
【3040-309F】 Hiragana 平假名
【30A0-30FF】 Katakana 片假名
【3100-312F】 Bopomofo 注音符號
【3130-318F】 Hangul Compatibility Jamo 諺文相容字母
【3190-319F】 Kanbun 漢文標註號
【31A0-31BF】 Bopomofo Extended 注音符號擴充
【31C0-31EF】 CJK Strokes 中日韓筆畫部件
【31F0-31FF】 Katakana Phonetic Extensions 片假名音標擴充
【3200-32FF】 Enclosed CJK Letters and Months 中日韓括號字母及月份
【3300-33FF】 CJK Compatibility 中日韓相容字元
【3400-4DBF】 CJK Unified Ideographs Extension A 中日韓統一表意文字擴充A
【4DC0-4DFF】 Yijing Hexagram Symbols 易經六十四卦象
【4E00-9FFF】 CJK Unified Ideographs 中日韓統一表意文字
【A000-A48F】 Yi Syllables 彞文音節
【A490-A4CF】 Yi Radicals 彞文字母
【A700-A71F】 Modifier Tone Letters 聲調符號
【A720-A7FF】 Latin Extended-D 拉丁字母擴充-D
【A800-A82F】 Syloti Nagri
【A840-A87F】 Phags-pa 八思巴字母
【AC00-D7AF】 Hangul Syllables 諺文音節
【D800-DB7F】 High Surrogates 高半代用區
【DB80-DBFF】 High Private Use Surrogates 高半專用代用區
【DC00-DFFF】 Low Surrogates 低半代用區
【E000-F8FF】 Private Use Area 專用區
【F900-FAFF】 CJK Compatibility Ideographs 中日韓相容表意文字
【FB00-FB4F】 Alphabetic Presentation Forms 字母變體顯現形式
【FB50-FDFF】 Arabic Presentation Forms-A 阿拉伯文變體顯現形式-A
【FE00-FE0F】 Variation Selectors 字型變換選取器
【FE10-FE1F】 Vertical Forms 豎式標點
【FE20-FE2F】 Combining HalF】 Marks 組合半形標示
【FE30-FE4F】 CJK Compatibility Forms 中日韓相容形式
【FE50-FE6F】 Small Form Variants 小寫變體
【FE70-FEFF】 Arabic Presentation Forms-B 阿拉伯文變體顯現形式-B
【FF00-FFEF】 Halfwidth and Fullwidth Forms 半形及全形字元
【FFF0-FFFF】 Specials 特殊區域
【10000-1007F】 Linear B Syllabary 線形文字B音節文字
【10080-100FF】 Linear B Ideograms 線形文字B表意文字
【10100-1013F】 Aegean Numbers 愛琴數字
【10140-1018F】 Ancient Greek Numbers 古希臘數字
【10300-1032F】 Old Italic 古義大利文
【10330-1034F】 Gothic 哥特文
【10380-1039F】 Ugaritic 烏加里特楔形文字
【103A0-103DF】 Old Persian 古波斯文
【10400-1044F】 Deseret 猶他大學音標
【10450-1047F】 Shavian 肅伯納字母
【10480-104AF】 Osmanya
【10800-1083F】 Cypriot Syllabary 塞普勒斯音節文字
【10900-1091F】 Phoenician 腓尼基字母
【10A00-10A5F】 Kharoshthi 佉盧字母
【12000-123FF】 Cuneiform 楔形文字
【12400-1247F】 Cuneiform Numbers and Punctuation 楔形文字數字及標點
【1D000-1D0FF】 Byzantine Musical Symbols 東正教音樂符號
【1D100-1D1FF】 Musical Symbols 音樂符號
【1D200-1D24F】 Ancient Greek Musical Notation 古希臘音樂譜記號
【1D300-1D35F】 Tai Xuan Jing Symbols 太玄經符號
【1D360-1D37F】 Counting Rod Numerals 算籌記數式
【1D400-1D7FF】 Mathematical Alphanumeric Symbols 數學用字母數字元號
【1F1E6-1F1FF】 Regional indicator symbols 區域指示符, A~Z 26 個字母，二個字母可以拼出特定區域，某些系統可繪出國旗，TW 為台灣。
【20000-2A6DF】 CJK Unified Ideographs Extension B 中日韓統一表意文字擴充B
【2F800-2FA1F】 CJK Compatibility Ideographs Supplement 中日韓相容表意文字補充
【E0000-E007F】 Tags 語言編碼捲標
【E0100-E01EF】 Variation Selectors Supplement 字型變換選取器補充
【FFF80-FFFFF】 Supplementary Private Use Area-A 補充專用區-A
【10FF80-10FFFF】 Supplementary Private Use Area-B 補充專用區-B
*/