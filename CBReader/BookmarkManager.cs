using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
    internal class BookmarkManager
    {
        private TreeView treeView;          // 書籤的樹
        public BookmarkItemRoot BookmarkRoot;   // 書籤的根

        public BookmarkManager(TreeView treeView, BookmarkItemRoot root)
        {
            this.treeView = treeView;
            BookmarkRoot = root;
        }

        // 加入書籤到指定的父書籤（高階）
        public void addBookmarkNode(TreeNode node, BookmarkItem newBookmark)
        {
            BookmarkItem parent;
            if(node == null) {
                parent = BookmarkRoot;
            } else {
                parent = node.Tag as BookmarkItem;
            }
            
            if(parent.IsFolder) {
                // node 是目錄
                parent.addBookmark(newBookmark);

                TreeNode newNode = new TreeNode();
                newNode.Text = newBookmark.Title;
                newNode.Tag = newBookmark;
                if (newBookmark.IsFolder) {
                    newNode.ImageIndex = 0;
                } else {
                    newNode.ImageIndex = 2;
                }
                newNode.SelectedImageIndex = newNode.ImageIndex;
                if (node == null) {
                    treeView.Nodes.Add(newNode);
                } else {
                    node.Nodes.Add(newNode);
                }
            } else {
                // node 是節點
                if(node.Parent == null) {
                    // node 是第一層節點
                    //BookmarkRoot.addBookmark(newBookmark);
                    moveA2BBottom(newBookmark, parent);

                    TreeNode newNode = new TreeNode();
                    newNode.Text = newBookmark.Title;
                    newNode.Tag = newBookmark;
                    if (newBookmark.IsFolder) {
                        newNode.ImageIndex = 0;
                    } else {
                        newNode.ImageIndex = 2;
                    }
                    newNode.SelectedImageIndex = newNode.ImageIndex;
                    int i = node.Index;
                    treeView.Nodes.Insert(i + 1, newNode);
                } else {
                    // node 是第n層節點
                    //parent.Parent.addBookmark(newBookmark);
                    moveA2BBottom(newBookmark, parent);

                    TreeNode newNode = new TreeNode();
                    newNode.Text = newBookmark.Title;
                    newNode.Tag = newBookmark;
                    if (newBookmark.IsFolder) {
                        newNode.ImageIndex = 0;
                    } else {
                        newNode.ImageIndex = 2;
                    }
                    newNode.SelectedImageIndex = newNode.ImageIndex;
                    int i = node.Index;
                    node.Parent.Nodes.Insert(i + 1, newNode);
                }
            }
        }

        // 加入書籤到指定的父書籤（低階）
        public void addBookmark(BookmarkItem parent, BookmarkItem newBookmark)
        {
            if (parent.Children == null) { return; }
            parent.Children.Add(newBookmark);
            newBookmark.Parent = parent; // 設定新書籤的父書籤
            updateTreeView();
        }


        // 刪除書籤
        public void removeBookmark(BookmarkItem bookmark)
        {
            bookmark.Parent.Children.Remove(bookmark);
            bookmark.Parent = null; // 移除書籤的父書籤關聯
            //updateTreeView();
        }

        public void removeBookmark(TreeNode node)
        {
            node.Remove();
            BookmarkItem item = node.Tag as BookmarkItem;
            removeBookmark(item);
        }

        // 把書籤 A 移到 B 的上方
        public void moveA2BTop(BookmarkItem a, BookmarkItem b)
        {
            // 有時 a 是新建的，沒有 Parent
            if (a.Parent != null) {
                a.Parent.Children.Remove(a);
            }
            int indexOfB = b.Parent.Children.IndexOf(b);
            b.Parent.Children.Insert(indexOfB, a);
            a.Parent = b.Parent;
        }

        // 把書籤 A 移到 B 的下方
        public void moveA2BBottom(BookmarkItem a, BookmarkItem b)
        {
            // 有時 a 是新建的，沒有 Parent
            if (a.Parent != null) {
                a.Parent.Children.Remove(a);
            }
            int indexOfB = b.Parent.Children.IndexOf(b);
            b.Parent.Children.Insert(indexOfB + 1, a);
            a.Parent = b.Parent;
        }

        // 把書籤 A 移到 B 的裡面
        public void moveAIntoB(BookmarkItem a, BookmarkItem b)
        {
            a.Parent.Children.Remove(a);
            b.Children.Add(a);
            a.Parent = b;
        }

        // 某個目錄樹節點重新排序，排序目錄的部份
        // 理由可能是目錄有移動了

        public void noteUpdateFolder(TreeNode node)
        {
            BookmarkItem bookmark = node.Tag as BookmarkItem;
            int i = 0;
            foreach (var item in bookmark.Children) {
                if (item.IsFolder) {
                    treeViewFolderNoteFindItemMove2NewPos(node, item, i);
                    i++;
                }
            }
        }

        // 目錄樹的節點找到 Item 位置後，將它移到第 n 個節點

        private void treeViewFolderNoteFindItemMove2NewPos(TreeNode node, BookmarkItem bookmark, int i)
        {
            if (node.Nodes.Count == 0) {
                return;
            }
            foreach (TreeNode n in node.Nodes) {
                if ((BookmarkItem)n.Tag == bookmark) {
                    n.Text = bookmark.Title;    // 在更改名稱時，也需要同步
                    n.Remove();
                    node.Nodes.Insert(i, n);
                    return;
                }
            }
        }


        // 更新 TreeView 顯示
        // bOnlyFolder : true 表示只呈現目錄
        public void updateTreeView(bool bOnlyFolder = false)
        {
            treeView.Nodes.Clear();

            if (bOnlyFolder) {
                // 只有目錄，所以要有第一層
                TreeNode node = createBookmarkNode(BookmarkRoot, bOnlyFolder);
                treeView.Nodes.Add(node);
            } else {
                // 沒有 Root 那一層
                foreach (var bookmark in BookmarkRoot.Children) {
                    TreeNode node = createBookmarkNode(bookmark, bOnlyFolder);
                    treeView.Nodes.Add(node);
                }
            }
        }

        // 將書籤轉換成 TreeNode
        private TreeNode createBookmarkNode(BookmarkItem bookmark, bool bOnlyFolder)
        {
            TreeNode node = new TreeNode(bookmark.Title);
            node.Tag = bookmark;
            if (bookmark.IsFolder == true) {
                //node.BackColor = System.Drawing.Color.Yellow;
                node.ImageIndex = 0;
            } else {
                node.ImageIndex = 2;
            }
            node.SelectedImageIndex = node.ImageIndex;

            if (bookmark.IsFolder) {
                foreach (var child in bookmark.Children) {
                    if (bOnlyFolder == false || child.IsFolder == true) {
                        TreeNode childNode = createBookmarkNode(child, bOnlyFolder);
                        node.Nodes.Add(childNode);
                    }
                }
            }

            return node;
        }


        // 輔助函式：檢查節點是否是目標節點的祖先
        public bool IsNodeAncestor(TreeNode node, TreeNode targetNode)
        {
            if (node.Nodes.Count == 0) {
                // 既然我沒有子節點，我就不會是目標的祖先
                return false;
            }
            TreeNode parentNode = targetNode;
            while (parentNode != null) {
                if (parentNode == node) {
                    return true;
                }
                parentNode = parentNode.Parent;
            }
            return false;
        }

        // 輔助函式：檢查節點是否是目標節點的祖先
        public bool IsBookAncestor(BookmarkItem book, BookmarkItem targetBook)
        {
            if (book.IsFolder == false) {
                // 既然我沒有子節點，我就不會是目標的祖先
                return false;
            }
            BookmarkItem parentBook = targetBook;
            while (parentBook != null) {
                if (parentBook == book) {
                    return true;
                }
                parentBook = parentBook.Parent;
            }
            return false;
        }

        // 在 node 底下尋找 Tag 為 item 的 node
        public TreeNode FindNodeByBookmark(TreeNode node, BookmarkItem item)
        {
            foreach(TreeNode child in node.Nodes) {
                BookmarkItem bookmark = child.Tag as BookmarkItem;
                if (bookmark == item) {
                    return child;
                }
            }
            return null;
        }

    }
}
