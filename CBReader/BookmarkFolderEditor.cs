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
    public partial class BookmarkFolderEditorForm : Form
    {
        MainForm mainForm;
        private bool validateData = true; // 預設值設為 true
        public BookmarkFolderEditorForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
        }

        // 設定目錄
        public void setFolderTitle(string title)
        {
            edTitle.Text = title;
        }

        public string getFolderTitle()
        {
            return edTitle.Text;
        }

        private void BookmarkFolderEditorForm_Shown(object sender, EventArgs e)
        {
            validateData = true;
            edTitle.Focus();
            edTitle.SelectAll();
        }

        private void BookmarkFolderEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // 檢查是否是使用者按右上角的關閉按鈕觸發的
            {
                validateData = false; // 設定為 false，表示取消資料驗證
            }

            if (validateData) {
                if (edTitle.Text == "") {
                    MessageBox.Show(t("名稱不可以空白。", "03010"));
                    edTitle.Focus();
                    e.Cancel = true;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            validateData = false;
        }

        // 專門處理字串語系的函數
        string t(string message, string msgId)
        {
            return mainForm.language.GetMessage(message, msgId);
        }
    }
}
