using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
    public partial class SearchRangeForm : Form
    {
        MainForm mainForm;
        public SearchRangeForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
            HideTabHeader();
            listBox.SelectedIndex = 0;
            tabControl.SelectedTab = tpBulei;
            tabControl.Top -= 1;
            tabControl.Height += 5;
        }

        void HideTabHeader()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        // 處理部類
        void BuleiSelect()
        {
            mainForm.Bookcase.CBETA.SearchEngine_CB.BuildFileList.NoneSearch();
            mainForm.Bookcase.CBETA.SearchEngine_orig.BuildFileList.NoneSearch();
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
            mainForm.Bookcase.CBETA.SearchEngine_CB.BuildFileList.NoneSearch();
            mainForm.Bookcase.CBETA.SearchEngine_orig.BuildFileList.NoneSearch();
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

        void TreeViewCheckAll(TreeView treeView, bool check)
        {
            foreach(TreeNode item in treeView.Nodes) {
                item.Checked = check;
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox.SelectedIndex == 0) {
                tabControl.SelectedTab = tpBulei;
            } else {
                tabControl.SelectedTab = tpBook;
            }
            listBox.Focus();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 0) {
                // 處理部類
                BuleiSelect();
            } else {
                // 處理原書
                BookSelect();
            }
        }

        private void btCheckAll_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 0) {
                // 處理部類
                TreeViewCheckAll(tvBulei, true);
            } else {
                // 處理原書
                TreeViewCheckAll(tvBook, true);
            }
        }

        private void btUnCheckAll_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 0) {
                // 處理部類
                TreeViewCheckAll(tvBulei, false);
            } else {
                // 處理原書
                TreeViewCheckAll(tvBook, false);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tpBulei) {
                listBox.SelectedIndex = 0;
            } else {
                listBox.SelectedIndex = 1;
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
    }
}
