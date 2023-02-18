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
    public partial class CreateHtml : Form
    {
        mainForm mainForm;
        bool Stop;
        public CreateHtml(mainForm main)
        {
            InitializeComponent();
            mainForm = main;
        }

		void CreateThisFile(string sFile)
		{
			if(sFile == "") {
				MessageBox.Show("沒有找到正確檔案");
				return;
			}

			string sXMLFile = mainForm.Bookcase.CBETA.Dir + sFile;
			string sJSFile = mainForm.Bookcase.CBETA.Dir + mainForm.Bookcase.CBETA.JSFile;
			CCBXML CBXML = new CCBXML(sXMLFile, "", mainForm.Setting, sJSFile, false, mainForm.Bookcase.CBETA);

			string sOutFile = sFile + ".htm";

			sOutFile = sOutFile.Replace('/', '_');
			sOutFile = sOutFile.Replace('\\', '_');
			sOutFile = edTempPath.Text + sOutFile;

			CBXML.SaveToHTML(sOutFile);
		}

		private void btStart_Click(object sender, EventArgs e)
		{
			Stop = false;
			// 如果找到第一筆, 而且有勾選 "繼續" , 就持續下去
			bool bGoing = false;

			string sTempPath = CGlobalVal.MyTempPath + "Debug\\";
			if (Directory.Exists(sTempPath)) {
				Directory.CreateDirectory(sTempPath);
			}
			edTempPath.Text = sTempPath;

			int iSpineCount = mainForm.Bookcase.CBETA.Spine.Files.Length;
			for (int i = 0; i < iSpineCount; i++) {
				// 該忽略還是要忽略才對
				if (edSkipThisBook.Text != "") {
					if (edSkipThisBook.Text == mainForm.Bookcase.CBETA.Spine.BookID[i]) {
						continue;
					}
				}

				if (!bGoing) {  // if true , 找到第一筆就不用比對, 一直做下去
				
					if (edBook.Text != "") {
						if (edBook.Text != mainForm.Bookcase.CBETA.Spine.BookID[i])
							continue;
					}
					if (edVolNum.Text != "") {
						if (edVolNum.Text.TrimStart('0') != mainForm.Bookcase.CBETA.Spine.VolNum[i].TrimStart('0'))
							continue;
					}
				}
				string sFile = mainForm.Bookcase.CBETA.Spine.Files[i];

				CreateThisFile(sFile);
				lbFileName.Text = sFile;

				if (cbContinue.Checked) {
					bGoing = true; // 找到第一筆就繼續
				}

				Application.DoEvents();
				if (Stop) {
					return;
				}
			}
			MessageBox.Show("OK");
        }

        private void btStop_Click(object sender, EventArgs e)
        {
			Stop = true;
		}
    }
}
