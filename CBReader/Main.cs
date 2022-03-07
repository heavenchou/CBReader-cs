using Monster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
    public partial class MainForm : Form
    {
        AboutForm aboutForm;
        OptionForm optionForm;
        SearchRangeForm searchrangeForm;
        UpdateForm updateForm;
        public CSetting Setting; // 設定檔

        int SelectedBook = -1;   // 目前選中的書, -1 表示還沒選

        public CBookcase Bookcase; // 書櫃
        CNavTree NavTree; // 導覽文件 (暫時的, 日後會放在 Serial 物件中 ???)
        CNavTree MuluTree; // 單經導覽文件 (暫時的, 日後會放在 Serial 物件中 ???)

        CMonster SearchEngine = null;   // 全文檢索引擎

        List<string> SearchWordList = new List<string>();	// 存放每一個檢索的詞, 日後塗色會用到
        string SearchSentence = "";         // 搜尋字串

        int SpineID;    // 目前開啟的檔案, 用來處理上一卷和下一卷用的

        int NavWidth;   // 目錄區的寬度
        int MuluWidth = 200;  // 書目區的寬度

        public MainForm()
        {
            InitializeComponent();

            // 設定目錄初值
            CGlobalVal.initialPath();
            // 將 IE 設定到 IE 11 (如果沒 IE 11 的如何?)
            SetPermissions(11001);

            // 取得設定檔並讀取所有設定
            Setting = new CSetting(CGlobalVal.SettingFile);

            // 載入環境
            LoadEnvironment();

            InitializeForms();  // 初始其它的 Form

            // 判斷是不是西蓮淨苑 SLReader 專用
            // CheckSeeland(); ????

            // 刪去舊版
            string sOld = CGlobalVal.MyHomePath + ".tmp";
            if (File.Exists(sOld)) {
                File.Delete(sOld);
            }

            MainFunc.SelectedIndex = 0;
            pnMulu.Width = 0;  // 書目先縮到最小
            cbFindSutraBookId.SelectedIndex = 0;
            cbGoBookBookId.SelectedIndex = 0;
            cbGoSutraBookId.SelectedIndex = 0;

            //sgTextSearch->OnKeyDown = sgTextSearchKeyDown;
            //sgFindSutra->OnKeyDown = sgFindSutraKeyDown;
        }

        // =====================================================
        // 成員函式
        // =====================================================

        // 初始其它的 Form
        void InitializeForms()
        {
            aboutForm = new AboutForm(this);
            optionForm = new OptionForm(this);
            searchrangeForm = new SearchRangeForm(this);
            updateForm = new UpdateForm(this);
        }

        // 初始資料
        void InitialData()
        {
            // 取得 Bookcase 所有資料區
            // 載入書櫃

            string sBookcasePath = "";

            // Bookcase 目錄處理原則
            // 1. Windows 在主程式所在目錄底下去找 Bookcase 子目錄
            // 2. Mac 有二個優先順序
            //    3.1 /User/xxx/Library/CBETA/Bookcase
            //    3.2 /Library/CBETA/Bookcase
            // 3. 上面若沒有, 則找 Setting->BookcaseFullDir
            // 4. 以上若都沒有, 則由使用者尋找, 找到後存在 Setting->BookcaseFullDir

            sBookcasePath = CGlobalVal.pathAddSlash(CGlobalVal.MyFullPath + Setting.BookcasePath);

            // 都沒有就查設定
            if (!Directory.Exists(sBookcasePath)) {
                if (Setting.BookcaseFullPath != "") {
                    sBookcasePath = Setting.BookcaseFullPath;
                }
            }

            // 都沒有就詢問使用者
            if (!Directory.Exists(sBookcasePath)) {

                MessageBox.Show("沒有找到您的 Bookcase 書櫃目錄，請手動選擇目錄所在位置。");
                // 使用指定目錄

                folderBrowserDialog1.Description = "選擇 Bookcase 目錄所在位置";
                //folderBrowserDialog1.RootFolder = CGlobalVal.MyFullPath;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                    sBookcasePath = folderBrowserDialog1.SelectedPath;
                }

                Setting.BookcaseFullPath = sBookcasePath;
                Setting.SaveToFile();
            }

            Bookcase = new CBookcase(sBookcasePath);

            // 在書櫃選擇叢書
            int iBookcaseCount = Bookcase.Books.Count;
            if (iBookcaseCount == 0) {
                CGlobalMessage.push("書櫃中一本書都沒有");
            }
            // else if(iBookcaseCount == 1)
            else {
                // 只有一本書就直接開了
                // OpenBookcase(0); // ???? 暫時取消, 這一版要直接開啟 CBETA
                OpenCBETABook();    // ???? 取消上面, 因為這一版要直接開啟 CBETA
            }

            //???? MuluTree = 0;

            lbSearchMsg.Text = ""; // 清空搜尋訊息
            SpineID = -1;   // 初值表示沒開啟

            if (iBookcaseCount != 0) {
                string URL = "file://" + Bookcase.CBETA.Dir + "help/index.htm";
                webBrowser.Navigate(URL);
            }

            Text = Text + " v" + CGlobalVal.Version;
            Text = Text.Remove(Text.LastIndexOf('.'));
            Text = Text.Remove(Text.LastIndexOf('.'));

            // 西蓮淨苑 SLReader 專用
            // 檢索範圍要加上西蓮
            /*
            if (Application->Title == u"SLReader")
	            {
	            // 版本末碼為 1 的表示全部西蓮, 就不用做檢索範圍了
	            if (*Version.LastChar() != '1') {
		            TTreeViewItem* newItem1 = new TTreeViewItem(fmSearchRange->tvBook);
		            newItem1->Text = u"DA 道安法師著作全集";   // 標題
		            fmSearchRange->tvBook->AddObject(newItem1);

		            TTreeViewItem* newItem2 = new TTreeViewItem(fmSearchRange->tvBook);
		            newItem2->Text = u"ZY 智諭法師著作全集";   // 標題
		            fmSearchRange->tvBook->AddObject(newItem2);

		            TTreeViewItem* newItem3 = new TTreeViewItem(fmSearchRange->tvBook);
		            newItem3->Text = u"HM 惠敏法師蓮風集";   // 標題
		            fmSearchRange->tvBook->AddObject(newItem3);
	            }
            }
            */
        }

        // 開啟指定的書櫃
        void OpenBookcase(int iID)
        {
            if (iID == SelectedBook) return;    // 同一本, 不要重開
            if (iID == -1) return;      // 沒選書

            SelectedBook = iID;

            // 載入叢書的起始目錄
            CSeries s = Bookcase.Books[iID];
            NavTree = new CNavTree(s.Dir + s.NavFile);
            NavTree.SaveToTreeView(tvNavTree);
        }

        // 開啟CBETA書櫃
        void OpenCBETABook()
        {
            for (int i = 0; i < Bookcase.Books.Count; i++) {
                if (Bookcase.Books[i] == Bookcase.CBETA) {
                    // 找到 CBETA 了
                    OpenBookcase(i);
                    return;
                }
            }
            MessageBox.Show("找不到 CBETA 資料");
            return;
        }

        // 將 IE 設定為 IE 11
        // 參考
        // https://msdn.microsoft.com/en-us/library/ee330730%28v=vs.85%29.aspx#browser_emulation
        // https://stackoverflow.com/questions/17922308/use-latest-version-of-internet-explorer-in-the-webbrowser-control
        // http://docwiki.embarcadero.com/Libraries/Tokyo/en/FMX.WebBrowser.TWebBrowser
        void SetPermissions(int iIE)
        {
            string sFeatureBrowserEmulation = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION\";
            string sKey = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

            var ieVer = Microsoft.Win32.Registry.GetValue(sFeatureBrowserEmulation, sKey, "0");
            string sIEVer = ieVer.ToString();
            if (sIEVer != iIE.ToString()) {
                Microsoft.Win32.Registry.SetValue(sFeatureBrowserEmulation, sKey, iIE);
            }
        }

        // 將檔案載入導覽樹
        void LoadNavTree(string sFile)
        {
            if (NavTree != null && NavTree.XMLFile == sFile) return;

            NavTree = new CNavTree(sFile);
            NavTree.SaveToTreeView(tvNavTree);
        }

        // 載入 XML 並處理成網頁
        void ShowCBXML(string sFile, bool bShowHighlight = false, CSeries sSeries = null)
        {
            if (sFile == "") {
                MessageBox.Show("沒有找到正確檔案");
                return;
            }
            if (sSeries == null) {
                sSeries = Bookcase.CBETA;
            }

            // 如果傳來的是 XML/T/T01/T01n0001_001.xml#p0001a01
            // 則要把 p0001a01 分離出來

            string sLink = "";
            int iPos = sFile.IndexOf("#");
            if (iPos >= 0) {
                sLink = sFile.Substring(iPos + 1);
                sFile = sFile.Substring(0, iPos);
                if (sFile == "") {
                    MessageBox.Show("沒有找到正確檔案");
                    return;
                }
            }

            string sXMLFile = Bookcase.CBETA.Dir + sFile;
            string sJSFile = Bookcase.CBETA.Dir + Bookcase.CBETA.JSFile;
            CCBXML CBXML = new CCBXML(sXMLFile, sLink, Setting, sJSFile, bShowHighlight, sSeries);

            // 找出 spine id , -1 表示沒找到
            SpineID = Array.IndexOf(Bookcase.CBETA.Spine.Files, sFile);

            string sOutFile = sFile + ".htm";

            sOutFile = sOutFile.Replace("/", "_");
            sOutFile = sOutFile.Replace("\\", "_");
            sOutFile = CGlobalVal.MyTempPath + sOutFile;

            CBXML.SaveToHTML(sOutFile);

            try {
                //WebBrowser->URL = (u"file://" + sOutFile);
                webBrowser.Navigate("file://" + sOutFile);
            } catch {
                //WebBrowser->Navigate(u"file://" + sOutFile);
            }

            // 產生目錄

            string sMulu = sFile.Replace("XML", "toc");
            int iLen = sMulu.Length;
            sMulu = sMulu.Substring(0, iLen - 8); // 扣掉最後的 _001.xml

            // toc/T/T01/T01n0001 => toc/T/T0001
            sMulu = Regex.Replace(sMulu, @"\d+[\/][A-Z]+\d+n", "");
            sMulu = Bookcase.CBETA.Dir + sMulu + ".xml";
            if (File.Exists(sMulu)) {
                if (MuluTree == null || sMulu != MuluTree.XMLFile) {
                    LoadMuluTree(sMulu);
                }
            }

            // 更改 form 的 title

            if (SpineID >= 0) {
                string sBook = Bookcase.CBETA.Spine.BookID[SpineID];
                string sVol = Bookcase.CBETA.Spine.Vol[SpineID];
                string sVolNum = Bookcase.CBETA.Spine.VolNum[SpineID];
                string sSutra = Bookcase.CBETA.Spine.Sutra[SpineID];
                string sJuan = Bookcase.CBETA.Spine.Juan[SpineID];
                int iIndex = Bookcase.CBETA.Catalog.FindIndexBySutraNum(sBook, sVolNum, sSutra);
                string sName = Bookcase.CBETA.Catalog.SutraName[iIndex];

                // 經名移除 (第X卷-第x卷)
                sName = CCBSutraUtil.CutJuanAfterSutraName(sName);
                sJuan = sJuan.TrimStart('0');
                sSutra = sSutra.TrimStart('0');
                string sCaption = CGlobalVal.ProgramTitle + "《" + sName + "》"
                        + sVol + ", No. " + sSutra + ", 卷/篇章" + sJuan;
                this.Text = sCaption;

                // 將經名後面的 （上中下一二三......十）移除
                sName = CCBSutraUtil.CutNumberAfterSutraName(sName);
                cbSearchThisSutra.Text = "檢索本經：" + sName;
                cbSearchThisSutraChange();  // 設定檢索本經的相關資料
            }

            // 檢索本經
            cbSearchThisSutra.Enabled = true;
        }

        // 將檔案載入目錄樹
        void LoadMuluTree(string sFile)
        {
            if (MuluTree != null && MuluTree.XMLFile == sFile) {
                return;
            }

            MuluTree = new CNavTree(sFile);
            MuluTree.SaveToTreeView(tvMuluTree);

            // 展開第一層

            for (int i = 0; i < tvMuluTree.GetNodeCount(false); i++) {
                try {
                    tvMuluTree.Nodes[i].Expand();
                } catch {
                    // 忽略...
                }
            }
            tvMuluTree.SelectedNode = tvMuluTree.Nodes[0];

            // 檢查書目區是不是縮到最小

            if (pnMulu.Width == 0) {
                btMuluWidthSwitchClick();
            }
        }

        void btMuluWidthSwitchClick()
        {
            if (pnMulu.Width == 0) {
                pnMulu.Width = MuluWidth;
                btMuluWidthSwitch.Text = "◄ 目次";
            } else {
                MuluWidth = pnMulu.Width;
                pnMulu.Width = 0;
                btMuluWidthSwitch.Text = "目次 ►";
            }
        }

        // 檢索本經
        void cbSearchThisSutraChange()
        {
            if (cbSearchThisSutra.Checked) {
                // 設定檢索此經
                if (SpineID == -1) {
                    cbSearchThisSutra.Checked = false;
                    return;
                }

                if (cbSearchRange.Visible) {
                    cbSearchRange.Checked = false;
                }

                // 取出本經
                string sThisBookId = Bookcase.CBETA.Spine.BookID[SpineID];
                string sThisSutra = Bookcase.CBETA.Spine.Sutra[SpineID];

                if (Bookcase.CBETA.SearchEngine_CB != null) {
                    Bookcase.CBETA.SearchEngine_CB.BuildFileList.NoneSearch();
                    Bookcase.CBETA.SearchEngine_CB.BuildFileList.SearchThisSutra(sThisBookId, sThisSutra);
                }
                if (Bookcase.CBETA.SearchEngine_orig != null) {
                    Bookcase.CBETA.SearchEngine_orig.BuildFileList.NoneSearch();
                    Bookcase.CBETA.SearchEngine_orig.BuildFileList.SearchThisSutra(sThisBookId, sThisSutra);
                }
            }
        }

        // 檢查有沒有更新程式, bShowNoUpdate : 沒更新時要不要秀訊息
        void CheckUpdate(bool bShowNoUpdate)
        {
            //return;

	        // 取得資料版本
	        string sDataVer = Bookcase.CBETA.Version;

            updateForm.CheckUpdate(CGlobalVal.Version, sDataVer, bShowNoUpdate);

	        if(!updateForm.IsUpdate)    // 有更新就不要修改更新日期
	        {
                Setting.LastUpdateChk = DateTime.Today.ToString("yyyyMMdd");
		        Setting.SaveToFile();
            }
        }

        // 切換目錄樹中的折疊
        void ToggleTreeViewItem(TreeNode tvItem)
        {
            // 如果有子層, 就切換展開或閉合狀態
            if (tvItem.GetNodeCount(false) > 0) {
                if (tvItem.IsExpanded) {
                    tvItem.Collapse();
                } else {
                    tvItem.Expand();
                }
            }
        }

        // 開啟目錄樹中的經文或另一層目錄
        void OpenTreeViewItem(TreeNode tvItem)
        {
            // Item
            SNavItem item = (SNavItem)tvItem.Tag;
            string sURL = item.URL;
            // ???? 這行取巧, 日後要拿掉
            // 因為從單經書目點選時, 有時沒有開啟 SelectedBook
            if (SelectedBook < 0) {
                SelectedBook = 0;
            }
            CSeries sSeries = Bookcase.Books[SelectedBook];
            var iType = item.Type;
            tvNavTree.Cursor = Cursors.WaitCursor;

            // 一般連結
            if (iType == ENavItemType.nit_NormalLink) {
                if (sURL.Substring(0, 4) == "http") {
                    webBrowser.Navigate(sURL);
                } else {
                    webBrowser.Navigate("file://" + sSeries.Dir + sURL);
                }
            } else if (iType == ENavItemType.nit_NavLink) {
                // 目錄連結
                LoadNavTree(sSeries.Dir + sURL);
            } else if (iType == ENavItemType.nit_CBLink) {
                // CBETA 經文
                ShowCBXML(sURL);
            }
            tvNavTree.Cursor = Cursors.Default;
        }

        // 載入環境
        void LoadEnvironment()
        {
            CIniFile iniFile = new CIniFile(Setting.SettingFile);
            string Section;

            // Ini file 結構是
            // [section]
            // Ident = Value

            Section = "MainForm";

            pnMainFunc.Width = iniFile.ReadInteger(Section, "FunMenuWidth", pnMainFunc.Width);
            MuluWidth = iniFile.ReadInteger(Section, "MuluWidth", MuluWidth);

            // 欄寬
            Section = "ColumnWidth";

            // 經目搜尋的欄寬
            for(int i=0; i<7; i++) {
                sgFindSutra.Columns[i].Width = iniFile.ReadInteger(Section, $"FindSutraC{i}", sgFindSutra.Columns[i].Width);
            }
            // 全文檢索的欄寬
            for (int i = 0; i < 8; i++) {
                sgTextSearch.Columns[i].Width = iniFile.ReadInteger(Section, $"TextSearchC{i}", sgTextSearch.Columns[i].Width);
            }

        }

        // 儲存環境
        void SaveEnvironment()
        {
            CIniFile iniFile = new CIniFile(Setting.SettingFile);
            string Section;

            // Ini file 結構是
            // [section]
            // Ident = Value

            Section = "MainForm";

            iniFile.WriteInteger(Section, "FunMenuWidth", pnMainFunc.Width);
            if (pnMulu.Width > 0) {
                iniFile.WriteInteger(Section, "MuluWidth", pnMulu.Width);
            } else {
                iniFile.WriteInteger(Section, "MuluWidth", MuluWidth);
            }

            // 欄寬
            Section = "ColumnWidth";

            // 經目搜尋的欄寬
            for (int i = 0; i < 7; i++) {
                iniFile.WriteInteger(Section, $"FindSutraC{i}", sgFindSutra.Columns[i].Width);
            }
            // 全文檢索的欄寬
            for (int i = 0; i < 8; i++) {
                iniFile.WriteInteger(Section, $"TextSearchC{i}", sgTextSearch.Columns[i].Width);
            }


        }

        // =====================================================
        // 元件函式
        // =====================================================

        private void cbSearchRange_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchRange.Checked) {
                // 設定檢索範圍
                var result = searchrangeForm.ShowDialog();
                if(result == DialogResult.Cancel) {
                    cbSearchRange.Checked = false;
                } else {
                    cbSearchThisSutra.Checked = false;
                }
            }
        }

        private void btOption_Click(object sender, EventArgs e)
        {
            optionForm.ShowDialog();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialog();
        }

        private void miOption_Click(object sender, EventArgs e)
        {
            btOption_Click(this, e);
        }

        private void miUpdate_Click(object sender, EventArgs e)
        {
            CheckUpdate(true);  // true 表示沒有更新要秀訊息
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitialData();


            // 檢查更新
            string sToday = DateTime.Today.ToString("yyyyMMdd");
            if (sToday != Setting.LastUpdateChk) { 
                CheckUpdate(false);   // 檢查更新 (false : 沒更新就不用秀訊息)
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetPermissions(7000); // 設定為 IE 7

            // 儲存環境
            SaveEnvironment();
        }

        private void btOpenNav_Click(object sender, EventArgs e)
        {
            btOpenNav.Cursor = Cursors.WaitCursor;
            LoadNavTree(Bookcase.CBETA.Dir + Bookcase.CBETA.NavFile);
            btOpenNav.Cursor = Cursors.Default;
        }

        private void btMuluWidthSwitch_Click(object sender, EventArgs e)
        {
            btMuluWidthSwitchClick();
        }

        // 上一卷
        private void btPrevJuan_Click(object sender, EventArgs e)
        {
            if (SpineID == -1) {
                return;
            }
            if (SpineID > 0) {
                // 檢查是不是同一經
                string sThisSutra = Bookcase.CBETA.Spine.Sutra[SpineID];
                string sPrevSutra = Bookcase.CBETA.Spine.Sutra[SpineID - 1];
                if (sThisSutra == sPrevSutra) {
                    string sFile = Bookcase.CBETA.Spine.CBGetFileNameBySpineIndex(SpineID - 1);
                    ShowCBXML(sFile);
                    return;
                }
            }
            MessageBox.Show("目前已是第一卷/篇章。");
        }

        // 下一卷
        private void btNextJuan_Click(object sender, EventArgs e)
        {
            if (SpineID == -1) {
                return;
            }
            if ((SpineID + 1) < Bookcase.CBETA.Spine.Files.Length) {
                // 檢查是不是同一經
                string sThisSutra = Bookcase.CBETA.Spine.Sutra[SpineID];
                string sNextSutra = Bookcase.CBETA.Spine.Sutra[SpineID + 1];
                if (sThisSutra == sNextSutra) {
                    string sFile = Bookcase.CBETA.Spine.CBGetFileNameBySpineIndex(SpineID + 1);
                    ShowCBXML(sFile);
                    return;
                }
            }
            MessageBox.Show("目前已是最後一卷/篇章。");
        }

        private void btNavWidthSwitch_Click(object sender, EventArgs e)
        {
            if (pnMainFunc.Width == 0) {
                pnMainFunc.Width = NavWidth;
                btNavWidthSwitch.Text = "◄ 主功能";
            } else {
                NavWidth = pnMainFunc.Width;
                pnMainFunc.Width = 0;
                btNavWidthSwitch.Text = "主功能 ►";
            }
        }

        private void btFindSutra_Click(object sender, EventArgs e)
        {
            if (edFindSutraSutraName.Text == CGlobalVal.DebugString) {
                CGlobalVal.IsDebug = true;
                edFindSutraSutraName.Text = "";

                //???? wmiDebug->Visible = true;

                return;
            }
            string sBook = cbFindSutraBookId.Text;
            if (cbFindSutraBookId.SelectedIndex == 0) {
                sBook = "";
            } else {
                int iPos = sBook.IndexOf(" ");
                sBook = sBook.Remove(iPos);
            }
            string sVolFrom = edFindSutraVolFrom.Text;
            string sVolTo = edFindSutraVolTo.Text;
            string sSutraFrom = edFindSutraSutraFrom.Text;
            string sSutraTo = edFindSutraSutraTo.Text;
            string sSutraName = edFindSutraSutraName.Text;
            string sByline = edFindSutraByline.Text;

            // 先用 CBETA 版 ???
            // 逐一搜尋目錄
            //if(IsSelectedBook())
            {
                // 先用 CBETA 版 ???
                // CSeries * Series = (CSeries *) Bookcase->Books->Items[SelectedBook];
                CSeries Series = Bookcase.CBETA;
                CCatalog Catalog = Series.Catalog;
                
                // 逐一檢查
                sgFindSutra.SuspendLayout();
                int iGridIndex = 0;
                sgFindSutra.Rows.Clear();
                sgFindSutra.RowCount = 10;
                for (int i = 0; i < Catalog.ID.Length; i++) {
                    // 找藏經
                    if (sBook != "") {
                        if (Catalog.ID[i] != sBook) {
                            continue;
                        }
                    }
                    // 找冊數
                    if (sVolFrom != "") {
                        if (Convert.ToInt32(Catalog.Vol[i]) < Convert.ToInt32(sVolFrom)) {
                            continue;
                        }
                    }
                    // 找冊數
                    if (sVolTo != "") {
                        if (Convert.ToInt32(Catalog.Vol[i]) > Convert.ToInt32(sVolTo)) {
                            continue;
                        }
                    }
                    // 找經號
                    if (sSutraFrom != "") {
                        // 經號標準化
                        sSutraFrom = CCBSutraUtil.getStandardSutraNumberFormat(sSutraFrom);
                        string sSutra = CCBSutraUtil.getStandardSutraNumberFormat(Catalog.SutraNum[i]);
                        sSutraFrom = sSutraFrom.ToLower();
                        sSutra = sSutra.ToLower();
                        if (string.Compare(sSutra, sSutraFrom) < 0) {
                            continue;
                        }
                    }
                    // 找經號
                    if (sSutraTo != "") {
                        // 經號標準化
                        sSutraTo = CCBSutraUtil.getStandardSutraNumberFormat(sSutraTo);
                        String sSutra = CCBSutraUtil.getStandardSutraNumberFormat(Catalog.SutraNum[i]);
                        sSutraTo = sSutraTo.ToLower();
                        sSutra = sSutra.ToLower();
                        if (sSutraTo.Length == 4 && sSutra.Length == 5) {
                            sSutraTo += "z";
                        }
                        if (string.Compare(sSutra, sSutraTo) > 0) {
                            continue;
                        }
                    }
                    // 找經名
                    if (sSutraName != "") {
                        if (Catalog.SutraName[i].IndexOf(sSutraName) < 0) {
                            continue;
                        }
                    }
                    // 找譯者
                    if (sByline != "") {
                        if (Catalog.Byline[i].IndexOf(sByline) < 0) {
                            continue;
                        }
                    }

                    // 找到了

                    sgFindSutra[0,iGridIndex].Value = Catalog.ID[i];
                    sgFindSutra[1,iGridIndex].Value = Catalog.Vol[i];
                    sgFindSutra[2,iGridIndex].Value = Catalog.SutraNum[i];
                    sgFindSutra[3,iGridIndex].Value = Catalog.SutraName[i];
                    sgFindSutra[4,iGridIndex].Value = Catalog.JuanNum[i];
                    sgFindSutra[5,iGridIndex].Value = Catalog.Part[i];
                    sgFindSutra[6,iGridIndex].Value = Catalog.Byline[i];
                    sgFindSutra[7,iGridIndex].Value = i;
                    iGridIndex++;

                    if (iGridIndex >= sgFindSutra.RowCount - 1) {
                        sgFindSutra.RowCount += 10;
                    }
                }
                sgFindSutra.RowCount = iGridIndex;
                sgFindSutra.ResumeLayout();

                lbFindSutraCount.Text = $"共找到 {iGridIndex} 筆";
                if (iGridIndex == 0) {
                    MessageBox.Show("沒有滿足此條件的資料");
                }
            }
        }

        private void sgFindSutra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) {
                return;
            }
            if(sgFindSutra[7, e.RowIndex].Value == null) {
                return ;
            }
            int iIndex = Convert.ToInt32(sgFindSutra[7,e.RowIndex].Value);
            ShowSutraByCatalogIndex(iIndex);
        }

        private void sgFindSutra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (sgFindSutra.SelectedRows.Count != 0) {
                    int iRow = sgFindSutra.SelectedRows[0].Index;
                    int iIndex = Convert.ToInt32(sgFindSutra[7, iRow].Value);
                    ShowSutraByCatalogIndex(iIndex);
                }
                // 表示略過控制項的預設處理，這樣 GridView 就不會自動跳到下一筆了
                e.Handled = true;
            }  
        }

        // sgFindSutra 開啟的經文
        void ShowSutraByCatalogIndex(int iIndex)
        {
            CCatalog cbCatalog = Bookcase.CBETA.Catalog;
            string sBookID = cbCatalog.ID[iIndex];
            string sVol = cbCatalog.Vol[iIndex];
            string sSutra = cbCatalog.SutraNum[iIndex];

            string sFile = Bookcase.CBETA.CBGetFileNameBySutraNumJuan(sBookID, sVol, sSutra);
            ShowCBXML(sFile);
        }

        // 由經卷頁欄行呈現經文
        private void btGoSutra_Click(object sender, EventArgs e)
        {
            string sBook = cbGoSutraBookId.Text;

            int iPos = sBook.IndexOf(" ");
            sBook = sBook.Remove(iPos);

            string sSutraNum = edGoSutraSutraNum.Text;
            string sJuan = edGoSutraJuan.Text;
            string sPage = edGoSutraPage.Text;
            string sCol = edGoSutraCol.Text;
            string sLine = edGoSutraLine.Text;

            if (sCol == "1") { sCol = "a"; }
            else if (sCol == "2") { sCol = "b"; }
            else if (sCol == "3") { sCol = "c"; }
            else if (sCol == "4") { sCol = "d"; }
            else if (sCol == "5") { sCol = "e"; }
            else if (sCol == "6") { sCol = "f"; }
            else if (sCol == "7") { sCol = "g"; }
            else if (sCol == "8") { sCol = "h"; }
            else if (sCol == "9") { sCol = "i"; }

            CSeries csCBETA = Bookcase.CBETA;

            string sFile = csCBETA.CBGetFileNameBySutraNumJuan(sBook, "", sSutraNum, sJuan, sPage, sCol, sLine);
            ShowCBXML(sFile);
        }
        
        // 由冊頁欄行呈現經文
        private void btGoBook_Click(object sender, EventArgs e)
        {
            string sBook = cbGoBookBookId.Text;

            int iPos = sBook.IndexOf(" ");
            sBook = sBook.Remove(iPos);

            string sVol = edGoBookVol.Text;
            string sPage = edGoBookPage.Text;
            string sCol = edGoBookCol.Text;
            string sLine = edGoBookLine.Text;

            if (sCol == "1") { sCol = "a"; }
            else if (sCol == "2") { sCol = "b"; }
            else if (sCol == "3") { sCol = "c"; }
            else if (sCol == "4") { sCol = "d"; }
            else if (sCol == "5") { sCol = "e"; }
            else if (sCol == "6") { sCol = "f"; }
            else if (sCol == "7") { sCol = "g"; }
            else if (sCol == "8") { sCol = "h"; }
            else if (sCol == "9") { sCol = "i"; }

            CSeries csCBETA = Bookcase.CBETA;

            string sFile = csCBETA.CBGetFileNameByVolPageColLine(sBook, sVol, sPage, sCol, sLine);
            ShowCBXML(sFile);
        }

        private void btGoByKeyword_Click(object sender, EventArgs e)
        {
            // 判斷各種直接前往指定經文的方法
            // 1. 行首 T01n0001_p0001a01
            // 2. 引用複製 T01,no.1,p.1,b5
            // 3. 特定的代碼, 例如 : SN1.1

            MatchCollection reMatch;
            GroupCollection reGroup;

            string sKey = edGoByKeyword.Text;
            // T01n0001_p0001a01
            string sPatten = @"([A-Z]+)(\d+)n.{5}p(.{4})(.)(\d\d)";

            reMatch = Regex.Matches(sKey, sPatten);
            if (reMatch.Count == 0) {
                // (CBETA, T01, no. 1, p. 23c20-21)  , 新版
                // (CBETA, T01, no. 1, p. 23, c20-21) , 舊版
                sPatten = @"([A-Z]+)(\d+)\s*,\s*no\.\s*.+?,\s*pp?\.\s*(\S+?)(?:\s*,\s*)?([a-z])(\d+)";
                reMatch = Regex.Matches(sKey, sPatten);
            }

            if (reMatch.Count > 0) {
                reGroup = reMatch[0].Groups;

                string sBook = reGroup[1].Value;
                string sVol = reGroup[2].Value;
                string sPage = reGroup[3].Value;
                string sField = reGroup[4].Value;
                string sLine = reGroup[5].Value;

                CSeries csCBETA = Bookcase.CBETA;

                string sFile = csCBETA.CBGetFileNameByVolPageColLine(sBook, sVol, sPage, sField, sLine);
                ShowCBXML(sFile);
            }
        }

        private void btTextSearch_Click(object sender, EventArgs e)
        {
            SearchSentence = edTextSearch.Text;

            // 去除頭尾的萬用字元
            SearchSentence = SearchSentence.Trim('?');

            if (SearchSentence == "") {
                return;    // 沒輸入
            }

            //RememberWord(cbSearchWord);		// 將查詢的字存起來
            //UpdateSearchHistory = true;

            //SearchSentenceOrig = cbSearchWord->Text;        // 最原始的檢索句字, 可能包含 unicode


            // 改變滑鼠
            Cursor csOldCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            DateTime t1 = DateTime.Now;
            bool bHasRange = false;     // 有範圍就要設定
            if (cbSearchRange.Checked || cbSearchThisSutra.Checked) {
                bHasRange = true;
            }

            // 選擇全文檢索引擎, 若某一方為 0 , 則選另一方 (全 0 就不管了)
            SearchEngine = Bookcase.CBETA.getSearchEngine(Setting.CollationType);
            if(SearchEngine == null) {
                MessageBox.Show("沒有可用的全文檢索引擎");
                return;
            }

            CCatalog Catalog = Bookcase.CBETA.Catalog;
            CSpine Spine = Bookcase.CBETA.Spine;
            bool bFindOK = SearchEngine.Find(SearchSentence, bHasRange);      // 在找囉.........................................
            DateTime t2 = DateTime.Now;

            int iFoundCount = SearchEngine.FileFound.Total;

            // 秀出找到幾個的訊息

            string timeDiff = string.Format("{0:#0.###}",(t2 - t1).TotalSeconds);

            lbSearchMsg.Text = $"找到 {iFoundCount} 筆，共花時間：{timeDiff} 秒";

            int iTotalSearchFileNum = 0;
            bool bShowAll = false;
            int iMaxSearchNum = 0;

            if (bFindOK) {
                SearchWordList.Clear();
                for (int i = 0; i < SearchEngine.SearchWordList.Count; i++)
                    SearchWordList.Add(SearchEngine.SearchWordList[i]);  // 存起查詢的詞

                // 先檢查有沒有超過限制

                for (int i = 0; i < SearchEngine.BuildFileList.FileCount; i++) {
                    if (SearchEngine.FileFound.Ints[i] > 0) {
                        iTotalSearchFileNum++;
                    }
                }

                // 將結果放入 list 列表中
            }

            sgTextSearch.SuspendLayout();
            int iGridIndex = 0;
            sgTextSearch.Rows.Clear();
            sgTextSearch.RowCount = 10;

            for (int i = 0; i < SearchEngine.BuildFileList.FileCount; i++) {
                // 找到了
                if (SearchEngine.FileFound.Ints[i] > 0) {
                    string sSutraNum = SearchEngine.BuildFileList.SutraNum[i];        // 取得經號
                    string sBook = SearchEngine.BuildFileList.Book[i];
                    int iVol = SearchEngine.BuildFileList.VolNum[i];

                    // 這裡可能找到 T220 第 600 卷, 卻傳回 T05 而不是 T07
                    // 有待改進處理 ????
                    if (i > 720) {
                        int j = 0;
                        j++;
                    }
                    int iCatalogIndex = Catalog.FindIndexBySutraNum(sBook, iVol, sSutraNum);   // 取得 TripitakaMenu 的編號

                    // 找到了

                    // 經名要移除 (第X卷)
                    string sSutraName = CCBSutraUtil.CutJuanAfterSutraName(Catalog.SutraName[iCatalogIndex]);

                    sgTextSearch[0,iGridIndex].Value = SearchEngine.FileFound.Ints[i];
                    sgTextSearch[1, iGridIndex].Value = Catalog.ID[iCatalogIndex];
                    sgTextSearch[2, iGridIndex].Value = Spine.VolNum[i];
                    sgTextSearch[3, iGridIndex].Value = Catalog.SutraNum[iCatalogIndex];
                    sgTextSearch[4, iGridIndex].Value = sSutraName;
                    sgTextSearch[5, iGridIndex].Value = SearchEngine.BuildFileList.JuanNum[i];
                    sgTextSearch[6, iGridIndex].Value = Catalog.Part[iCatalogIndex];
                    sgTextSearch[7, iGridIndex].Value = Catalog.Byline[iCatalogIndex];
                    sgTextSearch[8, iGridIndex].Value = i;
                    iGridIndex++;

                    if (iGridIndex >= sgTextSearch.RowCount - 1)
                        sgTextSearch.RowCount += 10;
                }
            }

            sgTextSearch.RowCount = iGridIndex;
            sgTextSearch.ResumeLayout(false);

            // 還原滑鼠
            Cursor = csOldCursor;

            if (bFindOK) {
                if (sgTextSearch.RowCount == 0) {
                    MessageBox.Show("找不到任何資料");
                }
            } else {
                MessageBox.Show("查詢字串語法有問題，請再檢查看看。");
            }
        }

        // 秀出全文檢索的布林運算符號
        private void btBoolean_Click(object sender, EventArgs e)
        {
            cmBoolean.Show(btBoolean, 0, btBoolean.Height + 2);
        }

        private void miNear_Click(object sender, EventArgs e)
        {
            edTextSearch.Text = edTextSearch.Text + "+";
        }

        private void miBefore_Click(object sender, EventArgs e)
        {
            edTextSearch.Text = edTextSearch.Text + "*";
        }

        private void miAnd_Click(object sender, EventArgs e)
        {
            edTextSearch.Text = edTextSearch.Text + "&";
        }

        private void miOr_Click(object sender, EventArgs e)
        {
            edTextSearch.Text = edTextSearch.Text + ",";
        }

        private void miExclude_Click(object sender, EventArgs e)
        {
            edTextSearch.Text = edTextSearch.Text + "-";
        }

        private void miAny_Click(object sender, EventArgs e)
        {
            edTextSearch.Text = edTextSearch.Text + "?";
        }

        private void sgTextSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) {
                return;
            }
            if (sgTextSearch[8, e.RowIndex].Value == null) {
                return;
            }
            int iIndex = Convert.ToInt32(sgTextSearch[8, e.RowIndex].Value);
            string sFile = Bookcase.CBETA.Spine.Files[iIndex];
            // 要塗色
            ShowCBXML(sFile, true, Bookcase.CBETA);
        }

        private void sgTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if(sgTextSearch.SelectedRows.Count > 0) {
                    int iRow = sgTextSearch.SelectedRows[0].Index;
                    int iIndex = Convert.ToInt32(sgTextSearch[8, iRow].Value);
                    string sFile = Bookcase.CBETA.Spine.Files[iIndex];
                    // 要塗色
                    ShowCBXML(sFile, true, Bookcase.CBETA);
                    e.Handled = true;
                }
            }
        }


        private void cbSearchThisSutra_CheckedChanged(object sender, EventArgs e)
        {
            cbSearchThisSutraChange();
        }


        private void tvNavTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            TreeNode tvItem = treeView.GetNodeAt(e.X, e.Y);
            if(tvItem == null) { return; }
            if(tvItem != treeView.SelectedNode) { return; }
            OpenTreeViewItem(tvItem);
        }

        private void tvNavTree_KeyDown(object sender, KeyEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            if (e.KeyCode == Keys.Enter) {
                TreeNode tvItem = treeView.SelectedNode;
                if (tvItem != null) {
                    SNavItem item = (SNavItem)tvItem.Tag;
                    string sURL = item.URL;

                    // 不能用有沒有 URL 來判斷是不是目錄，有些目錄也是有 URL，在書目區即是如此

                    if (tvItem.Nodes.Count > 0) {
                        ToggleTreeViewItem(tvItem);
                    }
                    if (sURL != "") {
                        // 開啟經文
                        OpenTreeViewItem(tvItem);
                    }
                }
            }
        }

        private void edFindSutraVolFrom_Enter(object sender, EventArgs e)
        {
            AcceptButton = btFindSutra;
        }

        private void edGoSutraSutraNum_Enter(object sender, EventArgs e)
        {
            AcceptButton = btGoSutra;
        }

        private void edFindSutraVolFrom_Leave(object sender, EventArgs e)
        {
            AcceptButton = null;
        }

        private void edGoBookVol_Enter(object sender, EventArgs e)
        {
            AcceptButton = btGoBook;
        }

        private void edGoByKeyword_Enter(object sender, EventArgs e)
        {
            AcceptButton = btGoByKeyword;
        }

        private void edTextSearch_Enter(object sender, EventArgs e)
        {
            AcceptButton = btTextSearch;
        }

        private void btMainFuncWide_Click(object sender, EventArgs e)
        {
            pnMainFunc.Width = 600;
        }

        private void btMainFuncNarrow_Click(object sender, EventArgs e)
        {
            pnMainFunc.Width = 380;
        }

        private void edGoBookVol_TextChanged(object sender, EventArgs e)
        {

        }

        private void edGoSutraLine_TextChanged(object sender, EventArgs e)
        {

        }

        private void edGoSutraPage_TextChanged(object sender, EventArgs e)
        {

        }

        private void edGoSutraSutraNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void edGoSutraCol_TextChanged(object sender, EventArgs e)
        {

        }

        private void edGoSutraJuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void edGoBookCol_TextChanged(object sender, EventArgs e)
        {

        }

        private void edGoBookLine_TextChanged(object sender, EventArgs e)
        {

        }

        private void edGoBookPage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
