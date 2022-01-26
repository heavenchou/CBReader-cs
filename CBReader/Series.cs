using Monster;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CBReader
{
	// 檢索引擎的版本
	public enum ESearchEngineType
    {
		Orig,	// 原書版本
		CBETA	// CBETA 版
    }

	public class CSeries
	{
		public string Dir = "";				// 本書的目錄

		public string ID = "";				// ID 代碼, CBETA 的指定為 CBEAT
		public string Title = "";			// 標題
		public string Creator = "";			// 作者
		public string PublishDate = "";		// 出版日期

		public string NavFile = "";			// 導覽文件
		public string CatalogFile = "";		// 目錄文件
		public string SpineFile = "";		// 遍歷文件
		public string BookDataFile = "";	// BookData 文件
		public string JSFile = "";			// CBReader 專用的 js 檔
		public string Version = "";			// 版本

		public CCatalog Catalog;			// 目錄
		public CSpine Spine;				// 遍歷文件
		public CJuanLine JuanLine;			// 各卷與頁欄行的關係物件, CBETA 專用
		public CBookData BookData;			// 每本書的資訊, 例如 T , 大正藏, 2

		public CMonster SearchEngine_orig;  // 原書全文檢索引擎
		public CMonster SearchEngine_CB;    // CB 版全文檢索引擎
		public CMonster SearchEngine;		// 目前在使用的全文檢索引擎

		// 建構式, 傳入目錄, 進行初值化
		public CSeries(string sDir)
		{
			// 本書的目錄
			Dir = sDir;
			if (Dir.Last() != '\\') {
				Dir += @"\"; 
			}
			if(!Directory.Exists(Dir)) {
				throw new Exception($"書籍目錄不存在：{Dir}");
			}

			// 判斷目錄中有沒有 metadata : index.xml

			string sMeta = Dir + "index.xml";

			if(!File.Exists(sMeta)) {
				throw new Exception($"後設文件不存在：{sMeta}");
			}

			LoadMetaData(sMeta);
			
			// 載入目錄資料

			Catalog = new CCatalog(Dir + CatalogFile);
			Spine = new CSpine(Dir + SpineFile);
			BookData = new CBookData(Dir + BookDataFile);

			// CBETA 專用, 要處理 JuanLine 資料
			if((ID == "CBETA") || (ID == "SEELAND")) {
				JuanLine = new CJuanLine(Spine);
			}

			// 載入全文檢索
			LoadSearchEngine();
			if (SearchEngine_CB != null) {
				SearchEngine = SearchEngine_CB;
			} else {
				SearchEngine = SearchEngine_orig;
			}
		}
		
		// 載入後設文件
		public void LoadMetaData(String sMeta) 
        {
			// 設定 settings

			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreComments = true;
			settings.IgnoreProcessingInstructions = true;
			settings.IgnoreWhitespace = true;

			// 建立 XmlReader 物件

			XmlReader reader = XmlReader.Create(sMeta, settings);

			// 分析 index.xml

			reader.MoveToContent();
			while(reader.Read()) {

				// 讀 ID
				if(reader.IsStartElement("id")) {
					reader.Read();
					ID = reader.Value;
				}

				// 讀 Title
				if(reader.IsStartElement("title")) {
					reader.Read();
					Title = reader.Value;
				}

				// 讀 Creator
				if(reader.IsStartElement("creator")) {
					reader.Read();
					Creator = reader.Value;
				}

				// 讀 date
				if(reader.IsStartElement("date")) {
					reader.Read();
					PublishDate = reader.Value;
				}

				// 讀 nav
				if(reader.IsStartElement("nav")) {
					NavFile = reader.GetAttribute("src");
				}

				// 讀 toc
				if(reader.IsStartElement("catalog")) {
					CatalogFile = reader.GetAttribute("src");
				}
				
				// 讀 Spine
				if(reader.IsStartElement("spine")) {
					SpineFile = reader.GetAttribute("src");
				}
			
				// 讀 BookData
				if(reader.IsStartElement("bookdata")) {
					BookDataFile = reader.GetAttribute("src");
				}
			
				// 讀 JSFile
				if(reader.IsStartElement("javascript")) {
					JSFile = reader.GetAttribute("src");
				}
				
				// 讀 Version
				if(reader.IsStartElement("version")) {
					reader.Read();
					Version = reader.Value;
				}
			}
		}

		// 由經卷去找經文, Vol 可以是空的, 但有跨冊的經文就要指定
		public string CBGetFileNameBySutraNumJuan(string sBookID, string sVol, string sSutraNum, string sJuan = "", string sPage = "", String sCol = "", string sLine = "")
		{
			string sFileName = Spine.CBGetFileNameBySutraNumJuan(sBookID, sVol, sSutraNum, sJuan);
			// 檔名要補上 #p0001a01 這種格式的位置	???? (為什麼用 sLine 來判斷?)
			if(sLine != "") {
				string sPageLine = CCBSutraUtil.getStandardPageColLine(sPage, sCol, sLine);
				sFileName += "#p" + sPageLine;
			}
			return sFileName;
		}

		// 由冊頁欄行找經文
		public string CBGetFileNameByVolPageColLine(string sBook, string sVol = "", string sPage = "", string sCol = "", String sLine = "")
		{
			// 傳入 T, 1 , 傳回 "01" 這種標準的冊數
			sVol = BookData.GetNormalVolNumString(sBook, sVol);

			int iIndex = JuanLine.CBGetSpineIndexByVolPageColLine(sBook, sVol, sPage, sCol, sLine);
			if(iIndex == -1) { return ""; }

			String sFileName = Spine.CBGetFileNameBySpineIndex(iIndex);

			// 檔名要補上 #p0001a01 這種格式的位置	???? (為什麼用 sLine 來判斷?)
			if(sLine != "") {
				string sPageLine = CCBSutraUtil.getStandardPageColLine(sPage, sCol, sLine);
				sFileName += "#p" + sPageLine;
			}
			return sFileName;
		}

		// 載入全文檢索引擎
		public void LoadSearchEngine()
		{
			if(Directory.Exists(Dir + "index")) {
				
				// CBETA 版的索引

				string sWordIndexFile = Dir + "index/wordindex.ndx";
				string sMainIndexFile = Dir + "index/main.ndx";
				if(File.Exists(Dir + SpineFile) &&
					File.Exists(sWordIndexFile) &&
					File.Exists(sMainIndexFile)) {
					try { 
						SearchEngine_CB = new CMonster(Dir + SpineFile, sWordIndexFile, sMainIndexFile);
					} catch(Exception ex) {
						CGlobalMessage.push("CBETA 版的索引檔開啟失敗");
					}
				} else {
					CGlobalMessage.push("沒有 CBETA 版的索引檔");
				}

				// 原書的索引

				sWordIndexFile = Dir + "index/wordindex_o.ndx";
				sMainIndexFile = Dir + "index/main_o.ndx";
				if(File.Exists(Dir + SpineFile) &&
					File.Exists(sWordIndexFile) &&
					File.Exists(sMainIndexFile)) {
					try {
						SearchEngine_orig = new CMonster(Dir + SpineFile, sWordIndexFile, sMainIndexFile);
					} catch (Exception ex) {
						CGlobalMessage.push("原書資料索引檔開啟失敗");
					}
				} else {
					CGlobalMessage.push("沒有原書資料的索引檔");
				}
			} else {
				CGlobalMessage.push("沒有找到全文檢索目錄:" + Dir + "index");
			}
		}

		// 選擇全文檢索引擎, 要傳入希望的版本, 預設 CBETA
		public CMonster getSearchEngine(ESearchEngineType searchType = ESearchEngineType.CBETA)
		{
			// 選擇全文檢索引擎, 若某一方為 0 , 則選另一方 (全 0 就不管了)
			if(SearchEngine_CB == null) {
				SearchEngine = SearchEngine_orig;	// 原書索引
			} else if(SearchEngine_orig == null) {
				SearchEngine = SearchEngine_CB;		// CBETA 索引
			} else if(searchType == ESearchEngineType.CBETA) {
				SearchEngine = SearchEngine_CB;		// CBETA 索引
			} else {
				SearchEngine = SearchEngine_orig;	// 原書索引
			}
			return SearchEngine;
		}

		// 釋放全文檢索引擎
		public void FreeSearchEngine()
		{
			SearchEngine_orig = null;
			SearchEngine_CB = null;
			SearchEngine = null;
		}
	}
}
