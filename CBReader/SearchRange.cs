using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows;
using System.Windows.Forms;
//using System.Windows.Media;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace CBReader
{
    public partial class SearchRangeForm : Form
    {
        MainForm mainForm;
        Theme theme;

        // 定義 TreeNode 狀態的列舉
        public enum NodeCheckState
        {
            Unchecked = 0,  // 0 代表 Unchecked
            Checked = 1,    // 1 代表 Checked
            Mix = 2         // 2 代表 Mix
        }

        public SearchRangeForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
            theme = mainForm.theme;
            HideTabHeader();
            listBox.SelectedIndex = 0;
            tabControl.SelectedTab = tpBulei;
            tabControl.Top -= 1;
            tabControl.Height += 5;

            // 開啟 TreeView 的 CheckBox 功能
            tvSutra.CheckBoxes = true;
        }

        void HideTabHeader()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabStop = false;
        }

        // 讀取 JSON 並顯示在 TreeView
        private void LoadJsonToTreeView()
        {
            try {
                // 讀取 SutraList.json 檔案
                string jsonString = File.ReadAllText(mainForm.Bookcase.CBETA.Dir + "/searchrange/SutraList.json");

                // 反序列化為 List<SearchLimitedRange>
                List<SearchLimitedRange> roots = JsonSerializer.Deserialize<List<SearchLimitedRange>>(jsonString);

                // 清空 TreeView
                tvSutra.Nodes.Clear();

                // 將根節點加入 TreeView
                if (roots != null) {
                    foreach (var root in roots) {
                        TreeNode rootNode = new TreeNode(root.Title);
                        rootNode.Tag = NodeCheckState.Unchecked;   // Tag 用來記錄 CheckBox 狀態
                        tvSutra.Nodes.Add(rootNode);

                        // 遞迴加入子節點
                        AddChildrenToTreeNode(rootNode, root.Children);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(t("載入 JSON 檔案時發生錯誤：","04005") + ex.Message, "CBReader", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 遞迴將子節點加入到 TreeNode
        private void AddChildrenToTreeNode(TreeNode parentNode, List<SearchLimitedRange> children)
        {
            if (children == null) return;

            foreach (var child in children) {
                TreeNode childNode = new TreeNode(child.Title);
                childNode.Tag = NodeCheckState.Unchecked;   // Tag 用來記錄 CheckBox 狀態
                parentNode.Nodes.Add(childNode);

                // 遞迴處理下一層的子節點
                AddChildrenToTreeNode(childNode, child.Children);
            }
        }

        // 當 checkbox 被勾選/取消勾選時觸發
        private void tvSutra_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 變更當前節點的文字顏色
            // e.Node.BackColor = e.Node.Checked ? Color.LightBlue : Color.White;

            var themeColor = mainForm.IsDarkTheme ? theme.darkColors : theme.lightColors;

            e.Node.Tag = e.Node.Checked ? NodeCheckState.Checked : NodeCheckState.Unchecked;

            if (e.Node.Checked) {
                // e.Node.BackColor = Color.LightBlue;
                // 底下其實沒什麼實際作用，但會觸發重繪，重繪時會再處理一次背景色 :)
                //e.Node.BackColor = themeColor.TreeViewCheckedBack;
            } else {
                // 底下其實沒什麼實際作用，但會觸發重繪，重繪時會再處理一次背景色 :)
                //e.Node.BackColor = Color.Empty;
            }
            e.Node.BackColor = Color.Empty;
            // Redraw the node to reflect the new state

            // 避免重入，當節點變化時阻止其他操作
            if (e.Action != TreeViewAction.Unknown) {
                // 先處理子節點的勾選
                SetChildNodesChecked(e.Node, e.Node.Checked);
                // 然後向上處理父節點的勾選狀態
                UpdateParentNodes(e.Node);
            }
            // 觸發重繪節點，範圍包括 checkbox （要向左 15 個px，否則 checkbox 不會即時更新）
            Rectangle bounds = e.Node.Bounds;
            bounds.X -= 15;
            bounds.Width += 15;
            tvSutra.Invalidate(bounds);
        }

        // 設置子節點的勾選狀態
        private void SetChildNodesChecked(TreeNode parentNode, bool isChecked)
        {
            foreach (TreeNode childNode in parentNode.Nodes) {
                childNode.Checked = isChecked;
                //childNode.Tag = childNode.Checked ? NodeCheckState.Checked : NodeCheckState.Unchecked;
                //childNode.BackColor = childNode.Checked ? Color.LightBlue : Color.White;
                SetChildNodesChecked(childNode, isChecked); // 遞迴設定所有子節點
            }
        }

        // 更新父節點的狀態
        private void UpdateParentNodes(TreeNode childNode)
        {
            if (childNode.Parent == null) return;

            bool allChecked = true;
            bool noneChecked = true;

            foreach (TreeNode siblingNode in childNode.Parent.Nodes) {
                if ((NodeCheckState)siblingNode.Tag == NodeCheckState.Checked) {
                    noneChecked = false;
                } else if ((NodeCheckState)siblingNode.Tag == NodeCheckState.Mix) {
                    allChecked = false;
                    noneChecked = false;
                } else if ((NodeCheckState)siblingNode.Tag == NodeCheckState.Unchecked) {
                    allChecked = false;
                }
            }
            
            var themeColor = mainForm.IsDarkTheme ? theme.darkColors : theme.lightColors;

            if (allChecked) {
                childNode.Parent.Checked = true; // 若所有子節點都勾選，勾選父節點
                childNode.Parent.Tag = NodeCheckState.Checked;
                // 底下不用了，改成自行重繪節點來處理
                //childNode.Parent.BackColor = themeColor.TreeViewCheckedBack;
            } else if (noneChecked) {
                childNode.Parent.Checked = false; // 若所有子節點都未勾選，取消勾選父節點
                childNode.Parent.Tag = NodeCheckState.Unchecked;
                //childNode.Parent.BackColor = Color.Empty;
            } else {
                childNode.Parent.Checked = false; // 若所有子節點都未勾選，取消勾選父節點
                childNode.Parent.Tag = NodeCheckState.Mix;
                //childNode.Parent.BackColor = themeColor.TreeViewMixBack; // 部分子節點勾選，設置父節點為中間狀態
            }
            // 後來發現可以不用寫，也會觸發重繪節點
            //tvSutra.Invalidate(childNode.Bounds);

            // 向上遞迴處理父節點
            UpdateParentNodes(childNode.Parent);
            // 後來發現可以不用寫，也會觸發重繪節點
            //tvSutra.Invalidate(childNode.Bounds);
        }

        // 處理部類
        void BuleiSelect()
        {
            // 逐一搜尋樹狀
            for (int i = 0; i < tvBulei.Nodes.Count; i++) {
                if (tvBulei.Nodes[i].Checked) {
                    string sBuleiName = tvBulei.Nodes[i].Text;
                    CSeries Series = mainForm.Bookcase.CBETA;
                    CCatalog Catalog = Series.Catalog;

                    // 先找出該部類的經
                    for (int j = 0; j < Catalog.Bulei.Length; j++) {
                        if (Catalog.Bulei[j] == sBuleiName) {
                            // 此經要檢索
                            mainForm.Bookcase.CBETA.SearchEngine_CB.BuildFileList.SearchThisSutra(Catalog.ID[j], Catalog.SutraNum[j]);
                            mainForm.Bookcase.CBETA.SearchEngine_orig.BuildFileList.SearchThisSutra(Catalog.ID[j], Catalog.SutraNum[j]);
                        }
                    }
                }
            }
        }

        // 處理原書
        void BookSelect()
        {
            // 逐一搜尋樹狀
            for (int i = 0; i < tvBook.Nodes.Count; i++) {
                if (tvBook.Nodes[i].Checked) {
                    string sName = tvBook.Nodes[i].Text;
                    // T 大正藏
                    // 取出前面的代碼
                    int iPos = sName.IndexOf(" ");
                    string sBookId = sName.Remove(iPos);
                    mainForm.Bookcase.CBETA.SearchEngine_CB.BuildFileList.SearchThisBook(sBookId);
                    mainForm.Bookcase.CBETA.SearchEngine_orig.BuildFileList.SearchThisBook(sBookId);
                }
            }
        }


        // 處理單經
        void SutraSelect(TreeNodeCollection nodes)
        {
            // 逐一搜尋樹狀
            foreach (TreeNode node in nodes) {

                // 如果有子節點，遞迴遍歷
                if (node.Nodes.Count > 0) {
                    // 若此節點沒有選擇，就不用進入子節點了，節省時間
                    if ((NodeCheckState)node.Tag != NodeCheckState.Unchecked) {
                        SutraSelect(node.Nodes);
                    }
                } else {
                    // 沒有子節點，才表示是最後節點，才要判斷是否有勾選
                    if (node.Checked) {
                        string sName = node.Text;
                        // T0001 長阿含經
                        // 取出前面的代碼
                        int iPos = sName.IndexOf(" ");
                        string sSutraId = sName.Remove(iPos);
                        mainForm.Bookcase.CBETA.SearchEngine_CB.BuildFileList.SearchThisSutraId(sSutraId);
                        mainForm.Bookcase.CBETA.SearchEngine_orig.BuildFileList.SearchThisSutraId(sSutraId);
                    }
                }
            }
        }

        void TreeViewCheckAll(TreeView treeView, bool check)
        {
            foreach (TreeNode item in treeView.Nodes) {
                item.Checked = check;
                if (treeView == tvSutra) {
                    SetChildNodesChecked(item, check);   // 單經樹狀目錄要另外處理
                }
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 0) {
                tabControl.SelectedTab = tpBulei;
            } else if (listBox.SelectedIndex == 1) {
                tabControl.SelectedTab = tpBook;
            } else if (listBox.SelectedIndex == 2) {
                tabControl.SelectedTab = tpSutra;
            }
            listBox.Focus();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            mainForm.Bookcase.CBETA.SearchEngine_CB.BuildFileList.NoneSearch();
            mainForm.Bookcase.CBETA.SearchEngine_orig.BuildFileList.NoneSearch();
            if (listBox.SelectedIndex == 0) {
                // 處理部類
                BuleiSelect();
            } else if (listBox.SelectedIndex == 1) {
                // 處理原書
                BookSelect();
            } else if (listBox.SelectedIndex == 2) {
                // 處理單經
                SutraSelect(tvSutra.Nodes);
            }
        }

        private void btCheckAll_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 0) {
                // 處理部類
                TreeViewCheckAll(tvBulei, true);
            } else if (listBox.SelectedIndex == 1) {
                // 處理原書
                TreeViewCheckAll(tvBook, true);
            } else if (listBox.SelectedIndex == 2) {
                // 處理單經
                TreeViewCheckAll(tvSutra, true);
            }
        }

        private void btUnCheckAll_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 0) {
                // 處理部類
                TreeViewCheckAll(tvBulei, false);
            } else if (listBox.SelectedIndex == 1) {
                // 處理原書
                TreeViewCheckAll(tvBook, false);
            } else if (listBox.SelectedIndex == 2) {
                // 處理單經
                TreeViewCheckAll(tvSutra, false);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tpBulei) {
                listBox.SelectedIndex = 0;
            } else if (tabControl.SelectedTab == tpBook) {
                listBox.SelectedIndex = 1;
            } else if (tabControl.SelectedTab == tpSutra) {
                listBox.SelectedIndex = 2;
            }
            tabControl.Focus();
        }

        private void tvBulei_DoubleClick(object sender, EventArgs e)
        {
            if (tvBulei.SelectedNode != null) {
                tvBulei.SelectedNode.Checked = !tvBulei.SelectedNode.Checked;
            }
        }

        private void tvBook_DoubleClick(object sender, EventArgs e)
        {
            if (tvBook.SelectedNode != null) {
                tvBook.SelectedNode.Checked = !tvBook.SelectedNode.Checked;
            }
        }

        private void tvBulei_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 || e.KeyChar == 13) {
                if (tvBulei.SelectedNode != null) {
                    tvBulei.SelectedNode.Checked = !tvBulei.SelectedNode.Checked;
                    e.Handled = true;
                }
            }
        }

        private void tvBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 || e.KeyChar == 13) {
                if (tvBook.SelectedNode != null) {
                    tvBook.SelectedNode.Checked = !tvBook.SelectedNode.Checked;
                    e.Handled = true;
                }
            }
        }

        private void SearchRangeForm_Shown(object sender, EventArgs e)
        {
            if (tvSutra.Nodes.Count == 0) {
                LoadJsonToTreeView();
            }
        }

        // 樹狀目錄展開
        private void btTreeviewExpand_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 2) {
                // 處理單經
                tvSutra.BeginUpdate();
                tvSutra.ExpandAll();
                tvSutra.EndUpdate();
            }
        }

        // 樹狀目錄收合
        private void btTreeviewCollapse_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 2) {
                // 處理單經
                tvSutra.CollapseAll();
            }
        }

        private void tvBulei_VisibleChanged(object sender, EventArgs e)
        {
            if (tvBulei.Visible) {
                btTreeviewExpand.Enabled = false;
                btTreeviewCollapse.Enabled = false;
                btLoad.Enabled = false;
                btSave.Enabled = false;
            }
        }

        private void tvBook_VisibleChanged(object sender, EventArgs e)
        {
            if (tvBook.Visible) {
                btTreeviewExpand.Enabled = false;
                btTreeviewCollapse.Enabled = false;
                btLoad.Enabled = false;
                btSave.Enabled = false;
            }
        }

        private void tvSutra_VisibleChanged(object sender, EventArgs e)
        {
            if (tvSutra.Visible) {
                btTreeviewExpand.Enabled = true;
                btTreeviewCollapse.Enabled = true;
                btLoad.Enabled = true;
                btSave.Enabled = true;
            }
        }

        // 載入 slr 檔案
        private void btLoad_Click(object sender, EventArgs e)
        {
            // 設定預設目錄
            if (openFileDialog.InitialDirectory == "") {
                openFileDialog.InitialDirectory = CGlobalVal.MyUserDataPath;
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                // 檢查是新版或舊版
                string[] readText = File.ReadAllLines(openFileDialog.FileName, Encoding.UTF8);

                if (readText[0] == "[ActivePage]") {
                    // 舊版 Search Limited Range File 格式
                    // [ActivePage]
                    // ActivePage = tsSearchByBuleiSingle
                    // 或（底下尚未支援）
                    // ActivePage = tsSearchBySutraSingle
                    if (readText[1].Contains("ActivePage") && readText[1].Contains("tsSearchByBuleiSingle")) {
                        LoadOldVersionSearchLimitedRangeFile(readText);
                    } else {
                        MessageBox.Show(t("舊版格式不支援，有需要者請聯絡CBETA。", "04001"), "CBReader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    // 新版 Search Limited Range File 格式
                    LoadNewVersionSearchLimitedRangeFile(openFileDialog.FileName);
                }
            }
        }

        // 載入舊版的 slr file, 僅限 ActivePage = tsSearchByBuleiSingle
        void LoadOldVersionSearchLimitedRangeFile(string[] lines)
        {
            TreeViewCheckAll(tvSutra, false);
            SearchLimitedRangeFile oldSLRF = new SearchLimitedRangeFile();
            // 載入舊格式
            oldSLRF.LoadFromOldFile(lines);
            SLRMapToTreeview(oldSLRF, tvSutra);
            MessageBox.Show(t("載入成功", "04003"), "CBReader", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void LoadNewVersionSearchLimitedRangeFile(string filename)
        {
            string json = File.ReadAllText(filename);

            SearchLimitedRangeFile newSLR;
            newSLR = JsonSerializer.Deserialize<SearchLimitedRangeFile>(json);
            SLRMapToTreeview(newSLR, tvSutra);
            MessageBox.Show(t("載入成功", "04003"), "CBReader", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 將 SLR 的資料填入 Treeview 中
        void SLRMapToTreeview(SearchLimitedRangeFile slr, TreeView treeView)
        {
            // 取消全部勾選
            TreeViewCheckAll(treeView, false);
            // 呼叫這個方法來遍歷你的 TreeView
            SLRMapToTreeviewNodes(slr, tvSutra.Nodes);
            // 根據子節點的狀態，重設 Tag 的狀態
            ResetTreeviewTag(tvSutra);
        }

        // 遍歷 TreeView 的節點
        void SLRMapToTreeviewNodes(SearchLimitedRangeFile slr, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes) {
                // 如果該節點沒有子節點（是葉節點）
                if (node.Nodes.Count == 0) {
                    // 遍歷 stringList，檢查是否節點的文字包含其中任一項
                    foreach (string keyword in slr.Children) {
                        if (node.Text.Contains(keyword)) {
                            // 勾選該節點的 checkbox
                            node.Checked = true;
                            break; // 一旦找到符合的關鍵字就可以跳出
                        }
                    }
                } else {
                    // 如果該節點有子節點，繼續遞迴檢查子節點
                    SLRMapToTreeviewNodes(slr, node.Nodes);
                }
            }
        }

        // 根據子節點的狀態，重設父節點的狀態
        void ResetTreeviewTag(TreeView tvSutra)
        {
            // 根據子節點的狀態，重設父節點的狀態
            foreach (TreeNode rootNode in tvSutra.Nodes) {
                ResetTreeviewNodeTag(rootNode);
            }
        }
        
        // 根據子節點的狀態，重設父節點的狀態
        void ResetTreeviewNodeTag(TreeNode node)
        {
            // 如果沒有子節點，直接依據節點是否被勾選來設定 tag
            if (node.Nodes.Count == 0) {
                node.Tag = node.Checked ? NodeCheckState.Checked : NodeCheckState.Unchecked;
                return;
            }

            // 遞迴處理所有子節點
            bool allChecked = true;
            bool allUnchecked = true;

            foreach (TreeNode child in node.Nodes) {
                ResetTreeviewNodeTag(child);

                // 根據子節點的 tag 決定當前節點的狀態
                if ((NodeCheckState)child.Tag != NodeCheckState.Checked) {
                    allChecked = false;
                }
                if ((NodeCheckState)child.Tag != NodeCheckState.Unchecked) {
                    allUnchecked = false;
                }
            }

            // 根據子節點的狀態決定父節點的 tag 和 checked 狀態
            // 要先設定 checked ，才能設 tag 及 color，因為 checked 會自動改變 tag 及 color
            if (allChecked) {
                node.Checked = true;
                node.Tag = NodeCheckState.Checked;
                // node.BackColor = Color.LightBlue;
                // 底下不用了，改成自行重繪節點來處理
                // node.BackColor = mainForm.IsDarkTheme ? theme.darkColors.TreeViewCheckedBack : theme.lightColors.TreeViewCheckedBack; 
            } else if (allUnchecked) {
                node.Checked = false;
                node.Tag = NodeCheckState.Unchecked;
                // node.BackColor = Color.White;
                // 底下不用了，改成自行重繪節點來處理
                // node.BackColor = mainForm.IsDarkTheme ? theme.darkColors.TreeViewBack : theme.lightColors.TreeViewBack;
            } else {
                node.Checked = false;
                node.Tag = NodeCheckState.Mix; // 混合狀態
                // node.BackColor = Color.LightGray;
                // 底下不用了，改成自行重繪節點來處理
                // node.BackColor = mainForm.IsDarkTheme ? theme.darkColors.TreeViewMixBack : theme.lightColors.TreeViewMixBack;

            }
        }

        // 將選擇結果另存檔案
        private void btSave_Click(object sender, EventArgs e)
        {
            bool bHasClick = false;
            // 檢查有沒有勾選
            foreach (TreeNode node in tvSutra.Nodes) {
                if((NodeCheckState) node.Tag != NodeCheckState.Unchecked) {
                    bHasClick = true;
                }
            }

            if (!bHasClick)
            {
                MessageBox.Show(t("沒有勾選任何典籍","04002"),"CBReader",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            // 設定預設目錄
            if (saveFileDialog.InitialDirectory == "") {
                saveFileDialog.InitialDirectory = CGlobalVal.MyUserDataPath;
            }
            // 匯出
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                SearchLimitedRangeFile searchLimitedRangeFile = new SearchLimitedRangeFile();
                searchLimitedRangeFile.Initial();
                searchLimitedRangeFileGetData(tvSutra.Nodes, searchLimitedRangeFile);
                searchLimitedRangeFile.SaveToFile(saveFileDialog.FileName);
                MessageBox.Show(t("儲存成功", "04004"), "CBReader", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 將有勾選的項目存入 slrf 中
        private void searchLimitedRangeFileGetData(TreeNodeCollection nodes, SearchLimitedRangeFile slrf)
        {
            // 逐一搜尋樹狀
            foreach (TreeNode node in nodes) {

                // 如果有子節點，遞迴遍歷
                if (node.Nodes.Count > 0) {
                    // 若此節點沒有選擇，就不用進入子節點了，節省時間
                    if ((NodeCheckState)node.Tag != NodeCheckState.Unchecked) {
                        searchLimitedRangeFileGetData(node.Nodes, slrf);
                    }
                } else {
                    // 沒有子節點，才表示是最後節點，才要判斷是否有勾選
                    if (node.Checked) {
                        string sName = node.Text;
                        // T0001 長阿含經
                        // 取出前面的代碼
                        int iPos = sName.IndexOf(" ");
                        string sSutraId = sName.Remove(iPos);
                        slrf.AddSutra(sSutraId);
                    }
                }
            }
        }

        // 專門處理字串語系的函數
        string t(string message, string msgId)
        {
            return mainForm.language.GetMessage(message, msgId);
        }

        // 自行繪製 checkbox 的節點，以模擬出三種狀態
        private void tvSutra_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // 自行繪製 checkbox 的範圍，剛好蓋住原來的 checkbox
            // 後來發現不用畫了，只有在 mix 時塗上灰色方塊就好了
            // Rectangle checkboxRect = new Rectangle(e.Bounds.X - 15, e.Bounds.Y + (e.Bounds.Height - 16) / 2, 16, 16);

            // 中間狀態在 checkbox 中間的灰色方塊
            // checkbox 固定 16 * 16，高度為文字的中間
            // 灰色為中間 8 * 8。
            // 例：
            // e.Bounds 的 (x,y) 為 （15,0), 高為 28, e.Bounds 的 X 等於 checkbox 最右邊線
            // checkbox 的 (x,y) 為 (0,6) - (15,21)
            // checkbox 中間的灰色為 (4,10) - (11,17) (8*8)
            Rectangle smallBox = new Rectangle(e.Bounds.X - 15 + 4, e.Bounds.Y + 4 + (e.Bounds.Height - 16 )/2 , 8, 8);

            var themeColor = mainForm.IsDarkTheme ? theme.darkColors : theme.lightColors;

            // 根據狀態，判斷是否畫出灰色方塊及文字
            switch ((NodeCheckState) e.Node.Tag) {
                case NodeCheckState.Checked:
                    // 可以自行畫 checkbox 或方框，也可以都不畫了
                    // ControlPaint.DrawCheckBox(e.Graphics, checkboxRect, ButtonState.Checked);
                    // ControlPaint.DrawBorder(e.Graphics, checkboxRect, Color.Black, ButtonBorderStyle.Solid);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, tvSutra.Font, e.Bounds, tvSutra.ForeColor, themeColor.TreeViewCheckedBack);
                    break;
                case NodeCheckState.Mix:
                    // 畫出灰色範圍
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), smallBox);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, tvSutra.Font, e.Bounds, tvSutra.ForeColor, themeColor.TreeViewMixBack);
                    break;
                default:
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, tvSutra.Font, e.Bounds, tvSutra.ForeColor);
                    break;
            }
        }
    }
}
