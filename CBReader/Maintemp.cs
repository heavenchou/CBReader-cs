using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Monster;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebLink;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CBReader
{
    // 為了讓程式可以接收 javascript 的呼叫
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class MainForm : Form
    {
        // 工具箱

        ToolboxManager toolboxManager = new ToolboxManager();
        int toolCardSize = 3;   // 工具箱卡片的 3 種大小

        public MainForm()
        {
            InitializeComponent();
            

            // 載入工具箱
            InitializeToolboxManager();

        }


        // =====================================================
        // 成員函式
        // =====================================================

        // 初始工具箱管理員
        private void InitializeToolboxManager()
        {
            toolboxManager.tcToolbox = tcToolbox;
            toolboxManager.webSplitter = webSplitter;
            
            toolboxManager.loadToolbox(CGlobalVal.MyFullPath + "Toolbox\\toolbox.json");
            DrawToolboxGroup();        
        }



        void DrawToolboxGroup()
        {
            string[] groups = toolboxManager.toolbox
                            .Select(x => x.Group)
                            .Distinct()
                            .ToArray();

            // 暫時停止版面更新，以減少閃爍
            pnToolboxClient.SuspendLayout();

            pnToolboxClient.Controls.Clear();
            int i = 0;
            foreach (var g in groups.Reverse()) { // 修正：加上括號呼叫 Reverse() 方法
                var groupPanel = new FlowLayoutPanel { 
                    Name = $"group_{i}", 
                    AutoSize = true, 
                    WrapContents = true
                };
                // 建立標題
                var lblGroupTitle = new Label {
                    AutoSize = false,
                    Width = pnToolboxClient.Width - 20,
                    Height = 30,
                    Text = g,
                    Font = new Font(SystemFonts.DefaultFont.FontFamily, 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 0, 0),
                    //BackColor = Color.LightGray
                    //BackColor = SystemColors.ButtonHighlight
                };
                var pnGroupTitle = new Panel {
                    Width = pnToolboxClient.Width - 20,
                    Height = 30,
                    Dock = DockStyle.Top,
                    BackColor = Color.LightGray
                };
                foreach (var item in toolboxManager.toolbox) {
                    if (item.Group != g) continue;
                    var card = DrawToolboxCard(item); // 圖示、名稱、說明、釘選開關、顯示位置開關、測試按鈕
                    groupPanel.Controls.Add(card);
                }
                pnToolboxClient.Controls.Add(groupPanel);
                groupPanel.Dock = DockStyle.Top;
                //pnToolboxClient.Controls.Add(lblGroupTitle);
                //lblGroupTitle.Dock = DockStyle.Top;
                pnToolboxClient.Controls.Add(pnGroupTitle);
                pnGroupTitle.Controls.Add(lblGroupTitle);
                lblGroupTitle.Dock = DockStyle.Fill;
                toolTip1.SetToolTip(groupPanel, "【開啟工具箱方式】\nClick:開啟並列視窗\n+Shift:開啟小視窗\n+Ctrl:開啟內建瀏覽器");
            }
            pnToolboxClient.ResumeLayout();
        }

        // ----- 卡片建構 -----
        private Control DrawToolboxCard(ToolboxItem a)
        {
            // 卡片外觀
            var card = new Panel {
                //Name = $"card_{a.ID}",
                Width = 300,
                Height = 60,
                Margin = new Padding(2),
                Padding = new Padding(19),
                BackColor = SystemColors.ButtonHighlight,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = a
            };

            // 圖示
            var pic = new PictureBox {
                Size = new Size(50, 50),
                Location = new Point(4, 4),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                Image = LoadIcon(a.Icon)
            };

            // 標題
            var lblTitle = new Label {
                AutoSize = false,
                Location = new Point(60, 18),
                Size = new Size(card.Width - 55, 25),
                Text = a.Description,
                //Font = new Font(SystemFonts.DefaultFont.FontFamily, 12)
                // Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold)
            };

            // 說明（兩行截斷）
            var lblDesc = new Label {
                AutoSize = false,
                Location = new Point(60, 34),
                Size = new Size(card.Width - 60 - 10, 18), // 二行是 36),
                Text = a.Title,
                ForeColor = SystemColors.GrayText,
                // 隱藏起來
                Visible = false
            };

            // 一個小小的 label ，寫著 T，表示會自動傳入 Title，放在卡面的右上角
            var lblSendText = new Label {
                AutoSize = true,
                Location = new Point(card.Width - 20, 4),
                Text = "文",
                Font = new Font(SystemFonts.DefaultFont.FontFamily, 8),
                ForeColor = Color.Blue,
                BackColor = Color.White,
                Cursor = Cursors.Help,
                // 隱藏起來
                Visible = false
            };

            // 一個小小的 label ，寫著 T，表示會自動傳入 Title，放在卡面的右上角
            var lblSendTitle = new Label {
                AutoSize = true,
                Location = new Point(card.Width - 20, 4),
                Text = "名",
                Font = new Font(SystemFonts.DefaultFont.FontFamily, 8),
                ForeColor = Color.Brown,
                BackColor = Color.White,
                Cursor = Cursors.Help,
                // 隱藏起來
                Visible = false
            };


            /*
            // 釘選/顯示
            var chkPin = new CheckBox {
                Text = "釘選",
                AutoSize = true,
                Location = new Point(10, 60),
                Checked = true
            };

            var chkShow = new CheckBox {
                Text = "顯示",
                AutoSize = true,
                Location = new Point(70, 60),
                Checked = true
            };
            */

            // ToolTip（顯示要開啟的目標）
            //_tip.SetToolTip(card, item.target);
            //_tip.SetToolTip(pic, item.target);
            //_tip.SetToolTip(lblTitle, item.target);
            //_tip.SetToolTip(lblDesc, item.target);


            // 設定滑鼠提示
            toolTip1.SetToolTip(card, a.Description);
            toolTip1.SetToolTip(pic, a.Description);
            toolTip1.SetToolTip(lblTitle, a.Description);
            toolTip1.SetToolTip(lblDesc, a.Description);
            toolTip1.SetToolTip(lblSendTitle, "表示此工具會自動傳入經名");
            toolTip1.SetToolTip(lblSendText, "表示此工具會自動傳入選取的文字");

            // 事件：按鈕或整張卡片皆可啟動

            card.Cursor = Cursors.Hand;
            pic.Cursor = Cursors.Hand;
            lblTitle.Cursor = Cursors.Hand;
            lblDesc.Cursor = Cursors.Hand;

            // void Open(object _, EventArgs __) => openToolCard(a);
            card.Click += Open;
            pic.Click += Open;
            lblTitle.Click += Open;
            lblDesc.Click += Open;
            //lblSendText.Click += Open;
            //lblSendTitle.Click += Open;

            if (a.Source.Contains("{seletext}") || a.Source.Contains("{selechar}") 
                || a.Source.Contains("{cbeta_online}") || a.Source.Contains("{show_img}") 
                || a.Source.Contains("{auto_punct}")) {
                lblSendText.Visible = true;
            }
            if (a.Source.Contains("{sutratitle}")) {
                lblSendTitle.Visible = true;
            }

            void Open(object _, EventArgs __)
            {
                Keys m = ModifierKeys;
                Keys mode = Keys.None;

                if ((m & (Keys.Control | Keys.Alt)) == (Keys.Control | Keys.Alt))
                    mode = Keys.Control | Keys.Alt;
                else if ((m & (Keys.Control | Keys.Shift)) == (Keys.Control | Keys.Shift))
                    mode = Keys.Control | Keys.Shift;
                else if ((m & Keys.Control) != 0)
                    mode = Keys.Control;
                else if ((m & Keys.Shift) != 0)
                    mode = Keys.Shift;
                else if ((m & Keys.Alt) != 0)
                    mode = Keys.Alt;

                openToolCard(a, mode);
            }
            /*
            // 事件：釘選/顯示狀態變更（回寫到模型，視需要保存）
            chkPin.CheckedChanged += (s, e) => {
                //item.pinned = chkPin.Checked;
                //OnActionChanged?.Invoke(item, "pinned");
            };
            chkShow.CheckedChanged += (s, e) => {
                //item.visible = chkShow.Checked;
                //OnActionChanged?.Invoke(item, "visible");
                // 若要即時隱藏卡片，可加：card.Visible = item.visible;
            };
            */

            // 加入控制項
            card.Controls.AddRange(new Control[] { pic, lblTitle, lblDesc, lblSendTitle, lblSendText });

            // 記錄到模型
            a.panel = card;
            a.img = pic;
            a.lbTitle = lblTitle;
            a.lbDescription = lblDesc;
            a.lblSendText = lblSendText;
            a.lblSendTitle = lblSendTitle;

            // 高 DPI/減少閃爍（選用）
            //EnableDoubleBuffer(card);

            return card;
        }

        // ----- 載入圖示（檔案 / Uri；失敗時給預設） -----
        private Image LoadIcon(string pathOrUrl)
        {
            pathOrUrl = "./Toolbox/icons/" + pathOrUrl;
            try {
                if (string.IsNullOrWhiteSpace(pathOrUrl)) return SystemIcons.Application.ToBitmap();

                if (Uri.IsWellFormedUriString(pathOrUrl, UriKind.Absolute)) {
                    // 只處理本機檔/資料夾或 http(s) 快取下載可自行擴充；
                    // 這裡保守：URL 不下載，改用預設。
                    return SystemIcons.Application.ToBitmap();
                }

                if (File.Exists(pathOrUrl))
                    return Image.FromFile(pathOrUrl);
            } catch { /* ignore */ }

            return SystemIcons.Application.ToBitmap();
        }

        /// <summary>
        /// 開啟工具卡
        /// </summary>
        /// <param name="item">傳入的 tool card </param>
        /// <param name="mode">額外的按鍵，包括 ctrl, shift, alt</param>
        // ----- 啟動邏輯 -----
        private async void openToolCard(ToolboxItem item, Keys mode)
        {
            string url = item.Source;

            // 如果 url 中有 {seletext}，則替換成 webView 中選取的文字
            if (url.Contains("{seletext}")) {
                string selectedText = await webView.CoreWebView2.ExecuteScriptAsync("document.getSelection().toString();");
                //selectedText = selectedText.Trim('"');
                selectedText = JsonSerializer.Deserialize<string>(selectedText);
                //url = url.Replace("{seletext}", selectedText); // Uri.EscapeDataString(selectedText));
                url = url.Replace("{seletext}", Uri.EscapeDataString(selectedText));
            }

            // 如果 url 中有 {selechar}，則替換成 webView 中選取文字的第一個字
            if (url.Contains("{selechar}")) {
                string selectedText = await webView.CoreWebView2.ExecuteScriptAsync("document.getSelection().toString();");

                // 去掉前後引號，但這方法不安全，要用 JSON 解析才對
                // selectedText = selectedText.Trim('"');
                selectedText = JsonSerializer.Deserialize<string>(selectedText);

                // 只取第一個字，不過底下的作法要注意 ext-b 等雙字元字元
                // 長度大於 0 時才取，且不可以用 Length 屬性,要用 TextElementEnumerator
                //if (selectedText.Length > 0) {
                //    selectedText = selectedText.Substring(0, 1);
                //}

                if (StringInfo.ParseCombiningCharacters(selectedText).Length > 0) {
                    // 取出第一個字
                    selectedText = StringInfo.GetNextTextElement(selectedText, 0);
                }

                url = url.Replace("{selechar}", Uri.EscapeDataString(selectedText));
            }

            // 如果 url 中有 {sutratitle}，則替換成 webView 中選取文字的第一個字
            if (url.Contains("{sutratitle}")) {
                string selectedText = "";

                string js = @"
    (function(){
        var title = $(""body"").attr(""data-sutraname"");
		title = title.replace(/\(第.*?卷\)$/,"""");
		return title;
    })();
    ";
                selectedText = await webView.CoreWebView2.ExecuteScriptAsync(js);
                // 用 json 移除前後的 ""
                selectedText = JsonSerializer.Deserialize<string>(selectedText);
                // null 時給空字串
                if (selectedText == null) {
                    selectedText = "";
                }
                //url = url.Replace("{seletext}", selectedText); // Uri.EscapeDataString(selectedText));
                url = url.Replace("{sutratitle}", Uri.EscapeDataString(selectedText));
            }

            // 特殊功能，讀取圖檔 {show_img}
            // 整合取代 {show_view_img} 和 {show_sele_img}
            if (url.Contains("{show_img}")) {
                url = "https://dia.dila.edu.tw/uv3/index.html?id=Tv{volnum}p{pagenum},{field_line}";

                // 先判斷是否有選取文字
                // 先取得行首資訊，格式為 T01n0001_p0001a01
                string js = "CBCopy.get_linedata();";
                // ["T02n0099_p0004b22║","T02n0099_p0004b22║"]
                // 若沒有選取文字，則傳回 "null"
                var result = await webView.CoreWebView2.ExecuteScriptAsync(js);
                if (result == "null" || result == "") {
                    // 沒有選取文字，改用目前畫面
                    result = await GetLineHead();
                }

                var match = Regex.Match(result, @"T(\d+)n.*?p(....)(...)");
                // 如果 url 中有 {volnum}，則替換成 webView 中目前頁面的卷號，T02 則是 02
                // 如果 url 中有 {pagenum}，則替換成 webView 中目前頁面的頁碼，p0123 則是 0123

                if (match.Success) {
                    string volNum = match.Groups[1].Value;
                    string pageNum = match.Groups[2].Value;
                    string field_line = match.Groups[3].Value;
                    url = url.Replace("{volnum}", volNum);
                    url = url.Replace("{pagenum}", pageNum);
                    url = url.Replace("{field_line}", field_line);
                } else {
                    url = "https://dia.dila.edu.tw/uv3/index.html?id=Tv01p0001,a01";
                }
            }

            // 特殊功能，cbeta online {cbeta_online}
            if (url.Contains("{cbeta_online}")) {
                // 先判斷是否有選取文字
                // 先取得行首資訊，格式為 T01n0001_p0001a01
                string js = "CBCopy.get_linedata();";
                // ["T02n0099_p0004b22║","T02n0099_p0004b22║"]
                // 若沒有選取文字，則傳回 "null"
                var result = await webView.CoreWebView2.ExecuteScriptAsync(js);
                bool hasSelection = true;
                if (result == "null" || result == "") {
                    // 沒有選取文字，改用目前畫面
                    hasSelection = false;
                    result = await GetLineHead();
                }

                var match = Regex.Match(result, @"([A-Z]+\d+n.*?_?p.......)");
                // 如果 url 中有 {volnum}，則替換成 webView 中目前頁面的卷號，T02 則是 02
                // 如果 url 中有 {pagenum}，則替換成 webView 中目前頁面的頁碼，p0123 則是 0123

                if (match.Success) {
                    url += "," + match.Groups[1].Value;
                }
            }

            // 特殊功能，自動標點 {auto_punct}
            if (url.Contains("{auto_punct}")) {
                // 先判斷是否有選取文字
                string js = "window.getSelection().toString()";
                string result = await webView.CoreWebView2.ExecuteScriptAsync(js);
                result = result.Trim('"');
                url += "," + result;
            }

            // 如果有按下 Ctrl 等鍵，強制用指定模式開啟

            string runMode = item.RunMode;
            if (mode == Keys.Control) {
                runMode = "External";
            } else if (mode == Keys.Shift) {
                runMode = "Float";
            } else if (mode == Keys.Alt) {
                runMode = "Dock";
            } else if (mode == (Keys.Control | Keys.Shift)) {
                runMode = "External+Float";
            } else if (mode == (Keys.Control | Keys.Alt)) {
                runMode = "External+Dock";
            }

            switch (runMode.ToLower()) {
                case "external": {
                    // 系統預設開啟
                    toolboxManager.externalToolboxItem(item, url);
                    return;
                }

                case "float": {
                    // 浮動視窗
                    toolboxManager.FloatToolboxItem(item, url);
                    return;
                }

                case "dock": {
                    toolboxManager.DockToolboxItem(item, url);
                    return;
                }

                // 底下暫時不實際使用

                case "browser-win": {
                    // 瀏覽器彈出視窗
                    // 這功能要小心使用，因為會被瀏覽器擋 popup
                    OpenInBrowserPopup(url);
                    return;
                }
                case "js-win": {
                    // 由 javascript 開啟小視窗
                    string js = $"window.open('{url}', '_blank', 'width=800,height=600');";
                    webView.CoreWebView2.ExecuteScriptAsync(js);
                    return;
                }
                default: {
                    toolboxManager.DockToolboxItem(item, url);
                    return;
                }
            }

            if (item.Source.StartsWith("http")) {
                OpenURL(url);
                return;
            }
            //try {
            //    switch (item.targetType) {
            //        case ActionTarget.Url:
            //        Process.Start(new ProcessStartInfo(item.target) { UseShellExecute = true });
            //        break;

            //        case ActionTarget.File:
            //        case ActionTarget.Program:
            //        var psi = new ProcessStartInfo(item.target) {
            //            UseShellExecute = true,
            //            WorkingDirectory = string.IsNullOrEmpty(item.workingDir) ? Path.GetDirectoryName(item.target) ?? "" : item.workingDir,
            //            Arguments = item.arguments ?? string.Empty
            //        };
            //        Process.Start(psi);
            //        break;
            //    }
            //} catch (Exception ex) {
            //    MessageBox.Show($"無法啟動：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        // 傳回目前畫面中的行首資訊
        public async Task<string> GetLineHead()
        {
            string js = @"
      (() => {
        const lineheads = document.querySelectorAll('.linehead');
        let closest = null;
        let minDistance = Infinity;

        // 檢查第一個 span 是否隱藏
        let bShowLineHead = true;
        if(lineheads[0].style.display == ""none"") {
            bShowLineHead = false;
        }

        if(bShowLineHead == false) {
  	        // 暫時顯示
  	        lineheads.forEach(span => span.style.display = 'inline');
        }

        lineheads.forEach(span => {
            const rect = span.getBoundingClientRect();
            if (rect.top >= 0 && rect.top < minDistance) {
                minDistance = rect.top;
                closest = span;
            }
        });

        if(bShowLineHead == false) {
  	        // 還原
  	        lineheads.forEach(span => span.style.display = 'none');
        }
        if (closest) {
            const lineCode = closest.textContent.trim().replace('║', '');
            return lineCode;
        } else {
            return '';
        }
      })()";

            var result = await webView.CoreWebView2.ExecuteScriptAsync(js);
            return result.Trim('"'); // 去掉 JSON 引號
        }

        void OpenInBrowserPopup(string url)
        {
            string html = $@"
<html><head><script>
window.onload=function(){{
  window.open('{url}','_blank','width=800,height=600');
  window.close();
}};
</script></head></html>";

            string tempFile = Path.Combine(Path.GetTempPath(), "open_popup.html");
            File.WriteAllText(tempFile, html, Encoding.UTF8);
            Process.Start(new ProcessStartInfo(tempFile) { UseShellExecute = true });
        }




        // 將加入選單項目獨立成方法
        private void AddContextMenuItem(CoreWebView2ContextMenuRequestedEventArgs e, string itemTitle, string toolTitle)
        {
            // 如果 itemTitle 是 "--" ，表示加入分隔線
            if (itemTitle == "--") {
                var separator = webView.CoreWebView2.Environment.CreateContextMenuItem(
                    "",
                    null,
                    CoreWebView2ContextMenuItemKind.Separator);
                e.MenuItems.Insert(0, separator);
                return;
            }

            // 先判斷 toolboxManager.toolbox 有沒有 "佛光大辭典"
            if (toolboxManager.toolbox.Any(x => x.Title == toolTitle)) {
                var searchItem = webView.CoreWebView2.Environment.CreateContextMenuItem(
                    itemTitle,
                    null,
                    CoreWebView2ContextMenuItemKind.Command);
                searchItem.CustomItemSelected += async (s, ev) => {
                    // mode 是目前按下的鍵
                    var mode = ModifierKeys;
                    openToolCard(
                        toolboxManager.toolbox.First(x => x.Title == toolTitle),
                        mode);
                };
                // 加到原生選單前面或後面都可以
                e.MenuItems.Insert(0, searchItem);
            }
        }



        private void btChangeCardSize_Click(object sender, EventArgs e)
        {
            // 工具列卡片大小變更
            toolCardSize -= 1;
            if (toolCardSize == 0) toolCardSize = 3;
            changeToolboxCardSize(toolCardSize);
        }

        // 更換卡片大小
        public void changeToolboxCardSize(int size)
        {
            pnToolboxClient.SuspendLayout();
            foreach (var card in toolboxManager.toolbox) {
                if (size == 3) {
                    card.panel.Width = 300;
                    card.panel.Height = 60;
                    card.img.Size = new Size(50, 50);
                    card.img.Location = new Point(4, 4);
                    card.lbTitle.Size = new Size(card.panel.Width - 55, 25);
                    card.lbDescription.Size = new Size(card.panel.Width - 60 - 10, 18);
                    card.lbTitle.Visible = true;
                    card.lbDescription.Visible = false;
                    string tmp = card.lbDescription.Text;
                    card.lbDescription.Text = card.lbTitle.Text;
                    card.lbTitle.Text = tmp;
                    card.lblSendText.Location = new Point(card.panel.Width - 20, 4);
                    card.lblSendTitle.Location = new Point(card.panel.Width - 20, 4);
                } else if (size == 2) {
                    card.panel.Width = 200;
                    card.panel.Height = 60;
                    card.img.Size = new Size(50, 50);
                    card.img.Location = new Point(4, 4);
                    card.lbTitle.Size = new Size(card.panel.Width - 55, 25);
                    card.lbTitle.Visible = true;
                    card.lbDescription.Visible = false;
                    string tmp = card.lbDescription.Text;
                    card.lbDescription.Text = card.lbTitle.Text;
                    card.lbTitle.Text = tmp;
                    card.lblSendText.Location = new Point(card.panel.Width - 20, 4);
                    card.lblSendTitle.Location = new Point(card.panel.Width - 20, 4);
                } else if (size == 1) {
                    card.panel.Width = 60;
                    card.panel.Height = 60;
                    card.img.Size = new Size(50, 50);
                    card.img.Location = new Point(4, 4);
                    card.lbTitle.Visible = false;
                    card.lbDescription.Visible = false;
                }
            }
            pnToolboxClient.ResumeLayout();
        }

        private void tcToolbox_VisibleChanged(object sender, EventArgs e)
        {
            // 同步 splitter 可見狀態
            webSplitter.Visible = tcToolbox.Visible;
        }

        private void tcToolbox_ControlAdded(object sender, ControlEventArgs e)
        {
            // 如果 tabpage 數量不為 0，則取消隱藏
            if (tcToolbox.TabPages.Count > 0) {
                tcToolbox.Visible = true;
            }
        }

        private void tcToolbox_ControlRemoved(object sender, ControlEventArgs e)
        {
            // 如果 tabpage 數量為 0，則本身隱藏
            if (e.Control is TabPage) {
                if (tcToolbox.TabPages.Count == 1) {
                    tcToolbox.Visible = false;
                }
            }
        }
    }
}
