using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{

    // 一開始只要給目錄，讓它取得所有的語系檔名及語系名稱
    // 更換語系時，就是切換檔名，再更換所有元件文字，取得所有訊息
    public class Language
    {
        string FileName = "";        // 目前使用中的語系檔名
        string LangPath = "";        // 語系檔的路徑
        string DefaultIni = "";
        CIniFile iniFile = new CIniFile();

        public SortedDictionary<string, string> FileNames;  // 語系檔列表 (語系名, 檔名)
        public Dictionary<string, string> Messages;         // 所有的訊息列表

        string FontName;            // 字型
        int FontSize;               // 字型大小
        //TFontCharset FontCharset;   // 字元集
        //unsigned int CodePage;      // code page

        public Language(string sLangPath) // 建構函式, 傳入語系檔目錄
        {
            LangPath = sLangPath;
            FileNames = new SortedDictionary<string, string>();  // 語系檔列表 (語系名, 檔名)
            Messages = new Dictionary<string, string>();         // 所有的訊息列表

            FontName = "";
            //FontCharset = 1;                    // 字元集
            FontSize = 12;
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
        }

        // 由語系檔取得此語系檔的語系名稱, 例如得到 FileNames[Chinese(Big5)]=cbr_big5.ini
        string GetLangNameFromFile(string fileName)
        {
            // Ini file 結構是
            // [section]
            // Ident = Value

            iniFile.FileName = fileName;
            return iniFile.ReadString("Info", "Language", "");
        }

        // 更換語系，傳入語系檔名，以及要更換的 form
        public void ChangeLanguage(string sFileName, params Form[] forms)
        {
            if (!File.Exists(sFileName)) {
                string sMessage = "Language : File " + FileName + " is not exist.";
                MessageBox.Show(sMessage);
                return;
            }

            FileName = sFileName;
            iniFile.FileName = sFileName;

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

            FontName = iniFile.ReadString(Section, "FontName", FontName);
            FontSize = iniFile.ReadInteger(Section, "FontSize", FontSize);
            //FontCharset = iniFile.ReadInteger(Section, "FontCharset", FontCharset);
            //CodePage = iniFile.ReadInteger(Section, "CodePage", CodePage);

            Section = "Message";

            Messages.Clear();
            string sSectionContent = iniFile.ReadSection(Section);

            // 拆分字串，將每個字串拆分成鍵和值
            foreach (string item in sSectionContent.Split('\0')) {
                if (!string.IsNullOrEmpty(item)) {
                    // 將字串拆分成鍵和值
                    int index = item.IndexOf("=");
                    string key = item.Substring(0, index);
                    string value = item.Substring(index + 1);

                    // 將鍵和值添加到字典中
                    Messages.Add(key, value);
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
            if (FontName != "") {
                Font newFont = new Font(FontName, FontSize);
                form.Font = newFont;
            }
            EachControl(form.Name, form);
        }

        void EachControl(string formName, Control c)
        {
            ChangeComponetLang(formName, c);

            // 其它有子項目的另外處理
            if (c is ToolStrip) {
                EachMenuItems(formName, (c as ToolStrip).Items);
            } else if (c is ComboBox) {
                EachComboBoxItems(formName, c.Name, (c as ComboBox).Items);
            } else if (c is ListBox) {
                EachListBoxItems(formName, c.Name, (c as ListBox).Items);
            } else if (c is DataGridView) {
                EachDataGridViewColumns(formName, c.Name, (c as DataGridView).Columns);
            }

            foreach (Control cs in c.Controls) {
                EachControl(formName, cs);
            }
        }

        // 更新元件的語系
        public void ChangeComponetLang(string formName, Control c)
        {
            string controlName = iniFile.ReadString(formName, c.Name, "");

            // 處理特殊的位置
            // 搜尋書目數量
            if (formName == "mainForm" && c.Name == "lbFindSutraCount") {
                controlName = GetMessage("找到 %d 筆", "01008");
                mainForm main = (mainForm) c.FindForm();
                controlName = controlName.Replace("%d", main.sgFindSutra.RowCount.ToString());
            }

            // 全文檢索數量
            if (formName == "mainForm" && c.Name == "lbSearchMsg") {
                controlName = GetMessage("找到 %d 筆，共花時間：%f 秒", "01024");
                mainForm main = (mainForm)c.FindForm();
                if (main.SearchTimeDiff == "") {
                    controlName = "";   // 還沒開始搜尋，所以不顯示
                } else {
                    controlName = controlName.Replace("%d", main.SearchFoundCount.ToString());
                    controlName = controlName.Replace("%f", main.SearchTimeDiff);
                }
            }

            if (controlName != "") {
                c.Text = controlName;
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
            string controlName = iniFile.ReadString(formName, item.Name, "");
            if (controlName != "") {
                item.Text = controlName;
            }
        }

        // 更新 ComboBox Item
        void EachComboBoxItems(string formName, string comboBoxName, ComboBox.ObjectCollection items)
        {
            for (int i = 0; i < items.Count; i++) {
                string controlName = iniFile.ReadString(formName, $"{comboBoxName}Item{i}", "");
                if (controlName != "") {
                    items[i] = controlName;
                }
            }
        }

        // 更新 ListBox Item
        void EachListBoxItems(string formName, string listBoxName, ListBox.ObjectCollection items)
        {
            for (int i = 0; i < items.Count; i++) {
                string controlName = iniFile.ReadString(formName, $"{listBoxName}Item{i}", "");
                if (controlName != "") {
                    items[i] = controlName;
                }
            }
        }

        // 更新 DataGridView Columns
        void EachDataGridViewColumns(string formName, string dataGridViewName, DataGridViewColumnCollection items)
        {
            for (int i = 0; i < items.Count; i++) {
                string controlName = iniFile.ReadString(formName, $"{dataGridViewName}Column{i + 1}", "");
                if (controlName != "") {
                    items[i].HeaderText = controlName;
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
