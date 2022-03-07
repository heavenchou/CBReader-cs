
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.edCSSFileName = new System.Windows.Forms.TextBox();
            this.cbUseCSSFile = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbGaijiUseNormal = new System.Windows.Forms.CheckBox();
            this.cbGaijiUseUniExt = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbGaijiImageFirst = new System.Windows.Forms.RadioButton();
            this.rbGaijiDesFirst = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbGaijiNormalFirst = new System.Windows.Forms.RadioButton();
            this.rbGaijiUniExtFirst = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbShowCollation = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbCBETACollation = new System.Windows.Forms.RadioButton();
            this.rbOrigCollation = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbVerticalMode = new System.Windows.Forms.CheckBox();
            this.cbNoShowAIPunc = new System.Windows.Forms.CheckBox();
            this.cbNoShowLgPunc = new System.Windows.Forms.CheckBox();
            this.cbShowPunc = new System.Windows.Forms.CheckBox();
            this.cbShowLineHead = new System.Windows.Forms.CheckBox();
            this.cbShowLineFormat = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.btCancel.Location = new System.Drawing.Point(510, 20);
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
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 537);
            this.panel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.edCSSFileName);
            this.groupBox4.Controls.Add(this.cbUseCSSFile);
            this.groupBox4.Location = new System.Drawing.Point(286, 396);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox4.Size = new System.Drawing.Size(312, 122);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "畫面呈現";
            // 
            // edCSSFileName
            // 
            this.edCSSFileName.Location = new System.Drawing.Point(34, 73);
            this.edCSSFileName.Margin = new System.Windows.Forms.Padding(4);
            this.edCSSFileName.Name = "edCSSFileName";
            this.edCSSFileName.Size = new System.Drawing.Size(248, 34);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbGaijiUseNormal);
            this.groupBox3.Controls.Add(this.cbGaijiUseUniExt);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Location = new System.Drawing.Point(286, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(312, 362);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "缺字格式";
            // 
            // cbGaijiUseNormal
            // 
            this.cbGaijiUseNormal.AutoSize = true;
            this.cbGaijiUseNormal.Location = new System.Drawing.Point(34, 73);
            this.cbGaijiUseNormal.Margin = new System.Windows.Forms.Padding(4);
            this.cbGaijiUseNormal.Name = "cbGaijiUseNormal";
            this.cbGaijiUseNormal.Size = new System.Drawing.Size(134, 29);
            this.cbGaijiUseNormal.TabIndex = 1;
            this.cbGaijiUseNormal.Text = "使用通用字";
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
            this.cbGaijiUseUniExt.Text = "使用 Unicode Ext";
            this.cbGaijiUseUniExt.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbGaijiImageFirst);
            this.groupBox7.Controls.Add(this.rbGaijiDesFirst);
            this.groupBox7.Location = new System.Drawing.Point(34, 226);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox7.Size = new System.Drawing.Size(248, 111);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "無 Unicode 及通用字時";
            // 
            // rbGaijiImageFirst
            // 
            this.rbGaijiImageFirst.AutoSize = true;
            this.rbGaijiImageFirst.Location = new System.Drawing.Point(23, 73);
            this.rbGaijiImageFirst.Margin = new System.Windows.Forms.Padding(4);
            this.rbGaijiImageFirst.Name = "rbGaijiImageFirst";
            this.rbGaijiImageFirst.Size = new System.Drawing.Size(73, 29);
            this.rbGaijiImageFirst.TabIndex = 5;
            this.rbGaijiImageFirst.TabStop = true;
            this.rbGaijiImageFirst.Text = "圖檔";
            this.rbGaijiImageFirst.UseVisualStyleBackColor = true;
            // 
            // rbGaijiDesFirst
            // 
            this.rbGaijiDesFirst.AutoSize = true;
            this.rbGaijiDesFirst.Location = new System.Drawing.Point(23, 36);
            this.rbGaijiDesFirst.Margin = new System.Windows.Forms.Padding(4);
            this.rbGaijiDesFirst.Name = "rbGaijiDesFirst";
            this.rbGaijiDesFirst.Size = new System.Drawing.Size(93, 29);
            this.rbGaijiDesFirst.TabIndex = 4;
            this.rbGaijiDesFirst.TabStop = true;
            this.rbGaijiDesFirst.Text = "組字式";
            this.rbGaijiDesFirst.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbGaijiNormalFirst);
            this.groupBox6.Controls.Add(this.rbGaijiUniExtFirst);
            this.groupBox6.Location = new System.Drawing.Point(34, 111);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox6.Size = new System.Drawing.Size(248, 105);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "何者優先";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbShowCollation);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(14, 307);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(246, 211);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "校注格式";
            // 
            // cbShowCollation
            // 
            this.cbShowCollation.AutoSize = true;
            this.cbShowCollation.Location = new System.Drawing.Point(30, 36);
            this.cbShowCollation.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowCollation.Name = "cbShowCollation";
            this.cbShowCollation.Size = new System.Drawing.Size(154, 29);
            this.cbShowCollation.TabIndex = 0;
            this.cbShowCollation.Text = "呈現校注符號";
            this.cbShowCollation.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbCBETACollation);
            this.groupBox5.Controls.Add(this.rbOrigCollation);
            this.groupBox5.Location = new System.Drawing.Point(30, 74);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(199, 116);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "校注選擇";
            // 
            // rbCBETACollation
            // 
            this.rbCBETACollation.AutoSize = true;
            this.rbCBETACollation.Location = new System.Drawing.Point(25, 71);
            this.rbCBETACollation.Margin = new System.Windows.Forms.Padding(4);
            this.rbCBETACollation.Name = "rbCBETACollation";
            this.rbCBETACollation.Size = new System.Drawing.Size(159, 29);
            this.rbCBETACollation.TabIndex = 1;
            this.rbCBETACollation.TabStop = true;
            this.rbCBETACollation.Text = "CBETA 版校注";
            this.rbCBETACollation.UseVisualStyleBackColor = true;
            // 
            // rbOrigCollation
            // 
            this.rbOrigCollation.AutoSize = true;
            this.rbOrigCollation.Location = new System.Drawing.Point(25, 36);
            this.rbOrigCollation.Margin = new System.Windows.Forms.Padding(4);
            this.rbOrigCollation.Name = "rbOrigCollation";
            this.rbOrigCollation.Size = new System.Drawing.Size(113, 29);
            this.rbOrigCollation.TabIndex = 0;
            this.rbOrigCollation.TabStop = true;
            this.rbOrigCollation.Text = "原書校注";
            this.rbOrigCollation.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbVerticalMode);
            this.groupBox1.Controls.Add(this.cbNoShowAIPunc);
            this.groupBox1.Controls.Add(this.cbNoShowLgPunc);
            this.groupBox1.Controls.Add(this.cbShowPunc);
            this.groupBox1.Controls.Add(this.cbShowLineHead);
            this.groupBox1.Controls.Add(this.cbShowLineFormat);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(246, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "經文格式";
            // 
            // cbVerticalMode
            // 
            this.cbVerticalMode.AutoSize = true;
            this.cbVerticalMode.Location = new System.Drawing.Point(30, 224);
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
            this.cbNoShowAIPunc.Location = new System.Drawing.Point(55, 187);
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
            this.cbNoShowLgPunc.Location = new System.Drawing.Point(55, 150);
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
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定";
            this.Shown += new System.EventHandler(this.OptionForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbUseCSSFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbGaijiUseNormal;
        private System.Windows.Forms.CheckBox cbGaijiUseUniExt;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbShowCollation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbCBETACollation;
        private System.Windows.Forms.RadioButton rbOrigCollation;
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}