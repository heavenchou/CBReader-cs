using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    // 校注呈現的方式
    public enum ECollationType : int
    {
        Orig = 0,   // 原書校注
        CBETA = 1   // CBETA 版校注
    }

    public class CSetting
    {
        public string SettingFile = "";             // 設定檔的位置

        //// string MyFullPath;           // 主程式所在目錄

        //CCBXMLOption * CBXMLOption;   // CBETA 經文的格式

        // 預設 Windows 會在主程式的子目錄 Bookcase
        // 預設 Mac 會在 /Library/CBETA/Bookcase
        // 若找不到, 會詢問使用者, 然後存在 BookcaseFullDir

        public string BookcasePath = "Bookcase";            // 書櫃的目錄
        public string BookcaseFullPath = "";        // 書櫃的完整目錄

        // 經文格式

        public bool ShowLineFormat = false;    // 是否依大正藏切行
        public bool ShowLineHead = false;      // 是否行首加上行首資訊
        public bool ShowCollation = true;     // 顯示校勘資料
        public bool ShowCollationCF = true;        // 呈現校注中的 cf 資訊

        public bool VerticalMode = false;      // 垂直顯示
        public bool ShowPunc = true;          // 呈現標點與段落
        public bool NoShowLgPunc = false;      // 不呈現偈頌的標點
        public bool NoShowAIPunc = false;      // 不呈現AI標點
        ////int LgType;             // 這是2016新的暫時功能, 設定偈頌呈現的方式, 0 為舊的方式用空格, 1 為非標準偈頌用 <p> 呈現編排

        // 校勘格式

        public ECollationType CollationType = ECollationType.CBETA;      // 校勘格式 0:原書, 1:CBETA
        

        // 經文呈現的顏色, 背景

        //Color BgColor;                  // 畫面的背景色
        public string BgImage = "";                 // 背景圖
        public int LineHeight = 20;                 // 行距

        //Color JuanNumFontColor;         // 經號的顏色
        public int JuanNumFontSize = 16;            // 經號的文字大小
        public bool JuanNumBold = false;               // 經號的文字是否粗體

        //Color JuanNameFontColor;        // 卷名的顏色
        public int JuanNameFontSize = 18;           // 卷名的文字大小
        public bool JuanNameBold = true;              // 卷名的文字是否粗體

        //Color XuFontColor;              // 序的顏色
        public int XuFontSize = 16;                 // 序的文字大小
        public bool XuBold = false;                    // 序的文字是否粗體

        //Color BodyFontColor;            // 正文的顏色
        public int BodyFontSize = 16;               // 正文的文字大小
        public bool BodyBold = false;                  // 正文的文字是否粗體

        //Color WFontColor;               // 附文的顏色
        public int WFontSize = 16;                  // 附文的文字大小
        public bool WBold = false;                     // 附文的文字是否粗體

        //Color BylineFontColor;          // 作譯者的顏色
        public int BylineFontSize = 16;             // 作譯者的文字大小
        public bool BylineBold = false;                // 作譯者的文字是否粗體

        //Color HeadNameFontColor;        // 標題的顏色
        public int HeadNameFontSize = 18;           // 標題的文字大小
        public bool HeadNameBold = true;              // 標題的文字是否粗體

        //Color LineHeadFontColor;        // 行首的顏色
        public int LineHeadFontSize = 14;           // 行首的文字大小
        public bool LineHeadBold = false;              // 行首的文字是否粗體

        //Color LgFontColor;              // 偈頌的顏色
        public int LgFontSize = 16;                 // 偈頌的文字大小
        public bool LgBold = false;                    // 偈頌的文字是否粗體

        //Color DharaniFontColor;         // 咒的顏色
        public int DharaniFontSize = 16;            // 咒的文字大小
        public bool UseDharaniFontColor = false;       // 是否使用咒的顏色
        public bool UseDharaniFontSize = false;        // 是否使用咒的文字大小
        public bool DharaniBold = false;               // 咒的文字是否粗體

        //Color CorrFontColor;            // 勘誤的顏色
        public int CorrFontSize = 16;               // 勘誤的文字大小
        public bool UseCorrFontColor = false;          // 是否使用勘誤的顏色
        public bool UseCorrFontSize = false;           // 是否使用勘誤的文字大小
        public bool CorrBold = false;                  // 勘誤的文字是否粗體

        //Color GaijiFontColor;           // 缺字的顏色
        public int GaijiFontSize = 16;              // 缺字的文字大小
        public bool UseGaijiFontColor = false;         // 是否使用缺字的顏色
        public bool UseGaijiFontSize = false;          // 是否使用缺字的文字大小
        public bool GaijiBold = false;                 // 缺字的文字是否粗體

        //Color NoteFontColor;            // 雙行小註的顏色
        public int NoteFontSize = 14;               // 雙行小註的文字大小
        public bool UseNoteFontColor = true;          // 是否使用雙行小註的顏色
        public bool UseNoteFontSize = true;           // 是否使用雙行小註的文字大小
        public bool NoteBold = false;                  // 雙行小註的文字是否粗體

        //Color FootFontColor;            // 校勘的顏色
        public int FootFontSize = 16;               // 校勘的文字大小
        public bool UseFootFontColor = false;          // 是否使用校勘的顏色
        public bool UseFootFontSize = false;           // 是否使用校勘的文字大小
        public bool FootBold = false;                  // 校勘的文字是否粗體

        public bool UseCSSFile = false;                // 使用 CSS 檔案
        public string CSSFileName = "";

        // 缺字處理

        public bool GaijiUseUniExt = true;    // 是否使用 Unicode Ext
        public bool GaijiUseNormal = true;    // 是否使用通用字

        public bool GaijiUniExtFirst = true;  // 優先使用 Unicode Ext
        public bool GaijiNormalFirst = false;  // 優先使用 通用字

        public bool GaijiDesFirst = true;     // 優先使用組字式
        public bool GaijiImageFirst = false;   // 優先使用缺字圖檔

        public int ShowSiddamWay = 6;      // 悉曇字處理法 0:悉曇字型(siddam.ttf) 1:羅馬轉寫(unicode) 2:羅馬轉寫(純文字) 3:悉曇圖檔 4:自訂符號 5:CB碼 6:悉曇羅馬對照
        public int ShowPaliWay = 0;        // 梵巴字處理法 0:Unicode 1:純文字 2:Ent 碼

        public string UserSiddamSign = "◇";  // 使用者自訂悉曇字符號
        public bool ShowUnicode30 = true;     // 呈現 Unicode 3.1

        // 圖檔大小

        public int GaijiWidth = 0;         // 缺字圖檔的寬, 0 為不設限
        public int GaijiHeight = 0;        // 缺字圖檔的高
        public int SDGifWidth = 0;         // 缺字圖檔的寬, 0 為不設限
        public int SDGifHeight = 0;        // 缺字圖檔的高
        public int FigureRate = 100;         // 圖檔的比例

        // 系統資訊

        //string CBETACDPath = "D:\\";     // CD 經文的位置
        public string XMLSutraPath = "XML\\";    // 經文的位置
        ////string BookmarkFile;    // Bookmark 的位置
        ////string SearchPath;      // 全文檢索的位置
        public string GaijiPath = "gaiji-CB\\";       // 缺字圖檔的位置
        public string SDGifPath = "sd-gif\\";       // 悉曇字圖檔的位置
        public string RJGifPath = "rj-gif\\";       // 蘭札字圖檔的位置
        public string FigurePath = "figures\\";      // 圖檔的位置
        public string LanguageFile = "";                // 使用的語系
        //string UserDataPath;    // 個人資料目錄
        public bool SaveLastTocFileName = true;   // 是否儲存最後開啟的書目
        //string LastTocFileName = "";     // 最後開啟的書目

        public int Theme = 0;       // Theme, 0 為預設, 1 為暗色系

        // 全文檢索

        public int NearNum = 30;                // 全文檢索 Near 的字距
        public int BeforeNum = 30;              // 全文檢索 Before 的字距
        public int MaxSearchNum = 500;           // 輸出最多的筆數, 0 表示不設限
        //bool OverSearchWarn = true;        // 超出全文檢索檔案數的限制時, 是否提出警告?
        //bool RMPunctuationWarn = true;     // 移除使用者輸入檢索字串中的標點時，是否提出警告訊息？

        // 引用複製模式

        public int CopyMode = 1;           // 1. 有校勘, 經名在前. 2.有校勘, 經名在後. 3. 無校勘, 經名在前. 4.無校勘, 經名在後.
        public bool CBCopyWithJuanNum = true; // 引用複製是否呈現卷數

        // 外部連結的資料

        public int CalloutCount = 0;                       // 外部連結程式的數目
        //TTntStringList * slCalloutTitle;       // 外部連結的標題
        //TTntStringList * slCalloutProgram;     // 外部連結的程式

        // 其他

        public string LastUpdateChk = "";       // 最後一次更新檢查, 格式為 20180517

        // 還沒處理 (或不處理?)

        ////string XMLJuanPosPath;      // 每一卷經文移位的資料檔
        ////string JuanLinePath;        // 每一卷經文第一行行首的資訊

        // 建構式, 載入檔案
        public CSetting(string sFile)
        {
            SettingFile = sFile;
            LoadFromFile();  // 載入設定檔
        }

        public void LoadFromFile()
        {
            LoadFromFile(SettingFile);
        }

        public void SaveToFile()
        {
            SaveToFile(SettingFile);
        }

        public void LoadFromFile(string sFile)
        {
            CIniFile iniFile = new CIniFile(sFile);

            string Section;

            // Ini file 結構是
            // [section]
            // Ident = Value

            Section = "ShowFormat";

            ShowLineFormat = iniFile.ReadBool(Section, "ShowLineFormat", ShowLineFormat);
            ShowLineHead = iniFile.ReadBool(Section, "ShowLineHead", ShowLineHead);
            ShowPunc = iniFile.ReadBool(Section, "ShowPunc", ShowPunc);
            NoShowLgPunc = iniFile.ReadBool(Section, "NoShowLgPunc", NoShowLgPunc);
            NoShowAIPunc = iniFile.ReadBool(Section, "NoShowAIPunc", NoShowAIPunc);
            VerticalMode = iniFile.ReadBool(Section, "VerticalMode", VerticalMode);
            ShowCollation = iniFile.ReadBool(Section, "ShowCollation", ShowCollation);
            ShowCollationCF = iniFile.ReadBool(Section, "ShowCollationCF", ShowCollationCF);
            CollationType = (ECollationType) (iniFile.ReadInteger(Section, "CollationType", (int) CollationType));

            // 缺字處理

            Section = "Gaiji";

            GaijiUseUniExt = iniFile.ReadBool(Section, "GaijiUseUniExt", GaijiUseUniExt);    // 是否使用 Unicode Ext
            GaijiUseNormal = iniFile.ReadBool(Section, "GaijiUseNormal", GaijiUseNormal);      // 是否使用通用字

            GaijiUniExtFirst = iniFile.ReadBool(Section, "GaijiUniExtFirst", GaijiUniExtFirst);  // 優先使用 Unicode Ext
            GaijiNormalFirst = !GaijiUniExtFirst;  // 優先使用 通用字

            GaijiDesFirst = iniFile.ReadBool(Section, "GaijiDesFirst", GaijiDesFirst);     // 優先使用組字式
            GaijiImageFirst = !GaijiDesFirst;   // 優先使用缺字圖檔

            // 系統資訊

            Section = "SystemInfo";

            //MyFullPath = IniFile.ReadString(Section, "MyFullPath", MyFullPath);
            BookcasePath = iniFile.ReadString(Section, "BookcasePath", BookcasePath);
            BookcaseFullPath = iniFile.ReadString(Section, "BookcaseFullPath", BookcaseFullPath);
            LanguageFile = iniFile.ReadString(Section, "LanguageFile", LanguageFile);
            Theme = iniFile.ReadInteger(Section, "Theme", Theme);

            // 自訂 CSS

            Section = "FontFormat";

            UseCSSFile = iniFile.ReadBool(Section, "UseCSSFile", UseCSSFile);
            CSSFileName = iniFile.ReadString(Section, "CSSFileName", CSSFileName);

            // 其他

            Section = "Misc";

            LastUpdateChk = iniFile.ReadString(Section, "LastUpdateChk", LastUpdateChk);
        }

        public void SaveToFile(string sFile)
        {
            CIniFile iniFile = new CIniFile(sFile);

            string Section;

            // Ini file 結構是
            // [section]
            // Ident = Value

            Section = "Version";

            // 第一筆儲存要檢查是否成功

            int iResult = iniFile.WriteString(Section, "Version", "2X");
            if(iResult == 0) {
                // 傳回 0 表示寫入失敗。
                int error = Marshal.GetLastWin32Error();        // 取得錯誤碼
                string msg = new Win32Exception(error).Message; // 取得錯誤訊息
                throw new Exception($"INI 檔案無法儲存。\r\n檔案：{sFile}\r\n錯誤代碼：{error}\r\n錯誤訊息：{msg}");
            }

            Section = "ShowFormat";

            iniFile.WriteBool(Section, "ShowLineFormat", ShowLineFormat);
            iniFile.WriteBool(Section, "ShowLineHead", ShowLineHead);
            iniFile.WriteBool(Section, "ShowPunc", ShowPunc);
            iniFile.WriteBool(Section, "NoShowLgPunc", NoShowLgPunc);
            iniFile.WriteBool(Section, "NoShowAIPunc", NoShowAIPunc);
            iniFile.WriteBool(Section, "VerticalMode", VerticalMode);
            iniFile.WriteBool(Section, "ShowCollation", ShowCollation);
            iniFile.WriteBool(Section, "ShowCollationCF", ShowCollationCF);
            iniFile.WriteInteger(Section, "CollationType", (int) CollationType);

            // 缺字處理

            Section = "Gaiji";

            iniFile.WriteBool(Section, "GaijiUseUniExt", GaijiUseUniExt);
            iniFile.WriteBool(Section, "GaijiUseNormal", GaijiUseNormal);
            iniFile.WriteBool(Section, "GaijiUniExtFirst", GaijiUniExtFirst);
            iniFile.WriteBool(Section, "GaijiDesFirst", GaijiDesFirst);

            // 系統資訊

            Section = "SystemInfo";

            //IniFile.WriteString(Section, "MyFullPath", MyFullPath);
            iniFile.WriteString(Section, "BookcasePath", BookcasePath);
            iniFile.WriteString(Section, "BookcaseFullPath", BookcaseFullPath);
            iniFile.WriteString(Section, "LanguageFile", LanguageFile);
            //iniFile.WriteInteger(Section, "Theme", Theme);    // 由 MainForm 寫入

            // 自訂 CSS

            Section = "FontFormat";

            iniFile.WriteBool(Section, "UseCSSFile", UseCSSFile);
            iniFile.WriteString(Section, "CSSFileName", CSSFileName);

            // 其他

            Section = "Misc";

            iniFile.WriteString(Section, "LastUpdateChk", LastUpdateChk);
        }
    }
}
