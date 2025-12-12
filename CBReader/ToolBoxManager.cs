using CBReader;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
結構說明：

主畫面右邊瀏覽區的元件由下而上依序為：
MainForm
  └ WebPanel
      └ tcWeb ： TabControl，是主要的經文區 + WebSplitter 拉軸 + tcToolbox 工具箱區

WebSplitter 拉軸 + tcToolbox 工具箱區 一開始是隱藏的。

使用者若開啟工具箱，選擇 Dock 模式，則會有如下動作：

1.tcToolbox 若是隱藏的，則先顯示出來，並將 WebSplitter 拉軸 顯示出來。
  tcWeb 的寬度會被縮小一半，tcToolbox 會出現在右邊另一半。
2.tcToolbox 建立新的 TabPage。
3.建立工具箱的內容，並加入到新的 TabPage 裡面。
4.記錄工具箱目前是 Dock 模式，其 TabPageParent 是該 TabPage。

使用者若開啟工具箱，選擇 Float 模式，則會有如下動作：

1.檢查工具箱是否已經開啟，若無，則建立一個新的 ToolboxForm 視窗。
2.建立工具箱的內容，並加入到 ToolboxForm 裡面。
3.記錄工具箱目前是 Float 模式，其 FormParent 是該 ToolboxForm。

工具箱關閉時的動作：
1.若是 Dock 模式，則移除該 TabPage，並檢查 tcToolbox 是否還有其他 TabPage，
  若無，則隱藏 tcToolbox 與 WebSplitter 拉軸，並將 tcWeb 的寬度恢復到原本的大小。
2.若是 Float 模式，則關閉 ToolboxForm 視窗。

其它功能：
1. Dock 模式與 Float 模式之間的切換。

*/

namespace WebLink
{
    internal class ToolboxManager
    {
        public List<ToolboxItem> toolbox { get; set; }
        public TabControl tcToolbox { get; set; }
        public Splitter webSplitter { get; set; }

        public void loadToolbox(string file)
        {
            string jsonString = File.ReadAllText(file);
            toolbox = JsonSerializer.Deserialize<List<ToolboxItem>>(jsonString);
        }


        // 建立新的 TabPage
        public TabPage createNewTabPage()
        {
            if (tcToolbox.TabPages.Count == 0) {
                // 若目前沒有任何 TabPage，表示工具箱區是隱藏的
                // 先顯示出來
                //webSplitter.Visible = true;
                //tcToolbox.Visible = true;
                // 調整寬度為一半
                var parentWidth = tcToolbox.Parent.ClientSize.Width;
                tcToolbox.Parent.SuspendLayout();
                tcToolbox.Width = parentWidth / 2;
                //tcToolbox.Left = parentWidth - tcToolbox.Width;
                tcToolbox.Parent.ResumeLayout();
            }
            var tp = new TabPage("");
            tcToolbox.TabPages.Add(tp);
            tcToolbox.SelectedTab = tp;
            return tp;
        }

        public async void externalToolboxItem(ToolboxItem card, string url)
        {
            // 處理特殊的 URL 開啟方式
            // 某些特殊網址會用 , 分隔額外參數, 例如佛光大藏經搜尋
            // 從網址中分離出額外參數（以 , 分隔）
            string extraPara = "";
            int idx = url.IndexOf(',');
            if (idx >= 0) {
                extraPara = url.Substring(idx + 1).Trim();
                url = url.Substring(0, idx).Trim();

                // 還原 EscapeDataString
                extraPara = Uri.UnescapeDataString(extraPara);
            }
            // 特別處理 CBETA Online
            if (url.Contains("{cbeta_online}")) {
                url = url.Replace("{cbeta_online}", "https://cbetaonline.dila.edu.tw/zh/");
                url += extraPara;
            }

            // 特別處理自動標點，會傳入要標點的句子
            if (url.Contains("{auto_punct}")) {
                url = url.Replace("{auto_punct}", "https://ocr.gj.cool/punct");
            }

            // 系統預設開啟
            try {
                Process.Start(new ProcessStartInfo {
                    FileName = url,
                    UseShellExecute = true
                });
            } catch (Exception ex) {
                MessageBox.Show($"無法啟動：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 內嵌於主視窗的工具箱項目
        /// </summary>
        /// <param name="card"></param>
        /// <param name="url"></param>
        /// 
        public async void DockToolboxItem(ToolboxItem card, string url)
        {
            if (card.dockWebViewHost != null && !card.dockWebViewHost.IsDisposed && card.dockWebViewHost.Parent is TabPage) {
                // 已經有對應的 WebView2Host，直接導覽
                card.dockWebViewHost.Navigate(url);
                // 這一頁 tabpage 要呈現
                TabPage tp = ((TabPage)card.dockWebViewHost.Parent);
                tcToolbox.SelectedTab = tp;
            } else {
                // 建立新的 TabPage
                var tpToolbox = createNewTabPage();

                // 建立比對的 WebView2Host
                var host = new WebView2Host();
                await host.InitializeAsync();
                host.Navigate(url);
                host.Dock = DockStyle.Fill;
                tpToolbox.Controls.Add(host);
                tpToolbox.Text = card.Title;
                card.dockWebViewHost = host;
            }
        }

        // 浮動視窗
        public async void FloatToolboxItem(ToolboxItem card, string url)
        {
            // 內部彈出視窗
            if (card.floatWebViewHost != null && !card.floatWebViewHost.IsDisposed && card.floatWebViewHost.Parent is WebView2Form) {
                // 已經有對應的 WebView2Host，直接導覽
                card.floatWebViewHost.Navigate(url);
                return;
            } else {
                // 尚未有對應的 WebView2Host，開新視窗
                OpenPopupWindow(CGlobalVal.ShareEnv, url, 800, 600, card);
                return;
            }
        }




        /// <summary>
        /// 可供事件或主程式直接呼叫的開窗函式
        /// </summary>
        /// 
        private async void OpenPopupWindow(CoreWebView2Environment env, string url, int width, int height, string windowName)
        {
            var popup = new WebView2Form(env, url, width, height, windowName);
            popup.Show();
        }
        private async void OpenPopupWindow(CoreWebView2Environment env, string url, int width, int height, ToolboxItem item)
        {
            var popup = new WebView2Form(env, url, width, height, item.Title);
            popup.Show(CGlobalVal.MainForm);
            item.floatWebViewHost = popup.host;
        }
    }
}
