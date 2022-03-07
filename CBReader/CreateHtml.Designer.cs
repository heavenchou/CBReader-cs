namespace CBReader
{
    partial class CreateHtml
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
            if (disposing && (components != null)) {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edBook = new System.Windows.Forms.TextBox();
            this.edSkipThisBook = new System.Windows.Forms.TextBox();
            this.edVolNum = new System.Windows.Forms.TextBox();
            this.edTempPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.cbContinue = new System.Windows.Forms.CheckBox();
            this.lbFileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "藏經";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "略過此藏經";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(29, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "冊數";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(29, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "暫存目錄";
            // 
            // edBook
            // 
            this.edBook.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edBook.Location = new System.Drawing.Point(154, 25);
            this.edBook.Name = "edBook";
            this.edBook.Size = new System.Drawing.Size(174, 34);
            this.edBook.TabIndex = 4;
            // 
            // edSkipThisBook
            // 
            this.edSkipThisBook.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edSkipThisBook.Location = new System.Drawing.Point(154, 74);
            this.edSkipThisBook.Name = "edSkipThisBook";
            this.edSkipThisBook.Size = new System.Drawing.Size(174, 34);
            this.edSkipThisBook.TabIndex = 5;
            // 
            // edVolNum
            // 
            this.edVolNum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edVolNum.Location = new System.Drawing.Point(154, 121);
            this.edVolNum.Name = "edVolNum";
            this.edVolNum.Size = new System.Drawing.Size(174, 34);
            this.edVolNum.TabIndex = 6;
            // 
            // edTempPath
            // 
            this.edTempPath.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.edTempPath.Location = new System.Drawing.Point(154, 216);
            this.edTempPath.Name = "edTempPath";
            this.edTempPath.Size = new System.Drawing.Size(413, 34);
            this.edTempPath.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(29, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "檔名";
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btStart.Location = new System.Drawing.Point(462, 28);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(105, 56);
            this.btStart.TabIndex = 9;
            this.btStart.Text = "開始";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btStop.Location = new System.Drawing.Point(462, 102);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(105, 56);
            this.btStop.TabIndex = 10;
            this.btStop.Text = "停止";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // cbContinue
            // 
            this.cbContinue.AutoSize = true;
            this.cbContinue.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbContinue.Location = new System.Drawing.Point(154, 171);
            this.cbContinue.Name = "cbContinue";
            this.cbContinue.Size = new System.Drawing.Size(174, 29);
            this.cbContinue.TabIndex = 11;
            this.cbContinue.Text = "找到就繼續下去";
            this.cbContinue.UseVisualStyleBackColor = true;
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFileName.Location = new System.Drawing.Point(149, 269);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(93, 25);
            this.lbFileName.TabIndex = 12;
            this.lbFileName.Text = "filename";
            // 
            // CreateHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 313);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.cbContinue);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edTempPath);
            this.Controls.Add(this.edVolNum);
            this.Controls.Add(this.edSkipThisBook);
            this.Controls.Add(this.edBook);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateHtml";
            this.Text = "批量產生 HTML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edBook;
        private System.Windows.Forms.TextBox edSkipThisBook;
        private System.Windows.Forms.TextBox edVolNum;
        private System.Windows.Forms.TextBox edTempPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.CheckBox cbContinue;
        private System.Windows.Forms.Label lbFileName;
    }
}