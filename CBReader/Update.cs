using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
    public partial class UpdateForm : Form
    {
        MainForm mainForm;
		FileStream fileStream;	// 共用的 fileStream，要給 Timer 看的。

		// string DestFile;

		string ServerURL = "http://www.cbeta.org/cbreader/update.php?";  // 要檢查更新的網頁目錄
		public bool UseLocalhostURL = false;  // 使用 localhost 的測試網址
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
		public bool IsDownloadOK = false;	// 是否下載完成

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
		// 若要不要回應是 true, 表示是使用者指定更新，因此更新機率是 100，不要隨機了
		public void CheckUpdate(string sCBRVer, string sDataVer, bool bShowNoUpdate)
        {
			IsShowMessage = bShowNoUpdate;

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

			// 一定要秀回應，也表示一定要判斷能不能更新，不考慮機率
			if(IsShowMessage) {
				sURL += "&rand=100";
			}

			try {
				//sURL = "https://www.cbeta.org/cbreader/update.php?cbr=0.5.5.0&data=0.5.4.0&os=win";
				string responseBody = httpClient.GetStringAsync(sURL).Result;
				slReceive.Clear();
				slReceive = responseBody.Split('\n').ToList();
			} catch (HttpRequestException e) {
				if (IsShowMessage) {
					MessageBox.Show(e.Message);
				}
				return;
			} catch (AggregateException ae) {
				if (IsShowMessage) {
					foreach (Exception ex in ae.InnerExceptions) {
						MessageBox.Show(ex.Message);
					}
				}
				return;
			} catch (Exception e) {
				if (IsShowMessage) {
					MessageBox.Show(e.Message);
				}
				return;
			}

			// 判斷是不是更新資料檔
			string sStr1 = slReceive[0];
			if (CGlobalVal.IsDebug) {
				MessageBox.Show(sStr1);
			}
			if (sStr1.Substring(0, 2) == "ok") {
				// 表示沒有更新資料
				if (IsShowMessage) {
					MessageBox.Show(t("您的 CBReader 是最新的!","02001"));
				}
			} else if (sStr1.StartsWith("message=")) {

				string msg = t("發現有更新檔案，您要進行更新嗎？", "02002") + "\n\n" + t("更新後會自動重啟程式。", "02003");

                var result = MessageBox.Show(msg, t("是否進行更新？","02008"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes) {
					IsUpdate = true;
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
				lbMessage.Text = t("下載中...","02005") + $" ({i+1}/{updateSource.Count})";
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

		// 若已存在的檔案不想被覆蓋，overwrite 可設為 false
		void UnzipToDirectory(string zipFile, string outDir, bool overwrite = true)
		{
			using (ZipArchive archive = ZipFile.OpenRead(zipFile)) {
				progressBar1.Maximum = archive.Entries.Count;
				progressBar1.Value = 0;
				foreach (ZipArchiveEntry file in archive.Entries) {
					// file.Name == "" 表示 file 為目錄
					if (file.Name == "") {
						string desPath = Path.Combine(outDir, file.FullName);

						// 目錄不存在就要建立
						if (!Directory.Exists(desPath)) {
							Directory.CreateDirectory(desPath);
						}
					} else {
						// file 為檔案
						string desFileName = Path.Combine(outDir, file.FullName);

						// 可覆寫就直接解壓縮
						if (overwrite) {
							file.ExtractToFile(desFileName, overwrite);
						} else {
							// 不可覆寫就要先判斷檔案是否存在，不存在才解壓縮
							if (!File.Exists(desFileName)) {
								file.ExtractToFile(desFileName);
							}
						}
					}
					progressBar1.Value++;
					Application.DoEvents();
				}
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
			if (IsDownloading) {
				return;
			}
			IsDownloading = true;

			// 開始下載
			lbMessage.Text = t("下載中...","02005");

			updateDest.Clear();
			updateSource.Clear();
			updateFilename.Clear();

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
							sSource = sSource.Replace("archive.cbeta.org/download",
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

			lbMessage.Text = t("下載完成","02006");
			IsDownloading = false;
			IsDownloadOK = true;
			btUpdate.Enabled = true;
			btDownload.Enabled = false;
			btUpdate.Focus();
			string msg = t("更新檔案下載完成。", "02007") + "\n\n" +
				t("按下「是」會自動進行更新，更新期間無法操作 CBReader。", "02012") + "\n\n" +
				t("您也可以稍候選擇按下「更新」按鈕進行更新。", "02013");
            var result = MessageBox.Show(msg, t("是否進行更新？", "02008"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes) {
				btUpdate_Click(this, null);
			}
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
			TopMost = true;
			mainForm.Bookcase.CBETA.FreeSearchEngine();
			for (int i = 0; i < updateFilename.Count; i++) {
				lbMessage.Text = t("更新中...","02009") + $" ({i+1}/{updateFilename.Count})";
				string zipFile = CGlobalVal.MyTempPath + updateFilename[i];
				if (updateDest[i] == "bookcase") {
					// 解壓縮到 bookcase 目錄
					// ZipFile.ExtractToDirectory(zipFile, mainForm.Bookcase.BookcaseDir);
					UnzipToDirectory(zipFile, mainForm.Bookcase.BookcaseDir);
				} else {
					// 解壓縮到主程式目錄
					string exeFile = CGlobalVal.MyFullPath + "CBReader.exe";
					string oldFile = CGlobalVal.MyFullPath + "CBReader_old.exe";
					if (File.Exists(oldFile)) {
						File.Delete(oldFile);
                    }
					File.Move(exeFile, oldFile);
					//ZipFile.ExtractToDirectory(zipFile, CGlobalVal.MyFullPath);
					UnzipToDirectory(zipFile, CGlobalVal.MyFullPath);
				}
            }
			lbMessage.Text = t("更新完成","02010");
			IsDownloadOK = false;
			MessageBox.Show(t("更新完成，按下「確定」後會重啟程式。","02011"));
			CGlobalVal.restart = true;
			mainForm.Close();
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			e.Cancel = true;
        }

        // 專門處理字串語系的函數
        string t(string message, string msgId)
        {
            return mainForm.language.GetMessage(message, msgId);
        }
    }
}
