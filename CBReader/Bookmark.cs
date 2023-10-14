using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CBReader
{
    public partial class BookmarkForm : Form
    {
        MainForm mainForm;
        BookmarkEditorForm bookmarkEditorForm;
        BookmarkFolderEditorForm bookmarkFolderEditorForm;
        BookmarkManager BookmarkTreeFolder; // 只有目錄，編輯用的
        public BookmarkItemRoot BookmarkRoot;          // 書籤的根

        // treeView 移動的節點和目標
        private TreeNode draggedNode;
        private TreeNode targetNode;

        // listView 移動的節點和目標
        private ListViewItem draggedItem;
        private ListViewItem targetItem;

        private TreeNode treeviewFoldrSelected = null; // 已經選取的目錄樹節點

        // 畫線用的
        //private bool insertAbove;
        int insertType = 0;             // 1: 插入在上方，2:放入節點中，3:插入在下方

        public BookmarkForm(MainForm main, BookmarkItemRoot book)
        {
            InitializeComponent();
            mainForm = main;
            bookmarkEditorForm = main.bookmarkEditorForm;
            bookmarkFolderEditorForm = main.bookmarkFolderEditorForm;
            BookmarkRoot = book;
            BookmarkTreeFolder = new BookmarkManager(treeViewFolder, BookmarkRoot);
        }

        private void BookmarkForm_Shown(object sender, EventArgs e)
        {
            BookmarkTreeFolder.updateTreeView(true);
            treeViewFolder.ExpandAll();
            treeViewFolder.SelectedNode = treeViewFolder.Nodes[0];
            lvBookmarkList_SizeChanged(this, null);
        }

        // 將某個目錄的內容複製到 ListView
        private void treeViewFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeviewFoldrSelected = treeViewFolder.SelectedNode;
            //if (node == null) { return; }
            BookmarkItem bookmark = (BookmarkItem)treeviewFoldrSelected.Tag;
            lvBookmarkList.Items.Clear();
            foreach (BookmarkItem child in bookmark.Children) {
                ListViewItem item = new ListViewItem();
                item.Tag = child;
                item.Text = child.Title;
                if (child.IsFolder) {
                    item.Text = "🗁" + child.Title;  // 📁📂🗀🗁
                    //item.ForeColor = Color.Blue;
                }
                item.SubItems.Add(child.URL);
                lvBookmarkList.Items.Add(item);
            }
        }

        /// =================================================
        /// 拖曳節點
        /// =================================================

        // 開始拖曳節點
        private void treeViewFolder_ItemDrag(object sender, ItemDragEventArgs e)
        {
            targetNode = null;                  // 重置目標節點
            insertType = 0;                     // 插入模式歸 0
            treeViewFolder.Invalidate();        // 畫面重新整理
            draggedNode = e.Item as TreeNode;   // 要移動的節點
            // 根節點不能拖曳
            if (draggedNode != treeViewFolder.Nodes[0]) {
                DoDragDrop(draggedNode, DragDropEffects.Move);  // 開始拖曳
            }
        }

        // 開始拖曳節點
        private void lvBookmarkList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            targetItem = null;                  // 重置目標節點
            insertType = 0;                     // 插入模式歸 0
            lvBookmarkList.Invalidate();              // 畫面重新整理
            draggedItem = e.Item as ListViewItem;   // 要移動的節點
            DoDragDrop(draggedItem, DragDropEffects.Move);  // 開始拖曳
        }

        // =========================================

        // 拖曳經過其它節點上方
        private void treeViewFolder_DragOver(object sender, DragEventArgs e)
        {
            //TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            Point point = treeViewFolder.PointToClient(new Point(e.X, e.Y));
            TreeNode newTargetNode = treeViewFolder.GetNodeAt(point);     // 目前目標

            if (newTargetNode == null) {
                int count = treeViewFolder.Nodes.Count;
                if (count > 0) {
                    newTargetNode = treeViewFolder.Nodes[count - 1];
                }
            }

            // 切換目標後，畫線才會重畫，否則會一直閃爍
            if (newTargetNode != targetNode) {
                treeViewFolder.Invalidate();
                if (targetNode != null) {
                    //targetNode.BackColor = Color.White;
                    //targetNode.ForeColor = Color.Black;
                }
                targetNode = newTargetNode;
            }

            // 如果滑鼠靠近 TreeView 的上方或下方邊界，則捲動捲軸
            int scrollMargin = 20; // 捲動邊界的大小，可以自行調整
            if (targetNode != null) {
                if (point.Y < scrollMargin) {
                    // 捲動到上一個可見節點
                    TreeNode prevNode = targetNode.PrevVisibleNode;
                    if (prevNode != null) {
                        prevNode.EnsureVisible();
                        treeViewFolder.Invalidate();
                    }
                    //e.Effect = DragDropEffects.Scroll;
                } else if (point.Y > treeViewFolder.Height - scrollMargin) {
                    // 捲動到下一個可見節點
                    TreeNode nextNode = targetNode.NextVisibleNode;
                    if (nextNode != null) {
                        nextNode.EnsureVisible();
                        treeViewFolder.Invalidate();
                    }
                    //e.Effect = DragDropEffects.Scroll;
                }
            }

            if ((draggedNode != null || draggedItem != null) && targetNode != null && newTargetNode != draggedNode) {
                // 判斷拖動節點是否可以移動到目標位置（同一層或下一層）
                //e.Effect = CanMoveToTargetNode(draggedNode, newTargetItem) ? DragDropEffects.Move : DragDropEffects.None;

                // 如果目標節點是收合的，則在停頓一段時間後自動展開
                if (!targetNode.IsExpanded) {
                    var timer = new Timer();
                    timer.Interval = 1000; // 設定停頓時間，這裡設為1秒（1000毫秒）
                    timer.Tick += (s, args) => {
                        if (targetNode != null) {
                            targetNode.Expand();
                            //treeViewFolder.Invalidate();
                        }
                        timer.Stop();
                    };
                    timer.Start();
                }

                // 判斷拖放提示線位置
                int newInsertType = 0;
                BookmarkItem bookmark = (BookmarkItem)targetNode.Tag;
                // 其實底下一定是目錄節點
                if (bookmark.IsFolder) {
                    if (targetNode != treeViewFolder.Nodes[0] && point.Y - targetNode.Bounds.Top < 8) {
                        // 插入在上方，前提是目標節點不可以是根目錄
                        newInsertType = 1;
                    } else if (targetNode != treeViewFolder.Nodes[0] && targetNode.Bounds.Bottom - point.Y < 8) {
                        // 插入在下方，前提是目標節點不可以是根目錄
                        newInsertType = 3;
                    } else {
                        // 放入目錄中
                        newInsertType = 2;
                    }
                } else {
                    // 一般節點 (這裡應該不會發生）
                    if (point.Y - targetNode.Bounds.Top < targetNode.Bounds.Height / 2) {
                        // 插入在上方
                        newInsertType = 1;
                    } else {
                        // 插入在下方
                        newInsertType = 3;
                    }
                }

                // 拖放線有改變才要重整畫面
                if (newInsertType != insertType) {
                    treeViewFolder.Invalidate();
                    insertType = newInsertType;
                }

                // 繪製拖放提示線
                if (insertType == 1) {
                    using (Pen pen = new Pen(Color.LightBlue, 3)) {
                        treeViewFolder.CreateGraphics().DrawLine(pen, targetNode.Bounds.Left - 20, targetNode.Bounds.Top, targetNode.Bounds.Left + 200, targetNode.Bounds.Top);

                        //targetNode.BackColor = Color.White;
                        //targetNode.ForeColor = Color.Black;
                    }
                } else if (insertType == 3) {
                    using (Pen pen = new Pen(Color.LightBlue, 3)) {
                        treeViewFolder.CreateGraphics().DrawLine(pen, targetNode.Bounds.Left - 20, targetNode.Bounds.Bottom, targetNode.Bounds.Left + 200, targetNode.Bounds.Bottom);

                        //targetNode.BackColor = Color.White;
                        //targetNode.ForeColor = Color.Black;
                    }
                } else {
                    using (Pen pen = new Pen(Color.LightGreen, 4)) {
                        //targetNode.BackColor = Color.LightPink;
                        //targetNode.ForeColor = Color.Red;
                        treeViewFolder.CreateGraphics().DrawRectangle(pen, targetNode.Bounds);
                    }
                }
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        // 拖曳經過其它節點上方
        private void lvBookmarkList_DragOver(object sender, DragEventArgs e)
        {
            if (draggedItem == null && draggedNode == null) {
                return;
            }
            Point point = lvBookmarkList.PointToClient(new Point(e.X, e.Y));
            ListViewItem newTargetItem = lvBookmarkList.GetItemAt(point.X, point.Y);     // 目前目標

            if (newTargetItem == null) {
                int count = lvBookmarkList.Items.Count;
                if (count > 0) {
                    newTargetItem = lvBookmarkList.Items[count - 1];
                }
            }

            // 切換目標後，畫線才會重畫，否則會一直閃爍
            if (newTargetItem != targetItem) {
                lvBookmarkList.Invalidate();
                if (targetItem != null) {
                    //targetItem.BackColor = Color.White;
                    //targetItem.ForeColor = Color.Black;
                }
                targetItem = newTargetItem;
            }

            // 如果滑鼠靠近 TreeView 的上方或下方邊界，則捲動捲軸
            int scrollMargin = 20; // 捲動邊界的大小，可以自行調整
            if (targetItem != null) {
                if (point.Y < scrollMargin + 10) {
                    // 捲動到上一個可見節點
                    if (targetItem.Index > 0) {
                        ListViewItem prevItem = lvBookmarkList.Items[targetItem.Index - 1];
                        prevItem.EnsureVisible();
                        lvBookmarkList.Invalidate();
                    }
                    //e.Effect = DragDropEffects.Scroll;
                } else if (point.Y > lvBookmarkList.Height - scrollMargin) {
                    // 捲動到下一個可見節點
                    if (targetItem.Index < lvBookmarkList.Items.Count - 1) {
                        ListViewItem nextItem = lvBookmarkList.Items[targetItem.Index + 1];
                        nextItem.EnsureVisible();
                        lvBookmarkList.Invalidate();
                    }
                    //e.Effect = DragDropEffects.Scroll;
                }
            }

            if ((draggedNode != null || draggedItem != null) && targetItem != null && newTargetItem != draggedItem) {
                // 判斷拖動節點是否可以移動到目標位置（同一層或下一層）
                //e.Effect = CanMoveToTargetNode(draggedNode, newTargetItem) ? DragDropEffects.Move : DragDropEffects.None;

                // 判斷拖放提示線位置
                int newInsertType = 0;
                BookmarkItem bookmark = (BookmarkItem)targetItem.Tag;
                if (bookmark.IsFolder) {
                    // 目錄節點
                    if (point.Y - targetItem.Bounds.Top < 8) {
                        // 插入在上方
                        newInsertType = 1;
                    } else if (targetItem.Bounds.Bottom - point.Y < 8) {
                        // 插入在下方
                        newInsertType = 3;
                    } else {
                        // 放入目錄中
                        newInsertType = 2;
                    }
                } else {
                    // 一般節點
                    if (point.Y - targetItem.Bounds.Top < targetItem.Bounds.Height / 2) {
                        // 插入在上方
                        newInsertType = 1;
                    } else {
                        // 插入在下方
                        newInsertType = 3;
                    }
                }

                // 拖放線有改變才要重整畫面
                if (newInsertType != insertType) {
                    lvBookmarkList.Invalidate();
                    insertType = newInsertType;
                }

                // 繪製拖放提示線
                if (insertType == 1) {
                    using (Pen pen = new Pen(Color.LightBlue, 3)) {
                        lvBookmarkList.CreateGraphics().DrawLine(pen, targetItem.Bounds.Left - 20, targetItem.Bounds.Top, targetItem.Bounds.Width, targetItem.Bounds.Top);

                        //targetItem.BackColor = Color.White;
                        //targetItem.ForeColor = Color.Black;
                    }
                } else if (insertType == 3) {
                    using (Pen pen = new Pen(Color.LightBlue, 3)) {
                        lvBookmarkList.CreateGraphics().DrawLine(pen, targetItem.Bounds.Left - 20, targetItem.Bounds.Bottom, targetItem.Bounds.Width, targetItem.Bounds.Bottom);

                        //targetItem.BackColor = Color.White;
                        //targetItem.ForeColor = Color.Black;
                    }
                } else {
                    using (Pen pen = new Pen(Color.LightGreen, 4)) {
                        //targetItem.BackColor = Color.LightPink;
                        //targetItem.ForeColor = Color.Red;
                        lvBookmarkList.CreateGraphics().DrawRectangle(pen, targetItem.Bounds);
                    }
                }
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        // =========================================

        // 拖曳到達目標
        private void treeViewFolder_DragDrop(object sender, DragEventArgs e)
        {
            //TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            //TreeNode targetNode = treeView.GetNodeAt(treeView.PointToClient(new Point(e.X, e.Y)));

            bool bUpdateListView = false;

            // 來源是同一棵目錄樹
            if (draggedNode != null) {
                // 如果拖曳的來源或目標是在已選擇的節點中，則 listview 要重整
                if ((draggedNode.Parent == treeviewFoldrSelected) || (targetNode.Parent == treeviewFoldrSelected)) {
                    bUpdateListView = true;
                }

                if (targetNode != null) {
                    // 確認目標節點不是要移動節點的子節點，避免出現無窮迴圈
                    if (!BookmarkTreeFolder.IsNodeAncestor(draggedNode, targetNode)) {
                        TreeNodeCollection parentNodes;

                        if (targetNode.Parent == null) {
                            parentNodes = treeViewFolder.Nodes;
                        } else {
                            parentNodes = targetNode.Parent.Nodes;
                        }
                        // 插入節點上方
                        if (insertType == 1) {
                            draggedNode.Remove();
                            int i = parentNodes.IndexOf(targetNode);
                            parentNodes.Insert(i, draggedNode);
                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveA2BTop((BookmarkItem)draggedNode.Tag, (BookmarkItem)targetNode.Tag);
                        }
                        // 放入目錄中
                        if (insertType == 2) {
                            draggedNode.Remove();
                            targetNode.Nodes.Add(draggedNode);
                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveAIntoB((BookmarkItem)draggedNode.Tag, (BookmarkItem)targetNode.Tag);
                            if (targetNode == treeviewFoldrSelected) {
                                bUpdateListView = true;
                            }
                        }
                        // 插入節點下方
                        if (insertType == 3) {
                            draggedNode.Remove();
                            int i = parentNodes.IndexOf(targetNode);
                            parentNodes.Insert(i + 1, draggedNode);
                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveA2BBottom((BookmarkItem)draggedNode.Tag, (BookmarkItem)targetNode.Tag);
                        }

                        //targetNode.BackColor = Color.White;
                        //targetNode.ForeColor = Color.Black;

                        // 如果拖曳的來源或目標是在已選擇的節點中，則 listview 要重整

                        if (bUpdateListView) {
                            treeViewFolder_AfterSelect(this, null);
                        }
                    }
                }
            }
            // 來源是 ListView
            else if (draggedItem != null) {

                List<ListViewItem> items = new List<ListViewItem>();

                foreach (ListViewItem item in lvBookmarkList.SelectedItems) {
                    items.Add(item);
                }

                if (insertType == 3) {
                    items.Reverse();
                }

                foreach (ListViewItem draggedItem in items) {

                    // 如果拖曳的來源或目標是在已選擇的節點中，則 listview 要重整

                    // 來源節點的書籤
                    BookmarkItem draggedBook = draggedItem.Tag as BookmarkItem;
                    // 目的節點的書籤
                    BookmarkItem targetBook = targetNode.Tag as BookmarkItem;
                    // 來源節點在目錄樹中的節點位置
                    TreeNode draggedItem2Node = null;
                    if (draggedBook.IsFolder) {
                        draggedItem2Node = BookmarkTreeFolder.FindNodeByBookmark(treeviewFoldrSelected, draggedBook);
                        /*
                        foreach (TreeNode node in treeviewFoldrSelected.Nodes) {
                            if (node.Tag == draggedBook) {
                                // 找到來源節點
                                draggedItem2Node = node;
                                break;
                            }
                        }
                        */
                        if (draggedItem2Node == null) {
                            // 有問題，沒找到來源
                            return;
                        }
                    }

                    if (targetNode != null) {
                        // 確認目標節點不是要移動節點的子節點，避免出現無窮迴圈
                        if (!BookmarkTreeFolder.IsBookAncestor(draggedBook, targetBook)) {
                            TreeNodeCollection parentNodes;

                            if (targetNode.Parent == null) {
                                parentNodes = treeViewFolder.Nodes;
                            } else {
                                parentNodes = targetNode.Parent.Nodes;
                            }
                            // 插入節點上方
                            if (insertType == 1) {
                                draggedItem.Remove();
                                // 如果節點是目錄
                                if (draggedItem2Node != null) {
                                    draggedItem2Node.Remove();
                                    int i = parentNodes.IndexOf(targetNode);
                                    parentNodes.Insert(i, draggedItem2Node);
                                }
                                // 書籤的位置也要處理
                                BookmarkTreeFolder.moveA2BTop(draggedBook, targetBook);
                                // 目標在所選的節點，則要更新 listview
                                if (targetNode.Parent == treeviewFoldrSelected) {
                                    bUpdateListView = true;
                                }
                            }
                            // 放入目錄中
                            if (insertType == 2) {
                                draggedItem.Remove();
                                // 如果節點是目錄
                                if (draggedItem2Node != null) {
                                    draggedItem2Node.Remove();
                                    targetNode.Nodes.Add(draggedItem2Node);
                                }
                                // 書籤的位置也要處理
                                BookmarkTreeFolder.moveAIntoB(draggedBook, targetBook);
                                // 目標在所選的節點，則要更新 listview
                                if (targetNode == treeviewFoldrSelected) {
                                    bUpdateListView = true;
                                }
                            }
                            // 插入節點下方
                            if (insertType == 3) {
                                draggedItem.Remove();
                                // 如果節點是目錄
                                if (draggedItem2Node != null) {
                                    draggedItem2Node.Remove();
                                    int i = parentNodes.IndexOf(targetNode);
                                    parentNodes.Insert(i + 1, draggedItem2Node);
                                }
                                // 書籤的位置也要處理
                                BookmarkTreeFolder.moveA2BBottom(draggedBook, targetBook);
                                // 目標在所選的節點，則要更新 listview
                                if (targetNode.Parent == treeviewFoldrSelected) {
                                    bUpdateListView = true;
                                }
                            }

                            //targetNode.BackColor = Color.White;
                            //targetNode.ForeColor = Color.Black;

                            // 如果拖曳的來源或目標是在已選擇的節點中，則 listview 要重整

                            if (bUpdateListView) {
                                treeViewFolder_AfterSelect(this, null);
                            }
                        }
                    }
                }
            }

            // 重置目標節點和拖放提示線
            draggedItem = null;
            draggedNode = null;
            targetNode = null;
            treeViewFolder.Invalidate();
        }

        private void lvBookmarkList_DragDrop(object sender, DragEventArgs e)
        {
            // 來源是 listview 本身
            if (draggedItem != null) {
                if (targetItem != null) {
                    // listview 多重選擇
                    List<ListViewItem> items = new List<ListViewItem>();
                    foreach (ListViewItem item in lvBookmarkList.SelectedItems) {
                        items.Add(item);
                    }
                    // 若是要插入節點下方要反向
                    if (insertType == 3) {
                        items.Reverse();
                    }
                    foreach (ListViewItem draggedItem in items) {
                        // 避免自己重複
                        if(draggedItem.Tag == targetItem.Tag) {
                            continue;
                        }
                        // 插入節點上方
                        if (insertType == 1) {
                            draggedItem.Remove();
                            int targetIndex = targetItem.Index;
                            lvBookmarkList.Items.Insert(targetIndex, draggedItem);
                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveA2BTop((BookmarkItem)draggedItem.Tag, (BookmarkItem)targetItem.Tag);
                            // listView 的目錄移動了，所以目錄樹也要移動
                            if (((BookmarkItem)draggedItem.Tag).IsFolder) {
                                BookmarkTreeFolder.noteUpdateFolder(treeviewFoldrSelected);
                            }
                        }
                        // 放入目錄中
                        if (insertType == 2) {
                            draggedItem.Remove();
                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveAIntoB((BookmarkItem)draggedItem.Tag, (BookmarkItem)targetItem.Tag);

                            // 書籤的位置也要處理
                            /*
                            BookmarkItem parentBookmark = (BookmarkItem) treeviewFoldrSelected.Tag;
                            BookmarkItem bookmark = (BookmarkItem) draggedItem.Tag;
                            BookmarkItem targetBookmark = (BookmarkItem) targetItem.Tag;
                            parentBookmark.Children.Remove(bookmark);
                            targetBookmark.Children.Add(bookmark);
                            bookmark.Parent = targetBookmark;
                            */
                            // listView 的目錄移動了，所以目錄樹也要移動
                            if (((BookmarkItem)draggedItem.Tag).IsFolder) {
                                // 先找出原來目錄樹的來源節點和目的節點
                                TreeNode source = null;
                                TreeNode target = null;
                                foreach (TreeNode node in treeviewFoldrSelected.Nodes) {
                                    if (node.Tag == draggedItem.Tag) {
                                        source = node;
                                    }
                                    if (node.Tag == targetItem.Tag) {
                                        target = node;
                                    }
                                }
                                if (source != null && target != null) {
                                    source.Remove();
                                    target.Nodes.Add(source);
                                }
                            }
                        }
                        // 插入節點下方
                        if (insertType == 3) {
                            draggedItem.Remove();
                            int targetIndex = targetItem.Index;
                            lvBookmarkList.Items.Insert(targetIndex + 1, draggedItem);
                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveA2BBottom((BookmarkItem)draggedItem.Tag, (BookmarkItem)targetItem.Tag);
                            // listView 的目錄移動了，所以目錄樹也要移動
                            if (((BookmarkItem)draggedItem.Tag).IsFolder) {
                                BookmarkTreeFolder.noteUpdateFolder(treeviewFoldrSelected);
                            }
                        }


                    }

                    //targetItem.BackColor = Color.White;
                    //targetItem.ForeColor = Color.Black;
                    // 更新書籤管理器中的書籤結構
                    // BookmarkTreeFolder.updateTreeView();
                }
            }
            // 來源是目錄樹
            else if (draggedNode != null) {
                if (targetItem != null) {
                    // 確認目標節點不是要移動節點的子節點，避免出現無窮迴圈
                    if (!BookmarkTreeFolder.IsNodeAncestor(draggedNode, treeviewFoldrSelected)) {
                        // 建立新的 listviewItem
                        ListViewItem newItem = new ListViewItem();
                        newItem.Tag = draggedNode.Tag;
                        newItem.Text = "🗁" + draggedNode.Text;
                        newItem.SubItems.Add("");
                        // 插入節點上方
                        if (insertType == 1) {
                            draggedNode.Remove();
                            int targetIndex = targetItem.Index;

                            lvBookmarkList.Items.Insert(targetIndex, newItem);

                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveA2BTop((BookmarkItem)draggedNode.Tag, (BookmarkItem)targetItem.Tag);
                            // listView 的目錄移動了，所以目錄樹也要移動
                            treeviewFoldrSelected.Nodes.Add(draggedNode);   // 先把來源丢入，底下再排序
                            BookmarkTreeFolder.noteUpdateFolder(treeviewFoldrSelected);
                        }
                        // 放入目錄中
                        if (insertType == 2) {
                            draggedNode.Remove();
                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveAIntoB((BookmarkItem)draggedNode.Tag, (BookmarkItem)targetItem.Tag);

                            // 移動目錄樹
                            // 先找出原來目錄樹的目的節點
                            TreeNode target = null;
                            foreach (TreeNode node in treeviewFoldrSelected.Nodes) {
                                if (node.Tag == targetItem.Tag) {
                                    target = node;
                                    target.Nodes.Add(draggedNode);
                                    break;
                                }
                            }
                        }
                        // 插入節點下方
                        if (insertType == 3) {
                            draggedNode.Remove();
                            int targetIndex = targetItem.Index;
                            lvBookmarkList.Items.Insert(targetIndex + 1, newItem);
                            // 書籤的位置也要處理
                            BookmarkTreeFolder.moveA2BBottom((BookmarkItem)draggedNode.Tag, (BookmarkItem)targetItem.Tag);
                            // listView 的目錄移動了，所以目錄樹也要移動
                            treeviewFoldrSelected.Nodes.Add(draggedNode);   // 先把來源丢入，底下再排序
                            BookmarkTreeFolder.noteUpdateFolder(treeviewFoldrSelected);
                        }
                    }
                    //targetItem.BackColor = Color.White;
                    //targetItem.ForeColor = Color.Black;
                    // 更新書籤管理器中的書籤結構
                    // BookmarkTreeFolder.updateTreeView();
                }
            }
            // 重置目標節點和拖放提示線
            draggedItem = null;
            draggedNode = null;
            targetItem = null;
            lvBookmarkList.Invalidate();
        }

        // =========================================

        // 離開拖曳區
        private void treeViewFolder_DragLeave(object sender, EventArgs e)
        {
            treeViewFolder.Invalidate();
        }

        private void lvBookmarkList_DragLeave(object sender, EventArgs e)
        {
            lvBookmarkList.Invalidate();
        }

        private void lvBookmarkList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // 使用背景色填充列標题區域
            if (mainForm.IsDarkTheme) {
                e.Graphics.FillRectangle(Brushes.Gray, e.Bounds);
            } else {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            e.DrawText();
        }

        private void lvBookmarkList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvBookmarkList_SizeChanged(object sender, EventArgs e)
        {
            int lastWidth = lvBookmarkList.ClientRectangle.Width - lvBookmarkList.Columns[0].Width;
            lvBookmarkList.Columns[1].Width = lastWidth;
            
        }

        private void btAddBookmarkFolder_Click(object sender, EventArgs e)
        {
            bookmarkFolderEditorForm.setFolderTitle("");

            DialogResult result = bookmarkFolderEditorForm.ShowDialog();
            if (result == DialogResult.OK) {
                string title = bookmarkFolderEditorForm.getFolderTitle();

                BookmarkItem item = new BookmarkItem(title);

                ListViewItem newItem = new ListViewItem();
                newItem.Tag = item;
                newItem.Text = "🗁" + item.Title;
                newItem.SubItems.Add("");

                ListViewItem targetItem = lvBookmarkList.FocusedItem;
                if (targetItem != null) {
                    int targetIndex = targetItem.Index;
                    lvBookmarkList.Items.Insert(targetIndex + 1, newItem);
                } else {
                    lvBookmarkList.Items.Add(newItem);
                }

                // 書籤的位置也要處理
                if (targetItem != null) {
                    BookmarkItem targetBookmark = (BookmarkItem)targetItem.Tag;
                    int indexOfTarget = targetBookmark.Parent.Children.IndexOf(targetBookmark);
                    targetBookmark.Parent.Children.Insert(indexOfTarget + 1, item);
                    item.Parent = targetBookmark.Parent;
                } else {
                    BookmarkItem parent = treeviewFoldrSelected.Tag as BookmarkItem;
                    parent.addBookmark(item);
                    item.Parent = parent;
                }

                // listView 的目錄新增了，所以目錄樹也要新增
                TreeNode newNode = new TreeNode();
                newNode.Tag = item;
                newNode.Text = item.Title;
                treeviewFoldrSelected.Nodes.Add(newNode);
                BookmarkTreeFolder.noteUpdateFolder(treeviewFoldrSelected);


                // 底下以後再研究
                //treeviewFoldrSelected.Nodes.Add(draggedNode);   // 先把來源丢入，底下再排序
                //BookmarkTreeFolder.addBookmarkNode(treeViewFolder.SelectedNode, item);

                if (treeViewFolder.SelectedNode != null) {
                    //BookmarkItem parent = treeViewFolder.SelectedNode.Tag as BookmarkItem;
                    //BookmarkTreeFolder.addBookmarkNode(treeViewFolder.SelectedNode, item);
                } else {
                    //BookmarkTree.addBookmarkNode(null, item);
                }
            }
        }

        private void btAddBookmark_Click(object sender, EventArgs e)
        {
            bookmarkEditorForm.setTitleAndLocation("", "");

            DialogResult result = bookmarkEditorForm.ShowDialog();
            if (result == DialogResult.OK) {
                (string, string) book = bookmarkEditorForm.getTitleAndLocation();

                BookmarkItem item = new BookmarkItem(book.Item1, book.Item2);

                ListViewItem newItem = new ListViewItem();
                newItem.Tag = item;
                newItem.Text = item.Title;
                newItem.SubItems.Add(item.URL);

                ListViewItem targetItem = lvBookmarkList.FocusedItem;
                if (targetItem != null) {
                    int targetIndex = targetItem.Index;
                    lvBookmarkList.Items.Insert(targetIndex + 1, newItem);
                } else {
                    lvBookmarkList.Items.Add(newItem);
                }

                // 書籤的位置也要處理
                if (targetItem != null) {
                    BookmarkItem targetBookmark = (BookmarkItem)targetItem.Tag;
                    int indexOfTarget = targetBookmark.Parent.Children.IndexOf(targetBookmark);
                    targetBookmark.Parent.Children.Insert(indexOfTarget + 1, item);
                    item.Parent = targetBookmark.Parent;
                } else {
                    BookmarkItem parent = treeviewFoldrSelected.Tag as BookmarkItem;
                    parent.addBookmark(item);
                    item.Parent = parent;
                }
            }
        }

        private void btEditBookmark_Click(object sender, EventArgs e)
        {
            if (lvBookmarkList.FocusedItem == null) { return; }

            BookmarkItem book = lvBookmarkList.FocusedItem.Tag as BookmarkItem;

            if (book.IsFolder) {
                // 目錄
                bookmarkFolderEditorForm.setFolderTitle(book.Title);

                DialogResult result = bookmarkFolderEditorForm.ShowDialog();
                if (result == DialogResult.OK) {
                    string title = bookmarkFolderEditorForm.getFolderTitle();
                    lvBookmarkList.FocusedItem.SubItems[0].Text = "🗁" + title;
                    lvBookmarkList.FocusedItem.SubItems[1].Text = "";

                    book.Title = title;
                    book.URL = "";

                    BookmarkTreeFolder.noteUpdateFolder(treeviewFoldrSelected);
                }
            } else {
                bookmarkEditorForm.setTitleAndLocation(book.Title, book.URL);

                DialogResult result = bookmarkEditorForm.ShowDialog();
                if (result == DialogResult.OK) {
                    (string, string) bookdata = bookmarkEditorForm.getTitleAndLocation();

                    lvBookmarkList.FocusedItem.SubItems[0].Text = bookdata.Item1;
                    lvBookmarkList.FocusedItem.SubItems[1].Text = bookdata.Item2;

                    book.Title = bookdata.Item1;
                    book.URL = bookdata.Item2;

                    BookmarkTreeFolder.noteUpdateFolder(treeviewFoldrSelected);
                }
            }

        }

        private void btDeleteBookmark_Click(object sender, EventArgs e)
        {
            if (lvBookmarkList.FocusedItem == null) { return; }
            
            DialogResult result;

            // listview 多重選擇
            if (lvBookmarkList.SelectedItems.Count == 1) {
                string sMsg = t("確定要刪除「%s」嗎？", "03006");
                sMsg = sMsg.Replace("%s", lvBookmarkList.FocusedItem.Text);
                result = MessageBox.Show(sMsg, t("刪除書籤", "03005"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            } else {
                string sMsg = t("確定要刪除 %d 筆記錄嗎？", "03007");
                sMsg = sMsg.Replace("%d", lvBookmarkList.SelectedItems.Count.ToString());
                result = MessageBox.Show(sMsg, t("刪除書籤", "03005"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            
            if (result == DialogResult.Yes) {
                // 選擇 Yes
                // 寫到這裡
                foreach (ListViewItem booklistitem in lvBookmarkList.SelectedItems) {
                    BookmarkItem item = booklistitem.Tag as BookmarkItem;
                    booklistitem.Remove();
                    if (item.IsFolder) {
                        // 整個 node 移除
                        TreeNode node = BookmarkTreeFolder.FindNodeByBookmark(treeviewFoldrSelected, item);
                        if(node != null) {
                            BookmarkTreeFolder.removeBookmark(node);
                        }
                        /*
                        foreach (TreeNode node in treeviewFoldrSelected.Nodes) {
                            if ((BookmarkItem)node.Tag == item) {
                                BookmarkTreeFolder.removeBookmark(node);
                                break;
                            }
                        }
                        */
                    } else {
                        // 只移除書籤
                        BookmarkTreeFolder.removeBookmark(item);
                    }
                }
            }
        }

        private void lvBookmarkList_KeyDown(object sender, KeyEventArgs e)
        {
            if(lvBookmarkList.FocusedItem != null) {
                BookmarkItem book = lvBookmarkList.FocusedItem.Tag as BookmarkItem;
                if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right) {
                    if(book.IsFolder) {
                        // 到下一層
                        TreeNode node = BookmarkTreeFolder.FindNodeByBookmark(treeviewFoldrSelected, book);
                        if (node != null) {
                            treeViewFolder.SelectedNode = node;
                            treeviewFoldrSelected = node;
                            lvBookmarkList.Focus();
                            if (lvBookmarkList.Items.Count > 0) {
                                lvBookmarkList.FocusedItem = lvBookmarkList.Items[0];
                            }
                        }
                    } else {
                        // 前進
                        mainForm.OpenBookmarkTreeViewItem(book);
                    }
                } else if (e.KeyCode == Keys.Delete) {
                    // 刪除
                    btDeleteBookmark_Click(sender, null);
                } 
            }

            if (e.KeyCode == Keys.Left) {
                // 上一層
                TreeNode node = treeviewFoldrSelected.Parent;
                if (node != null) {
                    treeViewFolder.SelectedNode = node;
                    treeviewFoldrSelected = node;
                    lvBookmarkList.Focus();
                    lvBookmarkList.FocusedItem = lvBookmarkList.Items[0];
                }
            }
        }

        private void lvBookmarkList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = lvBookmarkList.FocusedItem;
            if (item != null) {
                BookmarkItem book = lvBookmarkList.FocusedItem.Tag as BookmarkItem;
                if (book.IsFolder) {
                    // 到下一層
                    TreeNode node = BookmarkTreeFolder.FindNodeByBookmark(treeviewFoldrSelected, book);
                    if (node != null) {
                        treeViewFolder.SelectedNode = node;
                        treeviewFoldrSelected = node;
                        lvBookmarkList.Focus();
                        if (lvBookmarkList.Items.Count > 0) {
                            lvBookmarkList.FocusedItem = lvBookmarkList.Items[0];
                        }
                    }
                } else {
                    // 前進
                    mainForm.OpenBookmarkTreeViewItem(book);
                }
            }
        }

        // 專門處理字串語系的函數
        string t(string message, string msgId)
        {
            return mainForm.language.GetMessage(message, msgId);
        }
    }
}
