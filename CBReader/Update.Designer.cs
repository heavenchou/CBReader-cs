﻿
namespace CBReader
{
    partial class UpdateForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.Memo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btUpdate = new System.Windows.Forms.Button();
            this.cbUseChinaServer = new System.Windows.Forms.CheckBox();
            this.lbUseChineseSite = new System.Windows.Forms.Label();
            this.btDownload = new System.Windows.Forms.Button();
            this.plMessage = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbBookcasePath = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.edBookcasePath = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.plMessage.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Memo
            // 
            this.Memo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Memo.Location = new System.Drawing.Point(15, 18);
            this.Memo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Memo.Multiline = true;
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            this.Memo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Memo.Size = new System.Drawing.Size(520, 338);
            this.Memo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btUpdate);
            this.panel1.Controls.Add(this.cbUseChinaServer);
            this.panel1.Controls.Add(this.lbUseChineseSite);
            this.panel1.Controls.Add(this.btDownload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(541, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 491);
            this.panel1.TabIndex = 1;
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.Location = new System.Drawing.Point(6, 80);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(165, 55);
            this.btUpdate.TabIndex = 3;
            this.btUpdate.Text = "🆕 更新及重啟";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // cbUseChinaServer
            // 
            this.cbUseChinaServer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbUseChinaServer.Location = new System.Drawing.Point(6, 156);
            this.cbUseChinaServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUseChinaServer.Name = "cbUseChinaServer";
            this.cbUseChinaServer.Size = new System.Drawing.Size(174, 54);
            this.cbUseChinaServer.TabIndex = 2;
            this.cbUseChinaServer.Text = "中國大陸分站";
            this.cbUseChinaServer.UseVisualStyleBackColor = true;
            // 
            // lbUseChineseSite
            // 
            this.lbUseChineseSite.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbUseChineseSite.Location = new System.Drawing.Point(0, 214);
            this.lbUseChineseSite.Name = "lbUseChineseSite";
            this.lbUseChineseSite.Size = new System.Drawing.Size(180, 198);
            this.lbUseChineseSite.TabIndex = 1;
            this.lbUseChineseSite.Text = "使用中國大陸分站的主機進行更新";
            // 
            // btDownload
            // 
            this.btDownload.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btDownload.Location = new System.Drawing.Point(6, 18);
            this.btDownload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(165, 55);
            this.btDownload.TabIndex = 0;
            this.btDownload.Text = "📥 下載";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // plMessage
            // 
            this.plMessage.Controls.Add(this.lbMessage);
            this.plMessage.Controls.Add(this.lbBookcasePath);
            this.plMessage.Controls.Add(this.progressBar1);
            this.plMessage.Controls.Add(this.edBookcasePath);
            this.plMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plMessage.Location = new System.Drawing.Point(0, 364);
            this.plMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plMessage.Name = "plMessage";
            this.plMessage.Size = new System.Drawing.Size(541, 127);
            this.plMessage.TabIndex = 2;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbMessage.Location = new System.Drawing.Point(12, 13);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(72, 25);
            this.lbMessage.TabIndex = 3;
            this.lbMessage.Text = "訊息：";
            // 
            // lbBookcasePath
            // 
            this.lbBookcasePath.AutoSize = true;
            this.lbBookcasePath.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbBookcasePath.Location = new System.Drawing.Point(11, 81);
            this.lbBookcasePath.Name = "lbBookcasePath";
            this.lbBookcasePath.Size = new System.Drawing.Size(92, 25);
            this.lbBookcasePath.TabIndex = 2;
            this.lbBookcasePath.Text = "書櫃目錄";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(15, 42);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(520, 19);
            this.progressBar1.TabIndex = 1;
            // 
            // edBookcasePath
            // 
            this.edBookcasePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edBookcasePath.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edBookcasePath.Location = new System.Drawing.Point(109, 78);
            this.edBookcasePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.edBookcasePath.Name = "edBookcasePath";
            this.edBookcasePath.ReadOnly = true;
            this.edBookcasePath.Size = new System.Drawing.Size(426, 34);
            this.edBookcasePath.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Memo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(541, 364);
            this.panel3.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(724, 491);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.plMessage);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateForm_FormClosing);
            this.Shown += new System.EventHandler(this.UpdateForm_Shown);
            this.panel1.ResumeLayout(false);
            this.plMessage.ResumeLayout(false);
            this.plMessage.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbUseChinaServer;
        private System.Windows.Forms.Label lbUseChineseSite;
        private System.Windows.Forms.Button btDownload;
        public  System.Windows.Forms.Panel plMessage;
        private System.Windows.Forms.Label lbMessage;
        public  System.Windows.Forms.Label lbBookcasePath;
        public  System.Windows.Forms.ProgressBar progressBar1;
        public  System.Windows.Forms.TextBox edBookcasePath;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btUpdate;
    }
}