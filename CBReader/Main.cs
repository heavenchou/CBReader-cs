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
            /*
            DateTime t1 = DateTime.Now;
            CSpine spine = new CSpine(@"d:\Data\csharp\CBReader\CBReaderTests\TestData\spine.txt");
            CJuanLine juanLine = new CJuanLine(spine);
            DateTime t2 = DateTime.Now;
            MessageBox.Show(spine.Juan[4]);
            TimeSpan tt = t2 - t1;
            MessageBox.Show(tt.ToString());

            Action a0 = haha0;
            Action<string> a1 = haha1;

            Action a2 = () => haha0();
            Action<string> a3 = s => haha1(s);

            Func<string> f0 = haha2;
            Func<string, string> f1 = haha3;

            Func<string> f2 = () => haha2();
            Func<string, string> f3 = s => haha3(s);

            a0();
            a1("a1");

            a2();
            a3("a3");

            string s0 = f0();
            string s1 = f1("f1");
            string s2 = f2();
            string s3 = f3("f3");
            */

            string s = CCBSutraUtil.getStandardSutraNumberFormat("A12");
        }


        /*
        void haha1(string s)
        {
            MessageBox.Show(s);
        }

        string haha2()
        {
            MessageBox.Show("haha2");
            return "haha2";
        }
        string haha3(string s)
        {
            MessageBox.Show(s);
            return "haha3";
        }
        */
    }
}
