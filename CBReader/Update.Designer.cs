
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
            this.Memo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUseChinaServer = new System.Windows.Forms.CheckBox();
            this.edBookcasePath = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.Memo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Memo.Size = new System.Drawing.Size(553, 338);
            this.Memo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbUseChinaServer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btUpdate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(574, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 491);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbMessage);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.edBookcasePath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 364);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(574, 127);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Memo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(574, 364);
            this.panel3.TabIndex = 3;
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(15, 38);
            this.btUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(122, 55);
            this.btUpdate.TabIndex = 0;
            this.btUpdate.Text = "更新";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 77);
            this.label1.TabIndex = 1;
            this.label1.Text = "使用中國大陸分站的主機進行更新";
            // 
            // cbUseChinaServer
            // 
            this.cbUseChinaServer.AutoSize = true;
            this.cbUseChinaServer.Location = new System.Drawing.Point(15, 112);
            this.cbUseChinaServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUseChinaServer.Name = "cbUseChinaServer";
            this.cbUseChinaServer.Size = new System.Drawing.Size(134, 26);
            this.cbUseChinaServer.TabIndex = 2;
            this.cbUseChinaServer.Text = "中國大陸分站";
            this.cbUseChinaServer.UseVisualStyleBackColor = true;
            // 
            // edBookcasePath
            // 
            this.edBookcasePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edBookcasePath.Location = new System.Drawing.Point(95, 78);
            this.edBookcasePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.edBookcasePath.Name = "edBookcasePath";
            this.edBookcasePath.ReadOnly = true;
            this.edBookcasePath.Size = new System.Drawing.Size(473, 30);
            this.edBookcasePath.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(15, 39);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(553, 19);
            this.progressBar1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "書櫃目錄";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(12, 13);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(61, 22);
            this.lbMessage.TabIndex = 3;
            this.lbMessage.Text = "訊息：";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 491);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新";
            this.Shown += new System.EventHandler(this.UpdateForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbUseChinaServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox edBookcasePath;
        private System.Windows.Forms.Panel panel3;
    }
}