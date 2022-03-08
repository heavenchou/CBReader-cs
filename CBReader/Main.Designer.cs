
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
            this.btOption = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miOption = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateHtml = new System.Windows.Forms.ToolStripMenuItem();
            this.btNextJuan = new System.Windows.Forms.Button();
            this.btPrevJuan = new System.Windows.Forms.Button();
            this.btMuluWidthSwitch = new System.Windows.Forms.Button();
            this.btNavWidthSwitch = new System.Windows.Forms.Button();
            this.pnMainFunc = new System.Windows.Forms.Panel();
            this.MainFunc = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tvNavTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.btOpenNav = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edFindSutraByline = new System.Windows.Forms.TextBox();
            this.edFindSutraSutraName = new System.Windows.Forms.TextBox();
            this.edFindSutraSutraTo = new System.Windows.Forms.TextBox();
            this.edFindSutraSutraFrom = new System.Windows.Forms.TextBox();
            this.edFindSutraVolTo = new System.Windows.Forms.TextBox();
            this.edFindSutraVolFrom = new System.Windows.Forms.TextBox();
            this.cbFindSutraBookId = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btGoByKeyword = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbSearchMsg = new System.Windows.Forms.Label();
            this.btBoolean = new System.Windows.Forms.Button();
            this.btTextSearch = new System.Windows.Forms.Button();
            this.cbSearchThisSutra = new System.Windows.Forms.CheckBox();
            this.cbSearchRange = new System.Windows.Forms.CheckBox();
            this.edTextSearch = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnMulu = new System.Windows.Forms.Panel();
            this.tvMuluTree = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpWeb = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmBoolean = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miNear = new System.Windows.Forms.ToolStripMenuItem();
            this.miBefore = new System.Windows.Forms.ToolStripMenuItem();
            this.miAnd = new System.Windows.Forms.ToolStripMenuItem();
            this.miOr = new System.Windows.Forms.ToolStripMenuItem();
            this.miExclude = new System.Windows.Forms.ToolStripMenuItem();
            this.miAny = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnMainFunc.SuspendLayout();
            this.MainFunc.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sgFindSutra)).BeginInit();
            this.panel8.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sgTextSearch)).BeginInit();
            this.panel10.SuspendLayout();
            this.pnMulu.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpWeb.SuspendLayout();
            this.cmBoolean.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOption
            // 
            this.btOption.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btOption.Location = new System.Drawing.Point(17, 30);
            this.btOption.Name = "btOption";
            this.btOption.Size = new System.Drawing.Size(86, 40);
            this.btOption.TabIndex = 0;
            this.btOption.Text = "⚙ 設定";
            this.btOption.UseVisualStyleBackColor = true;
            this.btOption.Click += new System.EventHandler(this.btOption_Click);
            // 
            // panel1
            // 
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOption,
            this.miUpdate,
            this.miAbout,
            this.miAdmin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 30);
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
            this.miCreateHtml});
            this.miAdmin.Name = "miAdmin";
            this.miAdmin.Size = new System.Drawing.Size(105, 23);
            this.miAdmin.Text = "Heaven專用";
            this.miAdmin.Visible = false;
            // 
            // miCreateHtml
            // 
            this.miCreateHtml.Name = "miCreateHtml";
            this.miCreateHtml.Size = new System.Drawing.Size(193, 26);
            this.miCreateHtml.Text = "批量產生HTML";
            this.miCreateHtml.Click += new System.EventHandler(this.miCreateHtml_Click);
            // 
            // btNextJuan
            // 
            this.btNextJuan.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btNextJuan.Location = new System.Drawing.Point(530, 30);
            this.btNextJuan.Name = "btNextJuan";
            this.btNextJuan.Size = new System.Drawing.Size(161, 40);
            this.btNextJuan.TabIndex = 4;
            this.btNextJuan.Text = "下一卷/篇章 ▼";
            this.btNextJuan.UseVisualStyleBackColor = true;
            this.btNextJuan.Click += new System.EventHandler(this.btNextJuan_Click);
            // 
            // btPrevJuan
            // 
            this.btPrevJuan.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btPrevJuan.Location = new System.Drawing.Point(363, 30);
            this.btPrevJuan.Name = "btPrevJuan";
            this.btPrevJuan.Size = new System.Drawing.Size(161, 40);
            this.btPrevJuan.TabIndex = 3;
            this.btPrevJuan.Text = "上一卷/篇章 ▲";
            this.btPrevJuan.UseVisualStyleBackColor = true;
            this.btPrevJuan.Click += new System.EventHandler(this.btPrevJuan_Click);
            // 
            // btMuluWidthSwitch
            // 
            this.btMuluWidthSwitch.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btMuluWidthSwitch.Location = new System.Drawing.Point(226, 30);
            this.btMuluWidthSwitch.Name = "btMuluWidthSwitch";
            this.btMuluWidthSwitch.Size = new System.Drawing.Size(117, 40);
            this.btMuluWidthSwitch.TabIndex = 2;
            this.btMuluWidthSwitch.Text = "目次 ►";
            this.btMuluWidthSwitch.UseVisualStyleBackColor = true;
            this.btMuluWidthSwitch.Click += new System.EventHandler(this.btMuluWidthSwitch_Click);
            // 
            // btNavWidthSwitch
            // 
            this.btNavWidthSwitch.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btNavWidthSwitch.Location = new System.Drawing.Point(109, 30);
            this.btNavWidthSwitch.Name = "btNavWidthSwitch";
            this.btNavWidthSwitch.Size = new System.Drawing.Size(114, 40);
            this.btNavWidthSwitch.TabIndex = 1;
            this.btNavWidthSwitch.Text = "◄ 主功能";
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
            this.MainFunc.Controls.Add(this.tabPage1);
            this.MainFunc.Controls.Add(this.tabPage2);
            this.MainFunc.Controls.Add(this.tabPage3);
            this.MainFunc.Controls.Add(this.tabPage4);
            this.MainFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFunc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainFunc.ItemSize = new System.Drawing.Size(52, 26);
            this.MainFunc.Location = new System.Drawing.Point(0, 0);
            this.MainFunc.Name = "MainFunc";
            this.MainFunc.SelectedIndex = 0;
            this.MainFunc.Size = new System.Drawing.Size(364, 601);
            this.MainFunc.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.MainFunc.TabIndex = 0;
            this.MainFunc.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(356, 567);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "書目";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.panel6.Controls.Add(this.btOpenNav);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(350, 50);
            this.panel6.TabIndex = 0;
            // 
            // btOpenNav
            // 
            this.btOpenNav.Location = new System.Drawing.Point(10, 3);
            this.btOpenNav.Name = "btOpenNav";
            this.btOpenNav.Size = new System.Drawing.Size(109, 41);
            this.btOpenNav.TabIndex = 0;
            this.btOpenNav.Text = "🗃 主目錄";
            this.btOpenNav.UseVisualStyleBackColor = true;
            this.btOpenNav.Click += new System.EventHandler(this.btOpenNav_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel12);
            this.tabPage2.Controls.Add(this.splitter3);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(356, 567);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "經目";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.sgFindSutra.AllowUserToResizeRows = false;
            this.sgFindSutra.ColumnHeadersHeight = 29;
            this.sgFindSutra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            this.sgFindSutra.RowHeadersVisible = false;
            this.sgFindSutra.RowHeadersWidth = 44;
            this.sgFindSutra.RowTemplate.Height = 27;
            this.sgFindSutra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sgFindSutra.Size = new System.Drawing.Size(350, 312);
            this.sgFindSutra.TabIndex = 8;
            this.sgFindSutra.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sgFindSutra_CellDoubleClick);
            this.sgFindSutra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sgFindSutra_KeyDown);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "藏";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "冊";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "經";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "經名";
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
            this.Column12.HeaderText = "作譯者";
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
            this.panel8.Controls.Add(this.btMainFuncNarrow);
            this.panel8.Controls.Add(this.btMainFuncWide);
            this.panel8.Controls.Add(this.btFindSutra);
            this.panel8.Controls.Add(this.lbFindSutraCount);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
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
            this.btFindSutra.UseVisualStyleBackColor = true;
            this.btFindSutra.Click += new System.EventHandler(this.btFindSutra_Click);
            // 
            // lbFindSutraCount
            // 
            this.lbFindSutraCount.AutoSize = true;
            this.lbFindSutraCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFindSutraCount.Location = new System.Drawing.Point(6, 215);
            this.lbFindSutraCount.Name = "lbFindSutraCount";
            this.lbFindSutraCount.Size = new System.Drawing.Size(114, 25);
            this.lbFindSutraCount.TabIndex = 14;
            this.lbFindSutraCount.Text = "共找到 0 筆";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(192, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "到";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(192, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "到";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(6, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "作譯者";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(6, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "經名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "經號從";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "冊數從";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "藏經";
            // 
            // edFindSutraByline
            // 
            this.edFindSutraByline.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edFindSutraByline.Location = new System.Drawing.Point(84, 171);
            this.edFindSutraByline.Name = "edFindSutraByline";
            this.edFindSutraByline.Size = new System.Drawing.Size(228, 34);
            this.edFindSutraByline.TabIndex = 6;
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
            this.cbFindSutraBookId.Location = new System.Drawing.Point(84, 12);
            this.cbFindSutraBookId.Name = "cbFindSutraBookId";
            this.cbFindSutraBookId.Size = new System.Drawing.Size(228, 33);
            this.cbFindSutraBookId.TabIndex = 0;
            this.cbFindSutraBookId.Enter += new System.EventHandler(this.edFindSutraVolFrom_Enter);
            this.cbFindSutraBookId.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel9);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(356, 567);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "到";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel3);
            this.panel9.Controls.Add(this.panel2);
            this.panel9.Controls.Add(this.btGoByKeyword);
            this.panel9.Controls.Add(this.label24);
            this.panel9.Controls.Add(this.label23);
            this.panel9.Controls.Add(this.label22);
            this.panel9.Controls.Add(this.label21);
            this.panel9.Controls.Add(this.label20);
            this.panel9.Controls.Add(this.label19);
            this.panel9.Controls.Add(this.label18);
            this.panel9.Controls.Add(this.label17);
            this.panel9.Controls.Add(this.label16);
            this.panel9.Controls.Add(this.label15);
            this.panel9.Controls.Add(this.label14);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Controls.Add(this.label12);
            this.panel9.Controls.Add(this.label11);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Controls.Add(this.label9);
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
            this.panel9.Size = new System.Drawing.Size(350, 561);
            this.panel9.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel3.Location = new System.Drawing.Point(3, 391);
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
            this.panel2.Location = new System.Drawing.Point(3, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 10);
            this.panel2.TabIndex = 31;
            // 
            // btGoByKeyword
            // 
            this.btGoByKeyword.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btGoByKeyword.Location = new System.Drawing.Point(242, 435);
            this.btGoByKeyword.Name = "btGoByKeyword";
            this.btGoByKeyword.Size = new System.Drawing.Size(62, 34);
            this.btGoByKeyword.TabIndex = 14;
            this.btGoByKeyword.Text = "Go";
            this.btGoByKeyword.UseVisualStyleBackColor = true;
            this.btGoByKeyword.Click += new System.EventHandler(this.btGoByKeyword_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label24.Location = new System.Drawing.Point(7, 508);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(214, 25);
            this.label24.TabIndex = 30;
            this.label24.Text = "例2 : T01, no. 1, p.1a1";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label23.Location = new System.Drawing.Point(5, 483);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(259, 25);
            this.label23.TabIndex = 29;
            this.label23.Text = "例1 : T01n0001_p0001a01";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(5, 407);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(132, 25);
            this.label22.TabIndex = 28;
            this.label22.Text = "前往指定經文";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(169, 315);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 25);
            this.label21.TabIndex = 27;
            this.label21.Text = "行數";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(27, 315);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 25);
            this.label20.TabIndex = 26;
            this.label20.Text = "欄";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(169, 274);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 25);
            this.label19.TabIndex = 25;
            this.label19.Text = "頁數";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(7, 274);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 25);
            this.label18.TabIndex = 24;
            this.label18.Text = "冊數";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(5, 235);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 25);
            this.label17.TabIndex = 23;
            this.label17.Text = "藏經";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(5, 204);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 25);
            this.label16.TabIndex = 22;
            this.label16.Text = "書本結構";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(189, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 25);
            this.label15.TabIndex = 21;
            this.label15.Text = "欄";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(141, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 25);
            this.label14.TabIndex = 20;
            this.label14.Text = "卷/篇章";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(5, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 25);
            this.label13.TabIndex = 19;
            this.label13.Text = "行數";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(7, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 25);
            this.label12.TabIndex = 18;
            this.label12.Text = "頁數";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(7, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 25);
            this.label11.TabIndex = 17;
            this.label11.Text = "經號";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(7, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "藏經";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(7, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "經卷結構";
            // 
            // btGoSutra
            // 
            this.btGoSutra.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btGoSutra.Location = new System.Drawing.Point(227, 149);
            this.btGoSutra.Name = "btGoSutra";
            this.btGoSutra.Size = new System.Drawing.Size(77, 36);
            this.btGoSutra.TabIndex = 6;
            this.btGoSutra.Text = "Go";
            this.btGoSutra.UseVisualStyleBackColor = true;
            this.btGoSutra.Click += new System.EventHandler(this.btGoSutra_Click);
            // 
            // btGoBook
            // 
            this.btGoBook.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btGoBook.Location = new System.Drawing.Point(227, 348);
            this.btGoBook.Name = "btGoBook";
            this.btGoBook.Size = new System.Drawing.Size(77, 37);
            this.btGoBook.TabIndex = 12;
            this.btGoBook.Text = "Go";
            this.btGoBook.UseVisualStyleBackColor = true;
            this.btGoBook.Click += new System.EventHandler(this.btGoBook_Click);
            // 
            // edGoByKeyword
            // 
            this.edGoByKeyword.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoByKeyword.Location = new System.Drawing.Point(10, 435);
            this.edGoByKeyword.Name = "edGoByKeyword";
            this.edGoByKeyword.Size = new System.Drawing.Size(226, 34);
            this.edGoByKeyword.TabIndex = 13;
            this.edGoByKeyword.Enter += new System.EventHandler(this.edGoByKeyword_Enter);
            this.edGoByKeyword.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoBookLine
            // 
            this.edGoBookLine.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoBookLine.Location = new System.Drawing.Point(227, 311);
            this.edGoBookLine.Name = "edGoBookLine";
            this.edGoBookLine.Size = new System.Drawing.Size(77, 34);
            this.edGoBookLine.TabIndex = 11;
            this.edGoBookLine.TextChanged += new System.EventHandler(this.edGoBookLine_TextChanged);
            this.edGoBookLine.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.edGoBookLine.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoBookCol
            // 
            this.edGoBookCol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoBookCol.Location = new System.Drawing.Point(65, 311);
            this.edGoBookCol.Name = "edGoBookCol";
            this.edGoBookCol.Size = new System.Drawing.Size(72, 34);
            this.edGoBookCol.TabIndex = 10;
            this.edGoBookCol.TextChanged += new System.EventHandler(this.edGoBookCol_TextChanged);
            this.edGoBookCol.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.edGoBookCol.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoBookPage
            // 
            this.edGoBookPage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoBookPage.Location = new System.Drawing.Point(227, 271);
            this.edGoBookPage.Name = "edGoBookPage";
            this.edGoBookPage.Size = new System.Drawing.Size(77, 34);
            this.edGoBookPage.TabIndex = 9;
            this.edGoBookPage.TextChanged += new System.EventHandler(this.edGoBookPage_TextChanged);
            this.edGoBookPage.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.edGoBookPage.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoBookVol
            // 
            this.edGoBookVol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoBookVol.Location = new System.Drawing.Point(65, 271);
            this.edGoBookVol.Name = "edGoBookVol";
            this.edGoBookVol.Size = new System.Drawing.Size(72, 34);
            this.edGoBookVol.TabIndex = 8;
            this.edGoBookVol.TextChanged += new System.EventHandler(this.edGoBookVol_TextChanged);
            this.edGoBookVol.Enter += new System.EventHandler(this.edGoBookVol_Enter);
            this.edGoBookVol.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraLine
            // 
            this.edGoSutraLine.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraLine.Location = new System.Drawing.Point(65, 151);
            this.edGoSutraLine.Name = "edGoSutraLine";
            this.edGoSutraLine.Size = new System.Drawing.Size(72, 34);
            this.edGoSutraLine.TabIndex = 5;
            this.edGoSutraLine.TextChanged += new System.EventHandler(this.edGoSutraLine_TextChanged);
            this.edGoSutraLine.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraLine.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraCol
            // 
            this.edGoSutraCol.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraCol.Location = new System.Drawing.Point(227, 111);
            this.edGoSutraCol.Name = "edGoSutraCol";
            this.edGoSutraCol.Size = new System.Drawing.Size(77, 34);
            this.edGoSutraCol.TabIndex = 4;
            this.edGoSutraCol.TextChanged += new System.EventHandler(this.edGoSutraCol_TextChanged);
            this.edGoSutraCol.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraCol.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraPage
            // 
            this.edGoSutraPage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraPage.Location = new System.Drawing.Point(65, 111);
            this.edGoSutraPage.Name = "edGoSutraPage";
            this.edGoSutraPage.Size = new System.Drawing.Size(72, 34);
            this.edGoSutraPage.TabIndex = 3;
            this.edGoSutraPage.TextChanged += new System.EventHandler(this.edGoSutraPage_TextChanged);
            this.edGoSutraPage.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraPage.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraJuan
            // 
            this.edGoSutraJuan.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraJuan.Location = new System.Drawing.Point(227, 71);
            this.edGoSutraJuan.Name = "edGoSutraJuan";
            this.edGoSutraJuan.Size = new System.Drawing.Size(77, 34);
            this.edGoSutraJuan.TabIndex = 2;
            this.edGoSutraJuan.TextChanged += new System.EventHandler(this.edGoSutraJuan_TextChanged);
            this.edGoSutraJuan.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.edGoSutraJuan.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // edGoSutraSutraNum
            // 
            this.edGoSutraSutraNum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edGoSutraSutraNum.Location = new System.Drawing.Point(65, 71);
            this.edGoSutraSutraNum.Name = "edGoSutraSutraNum";
            this.edGoSutraSutraNum.Size = new System.Drawing.Size(72, 34);
            this.edGoSutraSutraNum.TabIndex = 1;
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
            this.cbGoBookBookId.Location = new System.Drawing.Point(65, 232);
            this.cbGoBookBookId.Name = "cbGoBookBookId";
            this.cbGoBookBookId.Size = new System.Drawing.Size(239, 33);
            this.cbGoBookBookId.TabIndex = 7;
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
            this.cbGoSutraBookId.Location = new System.Drawing.Point(65, 32);
            this.cbGoSutraBookId.Name = "cbGoSutraBookId";
            this.cbGoSutraBookId.Size = new System.Drawing.Size(239, 33);
            this.cbGoSutraBookId.TabIndex = 0;
            this.cbGoSutraBookId.Enter += new System.EventHandler(this.edGoSutraSutraNum_Enter);
            this.cbGoSutraBookId.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel11);
            this.tabPage4.Controls.Add(this.splitter4);
            this.tabPage4.Controls.Add(this.panel10);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(356, 567);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "全文檢索";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.sgTextSearch.AllowUserToResizeRows = false;
            this.sgTextSearch.ColumnHeadersHeight = 29;
            this.sgTextSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            this.Column2.HeaderText = "藏";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "冊";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 40;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "經";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 55;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "經名";
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
            this.Column9.HeaderText = "作譯者";
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
            this.panel10.Controls.Add(this.button1);
            this.panel10.Controls.Add(this.button2);
            this.panel10.Controls.Add(this.lbSearchMsg);
            this.panel10.Controls.Add(this.btBoolean);
            this.panel10.Controls.Add(this.btTextSearch);
            this.panel10.Controls.Add(this.cbSearchThisSutra);
            this.panel10.Controls.Add(this.cbSearchRange);
            this.panel10.Controls.Add(this.edTextSearch);
            this.panel10.Controls.Add(this.label26);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(350, 175);
            this.panel10.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(289, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 25);
            this.button1.TabIndex = 20;
            this.button1.TabStop = false;
            this.button1.Text = "◀";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btMainFuncNarrow_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(318, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 25);
            this.button2.TabIndex = 19;
            this.button2.TabStop = false;
            this.button2.Text = "▶";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btMainFuncWide_Click);
            // 
            // lbSearchMsg
            // 
            this.lbSearchMsg.AutoSize = true;
            this.lbSearchMsg.Location = new System.Drawing.Point(6, 145);
            this.lbSearchMsg.Name = "lbSearchMsg";
            this.lbSearchMsg.Size = new System.Drawing.Size(114, 25);
            this.lbSearchMsg.TabIndex = 18;
            this.lbSearchMsg.Text = "共找到 0 筆";
            // 
            // btBoolean
            // 
            this.btBoolean.Location = new System.Drawing.Point(265, 78);
            this.btBoolean.Name = "btBoolean";
            this.btBoolean.Size = new System.Drawing.Size(32, 34);
            this.btBoolean.TabIndex = 5;
            this.btBoolean.Text = "▷";
            this.btBoolean.UseVisualStyleBackColor = true;
            this.btBoolean.Click += new System.EventHandler(this.btBoolean_Click);
            // 
            // btTextSearch
            // 
            this.btTextSearch.Location = new System.Drawing.Point(265, 38);
            this.btTextSearch.Name = "btTextSearch";
            this.btTextSearch.Size = new System.Drawing.Size(32, 34);
            this.btTextSearch.TabIndex = 2;
            this.btTextSearch.Text = "🔍";
            this.btTextSearch.UseVisualStyleBackColor = true;
            this.btTextSearch.Click += new System.EventHandler(this.btTextSearch_Click);
            // 
            // cbSearchThisSutra
            // 
            this.cbSearchThisSutra.AutoSize = true;
            this.cbSearchThisSutra.Enabled = false;
            this.cbSearchThisSutra.Location = new System.Drawing.Point(10, 113);
            this.cbSearchThisSutra.Name = "cbSearchThisSutra";
            this.cbSearchThisSutra.Size = new System.Drawing.Size(134, 29);
            this.cbSearchThisSutra.TabIndex = 4;
            this.cbSearchThisSutra.Text = "檢索本經：";
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
            this.edTextSearch.Location = new System.Drawing.Point(11, 38);
            this.edTextSearch.Name = "edTextSearch";
            this.edTextSearch.Size = new System.Drawing.Size(248, 34);
            this.edTextSearch.TabIndex = 1;
            this.edTextSearch.Enter += new System.EventHandler(this.edTextSearch_Enter);
            this.edTextSearch.Leave += new System.EventHandler(this.edFindSutraVolFrom_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(92, 25);
            this.label26.TabIndex = 12;
            this.label26.Text = "檢索字串";
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
            this.tvMuluTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvNavTree_KeyDown);
            this.tvMuluTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvNavTree_MouseDoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(197, 28);
            this.panel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "本書目次";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(865, 677);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnMulu);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnMainFunc);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CBReader 毘舍離版";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnMainFunc.ResumeLayout(false);
            this.MainFunc.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sgFindSutra)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sgTextSearch)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.pnMulu.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tpWeb.ResumeLayout(false);
            this.cmBoolean.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOption;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnMainFunc;
        private System.Windows.Forms.TabControl MainFunc;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnMulu;
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
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.DataGridView sgFindSutra;
        private System.Windows.Forms.TreeView tvNavTree;
        private System.Windows.Forms.Label lbFindSutraCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edFindSutraByline;
        private System.Windows.Forms.TextBox edFindSutraSutraName;
        private System.Windows.Forms.TextBox edFindSutraSutraTo;
        private System.Windows.Forms.TextBox edFindSutraSutraFrom;
        private System.Windows.Forms.TextBox edFindSutraVolTo;
        private System.Windows.Forms.TextBox edFindSutraVolFrom;
        private System.Windows.Forms.ComboBox cbFindSutraBookId;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.Label label26;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.Button btMainFuncNarrow;
        private System.Windows.Forms.Button btMainFuncWide;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem miAdmin;
        private System.Windows.Forms.ToolStripMenuItem miCreateHtml;
    }
}

