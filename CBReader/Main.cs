using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSeries s = new CSeries(@"c:\cbeta\cbreader2x\bookcase\cbeta");
            s.SearchEngine = s.getSearchEngine();
            s.SearchEngine.Find("如是我聞", false);
            int f = s.SearchEngine.FileFound.Total;
            MessageBox.Show($"找到 {f} 筆");
        }
    }
}
