﻿
namespace CBReader
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btOption = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTheme = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miOption = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateHtml = new System.Windows.Forms.ToolStripMenuItem();
            this.miLocalUpdateURL = new System.Windows.Forms.ToolStripMenuItem();
            this.miGetLanguageIni = new System.Windows.Forms.ToolStripMenuItem();
            this.btNextJuan = new System.Windows.Forms.Button();
            this.btPrevJuan = new System.Windows.Forms.Button();
            this.btMuluWidthSwitch = new System.Windows.Forms.Button();
            this.btNavWidthSwitch = new System.Windows.Forms.Button();
            this.pnMainFunc = new System.Windows.Forms.Panel();
            this.MainFunc = new System.Windows.Forms.TabControl();
            this.tpCatalog = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tvNavTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.btOpenNav = new System.Windows.Forms.Button();
            this.tpBibl = new System.Windows.Forms.TabPage();
            this.panel12 = new System.Windows.Forms.Panel();
            this.sgFindSutra = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btMainFuncNarrow = new System.Windows.Forms.Button();
            this.btMainFuncWide = new System.Windows.Forms.Button();
            this.btFindSutra = new System.Windows.Forms.Button();
            this.lbFindSutraCount = new System.Windows.Forms.Label();
            this.lbFindSutraSutraTo = new System.Windows.Forms.Label();
            this.lbFindSutraVolTo = new System.Windows.Forms.Label();
            this.lbFindSutraByline = new System.Windows.Forms.Label();
            this.lbFindSutraSutraName = new System.Windows.Forms.Label();
            this.lbFindSutraSutraFrom = new System.Windows.Forms.Label();
            this.lbFindSutraVolFrom = new System.Windows.Forms.Label();
            this.lbFindSutraBookId = new System.Windows.Forms.Label();
            this.edFindSutraByline = new System.Windows.Forms.TextBox();
            this.edFindSutraSutraName = new System.Windows.Forms.TextBox();
            this.edFindSutraSutraTo = new System.Windows.Forms.TextBox();
            this.edFindSutraSutraFrom = new System.Windows.Forms.TextBox();
            this.edFindSutraVolTo = new System.Windows.Forms.TextBox();
            this.edFindSutraVolFrom = new System.Windows.Forms.TextBox();
            this.cbFindSutraBookId = new System.Windows.Forms.ComboBox();
            this.tpGoto = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbStar2 = new System.Windows.Forms.Label();
            this.lbGoSutraSutraNum = new System.Windows.Forms.Label();
            this.lbGoBookVol = new System.Windows.Forms.Label();
            this.lbStar1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btGoByKeyword = new System.Windows.Forms.Button();
            this.lbGoByKeywordEx2 = new System.Windows.Forms.Label();
            this.lbGoByKeywordEx1 = new System.Windows.Forms.Label();
            this.lbGoByKeyword = new System.Windows.Forms.Label();
            this.lbGoBookLine = new System.Windows.Forms.Label();
            this.lbGoBookCol = new System.Windows.Forms.Label();
            this.lbGoBookPage = new System.Windows.Forms.Label();
            this.lbGoBookBookId = new System.Windows.Forms.Label();
            this.lbGoBook = new System.Windows.Forms.Label();
            this.lbGoSutraCol = new System.Windows.Forms.Label();
            this.lbGoSutraJuan = new System.Windows.Forms.Label();
            this.lbGoSutraLine = new System.Windows.Forms.Label();
            this.lbGoSutraPage = new System.Windows.Forms.Label();
            this.lbGoSutraBookId = new System.Windows.Forms.Label();
            this.lbGoSutra = new System.Windows.Forms.Label();
            this.btGoSutra = new System.Windows.Forms.Button();
            this.btGoBook = new System.Windows.Forms.Button();
            this.edGoByKeyword = new System.Windows.Forms.TextBox();
            this.edGoBookLine = new System.Windows.Forms.TextBox();
            this.edGoBookCol = new System.Windows.Forms.TextBox();
            this.edGoBookPage = new System.Windows.Forms.TextBox();
            this.edGoBookVol = new System.Windows.Forms.TextBox();
            this.edGoSutraLine = new System.Windows.Forms.TextBox();
            this.edGoSutraCol = new System.Windows.Forms.TextBox();
            this.edGoSutraPage = new System.Windows.Forms.TextBox();
            this.edGoSutraJuan = new System.Windows.Forms.TextBox();
            this.edGoSutraSutraNum = new System.Windows.Forms.TextBox();
            this.cbGoBookBookId = new System.Windows.Forms.ComboBox();
            this.cbGoSutraBookId = new System.Windows.Forms.ComboBox();
            this.tpSearch = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.sgTextSearch = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel10 = new System.Windows.Forms.Panel();
            this.edUnicode = new System.Windows.Forms.TextBox();
            this.btMainFuncNarrow2 = new System.Windows.Forms.Button();
            this.btMainFuncWide2 = new System.Windows.Forms.Button();
            this.lbSearchMsg = new System.Windows.Forms.Label();
            this.btBoolean = new System.Windows.Forms.Button();
            this.cmBoolean = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miNear = new System.Windows.Forms.ToolStripMenuItem();
            this.miBefore = new System.Windows.Forms.ToolStripMenuItem();
            this.miAnd = new System.Windows.Forms.ToolStripMenuItem();
            this.miOr = new System.Windows.Forms.ToolStripMenuItem();
            this.miExclude = new System.Windows.Forms.ToolStripMenuItem();
            this.miAny = new System.Windows.Forms.ToolStripMenuItem();
            this.btTextSearch = new System.Windows.Forms.Button();
            this.cbSearchThisSutra = new System.Windows.Forms.CheckBox();
            this.cbSearchRange = new System.Windows.Forms.CheckBox();
            this.edTextSearch = new System.Windows.Forms.TextBox();
            this.lbSearchString = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnMulu = new System.Windows.Forms.Panel();
            this.tvMuluTree = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbToc = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpWeb = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnMainFunc.SuspendLayout();
            this.MainFunc.SuspendLayout();
            this.tpCatalog.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tpBibl.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sgFindSutra)).BeginInit();
            this.panel8.SuspendLayout();
            this.tpGoto.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tpSearch.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sgTextSearch)).BeginInit();
            this.panel10.SuspendLayout();
            this.cmBoolean.SuspendLayout();
            this.pnMulu.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpWeb.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOption
            // 
            this.btOption.AutoSize = true;
            this.btOption.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btOption.Location = new System.Drawing.Point(17, 30);
            this.btOption.Name = "btOption";
            this.btOption.Size = new System.Drawing.Size(88, 40);
            this.btOption.TabIndex = 0;
            this.btOption.Text = "⚙ 設定";
            this.toolTip1.SetToolTip(this.btOption, "開啟設定畫面");
            this.btOption.UseVisualStyleBackColor = true;
            this.btOption.Click += new System.EventHandler(this.btOption_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btTheme);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.btNextJuan);
            this.panel1.Controls.Add(this.btPrevJuan);
            this.panel1.Controls.Add(this.btMuluWidthSwitch);
            this.panel1.Controls.Add(this.btNavWidthSwitch);
            this.panel1.Controls.Add(this.btOption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 76);
            this.panel1.TabIndex = 1;
            // 
            // btTheme
            // 
            this.btTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTheme.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btTheme.Location = new System.Drawing.Point(811, 28);
            this.btTheme.Name = "btTheme";
            this.btTheme.Size = new System.Drawing.Size(47, 40);
            this.btTheme.TabIndex = 6;
            this.btTheme.Text = "💡";
            this.btTheme.Click += new System.EventHandler(this.btTheme_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOption,
            this.miUpdate,
            this.miLanguage,
            this.miAbout,
            this.miAdmin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 27);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miOption
            // 
            this.miOption.Name = "miOption";
            this.miOption.Size = new System.Drawing.Size(53, 23);
            this.miOption.Text = "設定";
            this.miOption.Click += new System.EventHandler(this.miOption_Click);
            // 
            // miUpdate
            // 
            this.miUpdate.Name = "miUpdate";
            this.miUpdate.Size = new System.Drawing.Size(83, 23);
            this.miUpdate.Text = "更新檢查";
            this.miUpdate.Click += new System.EventHandler(this.miUpdate_Click);
            // 
            // miLanguage
            // 
            this.miLanguage.Name = "miLanguage";
            this.miLanguage.Size = new System.Drawing.Size(133, 23);
            this.miLanguage.Text = "語言(Language)";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(53, 23);
            this.miAbout.Text = "關於";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miAdmin
            // 
            this.miAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateHtml,
            this.miLocalUpdateURL,
            this.miGetLanguageIni});
            this.miAdmin.Name = "miAdmin";
            this.miAdmin.Size = new System.Drawing.Size(105, 23);
            this.miAdmin.Text = "Heaven專用";
            this.miAdmin.Visible = false;
            // 
            // miCreateHtml
            // 
            this.miCreateHtml.Name = "miCreateHtml";
            this.miCreateHtml.Size = new System.Drawing.Size(222, 26);
            this.miCreateHtml.Text = "批量產生HTML";
            this.miCreateHtml.Click += new System.EventHandler(this.miCreateHtml_Click);
            // 
            // miLocalUpdateURL
            // 
            this.miLocalUpdateURL.Name = "miLocalUpdateURL";
            this.miLocalUpdateURL.Size = new System.Drawing.Size(222, 26);
            this.miLocalUpdateURL.Text = "使用 local 更新網址";
            this.miLocalUpdateURL.Click += new System.EventHandler(this.miLocalUpdateURL_Click);
            // 
            // miGetLanguageIni
            // 
            this.miGetLanguageIni.Name = "miGetLanguageIni";
            this.miGetLanguageIni.Size = new System.Drawing.Size(222, 26);
            this.miGetLanguageIni.Text = "産生基本語系檔";
            this.miGetLanguageIni.Click += new System.EventHandler(this.miGetLanguageIni_Click);
            // 
            // btNextJuan
            // 
            this.btNextJuan.AutoSize = true;
            this.btNextJuan.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btNextJuan.Location = new System.Drawing.Point(524, 30);
            this.btNextJuan.Name = "btNextJuan";
            this.btNextJuan.Size = new System.Drawing.Size(155, 40);
            this.btNextJuan.TabIndex = 4;
            this.btNextJuan.Text = "下一卷/篇章 ▼";
            this.toolTip1.SetToolTip(this.btNextJuan, "下一卷或下一篇、章");
            this.btNextJuan.UseVisualStyleBackColor = true;
            this.btNextJuan.Click += new System.EventHandler(this.btNextJuan_Click);
            // 
            // btPrevJuan
            // 
            this.btPrevJuan.AutoSize = true;
            this.btPrevJuan.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btPrevJuan.Location = new System.Drawing.Point(363, 30);
            this.btPrevJuan.Name = "btPrevJuan";
            this.btPrevJuan.Size = new System.Drawing.Size(155, 40);
            this.btPrevJuan.TabIndex = 3;
            this.btPrevJuan.Text = "上一卷/篇章 ▲";
            this.toolTip1.SetToolTip(this.btPrevJuan, "上一卷或上一篇、章");
            this.btPrevJuan.UseVisualStyleBackColor = true;
            this.btPrevJuan.Click += new System.EventHandler(this.btPrevJuan_Click);
            // 
            // btMuluWidthSwitch
            // 
            this.btMuluWidthSwitch.AutoSize = true;
            this.btMuluWidthSwitch.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btMuluWidthSwitch.Location = new System.Drawing.Point(217, 30);
            this.btMuluWidthSwitch.Name = "btMuluWidthSwitch";
            this.btMuluWidthSwitch.Size = new System.Drawing.Size(80, 40);
            this.btMuluWidthSwitch.TabIndex = 2;
            this.btMuluWidthSwitch.Text = "目次 ►";
            this.toolTip1.SetToolTip(this.btMuluWidthSwitch, "展開或收起目次");
            this.btMuluWidthSwitch.UseVisualStyleBackColor = true;
            this.btMuluWidthSwitch.Click += new System.EventHandler(this.btMuluWidthSwitch_Click);
            // 
            // btNavWidthSwitch
            // 
            this.btNavWidthSwitch.AutoSize = true;
            this.btNavWidthSwitch.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btNavWidthSwitch.Location = new System.Drawing.Point(111, 30);
            this.btNavWidthSwitch.Name = "btNavWidthSwitch";
            this.btNavWidthSwitch.Size = new System.Drawing.Size(100, 40);
            this.btNavWidthSwitch.TabIndex = 1;
            this.btNavWidthSwitch.Text = "◄ 主功能";
            this.toolTip1.SetToolTip(this.btNavWidthSwitch, "展開或收起主功能表");
            this.btNavWidthSwitch.UseVisualStyleBackColor = true;
            this.btNavWidthSwitch.Click += new System.EventHandler(this.btNavWidthSwitch_Click);
            // 
            // pnMainFunc
            // 
            this.pnMainFunc.Controls.Add(this.MainFunc);
            this.pnMainFunc.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMainFunc.Location = new System.Drawing.Point(0, 76);
            this.pnMainFunc.Name = "pnMainFunc";
            this.pnMainFunc.Size = new System.Drawing.Size(364, 601);
            this.pnMainFunc.TabIndex = 2;
            // 
            // MainFunc
            // 
            this.MainFunc.Controls.Add(this.tpCatalog);
            this.MainFunc.Controls.Add(this.tpBibl);
            this.MainFunc.Controls.Add(this.tpGoto);
            this.MainFunc.Controls.Add(this.tpSearch);
            this.MainFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFunc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainFunc.ItemSize = new System.Drawing.Size(52, 26);
            this.MainFunc.Location = new System.Drawing.Point(0, 0);
            this.MainFunc.Name = "MainFunc";
            this.MainFunc.SelectedIndex = 0;
            this.MainFunc.Size = new System.Drawing.Size(364, 601);
            this.MainFunc.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.MainFunc.TabIndex = 0;
            this.MainFunc.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MainFunc_DrawItem);
            this.MainFunc.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            this.MainFunc.Resize += new System.EventHandler(this.MainFunc_Resize);
            // 
            // tpCatalog
            // 
            this.tpCatalog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tpCatalog.Controls.Add(this.panel7);
            this.tpCatalog.Controls.Add(this.panel6);
            this.tpCatalog.Location = new System.Drawing.Point(4, 30);
            this.tpCatalog.Name = "tpCatalog";
            this.tpCatalog.Padding = new System.Windows.Forms.Padding(3);
            this.tpCatalog.Size = new System.Drawing.Size(356, 567);
            this.tpCatalog.TabIndex = 0;
            this.tpCatalog.Text = "目錄";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tvNavTree);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 53);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(350, 511);
            this.panel7.TabIndex = 1;
            // 
            // tvNavTree
            // 
            this.tvNavTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNavTree.FullRowSelect = true;
            this.tvNavTree.HideSelection = false;
            this.tvNavTree.ImageIndex = 0;
            this.tvNavTree.ImageList = this.imageList1;
            this.tvNavTree.Location = new System.Drawing.Point(0, 0);
            this.tvNavTree.Name = "tvNavTree";
            this.tvNavTree.SelectedImageKey = "openbook.ico";
            this.tvNavTree.ShowNodeToolTips = true;
            this.tvNavTree.Size = new System.Drawing.Size(350, 511);
            this.tvNavTree.TabIndex = 1;
            this.tvNavTree.Tag = "han";
            this.tvNavTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvNavTree_KeyDown);
            this.tvNavTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvNavTree_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "closebook.ico");
            this.imageList1.Images.SetKeyName(1, "openbook.ico");
            this.imageList1.Images.SetKeyName(2, "page.ico");
            this.imageList1.Images.SetKeyName(3, "page_green.ico");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel6.Controls.Add(this.btOpenNav);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(350, 50);
            this.panel6.TabIndex = 0;
            // 
            // btOpenNav
            // 
            this.btOpenNav.AutoSize = true;
            this.btOpenNav.Location = new System.Drawing.Point(10, 3);
            this.btOpenNav.Name = "btOpenNav";
            this.btOpenNav.Size = new System.Drawing.Size(134, 41);
            this.btOpenNav.TabIndex = 0;
            this.btOpenNav.Text = "🗃 選擇目錄";
            this.toolTip1.SetToolTip(this.btOpenNav, "顯示主目錄以開啟指定目錄");
            this.btOpenNav.UseVisualStyleBackColor = true;
            this.btOpenNav.Click += new System.EventHandler(this.btOpenNav_Click);
            // 
            // tpBibl
            // 
            this.tpBibl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tpBibl.Controls.Add(this.panel12);
            this.tpBibl.Controls.Add(this.splitter3);
            this.tpBibl.Controls.Add(this.panel8);
            this.tpBibl.Location = new System.Drawing.Point(4, 30);
            this.tpBibl.Name = "tpBibl";
            this.tpBibl.Padding = new System.Windows.Forms.Padding(3);
            this.tpBibl.Size = new System.Drawing.Size(356, 567);
            this.tpBibl.TabIndex = 1;
            this.tpBibl.Text = "書目";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.sgFindSutra);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(3, 252);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(350, 312);
            this.panel12.TabIndex = 3;
            // 
            // sgFindSutra
            // 
            this.sgFindSutra.AllowUserToAddRows = false;
            this.sgFindSutra.AllowUserToDeleteRows = false;
            this.sgFindSutra.ColumnHeadersHeight = 29;
            this.sgFindSutra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column5,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.sgFindSutra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgFindSutra.GridColor = System.Drawing.SystemColors.ControlLight;
            this.sgFindSutra.Location = new System.Drawing.Point(0, 0);
            this.sgFindSutra.MultiSelect = false;
            this.sgFindSutra.Name = "sgFindSutra";
            this.sgFindSutra.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sgFindSutra.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sgFindSutra.RowHeadersVisible = false;
            this.sgFindSutra.RowHeadersWidth = 44;
            this.sgFindSutra.RowTemplate.Height = 27;
            this.sgFindSutra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sgFindSutra.Size = new System.Drawing.Size(350, 312);
            this.sgFindSutra.TabIndex = 8;
            this.sgFindSutra.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sgFindSutra_CellDoubleClick);
            this.sgFindSutra.Paint += new System.Windows.Forms.PaintEventHandler(this.sgFindSutra_Paint);
            this.sgFindSutra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sgFindSutra_KeyDown);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "佛典";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "冊號";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "編號";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "佛典題名";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "卷/篇章";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 40;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "部";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 70;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "朝代/作譯者";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 150;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "id";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            this.Column13.Width = 125;
            // 
            // splitter3
            // 
            this.splitter3.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(3, 249);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(350, 3);
            this.splitter3.TabIndex = 2;
            this.splitter3.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel8.Controls.Add(this.btMainFuncNarrow);
            this.panel8.Controls.Add(this.btMainFuncWide);
            this.panel8.Controls.Add(this.btFindSutra);
            this.panel8.Controls.Add(this.lbFindSutraCount);
            this.panel8.Controls.Add(this.lbFindSutraSutraTo);
            this.panel8.Controls.Add(this.lbFindSutraVolTo);
            this.panel8.Controls.Add(this.lbFindSutraByline);
            this.panel8.Controls.Add(this.lbFindSutraSutraName);
            this.panel8.Controls.Add(this.lbFindSutraSutraFrom);
            this.panel8.Controls.Add(this.lbFindSutraVolFrom);
            this.panel8.Controls.Add(this.lbFindSutraBookId);
            this.panel8.Controls.Add(this.edFindSutraByline);
            this.panel8.Controls.Add(this.edFindSutraSutraName);
            this.panel8.Controls.Add(this.edFindSutraSutraTo);
            this.panel8.Controls.Add(this.edFindSutraSutraFrom);
            this.panel8.Controls.Add(this.edFindSutraVolTo);
            this.panel8.Controls.Add(this.edFindSutraVolFrom);
            this.panel8.Controls.Add(this.cbFindSutraBookId);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(350, 246);
            this.panel8.TabIndex = 1;
            // 
            // btMainFuncNarrow
            // 
            this.btMainFuncNarrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMainFuncNarrow.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btMainFuncNarrow.Location = new System.Drawing.Point(284, 211);
            this.btMainFuncNarrow.Name = "btMainFuncNarrow";
            this.btMainFuncNarrow.Size = new System.Drawing.Size(28, 29);
            this.btMainFuncNarrow.TabIndex = 16;
            this.btMainFuncNarrow.TabStop = false;
            this.btMainFuncNarrow.Text = "◀";
            this.toolTip1.SetToolTip(this.btMainFuncNarrow, "縮小頁面");
            this.btMainFuncNarrow.UseVisualStyleBackColor = true;
            this.btMainFuncNarrow.Click += new System.EventHandler(this.btMainFuncNarrow_Click);
            // 
            // btMainFuncWide
            // 
            this.btMainFuncWide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMainFuncWide.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btMainFuncWide.Location = new System.Drawing.Point(318, 211);
            this.btMainFuncWide.Name = "btMainFuncWide";
            this.btMainFuncWide.Size = new System.Drawing.Size(28, 29);
            this.btMainFuncWide.TabIndex = 15;
            this.btMainFuncWide.TabStop = false;
            this.btMainFuncWide.Text = "▶";
            this.toolTip1.SetToolTip(this.btMainFuncWide, "展開頁面");
            this.btMainFuncWide.UseVisualStyleBackColor = true;
            this.btMainFuncWide.Click += new System.EventHandler(this.btMainFuncWide_Click);
            // 
            // btFindSutra
            // 
            this.btFindSutra.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btFindSutra.Location = new System.Drawing.Point(318, 12);
            this.btFindSutra.Name = "btFindSutra";
            this.btFindSutra.Size = new System.Drawing.Size(30, 33);
            this.btFindSutra.TabIndex = 7;
            this.btFindSutra.Text = "🔍";
            this.toolTip1.SetToolTip(this.btFindSutra, "搜尋書目");
            this.btFindSutra.UseVisualStyleBackColor = true;
            this.btFindSutra.Click += new System.EventHandler(this.btFindSutra_Click);
            // 
            // lbFindSutraCount
            // 
            this.lbFindSutraCount.AutoSize = true;
            this.lbFindSutraCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraCount.Location = new System.Drawing.Point(6, 215);
            this.lbFindSutraCount.Name = "lbFindSutraCount";
            this.lbFindSutraCount.Size = new System.Drawing.Size(94, 25);
            this.lbFindSutraCount.TabIndex = 14;
            this.lbFindSutraCount.Text = "找到 0 筆";
            // 
            // lbFindSutraSutraTo
            // 
            this.lbFindSutraSutraTo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraSutraTo.Location = new System.Drawing.Point(172, 94);
            this.lbFindSutraSutraTo.Name = "lbFindSutraSutraTo";
            this.lbFindSutraSutraTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbFindSutraSutraTo.Size = new System.Drawing.Size(52, 25);
            this.lbFindSutraSutraTo.TabIndex = 13;
            this.lbFindSutraSutraTo.Text = "到";
            this.lbFindSutraSutraTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFindSutraVolTo
            // 
            this.lbFindSutraVolTo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraVolTo.Location = new System.Drawing.Point(172, 54);
            this.lbFindSutraVolTo.Name = "lbFindSutraVolTo";
            this.lbFindSutraVolTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbFindSutraVolTo.Size = new System.Drawing.Size(52, 25);
            this.lbFindSutraVolTo.TabIndex = 12;
            this.lbFindSutraVolTo.Text = "到";
            this.lbFindSutraVolTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFindSutraByline
            // 
            this.lbFindSutraByline.AutoSize = true;
            this.lbFindSutraByline.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraByline.Location = new System.Drawing.Point(6, 174);
            this.lbFindSutraByline.Name = "lbFindSutraByline";
            this.lbFindSutraByline.Size = new System.Drawing.Size(120, 25);
            this.lbFindSutraByline.TabIndex = 11;
            this.lbFindSutraByline.Text = "朝代/作譯者";
            // 
            // lbFindSutraSutraName
            // 
            this.lbFindSutraSutraName.AutoSize = true;
            this.lbFindSutraSutraName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraSutraName.Location = new System.Drawing.Point(6, 134);
            this.lbFindSutraSutraName.Name = "lbFindSutraSutraName";
            this.lbFindSutraSutraName.Size = new System.Drawing.Size(52, 25);
            this.lbFindSutraSutraName.TabIndex = 10;
            this.lbFindSutraSutraName.Text = "題名";
            // 
            // lbFindSutraSutraFrom
            // 
            this.lbFindSutraSutraFrom.AutoSize = true;
            this.lbFindSutraSutraFrom.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraSutraFrom.Location = new System.Drawing.Point(6, 94);
            this.lbFindSutraSutraFrom.Name = "lbFindSutraSutraFrom";
            this.lbFindSutraSutraFrom.Size = new System.Drawing.Size(72, 25);
            this.lbFindSutraSutraFrom.TabIndex = 9;
            this.lbFindSutraSutraFrom.Text = "編號從";
            // 
            // lbFindSutraVolFrom
            // 
            this.lbFindSutraVolFrom.AutoSize = true;
            this.lbFindSutraVolFrom.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraVolFrom.Location = new System.Drawing.Point(6, 54);
            this.lbFindSutraVolFrom.Name = "lbFindSutraVolFrom";
            this.lbFindSutraVolFrom.Size = new System.Drawing.Size(72, 25);
            this.lbFindSutraVolFrom.TabIndex = 8;
            this.lbFindSutraVolFrom.Text = "冊號從";
            // 
            // lbFindSutraBookId
            // 
            this.lbFindSutraBookId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraBookId.Location = new System.Drawing.Point(5, 15);
            this.lbFindSutraBookId.Name = "lbFindSutraBookId";
            this.lbFindSutraBookId.Size = new System.Drawing.Size(73, 25);
            this.lbFindSutraBookId.TabIndex = 7;
            this.lbFindSutraBookId.Text = "佛典";
            // 
            // edFindSutraByline
            // 
            this.edFindSutraByline.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edFindSutraByline.Location = new System.Drawing.Point(132, 171);
            this.edFindSutraByline.Name = "edFindSutraByline";
            this.edFindSutraByline.Size = new System.Drawing.Size(180, 34);
            this.edFindSutraByline.TabIndex = 6;
            this.toolTip1.SetToolTip(this.edFindSutraByline, "輸入要搜尋的朝代及作譯者名稱");
            this.edFindSutraByline.Enter += new System.EventHandler(this.edFindSutraVolFrom_Enter);
            this.edFindSutraByline.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edFindSutraSutraName
            // 
            this.edFindSutraSutraName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edFindSutraSutraName.Location = new System.Drawing.Point(84, 131);
            this.edFindSutraSutraName.Name = "edFindSutraSutraName";
            this.edFindSutraSutraName.Size = new System.Drawing.Size(228, 34);
            this.edFindSutraSutraName.TabIndex = 5;
            this.toolTip1.SetToolTip(this.edFindSutraSutraName, "輸入要搜尋的經名或現代文獻標題");
            this.edFindSutraSutraName.Enter += new System.EventHandler(this.edFindSutraVolFrom_Enter);
            this.edFindSutraSutraName.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edFindSutraSutraTo
            // 
            this.edFindSutraSutraTo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edFindSutraSutraTo.Location = new System.Drawing.Point(230, 91);
            this.edFindSutraSutraTo.Name = "edFindSutraSutraTo";
            this.edFindSutraSutraTo.Size = new System.Drawing.Size(82, 34);
            this.edFindSutraSutraTo.TabIndex = 4;
            this.toolTip1.SetToolTip(this.edFindSutraSutraTo, "結束編號");
            this.edFindSutraSutraTo.Enter += new System.EventHandler(this.edFindSutraVolFrom_Enter);
            this.edFindSutraSutraTo.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edFindSutraSutraFrom
            // 
            this.edFindSutraSutraFrom.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edFindSutraSutraFrom.Location = new System.Drawing.Point(84, 91);
            this.edFindSutraSutraFrom.Name = "edFindSutraSutraFrom";
            this.edFindSutraSutraFrom.Size = new System.Drawing.Size(82, 34);
            this.edFindSutraSutraFrom.TabIndex = 3;
            this.toolTip1.SetToolTip(this.edFindSutraSutraFrom, "起始編號");
            this.edFindSutraSutraFrom.Enter += new System.EventHandler(this.edFindSutraVolFrom_Enter);
            this.edFindSutraSutraFrom.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edFindSutraVolTo
            // 
            this.edFindSutraVolTo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edFindSutraVolTo.Location = new System.Drawing.Point(230, 51);
            this.edFindSutraVolTo.Name = "edFindSutraVolTo";
            this.edFindSutraVolTo.Size = new System.Drawing.Size(82, 34);
            this.edFindSutraVolTo.TabIndex = 2;
            this.toolTip1.SetToolTip(this.edFindSutraVolTo, "結束冊號");
            this.edFindSutraVolTo.Enter += new System.EventHandler(this.edFindSutraVolFrom_Enter);
            this.edFindSutraVolTo.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edFindSutraVolFrom
            // 
            this.edFindSutraVolFrom.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edFindSutraVolFrom.Location = new System.Drawing.Point(84, 51);
            this.edFindSutraVolFrom.Name = "edFindSutraVolFrom";
            this.edFindSutraVolFrom.Size = new System.Drawing.Size(82, 34);
            this.edFindSutraVolFrom.TabIndex = 1;
            this.toolTip1.SetToolTip(this.edFindSutraVolFrom, "起始冊號");
            this.edFindSutraVolFrom.Enter += new System.EventHandler(this.edFindSutraVolFrom_Enter);
            this.edFindSutraVolFrom.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // cbFindSutraBookId
            // 
            this.cbFindSutraBookId.BackColor = System.Drawing.SystemColors.Window;
            this.cbFindSutraBookId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindSutraBookId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbFindSutraBookId.FormattingEnabled = true;
            this.cbFindSutraBookId.Items.AddRange(new object[] {
            "   全部",
            "X  卍新纂大日本續藏經",
            "T  大正新脩大藏經",
            "A  趙城金藏",
            "K  高麗大藏經",
            "S  宋藏遺珍",
            "F  房山石經",
            "C  中華大藏經",
            "D  國家圖書館善本佛典",
            "U  洪武南藏",
            "P  永樂北藏",
            "J  嘉興大藏經",
            "L  乾隆大藏經",
            "G  佛教大藏經",
            "M  卍正藏經",
            "N  漢譯南傳大藏經",
            "ZS 正史佛教資料類編",
            "I  北朝佛教石刻拓片百品",
            "ZW 藏外佛教文獻",
            "B  大藏經補編",
            "GA 中國佛寺史志彙刊",
            "GB 中國佛寺志叢刊",
            "Y  印順法師佛學著作集",
            "LC 呂澂佛學著作集",
            "TX 太虛大師全書"});
            this.cbFindSutraBookId.Location = new System.Drawing.Point(84, 12);
            this.cbFindSutraBookId.Name = "cbFindSutraBookId";
            this.cbFindSutraBookId.Size = new System.Drawing.Size(228, 33);
            this.cbFindSutraBookId.TabIndex = 0;
            this.cbFindSutraBookId.Tag = "han";
            this.toolTip1.SetToolTip(this.cbFindSutraBookId, "請選擇佛教典籍");
            this.cbFindSutraBookId.Enter += new System.EventHandler(this.edFindSutraVolFrom_Enter);
            this.cbFindSutraBookId.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // tpGoto
            // 
            this.tpGoto.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tpGoto.Controls.Add(this.panel9);
            this.tpGoto.Location = new System.Drawing.Point(4, 30);
            this.tpGoto.Name = "tpGoto";
            this.tpGoto.Padding = new System.Windows.Forms.Padding(3);
            this.tpGoto.Size = new System.Drawing.Size(356, 567);
            this.tpGoto.TabIndex = 2;
            this.tpGoto.Text = "前往";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel9.Controls.Add(this.lbStar2);
            this.panel9.Controls.Add(this.lbGoSutraSutraNum);
            this.panel9.Controls.Add(this.lbGoBookVol);
            this.panel9.Controls.Add(this.lbStar1);
            this.panel9.Controls.Add(this.panel3);
            this.panel9.Controls.Add(this.panel2);
            this.panel9.Controls.Add(this.btGoByKeyword);
            this.panel9.Controls.Add(this.lbGoByKeywordEx2);
            this.panel9.Controls.Add(this.lbGoByKeywordEx1);
            this.panel9.Controls.Add(this.lbGoByKeyword);
            this.panel9.Controls.Add(this.lbGoBookLine);
            this.panel9.Controls.Add(this.lbGoBookCol);
            this.panel9.Controls.Add(this.lbGoBookPage);
            this.panel9.Controls.Add(this.lbGoBookBookId);
            this.panel9.Controls.Add(this.lbGoBook);
            this.panel9.Controls.Add(this.lbGoSutraCol);
            this.panel9.Controls.Add(this.lbGoSutraJuan);
            this.panel9.Controls.Add(this.lbGoSutraLine);
            this.panel9.Controls.Add(this.lbGoSutraPage);
            this.panel9.Controls.Add(this.lbGoSutraBookId);
            this.panel9.Controls.Add(this.lbGoSutra);
            this.panel9.Controls.Add(this.btGoSutra);
            this.panel9.Controls.Add(this.btGoBook);
            this.panel9.Controls.Add(this.edGoByKeyword);
            this.panel9.Controls.Add(this.edGoBookLine);
            this.panel9.Controls.Add(this.edGoBookCol);
            this.panel9.Controls.Add(this.edGoBookPage);
            this.panel9.Controls.Add(this.edGoBookVol);
            this.panel9.Controls.Add(this.edGoSutraLine);
            this.panel9.Controls.Add(this.edGoSutraCol);
            this.panel9.Controls.Add(this.edGoSutraPage);
            this.panel9.Controls.Add(this.edGoSutraJuan);
            this.panel9.Controls.Add(this.edGoSutraSutraNum);
            this.panel9.Controls.Add(this.cbGoBookBookId);
            this.panel9.Controls.Add(this.cbGoSutraBookId);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel9.Size = new System.Drawing.Size(350, 561);
            this.panel9.TabIndex = 1;
            // 
            // lbStar2
            // 
            this.lbStar2.AutoSize = true;
            this.lbStar2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbStar2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbStar2.Location = new System.Drawing.Point(0, 279);
            this.lbStar2.Name = "lbStar2";
            this.lbStar2.Size = new System.Drawing.Size(21, 25);
            this.lbStar2.TabIndex = 33;
            this.lbStar2.Text = "*";
            this.toolTip1.SetToolTip(this.lbStar2, "* 為必填欄位");
            // 
            // lbGoSutraSutraNum
            // 
            this.lbGoSutraSutraNum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoSutraSutraNum.Location = new System.Drawing.Point(5, 277);
            this.lbGoSutraSutraNum.Name = "lbGoSutraSutraNum";
            this.lbGoSutraSutraNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoSutraSutraNum.Size = new System.Drawing.Size(79, 25);
            this.lbGoSutraSutraNum.TabIndex = 17;
            this.lbGoSutraSutraNum.Text = "編號";
            this.lbGoSutraSutraNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoBookVol
            // 
            this.lbGoBookVol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoBookVol.Location = new System.Drawing.Point(19, 78);
            this.lbGoBookVol.Name = "lbGoBookVol";
            this.lbGoBookVol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoBookVol.Size = new System.Drawing.Size(65, 25);
            this.lbGoBookVol.TabIndex = 24;
            this.lbGoBookVol.Text = "冊號";
            this.lbGoBookVol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbStar1
            // 
            this.lbStar1.AutoSize = true;
            this.lbStar1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbStar1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbStar1.Location = new System.Drawing.Point(0, 78);
            this.lbStar1.Name = "lbStar1";
            this.lbStar1.Size = new System.Drawing.Size(21, 25);
            this.lbStar1.TabIndex = 34;
            this.lbStar1.Text = "*";
            this.toolTip1.SetToolTip(this.lbStar1, "* 為必填欄位");
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel3.Location = new System.Drawing.Point(2, 393);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 10);
            this.panel3.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel2.Location = new System.Drawing.Point(2, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 10);
            this.panel2.TabIndex = 31;
            // 
            // btGoByKeyword
            // 
            this.btGoByKeyword.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btGoByKeyword.Location = new System.Drawing.Point(249, 438);
            this.btGoByKeyword.Name = "btGoByKeyword";
            this.btGoByKeyword.Size = new System.Drawing.Size(72, 34);
            this.btGoByKeyword.TabIndex = 14;
            this.btGoByKeyword.Text = "Go";
            this.toolTip1.SetToolTip(this.btGoByKeyword, "開啟資料");
            this.btGoByKeyword.UseVisualStyleBackColor = true;
            this.btGoByKeyword.Click += new System.EventHandler(this.btGoByKeyword_Click);
            // 
            // lbGoByKeywordEx2
            // 
            this.lbGoByKeywordEx2.AutoSize = true;
            this.lbGoByKeywordEx2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoByKeywordEx2.Location = new System.Drawing.Point(12, 511);
            this.lbGoByKeywordEx2.Name = "lbGoByKeywordEx2";
            this.lbGoByKeywordEx2.Size = new System.Drawing.Size(214, 25);
            this.lbGoByKeywordEx2.TabIndex = 30;
            this.lbGoByKeywordEx2.Text = "例2 : T01, no. 1, p.1a1";
            // 
            // lbGoByKeywordEx1
            // 
            this.lbGoByKeywordEx1.AutoSize = true;
            this.lbGoByKeywordEx1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoByKeywordEx1.Location = new System.Drawing.Point(12, 486);
            this.lbGoByKeywordEx1.Name = "lbGoByKeywordEx1";
            this.lbGoByKeywordEx1.Size = new System.Drawing.Size(259, 25);
            this.lbGoByKeywordEx1.TabIndex = 29;
            this.lbGoByKeywordEx1.Text = "例1 : T01n0001_p0001a01";
            // 
            // lbGoByKeyword
            // 
            this.lbGoByKeyword.AutoSize = true;
            this.lbGoByKeyword.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoByKeyword.Location = new System.Drawing.Point(12, 410);
            this.lbGoByKeyword.Name = "lbGoByKeyword";
            this.lbGoByKeyword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoByKeyword.Size = new System.Drawing.Size(132, 25);
            this.lbGoByKeyword.TabIndex = 28;
            this.lbGoByKeyword.Text = "前往指定行首";
            // 
            // lbGoBookLine
            // 
            this.lbGoBookLine.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoBookLine.Location = new System.Drawing.Point(164, 117);
            this.lbGoBookLine.Name = "lbGoBookLine";
            this.lbGoBookLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoBookLine.Size = new System.Drawing.Size(79, 25);
            this.lbGoBookLine.TabIndex = 27;
            this.lbGoBookLine.Text = "行號";
            this.lbGoBookLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoBookCol
            // 
            this.lbGoBookCol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoBookCol.Location = new System.Drawing.Point(10, 117);
            this.lbGoBookCol.Name = "lbGoBookCol";
            this.lbGoBookCol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoBookCol.Size = new System.Drawing.Size(74, 25);
            this.lbGoBookCol.TabIndex = 26;
            this.lbGoBookCol.Text = "欄號";
            this.lbGoBookCol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoBookPage
            // 
            this.lbGoBookPage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoBookPage.Location = new System.Drawing.Point(164, 76);
            this.lbGoBookPage.Name = "lbGoBookPage";
            this.lbGoBookPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoBookPage.Size = new System.Drawing.Size(79, 25);
            this.lbGoBookPage.TabIndex = 25;
            this.lbGoBookPage.Text = "頁碼";
            this.lbGoBookPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoBookBookId
            // 
            this.lbGoBookBookId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoBookBookId.Location = new System.Drawing.Point(12, 34);
            this.lbGoBookBookId.Name = "lbGoBookBookId";
            this.lbGoBookBookId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoBookBookId.Size = new System.Drawing.Size(72, 25);
            this.lbGoBookBookId.TabIndex = 23;
            this.lbGoBookBookId.Text = "佛典";
            this.lbGoBookBookId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoBook
            // 
            this.lbGoBook.AutoSize = true;
            this.lbGoBook.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoBook.Location = new System.Drawing.Point(14, 3);
            this.lbGoBook.Name = "lbGoBook";
            this.lbGoBook.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoBook.Size = new System.Drawing.Size(92, 25);
            this.lbGoBook.TabIndex = 22;
            this.lbGoBook.Text = "書本結構";
            // 
            // lbGoSutraCol
            // 
            this.lbGoSutraCol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoSutraCol.Location = new System.Drawing.Point(164, 317);
            this.lbGoSutraCol.Name = "lbGoSutraCol";
            this.lbGoSutraCol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoSutraCol.Size = new System.Drawing.Size(79, 25);
            this.lbGoSutraCol.TabIndex = 21;
            this.lbGoSutraCol.Text = "欄號";
            this.lbGoSutraCol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoSutraJuan
            // 
            this.lbGoSutraJuan.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoSutraJuan.Location = new System.Drawing.Point(164, 277);
            this.lbGoSutraJuan.Name = "lbGoSutraJuan";
            this.lbGoSutraJuan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoSutraJuan.Size = new System.Drawing.Size(79, 25);
            this.lbGoSutraJuan.TabIndex = 20;
            this.lbGoSutraJuan.Text = "卷/篇章";
            this.lbGoSutraJuan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoSutraLine
            // 
            this.lbGoSutraLine.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoSutraLine.Location = new System.Drawing.Point(5, 357);
            this.lbGoSutraLine.Name = "lbGoSutraLine";
            this.lbGoSutraLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoSutraLine.Size = new System.Drawing.Size(79, 25);
            this.lbGoSutraLine.TabIndex = 19;
            this.lbGoSutraLine.Text = "行號";
            this.lbGoSutraLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoSutraPage
            // 
            this.lbGoSutraPage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoSutraPage.Location = new System.Drawing.Point(10, 317);
            this.lbGoSutraPage.Name = "lbGoSutraPage";
            this.lbGoSutraPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoSutraPage.Size = new System.Drawing.Size(74, 25);
            this.lbGoSutraPage.TabIndex = 18;
            this.lbGoSutraPage.Text = "頁碼";
            this.lbGoSutraPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoSutraBookId
            // 
            this.lbGoSutraBookId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoSutraBookId.Location = new System.Drawing.Point(7, 238);
            this.lbGoSutraBookId.Name = "lbGoSutraBookId";
            this.lbGoSutraBookId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoSutraBookId.Size = new System.Drawing.Size(77, 25);
            this.lbGoSutraBookId.TabIndex = 16;
            this.lbGoSutraBookId.Text = "佛典";
            this.lbGoSutraBookId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbGoSutra
            // 
            this.lbGoSutra.AutoSize = true;
            this.lbGoSutra.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbGoSutra.Location = new System.Drawing.Point(14, 207);
            this.lbGoSutra.Name = "lbGoSutra";
            this.lbGoSutra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbGoSutra.Size = new System.Drawing.Size(92, 25);
            this.lbGoSutra.TabIndex = 15;
            this.lbGoSutra.Text = "經卷結構";
            // 
            // btGoSutra
            // 
            this.btGoSutra.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btGoSutra.Location = new System.Drawing.Point(249, 354);
            this.btGoSutra.Name = "btGoSutra";
            this.btGoSutra.Size = new System.Drawing.Size(72, 34);
            this.btGoSutra.TabIndex = 12;
            this.btGoSutra.Text = "Go";
            this.toolTip1.SetToolTip(this.btGoSutra, "開啟資料");
            this.btGoSutra.UseVisualStyleBackColor = true;
            this.btGoSutra.Click += new System.EventHandler(this.btGoSutra_Click);
            // 
            // btGoBook
            // 
            this.btGoBook.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btGoBook.Location = new System.Drawing.Point(249, 154);
            this.btGoBook.Name = "btGoBook";
            this.btGoBook.Size = new System.Drawing.Size(72, 34);
            this.btGoBook.TabIndex = 5;
            this.btGoBook.Text = "Go";
            this.toolTip1.SetToolTip(this.btGoBook, "開啟資料");
            this.btGoBook.UseVisualStyleBackColor = true;
            this.btGoBook.Click += new System.EventHandler(this.btGoBook_Click);
            // 
            // edGoByKeyword
            // 
            this.edGoByKeyword.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoByKeyword.Location = new System.Drawing.Point(17, 438);
            this.edGoByKeyword.Name = "edGoByKeyword";
            this.edGoByKeyword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoByKeyword.Size = new System.Drawing.Size(226, 34);
            this.edGoByKeyword.TabIndex = 13;
            this.toolTip1.SetToolTip(this.edGoByKeyword, "可輸入行首或引用複製格式");
            this.edGoByKeyword.Enter += new System.EventHandler(this.edGoByKeyword_Enter);
            this.edGoByKeyword.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoBookLine
            // 
            this.edGoBookLine.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoBookLine.Location = new System.Drawing.Point(249, 113);
            this.edGoBookLine.Name = "edGoBookLine";
            this.edGoBookLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoBookLine.Size = new System.Drawing.Size(72, 34);
            this.edGoBookLine.TabIndex = 4;
            this.toolTip1.SetToolTip(this.edGoBookLine, "一頁、一欄中的行號");
            this.edGoBookLine.TextChanged += new System.EventHandler(this.edGoBookLine_TextChanged);
            this.edGoBookLine.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.edGoBookLine.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoBookCol
            // 
            this.edGoBookCol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoBookCol.Location = new System.Drawing.Point(86, 113);
            this.edGoBookCol.Name = "edGoBookCol";
            this.edGoBookCol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoBookCol.Size = new System.Drawing.Size(72, 34);
            this.edGoBookCol.TabIndex = 3;
            this.toolTip1.SetToolTip(this.edGoBookCol, "一頁中的欄號。可輸入 a,b,c 或 1,2,3");
            this.edGoBookCol.TextChanged += new System.EventHandler(this.edGoBookCol_TextChanged);
            this.edGoBookCol.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.edGoBookCol.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoBookPage
            // 
            this.edGoBookPage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoBookPage.Location = new System.Drawing.Point(249, 73);
            this.edGoBookPage.Name = "edGoBookPage";
            this.edGoBookPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoBookPage.Size = new System.Drawing.Size(72, 34);
            this.edGoBookPage.TabIndex = 2;
            this.toolTip1.SetToolTip(this.edGoBookPage, "書本的頁碼");
            this.edGoBookPage.TextChanged += new System.EventHandler(this.edGoBookPage_TextChanged);
            this.edGoBookPage.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.edGoBookPage.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoBookVol
            // 
            this.edGoBookVol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoBookVol.Location = new System.Drawing.Point(86, 73);
            this.edGoBookVol.Name = "edGoBookVol";
            this.edGoBookVol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoBookVol.Size = new System.Drawing.Size(72, 34);
            this.edGoBookVol.TabIndex = 1;
            this.toolTip1.SetToolTip(this.edGoBookVol, "書本的冊數，大正藏則稱此為「卷」");
            this.edGoBookVol.TextChanged += new System.EventHandler(this.edGoBookVol_TextChanged);
            this.edGoBookVol.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.edGoBookVol.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraLine
            // 
            this.edGoSutraLine.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraLine.Location = new System.Drawing.Point(86, 354);
            this.edGoSutraLine.Name = "edGoSutraLine";
            this.edGoSutraLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoSutraLine.Size = new System.Drawing.Size(72, 34);
            this.edGoSutraLine.TabIndex = 11;
            this.toolTip1.SetToolTip(this.edGoSutraLine, "一頁、一欄中的行號");
            this.edGoSutraLine.TextChanged += new System.EventHandler(this.edGoSutraLine_TextChanged);
            this.edGoSutraLine.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraLine.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraCol
            // 
            this.edGoSutraCol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraCol.Location = new System.Drawing.Point(249, 314);
            this.edGoSutraCol.Name = "edGoSutraCol";
            this.edGoSutraCol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoSutraCol.Size = new System.Drawing.Size(72, 34);
            this.edGoSutraCol.TabIndex = 10;
            this.toolTip1.SetToolTip(this.edGoSutraCol, "一頁中的欄號。可輸入 a,b,c 或 1,2,3");
            this.edGoSutraCol.TextChanged += new System.EventHandler(this.edGoSutraCol_TextChanged);
            this.edGoSutraCol.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraCol.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraPage
            // 
            this.edGoSutraPage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraPage.Location = new System.Drawing.Point(86, 314);
            this.edGoSutraPage.Name = "edGoSutraPage";
            this.edGoSutraPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoSutraPage.Size = new System.Drawing.Size(72, 34);
            this.edGoSutraPage.TabIndex = 9;
            this.toolTip1.SetToolTip(this.edGoSutraPage, "書本的頁碼");
            this.edGoSutraPage.TextChanged += new System.EventHandler(this.edGoSutraPage_TextChanged);
            this.edGoSutraPage.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraPage.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraJuan
            // 
            this.edGoSutraJuan.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraJuan.Location = new System.Drawing.Point(249, 274);
            this.edGoSutraJuan.Name = "edGoSutraJuan";
            this.edGoSutraJuan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoSutraJuan.Size = new System.Drawing.Size(72, 34);
            this.edGoSutraJuan.TabIndex = 8;
            this.toolTip1.SetToolTip(this.edGoSutraJuan, "「卷」是傳統經典中切成較小的數量單位，\r\n例如大般若經有 600 卷。\r\n現代文獻通常用「篇」或「章」來區分。");
            this.edGoSutraJuan.TextChanged += new System.EventHandler(this.edGoSutraJuan_TextChanged);
            this.edGoSutraJuan.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraJuan.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraSutraNum
            // 
            this.edGoSutraSutraNum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraSutraNum.Location = new System.Drawing.Point(86, 274);
            this.edGoSutraSutraNum.Name = "edGoSutraSutraNum";
            this.edGoSutraSutraNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edGoSutraSutraNum.Size = new System.Drawing.Size(72, 34);
            this.edGoSutraSutraNum.TabIndex = 7;
            this.toolTip1.SetToolTip(this.edGoSutraSutraNum, "傳統經典中的「經號」，\r\n例：大正藏大般若經 T0220 即輸入 220。\r\n現代典籍則輸入其「編號」。\r\n\r\n");
            this.edGoSutraSutraNum.TextChanged += new System.EventHandler(this.edGoSutraSutraNum_TextChanged);
            this.edGoSutraSutraNum.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraSutraNum.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // cbGoBookBookId
            // 
            this.cbGoBookBookId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGoBookBookId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbGoBookBookId.FormattingEnabled = true;
            this.cbGoBookBookId.Items.AddRange(new object[] {
            "T  大正新脩大藏經",
            "X  卍新纂大日本續藏經",
            "A  趙城金藏",
            "K  高麗大藏經",
            "S  宋藏遺珍",
            "F  房山石經",
            "C  中華大藏經",
            "D  國家圖書館善本佛典",
            "U  洪武南藏",
            "P  永樂北藏",
            "J  嘉興大藏經",
            "L  乾隆大藏經",
            "G  佛教大藏經",
            "M  卍正藏經",
            "N  漢譯南傳大藏經",
            "ZS 正史佛教資料類編",
            "I  北朝佛教石刻拓片百品",
            "ZW 藏外佛教文獻",
            "B  大藏經補編",
            "GA 中國佛寺史志彙刊",
            "GB 中國佛寺志叢刊",
            "Y  印順法師佛學著作集",
            "LC 呂澂佛學著作集",
            "TX 太虛大師全書"});
            this.cbGoBookBookId.Location = new System.Drawing.Point(86, 31);
            this.cbGoBookBookId.Name = "cbGoBookBookId";
            this.cbGoBookBookId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbGoBookBookId.Size = new System.Drawing.Size(235, 33);
            this.cbGoBookBookId.TabIndex = 0;
            this.cbGoBookBookId.Tag = "han";
            this.toolTip1.SetToolTip(this.cbGoBookBookId, "請選擇佛教典籍");
            this.cbGoBookBookId.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.cbGoBookBookId.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // cbGoSutraBookId
            // 
            this.cbGoSutraBookId.BackColor = System.Drawing.SystemColors.Window;
            this.cbGoSutraBookId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGoSutraBookId.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbGoSutraBookId.FormattingEnabled = true;
            this.cbGoSutraBookId.Items.AddRange(new object[] {
            "T  大正新脩大藏經",
            "X  卍新纂大日本續藏經",
            "A  趙城金藏",
            "K  高麗大藏經",
            "S  宋藏遺珍",
            "F  房山石經",
            "C  中華大藏經",
            "D  國家圖書館善本佛典",
            "U  洪武南藏",
            "P  永樂北藏",
            "J  嘉興大藏經",
            "L  乾隆大藏經",
            "G  佛教大藏經",
            "M  卍正藏經",
            "N  漢譯南傳大藏經",
            "ZS 正史佛教資料類編",
            "I  北朝佛教石刻拓片百品",
            "ZW 藏外佛教文獻",
            "B  大藏經補編",
            "GA 中國佛寺史志彙刊",
            "GB 中國佛寺志叢刊",
            "Y  印順法師佛學著作集",
            "LC 呂澂佛學著作集",
            "TX 太虛大師全書"});
            this.cbGoSutraBookId.Location = new System.Drawing.Point(86, 235);
            this.cbGoSutraBookId.Name = "cbGoSutraBookId";
            this.cbGoSutraBookId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbGoSutraBookId.Size = new System.Drawing.Size(235, 33);
            this.cbGoSutraBookId.TabIndex = 6;
            this.cbGoSutraBookId.Tag = "han";
            this.toolTip1.SetToolTip(this.cbGoSutraBookId, "請選擇佛教典籍");
            this.cbGoSutraBookId.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.cbGoSutraBookId.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // tpSearch
            // 
            this.tpSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tpSearch.Controls.Add(this.panel11);
            this.tpSearch.Controls.Add(this.splitter4);
            this.tpSearch.Controls.Add(this.panel10);
            this.tpSearch.Location = new System.Drawing.Point(4, 30);
            this.tpSearch.Name = "tpSearch";
            this.tpSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpSearch.Size = new System.Drawing.Size(356, 567);
            this.tpSearch.TabIndex = 3;
            this.tpSearch.Text = "全文檢索";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.sgTextSearch);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 181);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(350, 383);
            this.panel11.TabIndex = 3;
            // 
            // sgTextSearch
            // 
            this.sgTextSearch.AllowUserToAddRows = false;
            this.sgTextSearch.AllowUserToDeleteRows = false;
            this.sgTextSearch.ColumnHeadersHeight = 29;
            this.sgTextSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column14});
            this.sgTextSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgTextSearch.GridColor = System.Drawing.SystemColors.ControlLight;
            this.sgTextSearch.Location = new System.Drawing.Point(0, 0);
            this.sgTextSearch.MultiSelect = false;
            this.sgTextSearch.Name = "sgTextSearch";
            this.sgTextSearch.ReadOnly = true;
            this.sgTextSearch.RowHeadersVisible = false;
            this.sgTextSearch.RowHeadersWidth = 51;
            this.sgTextSearch.RowTemplate.Height = 27;
            this.sgTextSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sgTextSearch.Size = new System.Drawing.Size(350, 383);
            this.sgTextSearch.TabIndex = 6;
            this.sgTextSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sgTextSearch_CellDoubleClick);
            this.sgTextSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.sgTextSearch_Paint);
            this.sgTextSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sgTextSearch_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "筆數";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "佛典";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "冊號";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 40;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "編號";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 55;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "佛典題名";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "卷/篇章";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 40;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "部";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "朝代/作譯者";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 150;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "id";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            this.Column14.Width = 125;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(3, 178);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(350, 3);
            this.splitter4.TabIndex = 2;
            this.splitter4.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel10.Controls.Add(this.edUnicode);
            this.panel10.Controls.Add(this.btMainFuncNarrow2);
            this.panel10.Controls.Add(this.btMainFuncWide2);
            this.panel10.Controls.Add(this.lbSearchMsg);
            this.panel10.Controls.Add(this.btBoolean);
            this.panel10.Controls.Add(this.btTextSearch);
            this.panel10.Controls.Add(this.cbSearchThisSutra);
            this.panel10.Controls.Add(this.cbSearchRange);
            this.panel10.Controls.Add(this.edTextSearch);
            this.panel10.Controls.Add(this.lbSearchString);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(350, 175);
            this.panel10.TabIndex = 1;
            // 
            // edUnicode
            // 
            this.edUnicode.Font = new System.Drawing.Font("Hanazono Mincho C Regular", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.edUnicode.Location = new System.Drawing.Point(104, 4);
            this.edUnicode.Name = "edUnicode";
            this.edUnicode.Size = new System.Drawing.Size(91, 31);
            this.edUnicode.TabIndex = 21;
            this.edUnicode.Visible = false;
            // 
            // btMainFuncNarrow2
            // 
            this.btMainFuncNarrow2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMainFuncNarrow2.Font = new System.Drawing.Font("細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btMainFuncNarrow2.Location = new System.Drawing.Point(289, 147);
            this.btMainFuncNarrow2.Name = "btMainFuncNarrow2";
            this.btMainFuncNarrow2.Size = new System.Drawing.Size(29, 25);
            this.btMainFuncNarrow2.TabIndex = 20;
            this.btMainFuncNarrow2.TabStop = false;
            this.btMainFuncNarrow2.Text = "◀";
            this.toolTip1.SetToolTip(this.btMainFuncNarrow2, "縮小頁面");
            this.btMainFuncNarrow2.UseVisualStyleBackColor = true;
            this.btMainFuncNarrow2.Click += new System.EventHandler(this.btMainFuncNarrow_Click);
            // 
            // btMainFuncWide2
            // 
            this.btMainFuncWide2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMainFuncWide2.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btMainFuncWide2.Location = new System.Drawing.Point(318, 147);
            this.btMainFuncWide2.Name = "btMainFuncWide2";
            this.btMainFuncWide2.Size = new System.Drawing.Size(29, 25);
            this.btMainFuncWide2.TabIndex = 19;
            this.btMainFuncWide2.TabStop = false;
            this.btMainFuncWide2.Text = "▶";
            this.toolTip1.SetToolTip(this.btMainFuncWide2, "展開頁面");
            this.btMainFuncWide2.UseVisualStyleBackColor = true;
            this.btMainFuncWide2.Click += new System.EventHandler(this.btMainFuncWide_Click);
            // 
            // lbSearchMsg
            // 
            this.lbSearchMsg.AutoSize = true;
            this.lbSearchMsg.Location = new System.Drawing.Point(6, 145);
            this.lbSearchMsg.Name = "lbSearchMsg";
            this.lbSearchMsg.Size = new System.Drawing.Size(94, 25);
            this.lbSearchMsg.TabIndex = 18;
            this.lbSearchMsg.Text = "找到 0 筆";
            // 
            // btBoolean
            // 
            this.btBoolean.ContextMenuStrip = this.cmBoolean;
            this.btBoolean.Location = new System.Drawing.Point(265, 78);
            this.btBoolean.Name = "btBoolean";
            this.btBoolean.Size = new System.Drawing.Size(32, 34);
            this.btBoolean.TabIndex = 5;
            this.btBoolean.Text = "▷";
            this.toolTip1.SetToolTip(this.btBoolean, "全文檢索運算邏輯");
            this.btBoolean.UseVisualStyleBackColor = true;
            this.btBoolean.Click += new System.EventHandler(this.btBoolean_Click);
            // 
            // cmBoolean
            // 
            this.cmBoolean.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmBoolean.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNear,
            this.miBefore,
            this.miAnd,
            this.miOr,
            this.miExclude,
            this.miAny});
            this.cmBoolean.Name = "cmBoolean";
            this.cmBoolean.Size = new System.Drawing.Size(142, 148);
            // 
            // miNear
            // 
            this.miNear.Name = "miNear";
            this.miNear.Size = new System.Drawing.Size(141, 24);
            this.miNear.Text = "+ near";
            this.miNear.Click += new System.EventHandler(this.miNear_Click);
            // 
            // miBefore
            // 
            this.miBefore.Name = "miBefore";
            this.miBefore.Size = new System.Drawing.Size(141, 24);
            this.miBefore.Text = "* before";
            this.miBefore.Click += new System.EventHandler(this.miBefore_Click);
            // 
            // miAnd
            // 
            this.miAnd.Name = "miAnd";
            this.miAnd.Size = new System.Drawing.Size(141, 24);
            this.miAnd.Text = "&& and";
            this.miAnd.Click += new System.EventHandler(this.miAnd_Click);
            // 
            // miOr
            // 
            this.miOr.Name = "miOr";
            this.miOr.Size = new System.Drawing.Size(141, 24);
            this.miOr.Text = ", or";
            this.miOr.Click += new System.EventHandler(this.miOr_Click);
            // 
            // miExclude
            // 
            this.miExclude.Name = "miExclude";
            this.miExclude.Size = new System.Drawing.Size(141, 24);
            this.miExclude.Text = "- exclude";
            this.miExclude.Click += new System.EventHandler(this.miExclude_Click);
            // 
            // miAny
            // 
            this.miAny.Name = "miAny";
            this.miAny.Size = new System.Drawing.Size(141, 24);
            this.miAny.Text = "? Any";
            this.miAny.Click += new System.EventHandler(this.miAny_Click);
            // 
            // btTextSearch
            // 
            this.btTextSearch.Location = new System.Drawing.Point(265, 38);
            this.btTextSearch.Name = "btTextSearch";
            this.btTextSearch.Size = new System.Drawing.Size(32, 34);
            this.btTextSearch.TabIndex = 2;
            this.btTextSearch.Text = "🔍";
            this.toolTip1.SetToolTip(this.btTextSearch, "搜尋");
            this.btTextSearch.UseVisualStyleBackColor = true;
            this.btTextSearch.Click += new System.EventHandler(this.btTextSearch_Click);
            // 
            // cbSearchThisSutra
            // 
            this.cbSearchThisSutra.AutoSize = true;
            this.cbSearchThisSutra.Location = new System.Drawing.Point(10, 113);
            this.cbSearchThisSutra.Name = "cbSearchThisSutra";
            this.cbSearchThisSutra.Size = new System.Drawing.Size(134, 29);
            this.cbSearchThisSutra.TabIndex = 4;
            this.cbSearchThisSutra.Text = "檢索本書：";
            this.cbSearchThisSutra.UseVisualStyleBackColor = true;
            this.cbSearchThisSutra.CheckedChanged += new System.EventHandler(this.cbSearchThisSutra_CheckedChanged);
            this.cbSearchThisSutra.Enter += new System.EventHandler(this.edTextSearch_Enter);
            this.cbSearchThisSutra.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // cbSearchRange
            // 
            this.cbSearchRange.AutoSize = true;
            this.cbSearchRange.Location = new System.Drawing.Point(10, 78);
            this.cbSearchRange.Name = "cbSearchRange";
            this.cbSearchRange.Size = new System.Drawing.Size(154, 29);
            this.cbSearchRange.TabIndex = 3;
            this.cbSearchRange.Text = "指定檢索範圍";
            this.cbSearchRange.UseVisualStyleBackColor = true;
            this.cbSearchRange.CheckedChanged += new System.EventHandler(this.cbSearchRange_CheckedChanged);
            this.cbSearchRange.Enter += new System.EventHandler(this.edTextSearch_Enter);
            this.cbSearchRange.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edTextSearch
            // 
            this.edTextSearch.Font = new System.Drawing.Font("Hanazono Mincho C Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edTextSearch.Location = new System.Drawing.Point(11, 38);
            this.edTextSearch.Name = "edTextSearch";
            this.edTextSearch.Size = new System.Drawing.Size(248, 28);
            this.edTextSearch.TabIndex = 1;
            this.toolTip1.SetToolTip(this.edTextSearch, "輸入要檢索的字串");
            this.edTextSearch.TextChanged += new System.EventHandler(this.edTextSearch_TextChanged);
            this.edTextSearch.Enter += new System.EventHandler(this.edTextSearch_Enter);
            this.edTextSearch.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // lbSearchString
            // 
            this.lbSearchString.AutoSize = true;
            this.lbSearchString.Location = new System.Drawing.Point(6, 10);
            this.lbSearchString.Name = "lbSearchString";
            this.lbSearchString.Size = new System.Drawing.Size(92, 25);
            this.lbSearchString.TabIndex = 12;
            this.lbSearchString.Text = "檢索字串";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(364, 76);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 601);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // pnMulu
            // 
            this.pnMulu.Controls.Add(this.tvMuluTree);
            this.pnMulu.Controls.Add(this.panel5);
            this.pnMulu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMulu.Location = new System.Drawing.Point(367, 76);
            this.pnMulu.Name = "pnMulu";
            this.pnMulu.Size = new System.Drawing.Size(197, 601);
            this.pnMulu.TabIndex = 4;
            // 
            // tvMuluTree
            // 
            this.tvMuluTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMuluTree.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tvMuluTree.HideSelection = false;
            this.tvMuluTree.Location = new System.Drawing.Point(0, 28);
            this.tvMuluTree.Name = "tvMuluTree";
            this.tvMuluTree.Size = new System.Drawing.Size(197, 573);
            this.tvMuluTree.TabIndex = 2;
            this.tvMuluTree.Tag = "han";
            this.tvMuluTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvNavTree_KeyDown);
            this.tvMuluTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvNavTree_MouseDoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbToc);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(197, 28);
            this.panel5.TabIndex = 1;
            // 
            // lbToc
            // 
            this.lbToc.AutoSize = true;
            this.lbToc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbToc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbToc.Location = new System.Drawing.Point(0, 0);
            this.lbToc.Name = "lbToc";
            this.lbToc.Size = new System.Drawing.Size(92, 25);
            this.lbToc.TabIndex = 0;
            this.lbToc.Text = "本書目次";
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(564, 76);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 601);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabControl2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(567, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(298, 601);
            this.panel4.TabIndex = 6;
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.Controls.Add(this.tpWeb);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(298, 601);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 0;
            // 
            // tpWeb
            // 
            this.tpWeb.Controls.Add(this.webBrowser);
            this.tpWeb.Location = new System.Drawing.Point(4, 5);
            this.tpWeb.Name = "tpWeb";
            this.tpWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tpWeb.Size = new System.Drawing.Size(290, 592);
            this.tpWeb.TabIndex = 1;
            this.tpWeb.Text = "tabPage4";
            this.tpWeb.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(24, 27);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(284, 586);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.StripAmpersands = true;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(865, 677);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnMulu);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnMainFunc);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CBReader 毘舍離版";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnMainFunc.ResumeLayout(false);
            this.MainFunc.ResumeLayout(false);
            this.tpCatalog.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tpBibl.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sgFindSutra)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tpGoto.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tpSearch.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sgTextSearch)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.cmBoolean.ResumeLayout(false);
            this.pnMulu.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tpWeb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOption;
        private System.Windows.Forms.Panel panel1;
        public  System.Windows.Forms.Panel pnMainFunc;
        private System.Windows.Forms.TabControl MainFunc;
        private System.Windows.Forms.TabPage tpCatalog;
        private System.Windows.Forms.TabPage tpBibl;
        private System.Windows.Forms.TabPage tpGoto;
        private System.Windows.Forms.TabPage tpSearch;
        private System.Windows.Forms.Splitter splitter1;
        public  System.Windows.Forms.Panel pnMulu;
        private System.Windows.Forms.TreeView tvMuluTree;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tpWeb;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button btNextJuan;
        private System.Windows.Forms.Button btPrevJuan;
        private System.Windows.Forms.Button btMuluWidthSwitch;
        private System.Windows.Forms.Button btNavWidthSwitch;
        private System.Windows.Forms.Label lbToc;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btOpenNav;
        private System.Windows.Forms.DataGridView sgTextSearch;
        public  System.Windows.Forms.DataGridView sgFindSutra;
        private System.Windows.Forms.TreeView tvNavTree;
        private System.Windows.Forms.Label lbFindSutraCount;
        private System.Windows.Forms.Label lbFindSutraSutraTo;
        private System.Windows.Forms.Label lbFindSutraVolTo;
        private System.Windows.Forms.Label lbFindSutraByline;
        private System.Windows.Forms.Label lbFindSutraSutraName;
        private System.Windows.Forms.Label lbFindSutraSutraFrom;
        private System.Windows.Forms.Label lbFindSutraVolFrom;
        private System.Windows.Forms.Label lbFindSutraBookId;
        public  System.Windows.Forms.TextBox edFindSutraByline;
        public  System.Windows.Forms.TextBox edFindSutraSutraName;
        private System.Windows.Forms.TextBox edFindSutraSutraTo;
        private System.Windows.Forms.TextBox edFindSutraSutraFrom;
        private System.Windows.Forms.TextBox edFindSutraVolTo;
        private System.Windows.Forms.TextBox edFindSutraVolFrom;
        private System.Windows.Forms.ComboBox cbFindSutraBookId;
        private System.Windows.Forms.Label lbGoByKeywordEx2;
        private System.Windows.Forms.Label lbGoByKeywordEx1;
        private System.Windows.Forms.Label lbGoByKeyword;
        private System.Windows.Forms.Label lbGoBookLine;
        private System.Windows.Forms.Label lbGoBookCol;
        private System.Windows.Forms.Label lbGoBookPage;
        private System.Windows.Forms.Label lbGoBookVol;
        private System.Windows.Forms.Label lbGoBookBookId;
        private System.Windows.Forms.Label lbGoBook;
        private System.Windows.Forms.Label lbGoSutraCol;
        private System.Windows.Forms.Label lbGoSutraJuan;
        private System.Windows.Forms.Label lbGoSutraLine;
        private System.Windows.Forms.Label lbGoSutraPage;
        private System.Windows.Forms.Label lbGoSutraSutraNum;
        private System.Windows.Forms.Label lbGoSutraBookId;
        private System.Windows.Forms.Label lbGoSutra;
        private System.Windows.Forms.Button btGoSutra;
        private System.Windows.Forms.Button btGoBook;
        private System.Windows.Forms.TextBox edGoByKeyword;
        private System.Windows.Forms.TextBox edGoBookLine;
        private System.Windows.Forms.TextBox edGoBookCol;
        private System.Windows.Forms.TextBox edGoBookPage;
        private System.Windows.Forms.TextBox edGoBookVol;
        private System.Windows.Forms.TextBox edGoSutraLine;
        private System.Windows.Forms.TextBox edGoSutraCol;
        private System.Windows.Forms.TextBox edGoSutraPage;
        private System.Windows.Forms.TextBox edGoSutraJuan;
        private System.Windows.Forms.TextBox edGoSutraSutraNum;
        private System.Windows.Forms.ComboBox cbGoBookBookId;
        private System.Windows.Forms.ComboBox cbGoSutraBookId;
        private System.Windows.Forms.Button btBoolean;
        private System.Windows.Forms.Button btTextSearch;
        private System.Windows.Forms.CheckBox cbSearchThisSutra;
        private System.Windows.Forms.CheckBox cbSearchRange;
        private System.Windows.Forms.TextBox edTextSearch;
        private System.Windows.Forms.Label lbSearchString;
        private System.Windows.Forms.Button btGoByKeyword;
        private System.Windows.Forms.Label lbSearchMsg;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miOption;
        private System.Windows.Forms.ToolStripMenuItem miUpdate;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btFindSutra;
        private System.Windows.Forms.ContextMenuStrip cmBoolean;
        private System.Windows.Forms.ToolStripMenuItem miNear;
        private System.Windows.Forms.ToolStripMenuItem miBefore;
        private System.Windows.Forms.ToolStripMenuItem miAnd;
        private System.Windows.Forms.ToolStripMenuItem miOr;
        private System.Windows.Forms.ToolStripMenuItem miExclude;
        private System.Windows.Forms.ToolStripMenuItem miAny;
        private System.Windows.Forms.Button btMainFuncNarrow;
        private System.Windows.Forms.Button btMainFuncWide;
        private System.Windows.Forms.Button btMainFuncNarrow2;
        private System.Windows.Forms.Button btMainFuncWide2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem miAdmin;
        private System.Windows.Forms.ToolStripMenuItem miCreateHtml;
        private System.Windows.Forms.ToolStripMenuItem miLocalUpdateURL;
        private System.Windows.Forms.TextBox edUnicode;
        private System.Windows.Forms.Label lbStar1;
        private System.Windows.Forms.Label lbStar2;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem miLanguage;
        private System.Windows.Forms.ToolStripMenuItem miGetLanguageIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.Button btTheme;
    }
}

