using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
    public partial class MainForm : Form
    {
        AboutForm aboutForm;
        OptionForm optionForm;
        SearchRangeForm searchrangeForm;
        UpdateForm updateForm;
        public MainForm()
        {
            InitializeComponent();
            InitializeForms();  // 初始其它的 Form

            webBrowser1.Navigate("file:///c:/CBETA/CBReader2X/Bookcase/CBETA/help/index.htm");
        }

        // =====================================================
        // 成員函式
        // =====================================================

        // 初始其它的 Form
        void InitializeForms()
        {
            aboutForm = new AboutForm(this);
            optionForm = new OptionForm(this);
            searchrangeForm = new SearchRangeForm(this);
            updateForm = new UpdateForm(this);
        }

        // =====================================================
        // 元件函式
        // =====================================================

        private void cbSearchRange_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSearchRange.Checked) {
                // 設定檢索範圍
                searchrangeForm.ShowDialog();
            }
        }

        private void btOption_Click(object sender, EventArgs e)
        {
            optionForm.ShowDialog();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialog();
        }

        private void miOption_Click(object sender, EventArgs e)
        {
            btOption_Click(this, e);
        }

        private void miUpdate_Click(object sender, EventArgs e)
        {
            updateForm.ShowDialog();
        }
    }
}
