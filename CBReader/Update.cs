using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
    public partial class UpdateForm : Form
    {
        MainForm mainForm;
		FileStream fileStream;	// 共用的 fileStream，要給 Timer 看的。

		string DestFile;

		string ServerURL = "http://www.cbeta.org/cbreader/update.php?";  // 要檢查更新的網頁目錄
		bool UseLocalhostURL = false;  // 使用 localhost 的測試網址
		string LocalhostURL = "http://localhost/cbreader/update.php?";    // 內部測試的網址

		// 二個版本
		//String CBRVer;  // CBReader 的版本
		//String DataVer;	// 經文資料的版本

		// 判斷要不要秀訊息
		// 如果傳入參數 true , 表示要秀訊息
		// 自動檢查更新時, 若沒更新就自行離開
		// 手動檢查更新, 沒更新就需要秀訊息 "目前是最新版".
		bool IsShowMessage = false;

		// 判斷有沒有更新, 如果有更新, 就不修改更新時期,
		// 這樣才能再次執行時, 再次檢查有沒有更新的更新
		public bool IsUpdate = false;
		public bool IsDownloading = false;	// 是否正在下載

		List<string> slReceive = new List<string>(); // 接收網頁訊息

		List<string> updateSource = new List<string>();     // 要下載更新的檔案
		List<string> updateDest = new List<string>();       // 要更新的目的
		List<string> updateFilename = new List<string>();	// 要更新的檔名 (不含路徑)
		List<int> updateFileSize = new List<int>();			// 要更新的檔案大小

		static readonly HttpClient httpClient = new HttpClient();	// HttpClient

		public UpdateForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
		}

		// 檢查需不需要更新, 傳入 cbreader 版本, 資料版本, 以及要不要回應目前是最新的 (手動更新才需要)
		public void CheckUpdate(string sCBRVer, string sDataVer, bool bShowNoUpdate)
        {
			IsShowMessage = bShowNoUpdate;

			// 判斷有沒有更新, 如果有更新, 就不修改更新時期,
			// 這樣才能再次執行時, 再次檢查有沒有更新的更新
			IsUpdate = false;

			// 傳過去的版本格式 ?cbr=0.1.0.0&data=0.1.0.0
			// 作業系統 &os=win
			// debug 模式 &type=debug

			string sURL = ServerURL;
			if (UseLocalhostURL) {
				sURL = LocalhostURL;
			}

			sURL = sURL + $"cbr={sCBRVer}&data={sDataVer}&os=win";

			if (CGlobalVal.IsDebug) {
				sURL += "&type=debug";
				MessageBox.Show(sURL);
			}

			try {
				//sURL = "https://www.cbeta.org/cbreader/update.php?cbr=0.5.5.0&data=0.5.4.0&os=win";
				string responseBody = httpClient.GetStringAsync(sURL).Result;
				slReceive.Clear();
				slReceive = responseBody.Split('\n').ToList();
			} catch (HttpRequestException e) {
				MessageBox.Show(e.Message);
			}

			// 判斷是不是更新資料檔
			string sStr1 = slReceive[0];
			if (CGlobalVal.IsDebug) {
				MessageBox.Show(sStr1);
			}
			if (sStr1.Substring(0, 2) == "ok") {
				// 表示沒有更新資料
				if (IsShowMessage) {
					MessageBox.Show("您的 CBReader 是最新的!");
				}
			} else if (sStr1.StartsWith("message=")) {

				var result = MessageBox.Show("發現更新檔案，您要進行更新嗎？更新後請立刻重新開啟本程式，以確保程式與資料能正確搭配。", "進行更新", MessageBoxButtons.YesNoCancel);

				if (result == DialogResult.Yes) {
					Show();
				} else {
					if (CGlobalVal.IsDebug) {
						MessageBox.Show("不更新就算了");
					}
				}
			} else {
				// 呈現其它訊息
				MessageBox.Show(string.Join("\n",slReceive));
			}
		}

		// 下載檔案
		async Task Download()
        {
			for (int i = 0; i < updateSource.Count; i++) {
				using (HttpClient httpClient = new HttpClient()) {
					try {
						var requestUri = updateSource[i];
						var header = await httpClient.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead);
						// 取得檔案大小
						var size = header.Content.Headers.ContentLength;
						// 檔案大小記錄至進度條
						progressBar1.Maximum = (int)size;
						var stream = await httpClient.GetStreamAsync(requestUri);

						fileStream = File.Create(CGlobalVal.MyTempPath + updateFilename[i]);
						timer1.Start(); // 開始計時器
						await stream.CopyToAsync(fileStream);

						// 完成後還要填入長度
						progressBar1.Value = (int)fileStream.Length;
						timer1.Stop();
						fileStream.Close();
					} catch (HttpRequestException ex) {
						MessageBox.Show(ex.Message.ToString());
					}
				}
			}
			MessageBox.Show("檔案下載完成，已可執行更新作業，更新期間無法操作");
		}

		// 由 http 網址取得最後的檔名
		string GetHttpFileName(string sURL)
        {
			int iPos = sURL.LastIndexOf('/');
			if (iPos >= 0) {
				return sURL.Substring(iPos + 1);
			} else {
				return "";
			}
        }

		// 元件事件 =========================================

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
			string sMsg = slReceive[0];
			sMsg = sMsg.Remove(0, 8);  // 移除 "message="
			
			// 把更新訊息呈現出來
			for (int i = 1; i < slReceive.Count; i++) {
				if (!slReceive[i].StartsWith("source=")) {
					sMsg += "\n";
					sMsg += slReceive[i];
				} else {
					break;
				}
			}

			Memo.Lines = sMsg.Split('\n');

			edBookcasePath.Text = mainForm.Bookcase.BookcaseDir;
			lbMessage.Text = "";
        }

		// 開始下載
        private async void btDownload_Click(object sender, EventArgs e)
        {
			IsUpdate = true;    // 表示有更新, 不要修改更新日期
			IsDownloading = true;

			// 開始下載
			lbMessage.Text = "下載中...";

			for (int i = 1; i < slReceive.Count; i++) {
				// 來源
				string sSource = slReceive[i];
				// 有時會有空白行, 所以要加上判斷
				if (sSource.StartsWith("source=")) {

					// 目的
					string sDest = slReceive[i + 1];

					if (sDest.StartsWith("dest=")) {
						sSource = sSource.Remove(0, 7);
						sDest = sDest.Remove(0, 5);

						// 使用中國大陸分站

						if (cbUseChinaServer.Checked) {
							sSource = sSource.Replace("archive.cbeta.org/cbreader", 
								                      "archive.cbetaonline.cn/download");
						}

						if (CGlobalVal.IsDebug) {
							MessageBox.Show(sSource);
							MessageBox.Show(sDest);
						}
						if (sDest.ToLower() == "cbreader" || sDest.ToLower() == "bookcase") {
							// 只有這二種才要更新, 一是主程式, 一是資料
							updateSource.Add(sSource);
							updateDest.Add(sDest);
							updateFilename.Add(GetHttpFileName(sSource));
						}
						i++;
					}
				}
			}
			await Download();
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
			if (fileStream != null) {
				// 更新進度條
				progressBar1.Value = (int)fileStream.Length;
			}
		}

		// 更新檔案，也就是逐一解壓縮
        private void btUpdate_Click(object sender, EventArgs e)
        {
			//TopMost = true;

			for (int i = 0; i < updateFilename.Count; i++) {
				string zipFile = CGlobalVal.MyTempPath + updateFilename[i];
				if (updateDest[i] == "bookcase") {
					// 解壓縮到 bookcase 目錄
					ZipFile.ExtractToDirectory(zipFile, mainForm.Bookcase.BookcaseDir);
				} else {
					// 解壓縮到主程式目錄
					string exeFile = CGlobalVal.MyFullPath + "CBReader.exe";
					string oldFile = CGlobalVal.MyFullPath + "CBReader_old.exe";
					//Directory.Move(exeFile, oldFile);
					File.Move(exeFile, oldFile);
					ZipFile.ExtractToDirectory(zipFile, CGlobalVal.MyFullPath);
				}
            }
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			e.Cancel = true;
			Hide();
        }
    }
}
