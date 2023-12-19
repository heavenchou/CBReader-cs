namespace CBReader
{
    partial class BookmarkForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookmarkForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeViewFolder = new System.Windows.Forms.TreeView();
            this.imglBookmark = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvBookmarkList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btDeleteBookmark = new System.Windows.Forms.Button();
            this.btEditBookmark = new System.Windows.Forms.Button();
            this.btAddBookmark = new System.Windows.Forms.Button();
            this.btAddBookmarkFolder = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeViewFolder);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 440);
            this.panel1.TabIndex = 0;
            // 
            // treeViewFolder
            // 
            this.treeViewFolder.AllowDrop = true;
            this.treeViewFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFolder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewFolder.HideSelection = false;
            this.treeViewFolder.ImageIndex = 0;
            this.treeViewFolder.ImageList = this.imglBookmark;
            this.treeViewFolder.Location = new System.Drawing.Point(0, 47);
            this.treeViewFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewFolder.Name = "treeViewFolder";
            this.treeViewFolder.SelectedImageIndex = 0;
            this.treeViewFolder.Size = new System.Drawing.Size(254, 393);
            this.treeViewFolder.TabIndex = 1;
            this.treeViewFolder.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewFolder_ItemDrag);
            this.treeViewFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolder_AfterSelect);
            this.treeViewFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewFolder_DragDrop);
            this.treeViewFolder.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewFolder_DragOver);
            this.treeViewFolder.DragLeave += new System.EventHandler(this.treeViewFolder_DragLeave);
            // 
            // imglBookmark
            // 
            this.imglBookmark.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglBookmark.ImageStream")));
            this.imglBookmark.TransparentColor = System.Drawing.Color.Transparent;
            this.imglBookmark.Images.SetKeyName(0, "folder_close.ico");
            this.imglBookmark.Images.SetKeyName(1, "folder_open.ico");
            this.imglBookmark.Images.SetKeyName(2, "Boookmark.png");
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 47);
            this.panel3.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(254, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 440);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvBookmarkList);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(258, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 440);
            this.panel2.TabIndex = 2;
            // 
            // lvBookmarkList
            // 
            this.lvBookmarkList.AllowDrop = true;
            this.lvBookmarkList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvBookmarkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBookmarkList.FullRowSelect = true;
            this.lvBookmarkList.GridLines = true;
            this.lvBookmarkList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBookmarkList.HideSelection = false;
            this.lvBookmarkList.Location = new System.Drawing.Point(0, 47);
            this.lvBookmarkList.Name = "lvBookmarkList";
            this.lvBookmarkList.OwnerDraw = true;
            this.lvBookmarkList.Size = new System.Drawing.Size(478, 393);
            this.lvBookmarkList.TabIndex = 5;
            this.lvBookmarkList.UseCompatibleStateImageBehavior = false;
            this.lvBookmarkList.View = System.Windows.Forms.View.Details;
            this.lvBookmarkList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvBookmarkList_DrawColumnHeader);
            this.lvBookmarkList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvBookmarkList_DrawItem);
            this.lvBookmarkList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvBookmarkList_ItemDrag);
            this.lvBookmarkList.SizeChanged += new System.EventHandler(this.lvBookmarkList_SizeChanged);
            this.lvBookmarkList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvBookmarkList_DragDrop);
            this.lvBookmarkList.DragOver += new System.Windows.Forms.DragEventHandler(this.lvBookmarkList_DragOver);
            this.lvBookmarkList.DragLeave += new System.EventHandler(this.lvBookmarkList_DragLeave);
            this.lvBookmarkList.DoubleClick += new System.EventHandler(this.lvBookmarkList_DoubleClick);
            this.lvBookmarkList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvBookmarkList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名稱";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "位置";
            this.columnHeader2.Width = 240;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btDeleteBookmark);
            this.panel4.Controls.Add(this.btEditBookmark);
            this.panel4.Controls.Add(this.btAddBookmark);
            this.panel4.Controls.Add(this.btAddBookmarkFolder);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(478, 47);
            this.panel4.TabIndex = 1;
            // 
            // btDeleteBookmark
            // 
            this.btDeleteBookmark.Image = global::CBReader.Properties.Resources.BookmarkDelete;
            this.btDeleteBookmark.Location = new System.Drawing.Point(142, 5);
            this.btDeleteBookmark.Name = "btDeleteBookmark";
            this.btDeleteBookmark.Size = new System.Drawing.Size(36, 36);
            this.btDeleteBookmark.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btDeleteBookmark, "刪除");
            this.btDeleteBookmark.UseVisualStyleBackColor = true;
            this.btDeleteBookmark.Click += new System.EventHandler(this.btDeleteBookmark_Click);
            // 
            // btEditBookmark
            // 
            this.btEditBookmark.Image = global::CBReader.Properties.Resources.BookmarkEdit;
            this.btEditBookmark.Location = new System.Drawing.Point(100, 5);
            this.btEditBookmark.Name = "btEditBookmark";
            this.btEditBookmark.Size = new System.Drawing.Size(36, 36);
            this.btEditBookmark.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btEditBookmark, "編輯");
            this.btEditBookmark.UseVisualStyleBackColor = true;
            this.btEditBookmark.Click += new System.EventHandler(this.btEditBookmark_Click);
            // 
            // btAddBookmark
            // 
            this.btAddBookmark.Image = global::CBReader.Properties.Resources.NewBookmark;
            this.btAddBookmark.Location = new System.Drawing.Point(49, 5);
            this.btAddBookmark.Name = "btAddBookmark";
            this.btAddBookmark.Size = new System.Drawing.Size(36, 36);
            this.btAddBookmark.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btAddBookmark, "新增書籤");
            this.btAddBookmark.UseVisualStyleBackColor = true;
            this.btAddBookmark.Click += new System.EventHandler(this.btAddBookmark_Click);
            // 
            // btAddBookmarkFolder
            // 
            this.btAddBookmarkFolder.Image = global::CBReader.Properties.Resources.NewFolder;
            this.btAddBookmarkFolder.Location = new System.Drawing.Point(7, 5);
            this.btAddBookmarkFolder.Name = "btAddBookmarkFolder";
            this.btAddBookmarkFolder.Size = new System.Drawing.Size(36, 36);
            this.btAddBookmarkFolder.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btAddBookmarkFolder, "新增目錄");
            this.btAddBookmarkFolder.UseVisualStyleBackColor = true;
            this.btAddBookmarkFolder.Click += new System.EventHandler(this.btAddBookmarkFolder_Click);
            // 
            // BookmarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(736, 440);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BookmarkForm";
            this.Text = "書籤管理員";
            this.Shown += new System.EventHandler(this.BookmarkForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewFolder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lvBookmarkList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imglBookmark;
        private System.Windows.Forms.Button btAddBookmarkFolder;
        private System.Windows.Forms.Button btDeleteBookmark;
        private System.Windows.Forms.Button btEditBookmark;
        private System.Windows.Forms.Button btAddBookmark;
        public System.Windows.Forms.ToolTip toolTip1;
    }
}