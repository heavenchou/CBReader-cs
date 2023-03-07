
namespace CBReader
{
    partial class OptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbViewShow = new System.Windows.Forms.GroupBox();
            this.edCSSFileName = new System.Windows.Forms.TextBox();
            this.cbUseCSSFile = new System.Windows.Forms.CheckBox();
            this.gbGaijiFormat = new System.Windows.Forms.GroupBox();
            this.cbGaijiUseNormal = new System.Windows.Forms.CheckBox();
            this.cbGaijiUseUniExt = new System.Windows.Forms.CheckBox();
            this.gbNoUnicodeAndNormal = new System.Windows.Forms.GroupBox();
            this.rbGaijiImageFirst = new System.Windows.Forms.RadioButton();
            this.rbGaijiDesFirst = new System.Windows.Forms.RadioButton();
            this.gbWhichFirst = new System.Windows.Forms.GroupBox();
            this.rbGaijiNormalFirst = new System.Windows.Forms.RadioButton();
            this.rbGaijiUniExtFirst = new System.Windows.Forms.RadioButton();
            this.gbTextSelect = new System.Windows.Forms.GroupBox();
            this.lbIncludeTextNoteSearch = new System.Windows.Forms.Label();
            this.rbCBETACollation = new System.Windows.Forms.RadioButton();
            this.rbOrigCollation = new System.Windows.Forms.RadioButton();
            this.gbNoteFormat = new System.Windows.Forms.GroupBox();
            this.cbShowCollationCF = new System.Windows.Forms.CheckBox();
            this.cbShowCollation = new System.Windows.Forms.CheckBox();
            this.gbSutraFormat = new System.Windows.Forms.GroupBox();
            this.cbVerticalMode = new System.Windows.Forms.CheckBox();
            this.cbNoShowAIPunc = new System.Windows.Forms.CheckBox();
            this.cbNoShowLgPunc = new System.Windows.Forms.CheckBox();
            this.cbShowPunc = new System.Windows.Forms.CheckBox();
            this.cbShowLineHead = new System.Windows.Forms.CheckBox();
            this.cbShowLineFormat = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbViewShow.SuspendLayout();
            this.gbGaijiFormat.SuspendLayout();
            this.gbNoUnicodeAndNormal.SuspendLayout();
            this.gbWhichFirst.SuspendLayout();
            this.gbTextSelect.SuspendLayout();
            this.gbNoteFormat.SuspendLayout();
            this.gbSutraFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 537);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 76);
            this.panel1.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(518, 20);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(88, 42);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(286, 20);
            this.btOK.Margin = new System.Windows.Forms.Padding(5);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(88, 42);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "確定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btSave
            // 
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSave.Location = new System.Drawing.Point(172, 20);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(88, 42);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "儲存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.gbViewShow);
            this.panel2.Controls.Add(this.gbGaijiFormat);
            this.panel2.Controls.Add(this.gbTextSelect);
            this.panel2.Controls.Add(this.gbNoteFormat);
            this.panel2.Controls.Add(this.gbSutraFormat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 537);
            this.panel2.TabIndex = 1;
            // 
            // gbViewShow
            // 
            this.gbViewShow.Controls.Add(this.edCSSFileName);
            this.gbViewShow.Controls.Add(this.cbUseCSSFile);
            this.gbViewShow.Location = new System.Drawing.Point(286, 396);
            this.gbViewShow.Margin = new System.Windows.Forms.Padding(5);
            this.gbViewShow.Name = "gbViewShow";
            this.gbViewShow.Padding = new System.Windows.Forms.Padding(5);
            this.gbViewShow.Size = new System.Drawing.Size(320, 122);
            this.gbViewShow.TabIndex = 3;
            this.gbViewShow.TabStop = false;
            this.gbViewShow.Text = "畫面呈現";
            // 
            // edCSSFileName
            // 
            this.edCSSFileName.Location = new System.Drawing.Point(34, 73);
            this.edCSSFileName.Margin = new System.Windows.Forms.Padding(4);
            this.edCSSFileName.Name = "edCSSFileName";
            this.edCSSFileName.Size = new System.Drawing.Size(278, 34);
            this.edCSSFileName.TabIndex = 10;
            // 
            // cbUseCSSFile
            // 
            this.cbUseCSSFile.AutoSize = true;
            this.cbUseCSSFile.Location = new System.Drawing.Point(34, 36);
            this.cbUseCSSFile.Margin = new System.Windows.Forms.Padding(4);
            this.cbUseCSSFile.Name = "cbUseCSSFile";
            this.cbUseCSSFile.Size = new System.Drawing.Size(199, 29);
            this.cbUseCSSFile.TabIndex = 9;
            this.cbUseCSSFile.Text = "增加自訂 CSS 檔案";
            this.cbUseCSSFile.UseVisualStyleBackColor = true;
            // 
            // gbGaijiFormat
            // 
            this.gbGaijiFormat.Controls.Add(this.cbGaijiUseNormal);
            this.gbGaijiFormat.Controls.Add(this.cbGaijiUseUniExt);
            this.gbGaijiFormat.Controls.Add(this.gbNoUnicodeAndNormal);
            this.gbGaijiFormat.Controls.Add(this.gbWhichFirst);
            this.gbGaijiFormat.Location = new System.Drawing.Point(286, 14);
            this.gbGaijiFormat.Margin = new System.Windows.Forms.Padding(5);
            this.gbGaijiFormat.Name = "gbGaijiFormat";
            this.gbGaijiFormat.Padding = new System.Windows.Forms.Padding(5);
            this.gbGaijiFormat.Size = new System.Drawing.Size(320, 362);
            this.gbGaijiFormat.TabIndex = 2;
            this.gbGaijiFormat.TabStop = false;
            this.gbGaijiFormat.Text = "缺字格式";
            // 
            // cbGaijiUseNormal
            // 
            this.cbGaijiUseNormal.AutoSize = true;
            this.cbGaijiUseNormal.Location = new System.Drawing.Point(34, 73);
            this.cbGaijiUseNormal.Margin = new System.Windows.Forms.Padding(4);
            this.cbGaijiUseNormal.Name = "cbGaijiUseNormal";
            this.cbGaijiUseNormal.Size = new System.Drawing.Size(134, 29);
            this.cbGaijiUseNormal.TabIndex = 1;
            this.cbGaijiUseNormal.Text = "顯示通用字";
            this.cbGaijiUseNormal.UseVisualStyleBackColor = true;
            // 
            // cbGaijiUseUniExt
            // 
            this.cbGaijiUseUniExt.AutoSize = true;
            this.cbGaijiUseUniExt.Location = new System.Drawing.Point(34, 36);
            this.cbGaijiUseUniExt.Margin = new System.Windows.Forms.Padding(4);
            this.cbGaijiUseUniExt.Name = "cbGaijiUseUniExt";
            this.cbGaijiUseUniExt.Size = new System.Drawing.Size(191, 29);
            this.cbGaijiUseUniExt.TabIndex = 0;
            this.cbGaijiUseUniExt.Text = "顯示 Unicode Ext";
            this.cbGaijiUseUniExt.UseVisualStyleBackColor = true;
            // 
            // gbNoUnicodeAndNormal
            // 
            this.gbNoUnicodeAndNormal.Controls.Add(this.rbGaijiImageFirst);
            this.gbNoUnicodeAndNormal.Controls.Add(this.rbGaijiDesFirst);
            this.gbNoUnicodeAndNormal.Location = new System.Drawing.Point(10, 226);
            this.gbNoUnicodeAndNormal.Margin = new System.Windows.Forms.Padding(5);
            this.gbNoUnicodeAndNormal.Name = "gbNoUnicodeAndNormal";
            this.gbNoUnicodeAndNormal.Padding = new System.Windows.Forms.Padding(5);
            this.gbNoUnicodeAndNormal.Size = new System.Drawing.Size(302, 111);
            this.gbNoUnicodeAndNormal.TabIndex = 4;
            this.gbNoUnicodeAndNormal.TabStop = false;
            this.gbNoUnicodeAndNormal.Text = "無 Unicode 及通用字時";
            // 
            // rbGaijiImageFirst
            // 
            this.rbGaijiImageFirst.AutoSize = true;
            this.rbGaijiImageFirst.Location = new System.Drawing.Point(23, 73);
            this.rbGaijiImageFirst.Margin = new System.Windows.Forms.Padding(4);
            this.rbGaijiImageFirst.Name = "rbGaijiImageFirst";
            this.rbGaijiImageFirst.Size = new System.Drawing.Size(113, 29);
            this.rbGaijiImageFirst.TabIndex = 5;
            this.rbGaijiImageFirst.TabStop = true;
            this.rbGaijiImageFirst.Text = "顯示圖檔";
            this.rbGaijiImageFirst.UseVisualStyleBackColor = true;
            // 
            // rbGaijiDesFirst
            // 
            this.rbGaijiDesFirst.AutoSize = true;
            this.rbGaijiDesFirst.Location = new System.Drawing.Point(23, 36);
            this.rbGaijiDesFirst.Margin = new System.Windows.Forms.Padding(4);
            this.rbGaijiDesFirst.Name = "rbGaijiDesFirst";
            this.rbGaijiDesFirst.Size = new System.Drawing.Size(133, 29);
            this.rbGaijiDesFirst.TabIndex = 4;
            this.rbGaijiDesFirst.TabStop = true;
            this.rbGaijiDesFirst.Text = "顯示組字式";
            this.rbGaijiDesFirst.UseVisualStyleBackColor = true;
            // 
            // gbWhichFirst
            // 
            this.gbWhichFirst.Controls.Add(this.rbGaijiNormalFirst);
            this.gbWhichFirst.Controls.Add(this.rbGaijiUniExtFirst);
            this.gbWhichFirst.Location = new System.Drawing.Point(10, 111);
            this.gbWhichFirst.Margin = new System.Windows.Forms.Padding(5);
            this.gbWhichFirst.Name = "gbWhichFirst";
            this.gbWhichFirst.Padding = new System.Windows.Forms.Padding(5);
            this.gbWhichFirst.Size = new System.Drawing.Size(302, 105);
            this.gbWhichFirst.TabIndex = 3;
            this.gbWhichFirst.TabStop = false;
            this.gbWhichFirst.Text = "優先顯示順序";
            // 
            // rbGaijiNormalFirst
            // 
            this.rbGaijiNormalFirst.AutoSize = true;
            this.rbGaijiNormalFirst.Location = new System.Drawing.Point(23, 73);
            this.rbGaijiNormalFirst.Margin = new System.Windows.Forms.Padding(4);
            this.rbGaijiNormalFirst.Name = "rbGaijiNormalFirst";
            this.rbGaijiNormalFirst.Size = new System.Drawing.Size(93, 29);
            this.rbGaijiNormalFirst.TabIndex = 3;
            this.rbGaijiNormalFirst.TabStop = true;
            this.rbGaijiNormalFirst.Text = "通用字";
            this.rbGaijiNormalFirst.UseVisualStyleBackColor = true;
            // 
            // rbGaijiUniExtFirst
            // 
            this.rbGaijiUniExtFirst.AutoSize = true;
            this.rbGaijiUniExtFirst.Location = new System.Drawing.Point(23, 36);
            this.rbGaijiUniExtFirst.Margin = new System.Windows.Forms.Padding(4);
            this.rbGaijiUniExtFirst.Name = "rbGaijiUniExtFirst";
            this.rbGaijiUniExtFirst.Size = new System.Drawing.Size(145, 29);
            this.rbGaijiUniExtFirst.TabIndex = 2;
            this.rbGaijiUniExtFirst.TabStop = true;
            this.rbGaijiUniExtFirst.Text = "Unicode Ext";
            this.rbGaijiUniExtFirst.UseVisualStyleBackColor = true;
            // 
            // gbTextSelect
            // 
            this.gbTextSelect.Controls.Add(this.lbIncludeTextNoteSearch);
            this.gbTextSelect.Controls.Add(this.rbCBETACollation);
            this.gbTextSelect.Controls.Add(this.rbOrigCollation);
            this.gbTextSelect.Location = new System.Drawing.Point(14, 276);
            this.gbTextSelect.Margin = new System.Windows.Forms.Padding(5);
            this.gbTextSelect.Name = "gbTextSelect";
            this.gbTextSelect.Padding = new System.Windows.Forms.Padding(5);
            this.gbTextSelect.Size = new System.Drawing.Size(262, 132);
            this.gbTextSelect.TabIndex = 2;
            this.gbTextSelect.TabStop = false;
            this.gbTextSelect.Text = "文字版本選擇";
            // 
            // lbIncludeTextNoteSearch
            // 
            this.lbIncludeTextNoteSearch.AutoSize = true;
            this.lbIncludeTextNoteSearch.Location = new System.Drawing.Point(8, 32);
            this.lbIncludeTextNoteSearch.Name = "lbIncludeTextNoteSearch";
            this.lbIncludeTextNoteSearch.Size = new System.Drawing.Size(232, 25);
            this.lbIncludeTextNoteSearch.TabIndex = 4;
            this.lbIncludeTextNoteSearch.Text = "含用字、校注、全文檢索";
            // 
            // rbCBETACollation
            // 
            this.rbCBETACollation.AutoSize = true;
            this.rbCBETACollation.Location = new System.Drawing.Point(25, 94);
            this.rbCBETACollation.Margin = new System.Windows.Forms.Padding(4);
            this.rbCBETACollation.Name = "rbCBETACollation";
            this.rbCBETACollation.Size = new System.Drawing.Size(119, 29);
            this.rbCBETACollation.TabIndex = 1;
            this.rbCBETACollation.TabStop = true;
            this.rbCBETACollation.Text = "CBETA 版";
            this.rbCBETACollation.UseVisualStyleBackColor = true;
            // 
            // rbOrigCollation
            // 
            this.rbOrigCollation.AutoSize = true;
            this.rbOrigCollation.Location = new System.Drawing.Point(25, 61);
            this.rbOrigCollation.Margin = new System.Windows.Forms.Padding(4);
            this.rbOrigCollation.Name = "rbOrigCollation";
            this.rbOrigCollation.Size = new System.Drawing.Size(73, 29);
            this.rbOrigCollation.TabIndex = 0;
            this.rbOrigCollation.TabStop = true;
            this.rbOrigCollation.Text = "原書";
            this.rbOrigCollation.UseVisualStyleBackColor = true;
            // 
            // gbNoteFormat
            // 
            this.gbNoteFormat.Controls.Add(this.cbShowCollationCF);
            this.gbNoteFormat.Controls.Add(this.cbShowCollation);
            this.gbNoteFormat.Location = new System.Drawing.Point(14, 418);
            this.gbNoteFormat.Margin = new System.Windows.Forms.Padding(5);
            this.gbNoteFormat.Name = "gbNoteFormat";
            this.gbNoteFormat.Padding = new System.Windows.Forms.Padding(5);
            this.gbNoteFormat.Size = new System.Drawing.Size(262, 100);
            this.gbNoteFormat.TabIndex = 1;
            this.gbNoteFormat.TabStop = false;
            this.gbNoteFormat.Text = "校注格式";
            // 
            // cbShowCollationCF
            // 
            this.cbShowCollationCF.AutoSize = true;
            this.cbShowCollationCF.Location = new System.Drawing.Point(55, 63);
            this.cbShowCollationCF.Name = "cbShowCollationCF";
            this.cbShowCollationCF.Size = new System.Drawing.Size(194, 29);
            this.cbShowCollationCF.TabIndex = 3;
            this.cbShowCollationCF.Text = "顯示校注參考資訊";
            this.cbShowCollationCF.UseVisualStyleBackColor = true;
            // 
            // cbShowCollation
            // 
            this.cbShowCollation.AutoSize = true;
            this.cbShowCollation.Location = new System.Drawing.Point(30, 31);
            this.cbShowCollation.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowCollation.Name = "cbShowCollation";
            this.cbShowCollation.Size = new System.Drawing.Size(154, 29);
            this.cbShowCollation.TabIndex = 0;
            this.cbShowCollation.Text = "顯示校注符號";
            this.cbShowCollation.UseVisualStyleBackColor = true;
            this.cbShowCollation.CheckedChanged += new System.EventHandler(this.cbShowCollation_CheckedChanged);
            // 
            // gbSutraFormat
            // 
            this.gbSutraFormat.Controls.Add(this.cbVerticalMode);
            this.gbSutraFormat.Controls.Add(this.cbNoShowAIPunc);
            this.gbSutraFormat.Controls.Add(this.cbNoShowLgPunc);
            this.gbSutraFormat.Controls.Add(this.cbShowPunc);
            this.gbSutraFormat.Controls.Add(this.cbShowLineHead);
            this.gbSutraFormat.Controls.Add(this.cbShowLineFormat);
            this.gbSutraFormat.Location = new System.Drawing.Point(14, 14);
            this.gbSutraFormat.Margin = new System.Windows.Forms.Padding(5);
            this.gbSutraFormat.Name = "gbSutraFormat";
            this.gbSutraFormat.Padding = new System.Windows.Forms.Padding(5);
            this.gbSutraFormat.Size = new System.Drawing.Size(262, 252);
            this.gbSutraFormat.TabIndex = 0;
            this.gbSutraFormat.TabStop = false;
            this.gbSutraFormat.Text = "經文格式";
            // 
            // cbVerticalMode
            // 
            this.cbVerticalMode.AutoSize = true;
            this.cbVerticalMode.Location = new System.Drawing.Point(30, 214);
            this.cbVerticalMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbVerticalMode.Name = "cbVerticalMode";
            this.cbVerticalMode.Size = new System.Drawing.Size(74, 29);
            this.cbVerticalMode.TabIndex = 5;
            this.cbVerticalMode.Text = "直排";
            this.cbVerticalMode.UseVisualStyleBackColor = true;
            // 
            // cbNoShowAIPunc
            // 
            this.cbNoShowAIPunc.AutoSize = true;
            this.cbNoShowAIPunc.Location = new System.Drawing.Point(55, 184);
            this.cbNoShowAIPunc.Margin = new System.Windows.Forms.Padding(4);
            this.cbNoShowAIPunc.Name = "cbNoShowAIPunc";
            this.cbNoShowAIPunc.Size = new System.Drawing.Size(164, 29);
            this.cbNoShowAIPunc.TabIndex = 4;
            this.cbNoShowAIPunc.Text = "不呈現 AI 標點";
            this.cbNoShowAIPunc.UseVisualStyleBackColor = true;
            // 
            // cbNoShowLgPunc
            // 
            this.cbNoShowLgPunc.AutoSize = true;
            this.cbNoShowLgPunc.Location = new System.Drawing.Point(55, 147);
            this.cbNoShowLgPunc.Margin = new System.Windows.Forms.Padding(4);
            this.cbNoShowLgPunc.Name = "cbNoShowLgPunc";
            this.cbNoShowLgPunc.Size = new System.Drawing.Size(174, 29);
            this.cbNoShowLgPunc.TabIndex = 3;
            this.cbNoShowLgPunc.Text = "不呈現偈頌標點";
            this.cbNoShowLgPunc.UseVisualStyleBackColor = true;
            // 
            // cbShowPunc
            // 
            this.cbShowPunc.AutoSize = true;
            this.cbShowPunc.Location = new System.Drawing.Point(30, 113);
            this.cbShowPunc.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowPunc.Name = "cbShowPunc";
            this.cbShowPunc.Size = new System.Drawing.Size(154, 29);
            this.cbShowPunc.TabIndex = 2;
            this.cbShowPunc.Text = "顯示標點符號";
            this.cbShowPunc.UseVisualStyleBackColor = true;
            this.cbShowPunc.CheckedChanged += new System.EventHandler(this.cbShowPunc_CheckedChanged);
            // 
            // cbShowLineHead
            // 
            this.cbShowLineHead.AutoSize = true;
            this.cbShowLineHead.Location = new System.Drawing.Point(30, 76);
            this.cbShowLineHead.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowLineHead.Name = "cbShowLineHead";
            this.cbShowLineHead.Size = new System.Drawing.Size(214, 29);
            this.cbShowLineHead.TabIndex = 1;
            this.cbShowLineHead.Text = "加上「頁、欄、行」";
            this.cbShowLineHead.UseVisualStyleBackColor = true;
            // 
            // cbShowLineFormat
            // 
            this.cbShowLineFormat.AutoSize = true;
            this.cbShowLineFormat.Location = new System.Drawing.Point(30, 39);
            this.cbShowLineFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowLineFormat.Name = "cbShowLineFormat";
            this.cbShowLineFormat.Size = new System.Drawing.Size(174, 29);
            this.cbShowLineFormat.TabIndex = 0;
            this.cbShowLineFormat.Text = "依原書格式呈現";
            this.cbShowLineFormat.UseVisualStyleBackColor = true;
            // 
            // OptionForm
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(620, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定";
            this.Shown += new System.EventHandler(this.OptionForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbViewShow.ResumeLayout(false);
            this.gbViewShow.PerformLayout();
            this.gbGaijiFormat.ResumeLayout(false);
            this.gbGaijiFormat.PerformLayout();
            this.gbNoUnicodeAndNormal.ResumeLayout(false);
            this.gbNoUnicodeAndNormal.PerformLayout();
            this.gbWhichFirst.ResumeLayout(false);
            this.gbWhichFirst.PerformLayout();
            this.gbTextSelect.ResumeLayout(false);
            this.gbTextSelect.PerformLayout();
            this.gbNoteFormat.ResumeLayout(false);
            this.gbNoteFormat.PerformLayout();
            this.gbSutraFormat.ResumeLayout(false);
            this.gbSutraFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbViewShow;
        private System.Windows.Forms.CheckBox cbUseCSSFile;
        private System.Windows.Forms.GroupBox gbGaijiFormat;
        private System.Windows.Forms.CheckBox cbGaijiUseNormal;
        private System.Windows.Forms.CheckBox cbGaijiUseUniExt;
        private System.Windows.Forms.GroupBox gbNoUnicodeAndNormal;
        private System.Windows.Forms.GroupBox gbWhichFirst;
        private System.Windows.Forms.GroupBox gbNoteFormat;
        private System.Windows.Forms.CheckBox cbShowCollation;
        private System.Windows.Forms.GroupBox gbTextSelect;
        private System.Windows.Forms.RadioButton rbCBETACollation;
        private System.Windows.Forms.RadioButton rbOrigCollation;
        private System.Windows.Forms.GroupBox gbSutraFormat;
        private System.Windows.Forms.CheckBox cbVerticalMode;
        private System.Windows.Forms.CheckBox cbNoShowAIPunc;
        private System.Windows.Forms.CheckBox cbNoShowLgPunc;
        private System.Windows.Forms.CheckBox cbShowPunc;
        private System.Windows.Forms.CheckBox cbShowLineHead;
        private System.Windows.Forms.CheckBox cbShowLineFormat;
        private System.Windows.Forms.TextBox edCSSFileName;
        private System.Windows.Forms.RadioButton rbGaijiImageFirst;
        private System.Windows.Forms.RadioButton rbGaijiDesFirst;
        private System.Windows.Forms.RadioButton rbGaijiNormalFirst;
        private System.Windows.Forms.RadioButton rbGaijiUniExtFirst;
        private System.Windows.Forms.CheckBox cbShowCollationCF;
        private System.Windows.Forms.Label lbIncludeTextNoteSearch;
    }
}