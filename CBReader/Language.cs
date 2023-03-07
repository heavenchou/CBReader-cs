using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 1.記錄 lang
 * 2.自訂 lang
 * 3.跨行 message 及 tip
 * 4.lang 目錄位置
 * 5.語系要排序
 * 6.語言選單額外處理
 * 7.更新要修改打包格式，乾脆做成 cbreader.exe + bookcase+lang 包在一起
 * 8.增加中文字型
 */
namespace CBReader
{
    // 一開始只要給目錄，讓它取得所有的語系檔名及語系名稱
    // 更換語系時，就是切換檔名，再更換所有元件文字，取得所有訊息
    public class Language
    {
        string FileName = "";        // 目前使用中的語系檔名
        string UserFileName = "";        // 目前使用中的語系檔名
        string LangPath = "";        // 語系檔的路徑
        string UserLangPath = "";        // 使用者自訂語系檔的路徑
        string DefaultIni = "";     // heaven 專用，要列出預設 ini 有哪些項目
        CIniFile IniFile = new CIniFile();
        CIniFile UserIniFile = new CIniFile();

        public SortedDictionary<string, string> FileNames;  // 語系檔列表 (語系名, 檔名)
        public SortedDictionary<string, string> UserFileNames;  // 使用者自訂語系檔列表 (語系名, 檔名)
        public Dictionary<string, string> Messages;         // 所有的訊息列表

        string FontName;            // 字型
        int FontSize;               // 字型大小
        string HanFontName;            // 漢字字型
        int HanFontSize;               // 漢字字型大小
        //TFontCharset FontCharset;   // 字元集
        //unsigned int CodePage;      // code page

        public Language(string sLangPath, string sUserLangPath) // 建構函式, 傳入語系檔目錄
        {
            LangPath = sLangPath;
            UserLangPath = sUserLangPath;
            FileNames = new SortedDictionary<string, string>();  // 語系檔列表 (語系名, 檔名)
            UserFileNames = new SortedDictionary<string, string>();  // 語系檔列表 (語系名, 檔名)
            Messages = new Dictionary<string, string>();         // 所有的訊息列表

            FontName = "";
            HanFontName = "";
            FontSize = 12;
            HanFontSize = 12;
            //FontCharset = 1;                    // 字元集
            //CodePage = 0;                       // code page

            //MessageInitial();       // Message 要初值化, 否則若找不到語系檔就麻煩了
            GetAllFileName();       // 取得全部的語系檔, 例如得到 FileNames[Chinese(Big5)]=cbr_big5.ini
        }

        // 取得全部的語系檔, 例如得到 FileNames[Chinese(Big5)]=cbr_big5.ini
        void GetAllFileName()
        {
            if (!Directory.Exists(LangPath)) {
                return;    
            }
            string[] files = Directory.GetFiles(LangPath, "*.ini");
            FileNames.Clear();

            foreach (string file in files) {
                // 取得此語系檔的語系名稱
                string langName = GetLangNameFromFile(file);
                if (langName != "") {
                    FileNames[langName] = file;
                }
            }
            
            // 使用者自訂

            if (!Directory.Exists(UserLangPath)) {
                return;
            }
            string[] userFiles = Directory.GetFiles(UserLangPath, "*.ini");
            UserFileNames.Clear();

            foreach (string file in userFiles) {
                // 取得此語系檔的語系名稱
                string langName = GetLangNameFromFile(file);
                if (langName != "") {
                    UserFileNames[langName] = file;
                }
            }
        }

        // 由語系檔取得此語系檔的語系名稱, 例如得到 FileNames[Chinese(Big5)]=xxx/xxx/cbr_big5.ini
        string GetLangNameFromFile(string fileName)
        {
            // Ini file 結構是
            // [section]
            // Ident = Value

            IniFile.FileName = fileName;
            return IniFile.ReadString("Info", "Language", "");
        }

        // 更換語系，傳入語系檔名，以及要更換的 form
        public void ChangeLanguage(string langName, params Form[] forms)
        {
            string sFileName = FileNames[langName];

            if (!File.Exists(sFileName)) {
                string sMessage = "Language : File " + FileName + " is not exist.";
                MessageBox.Show(sMessage);
                return;
            }

            FileName = sFileName;
            IniFile.FileName = sFileName;

            if(UserFileNames.ContainsKey(langName)) {
                UserFileName = UserFileNames[langName];
                UserIniFile.FileName = UserFileName;
            } else {
                UserFileName = "";
                UserIniFile.FileName = "";
            }

            // 取得全部的 message
            // 要先處理，才能取得 Font 資料
            GetAllMessages();

            // 更換所有元件標題

            foreach (Form form in forms) {
                ChangeFormLang(form);
            }

        }

        // 取得語系檔所有 [Messages] Section 裡面的資料, 放到 Messages 裡面
        void GetAllMessages()
        {
            // Ini file 結構是
            // [section]
            // Ident = Value

            // 取得字體大小及字形

            string Section = "INFO";

            string UserFontName = UserIniFile.ReadString(Section, "FontName", "");
            if (UserFontName == "") {
                FontName = IniFile.ReadString(Section, "FontName", FontName);
            } else {
                FontName = UserFontName;
            }

            // 漢字
            HanFontName = FontName;     // 預設等於 FontName
            UserFontName = UserIniFile.ReadString(Section, "HanFontName", "");
            if (UserFontName == "") {
                HanFontName = IniFile.ReadString(Section, "HanFontName", HanFontName);
            } else {
                HanFontName = UserFontName;
            }

            int UserFontSize = UserIniFile.ReadInteger(Section, "FontSize", 0);
            if (UserFontSize == 0) {
                FontSize = IniFile.ReadInteger(Section, "FontSize", FontSize);
            } else {
                FontSize = UserFontSize;
            }

            // 漢字
            HanFontSize = FontSize;     // 預設等於 FontSize
            UserFontSize = UserIniFile.ReadInteger(Section, "HanFontSize", 0);
            if (UserFontSize == 0) {
                HanFontSize = IniFile.ReadInteger(Section, "HanFontSize", HanFontSize);
            } else {
                HanFontSize = UserFontSize;
            }

            //FontCharset = IniFile.ReadInteger(Section, "FontCharset", FontCharset);
            //CodePage = IniFile.ReadInteger(Section, "CodePage", CodePage);

            Section = "Message";

            Messages.Clear();
            
            // 先處理一般語系
            string sSectionContent = IniFile.ReadSection(Section);
            SplitString2KeyAndValue(sSectionContent);   // 拆分字串，將每個字串拆分成鍵和值
            // 再處理使用者自訂語系
            sSectionContent = UserIniFile.ReadSection(Section);
            SplitString2KeyAndValue(sSectionContent);   // 拆分字串，將每個字串拆分成鍵和值
        }

        // 拆分字串，將每個字串拆分成鍵和值
        void SplitString2KeyAndValue(string sSectionContent)
        {
            // 拆分字串，將每個字串拆分成鍵和值
            foreach (string item in sSectionContent.Split('\0')) {
                if (!string.IsNullOrEmpty(item)) {
                    // 將字串拆分成鍵和值
                    int index = item.IndexOf("=");
                    string key = item.Substring(0, index);
                    string value = item.Substring(index + 1);

                    value = value.Replace("\\r", "\r");
                    value = value.Replace("\\n", "\n");
                    // 將鍵和值添加到字典中
                    if (Messages.ContainsKey(key)) {
                        Messages[key] = value;
                    } else {
                        Messages.Add(key, value);
                    }
                }
            }
        }

        // 傳入 message 和 id, 若 id 有內容則傳回，否則傳回 message
        public string GetMessage(string message, string msgId)
        {
            if (Messages.ContainsKey(msgId)) {
                return Messages[msgId];
            } else {
                return message;
            }
        }
        
        // 更新所有 form 的語系
        public void ChangeFormLang(Form form)
        {
            EachControl(form.Name, form);
        }

        void EachControl(string formName, Control c)
        {
            ChangeComponentLang(formName, c);

            if(formName == "AboutForm") {
                // about 只要處理標題即可
                return;
            }

            // 其它有子項目或特殊項目的另外處理
            if (c is ToolStrip) {
                EachMenuItems(formName, (c as ToolStrip).Items);
            } else if (c is ComboBox) {
                if (c.Tag == "han") {
                    c.Font = new Font(HanFontName, HanFontSize);
                } else {
                    c.Font = new Font(FontName, FontSize);
                }
                EachComboBoxItems(formName, c.Name, (c as ComboBox).Items);
            } else if (c is ListBox) {
                if (c.Tag == "han") {
                    c.Font = new Font(HanFontName, HanFontSize);
                } else {
                    c.Font = new Font(FontName, FontSize);
                }
                EachListBoxItems(formName, c.Name, (c as ListBox).Items);
            } else if (c is DataGridView) {
                c.Font = new Font(FontName, FontSize);
                EachDataGridViewColumns(formName, c.Name, (c as DataGridView).Columns);
            } else if (c is TabControl) {
                // 設定 TabControl 字型
                c.Font = new Font(FontName, FontSize);
            } else if (c is TreeView) {
                // 設定 TreeView 字型
                if (c.Tag == "han") {
                    c.Font = new Font(HanFontName, HanFontSize);
                } else {
                    c.Font = new Font(FontName, FontSize);
                }
            }

            foreach (Control cs in c.Controls) {
                EachControl(formName, cs);
            }
        }

        // 更新元件的語系
        public void ChangeComponentLang(string formName, Control c)
        {
            string controlName = IniFile.ReadString(formName, c.Name, "");
            controlName = UserIniFile.ReadString(formName, c.Name, controlName);
            MainForm main = null;
            if (formName == "MainForm") {
                main = (MainForm) c.FindForm();
            }

            // 處理特殊的位置
            // 主功能表切換按鈕
            if (formName == "MainForm" && c.Name == "btNavWidthSwitch") {
                if (main.pnMainFunc.Width == 0) {
                    controlName = GetMessage("主功能 ►", "01023");
                } else {
                    controlName = GetMessage("◄ 主功能", "01022");
                }
            }
            // 目錄切換按鈕
            if (formName == "MainForm" && c.Name == "btMuluWidthSwitch") {
                if (main.pnMulu.Width == 0) {
                    controlName = GetMessage("目次 ►", "01021");
                } else {
                    controlName = GetMessage("◄ 目次", "01020");
                }
            }

            // 搜尋書目數量
            if (formName == "MainForm" && c.Name == "lbFindSutraCount") {
                controlName = GetMessage("找到 %d 筆", "01008");
                controlName = controlName.Replace("%d", main.sgFindSutra.RowCount.ToString());
            }

            // 全文檢索數量
            if (formName == "MainForm" && c.Name == "lbSearchMsg") {
                controlName = GetMessage("找到 %d 筆，共花時間：%f 秒", "01024");
                if (main.SearchTimeDiff == "") {
                    controlName = "";   // 還沒開始搜尋，所以不顯示
                } else {
                    controlName = controlName.Replace("%d", main.SearchFoundCount.ToString());
                    controlName = controlName.Replace("%f", main.SearchTimeDiff);
                }
            }

            // 檢索本書
            if (formName == "MainForm" && c.Name == "cbSearchThisSutra") {
                controlName = GetMessage("檢索本書：", "01019") + main.SearchThisBookName;
            }

            // 更新元件標題與字型
            if (controlName != "") {
                c.Text = controlName;
                if (formName != "AboutForm") {
                    // about 不換字型
                    if (c.Tag == "han") {
                        c.Font = new Font(HanFontName, HanFontSize);
                    } else {
                        c.Font = new Font(FontName, FontSize);
                    }
                }
            }

            // 設定 tooltip
            if (formName == "MainForm") {
                string controlTooltip = IniFile.ReadString(formName, c.Name + "_tip", "");
                controlTooltip = UserIniFile.ReadString(formName, c.Name + "_tip", controlTooltip);
                if (controlTooltip != "") {
                    controlTooltip = controlTooltip.Replace("\\r", "\r");
                    controlTooltip = controlTooltip.Replace("\\n", "\n");
                    main.toolTip1.SetToolTip(c, controlTooltip);
                }
            }
        }

        void EachMenuItems(string formName, ToolStripItemCollection items)
        {
            foreach (ToolStripMenuItem item in items) {
                ChangeMenuItemLang(formName, item);
                if (item.HasDropDownItems) {
                    EachMenuItems(formName, item.DropDownItems);
                }
            }
        }

        // 更新選單的語系
        void ChangeMenuItemLang(string formName, ToolStripMenuItem item)
        {
            string controlName = IniFile.ReadString(formName, item.Name, "");
            controlName = UserIniFile.ReadString(formName, item.Name, controlName);
            // 特別處理語言
            if(item.Name == "miLanguage") {
                if(controlName == "") {
                    controlName = "Language";
                } else if(controlName.ToUpper() != "LANGUAGE") {
                    controlName = controlName + " (Language)";
                } 
            }
            if (controlName != "") {
                item.Text = controlName;
                item.Font = new Font(FontName,9);
            }
        }

        // 更新 ComboBox Item
        void EachComboBoxItems(string formName, string comboBoxName, ComboBox.ObjectCollection items)
        {
            for (int i = 0; i < items.Count; i++) {
                string controlName = IniFile.ReadString(formName, $"{comboBoxName}Item{i}", "");
                controlName = UserIniFile.ReadString(formName, $"{comboBoxName}Item{i}", controlName);
                if (controlName != "") {
                    items[i] = controlName;
                }
            }
        }

        // 更新 ListBox Item
        void EachListBoxItems(string formName, string listBoxName, ListBox.ObjectCollection items)
        {
            for (int i = 0; i < items.Count; i++) {
                string controlName = IniFile.ReadString(formName, $"{listBoxName}Item{i}", "");
                controlName = UserIniFile.ReadString(formName, $"{listBoxName}Item{i}", controlName);
                if (controlName != "") {
                    items[i] = controlName;
                }
            }
        }

        // 更新 DataGridView Columns
        void EachDataGridViewColumns(string formName, string dataGridViewName, DataGridViewColumnCollection items)
        {
            for (int i = 0; i < items.Count; i++) {
                string controlName = IniFile.ReadString(formName, $"{dataGridViewName}Column{i + 1}", "");
                controlName = UserIniFile.ReadString(formName, $"{dataGridViewName}Column{i + 1}", controlName);
                if (controlName != "") {
                    items[i].HeaderText = controlName;
                }

                // 特殊的欄位要用中文字型
                if (dataGridViewName == "sgFindSutra" && (i == 3 || i == 5 || i == 6)) {
                    items[i].DefaultCellStyle.Font = new Font(HanFontName, HanFontSize);
                } else if (dataGridViewName == "sgTextSearch" && (i == 4 || i == 6 || i == 7)) {
                    items[i].DefaultCellStyle.Font = new Font(HanFontName, HanFontSize);
                } else {
                    items[i].DefaultCellStyle.Font = new Font(FontName, FontSize);
                }
            }
        }

        // ================================================
        // 産生基本的繁體語系檔
        public void CreateIniFile(params Form[] forms)
        {
            DefaultIni = "";    // 預設的 Ini 內容
            foreach (Form form in forms) {
                DefaultIni += "[" + form.Name + "]\n";
                GetAllControlNameAndText(form.Name, form);
            }
            StreamWriter sw = new StreamWriter("default_lang.ini", false, Encoding.UTF8);
            sw.Write(DefaultIni);
            sw.Close();
        }

        private void GetAllControlNameAndText(string formName, Control c)
        {
            DefaultIni += c.Name + "=" + c.Text + "\n";

            // 其它有子項目的另外處理
            if (c is ToolStrip) {
                GetEachMenuItemNameAndText(formName, (c as ToolStrip).Items);
            } else if (c is ComboBox) {
                ComboBox.ObjectCollection items = (c as ComboBox).Items;
                for (int i = 0; i < items.Count; i++) {
                    DefaultIni += $"{c.Name}Item{i}=" + items[i] + "\n";
                }
            } else if (c is ListBox) {
                ListBox.ObjectCollection items = (c as ListBox).Items;
                for (int i = 0; i < items.Count; i++) {
                    DefaultIni += $"{c.Name}Item{i}=" + items[i] + "\n";
                }
            } else if (c is DataGridView) {
                DataGridViewColumnCollection items = (c as DataGridView).Columns;
                for (int i = 0; i < items.Count; i++) {
                    DefaultIni += $"{c.Name}Item{i}=" + items[i].HeaderText + "\n";
                }
            }

            foreach (Control cs in c.Controls) {
                GetAllControlNameAndText(formName, cs);
            }
        }

        void GetEachMenuItemNameAndText(string formName, ToolStripItemCollection items)
        {
            foreach (ToolStripMenuItem item in items) {
                DefaultIni += item.Name + "=" + item.Text + "\n";
                if (item.HasDropDownItems) {
                    GetEachMenuItemNameAndText(formName, item.DropDownItems);
                }
            }
        }
    }
}
