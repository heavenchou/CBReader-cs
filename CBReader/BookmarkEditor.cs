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
    public partial class BookmarkEditorForm : Form
    {
        MainForm mainForm;
        private bool validateData = true; // 預設值設為 true

        public BookmarkEditorForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
        }
        // 設定書籤
        public void setTitleAndLocation(string title, string location)
        {
            edTitle.Text = title;
            edLocation.Text = location;
            edLocation.Enabled = true;
        }

        public (string, string) getTitleAndLocation()
        {
            return (edTitle.Text, edLocation.Text);
        }

        private void BookmarkEditorForm_Shown(object sender, EventArgs e)
        {
            validateData = true;
            edTitle.Focus();
            edTitle.SelectAll();
            edLocation.SelectAll();
        }

        private void edTitle_Enter(object sender, EventArgs e)
        {
            AcceptButton = null;
        }

        private void edTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                edLocation.Focus();
            }
        }

        private void BookmarkEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // 檢查是否是使用者按右上角的關閉按鈕觸發的
            {
                validateData = false; // 設定為 false，表示取消資料驗證
            }

            if (validateData) {
                if (edTitle.Text == "") {
                    MessageBox.Show(t("名稱不可以空白。", "03008"));
                    edTitle.Focus();
                    e.Cancel = true;
                } else if (edLocation.Text == "") {
                    MessageBox.Show(t("位置不可以空白。", "03009"));
                    edLocation.Focus();
                    e.Cancel = true;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            validateData = false;
        }

        private void edLocation_Enter(object sender, EventArgs e)
        {
            AcceptButton = btSave;
        }

        // 專門處理字串語系的函數
        string t(string message, string msgId)
        {
            return mainForm.language.GetMessage(message, msgId);
        }
    }
}
