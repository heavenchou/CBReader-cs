using Monster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
        CSetting Setting; // 設定檔

        int SelectedBook = -1;   // 目前選中的書, -1 表示還沒選

        CBookcase Bookcase; // 書櫃
        //CNavTree* NavTree; // 導覽文件 (暫時的, 日後會放在 Serial 物件中 ???)
        //CNavTree* MuluTree; // 單經導覽文件 (暫時的, 日後會放在 Serial 物件中 ???)

        CMonster SearchEngine = null;   // 全文檢索引擎

        List<string> SearchWordList = new List<string>();	// 存放每一個檢索的詞, 日後塗色會用到
        string SearchSentence = "";         // 搜尋字串

        int SpineID;    // 目前開啟的檔案, 用來處理上一卷和下一卷用的

        int NavWidth;   // 目錄區的寬度
        int MuluWidth  = 200;  // 書目區的寬度

        public MainForm()
        {
            InitializeComponent();

            Setting = new CSetting("");
            InitializeForms();  // 初始其它的 Form

            // 判斷是不是西蓮淨苑 SLReader 專用
            // CheckSeeland(); ????

            // 設定目錄初值
            CGlobalVal.initialPath();
            // 將 IE 設定到 IE 11 (如果沒 IE 11 的如何?)
            SetPermissions(11001);
            
            // 刪去舊版
            string sOld = CGlobalVal.MyHomePath + ".tmp";
            if (File.Exists(sOld)) {
                File.Delete(sOld);
            }

            // 取得設定檔並讀取所有設定
            Setting = new CSetting(CGlobalVal.SettingFile);

            MainFunc.SelectedIndex = 0;
            pnMulu.Width = 0;  // 書目先縮到最小

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
	        if(!Directory.Exists(sBookcasePath))  {
		        if(Setting.BookcaseFullPath != "") {
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
	        if(iID == SelectedBook) return;	// 同一本, 不要重開
	        if(iID == -1) return;   	// 沒選書

	        SelectedBook = iID;

	        // 載入叢書的起始目錄
	        //if(NavTree) delete NavTree;
	        CSeries s = Bookcase.Books[iID];
            //NavTree = new CNavTree(s->Dir + s->NavFile);
            //NavTree->SaveToTreeView(tvNavTree, NavTreeItemClick);
        }

        // 開啟CBETA書櫃
        void OpenCBETABook()
        {
	        for(int i=0; i<Bookcase.Books.Count; i++) {
		        if(Bookcase.Books[i] == Bookcase.CBETA) {
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
            if(sIEVer != iIE.ToString()) {
                Microsoft.Win32.Registry.SetValue(sFeatureBrowserEmulation, sKey, iIE);
            }
        }

        // 載入 XML 並處理成網頁
        void ShowCBXML(string sFile, bool bShowHighlight = false, CSeries sSeries = null)
        {
            if (sSeries == null) {
                sSeries = Bookcase.CBETA;
            }
            string sJSFile = sSeries.Dir + sSeries.JSFile;
            CCBXML CBXML = new CCBXML(sFile, "", Setting, sJSFile, bShowHighlight, sSeries);
            CBXML.SaveToHTML(@"d:\temp\cbrtmp.htm");
            webBrowser.Navigate(@"file:///d:\temp\cbrtmp.htm");
        }

        // =====================================================
        // 元件函式
        // =====================================================

        private void cbSearchRange_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSearchRange.Checked) {
                // 設定檢索範圍
                searchrangeForm.ShowDialog();
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
            updateForm.ShowDialog();
        }

        private void btGoByKeyword_Click(object sender, EventArgs e)
        {
            string sFile = @"C:\CBETA\CBReader2X\Bookcase\CBETA\xml\T\T01\T01n0001_001.xml";
            // sFile = @"C:\CBETA\CBReader2X\Bookcase\CBETA\xml\J\J20\J20nB098_001.xml";
            //string sFile = @"CB01n0001_001.xml";
            ShowCBXML(sFile);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitialData();

            // 檢查更新
            string sToday = "";//???? GetTodayString();
            if (sToday != Setting.LastUpdateChk) { 
                //???? CheckUpdate();   // 檢查更新
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetPermissions(7000); // 設定為 IE 7
        }
    }
}
