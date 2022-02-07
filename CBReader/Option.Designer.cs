﻿
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
            this.panel1.Location = new System.Drawing.Point(0, 544);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 79);
            this.panel1.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(514, 19);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(94, 42);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(321, 19);
            this.btOK.Margin = new System.Windows.Forms.Padding(4);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(94, 42);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "確定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btSave
            // 
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSave.Location = new System.Drawing.Point(189, 19);
            this.btSave.Margin = new System.Windows.Forms.Padding(4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(94, 42);
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
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 544);
            this.panel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.edCSSFileName);
            this.groupBox4.Controls.Add(this.cbUseCSSFile);
            this.groupBox4.Location = new System.Drawing.Point(326, 414);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(282, 107);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "畫面呈現";
            // 
            // edCSSFileName
            // 
            this.edCSSFileName.Location = new System.Drawing.Point(29, 62);
            this.edCSSFileName.Name = "edCSSFileName";
            this.edCSSFileName.Size = new System.Drawing.Size(231, 31);
            this.edCSSFileName.TabIndex = 10;
            // 
            // cbUseCSSFile
            // 
            this.cbUseCSSFile.AutoSize = true;
            this.cbUseCSSFile.Location = new System.Drawing.Point(28, 31);
            this.cbUseCSSFile.Name = "cbUseCSSFile";
            this.cbUseCSSFile.Size = new System.Drawing.Size(194, 24);
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
            this.groupBox3.Location = new System.Drawing.Point(326, 28);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(282, 370);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "缺字格式";
            // 
            // cbGaijiUseNormal
            // 
            this.cbGaijiUseNormal.AutoSize = true;
            this.cbGaijiUseNormal.Location = new System.Drawing.Point(28, 62);
            this.cbGaijiUseNormal.Name = "cbGaijiUseNormal";
            this.cbGaijiUseNormal.Size = new System.Drawing.Size(131, 24);
            this.cbGaijiUseNormal.TabIndex = 1;
            this.cbGaijiUseNormal.Text = "使用通用字";
            this.cbGaijiUseNormal.UseVisualStyleBackColor = true;
            // 
            // cbGaijiUseUniExt
            // 
            this.cbGaijiUseUniExt.AutoSize = true;
            this.cbGaijiUseUniExt.Location = new System.Drawing.Point(28, 31);
            this.cbGaijiUseUniExt.Name = "cbGaijiUseUniExt";
            this.cbGaijiUseUniExt.Size = new System.Drawing.Size(168, 24);
            this.cbGaijiUseUniExt.TabIndex = 0;
            this.cbGaijiUseUniExt.Text = "使用 Unicode Ext";
            this.cbGaijiUseUniExt.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbGaijiImageFirst);
            this.groupBox7.Controls.Add(this.rbGaijiDesFirst);
            this.groupBox7.Location = new System.Drawing.Point(28, 237);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(232, 116);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "無 Unicode 及通用字時";
            // 
            // rbGaijiImageFirst
            // 
            this.rbGaijiImageFirst.AutoSize = true;
            this.rbGaijiImageFirst.Location = new System.Drawing.Point(19, 74);
            this.rbGaijiImageFirst.Name = "rbGaijiImageFirst";
            this.rbGaijiImageFirst.Size = new System.Drawing.Size(70, 24);
            this.rbGaijiImageFirst.TabIndex = 5;
            this.rbGaijiImageFirst.TabStop = true;
            this.rbGaijiImageFirst.Text = "圖檔";
            this.rbGaijiImageFirst.UseVisualStyleBackColor = true;
            // 
            // rbGaijiDesFirst
            // 
            this.rbGaijiDesFirst.AutoSize = true;
            this.rbGaijiDesFirst.Location = new System.Drawing.Point(19, 31);
            this.rbGaijiDesFirst.Name = "rbGaijiDesFirst";
            this.rbGaijiDesFirst.Size = new System.Drawing.Size(90, 24);
            this.rbGaijiDesFirst.TabIndex = 4;
            this.rbGaijiDesFirst.TabStop = true;
            this.rbGaijiDesFirst.Text = "組字式";
            this.rbGaijiDesFirst.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbGaijiNormalFirst);
            this.groupBox6.Controls.Add(this.rbGaijiUniExtFirst);
            this.groupBox6.Location = new System.Drawing.Point(28, 110);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(232, 110);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "何者優先";
            // 
            // rbGaijiNormalFirst
            // 
            this.rbGaijiNormalFirst.AutoSize = true;
            this.rbGaijiNormalFirst.Location = new System.Drawing.Point(19, 68);
            this.rbGaijiNormalFirst.Name = "rbGaijiNormalFirst";
            this.rbGaijiNormalFirst.Size = new System.Drawing.Size(90, 24);
            this.rbGaijiNormalFirst.TabIndex = 3;
            this.rbGaijiNormalFirst.TabStop = true;
            this.rbGaijiNormalFirst.Text = "通用字";
            this.rbGaijiNormalFirst.UseVisualStyleBackColor = true;
            // 
            // rbGaijiUniExtFirst
            // 
            this.rbGaijiUniExtFirst.AutoSize = true;
            this.rbGaijiUniExtFirst.Location = new System.Drawing.Point(19, 31);
            this.rbGaijiUniExtFirst.Name = "rbGaijiUniExtFirst";
            this.rbGaijiUniExtFirst.Size = new System.Drawing.Size(122, 24);
            this.rbGaijiUniExtFirst.TabIndex = 2;
            this.rbGaijiUniExtFirst.TabStop = true;
            this.rbGaijiUniExtFirst.Text = "Unicode Ext";
            this.rbGaijiUniExtFirst.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbShowCollation);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(28, 309);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(255, 212);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "校注格式";
            // 
            // cbShowCollation
            // 
            this.cbShowCollation.AutoSize = true;
            this.cbShowCollation.Location = new System.Drawing.Point(25, 31);
            this.cbShowCollation.Name = "cbShowCollation";
            this.cbShowCollation.Size = new System.Drawing.Size(151, 24);
            this.cbShowCollation.TabIndex = 0;
            this.cbShowCollation.Text = "呈現校注符號";
            this.cbShowCollation.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbCBETACollation);
            this.groupBox5.Controls.Add(this.rbOrigCollation);
            this.groupBox5.Location = new System.Drawing.Point(25, 73);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(191, 114);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "校注選擇";
            // 
            // rbCBETACollation
            // 
            this.rbCBETACollation.AutoSize = true;
            this.rbCBETACollation.Location = new System.Drawing.Point(16, 72);
            this.rbCBETACollation.Name = "rbCBETACollation";
            this.rbCBETACollation.Size = new System.Drawing.Size(157, 24);
            this.rbCBETACollation.TabIndex = 1;
            this.rbCBETACollation.TabStop = true;
            this.rbCBETACollation.Text = "CBETA 版校注";
            this.rbCBETACollation.UseVisualStyleBackColor = true;
            // 
            // rbOrigCollation
            // 
            this.rbOrigCollation.AutoSize = true;
            this.rbOrigCollation.Location = new System.Drawing.Point(16, 32);
            this.rbOrigCollation.Name = "rbOrigCollation";
            this.rbOrigCollation.Size = new System.Drawing.Size(110, 24);
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
            this.groupBox1.Location = new System.Drawing.Point(28, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(255, 253);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "經文格式";
            // 
            // cbVerticalMode
            // 
            this.cbVerticalMode.AutoSize = true;
            this.cbVerticalMode.Location = new System.Drawing.Point(25, 218);
            this.cbVerticalMode.Name = "cbVerticalMode";
            this.cbVerticalMode.Size = new System.Drawing.Size(71, 24);
            this.cbVerticalMode.TabIndex = 5;
            this.cbVerticalMode.Text = "直排";
            this.cbVerticalMode.UseVisualStyleBackColor = true;
            // 
            // cbNoShowAIPunc
            // 
            this.cbNoShowAIPunc.AutoSize = true;
            this.cbNoShowAIPunc.Location = new System.Drawing.Point(54, 179);
            this.cbNoShowAIPunc.Name = "cbNoShowAIPunc";
            this.cbNoShowAIPunc.Size = new System.Drawing.Size(161, 24);
            this.cbNoShowAIPunc.TabIndex = 4;
            this.cbNoShowAIPunc.Text = "不呈現 AI 標點";
            this.cbNoShowAIPunc.UseVisualStyleBackColor = true;
            // 
            // cbNoShowLgPunc
            // 
            this.cbNoShowLgPunc.AutoSize = true;
            this.cbNoShowLgPunc.Location = new System.Drawing.Point(54, 149);
            this.cbNoShowLgPunc.Name = "cbNoShowLgPunc";
            this.cbNoShowLgPunc.Size = new System.Drawing.Size(171, 24);
            this.cbNoShowLgPunc.TabIndex = 3;
            this.cbNoShowLgPunc.Text = "不呈現偈頌標點";
            this.cbNoShowLgPunc.UseVisualStyleBackColor = true;
            // 
            // cbShowPunc
            // 
            this.cbShowPunc.AutoSize = true;
            this.cbShowPunc.Location = new System.Drawing.Point(25, 110);
            this.cbShowPunc.Name = "cbShowPunc";
            this.cbShowPunc.Size = new System.Drawing.Size(151, 24);
            this.cbShowPunc.TabIndex = 2;
            this.cbShowPunc.Text = "顯示標點符號";
            this.cbShowPunc.UseVisualStyleBackColor = true;
            this.cbShowPunc.CheckedChanged += new System.EventHandler(this.cbShowPunc_CheckedChanged);
            // 
            // cbShowLineHead
            // 
            this.cbShowLineHead.AutoSize = true;
            this.cbShowLineHead.Location = new System.Drawing.Point(25, 71);
            this.cbShowLineHead.Name = "cbShowLineHead";
            this.cbShowLineHead.Size = new System.Drawing.Size(211, 24);
            this.cbShowLineHead.TabIndex = 1;
            this.cbShowLineHead.Text = "加上「頁、欄、行」";
            this.cbShowLineHead.UseVisualStyleBackColor = true;
            // 
            // cbShowLineFormat
            // 
            this.cbShowLineFormat.AutoSize = true;
            this.cbShowLineFormat.Location = new System.Drawing.Point(25, 31);
            this.cbShowLineFormat.Name = "cbShowLineFormat";
            this.cbShowLineFormat.Size = new System.Drawing.Size(171, 24);
            this.cbShowLineFormat.TabIndex = 0;
            this.cbShowLineFormat.Text = "依原書格式呈現";
            this.cbShowLineFormat.UseVisualStyleBackColor = true;
            // 
            // OptionForm
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(639, 623);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
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