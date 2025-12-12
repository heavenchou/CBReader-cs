using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebLink
{
    // 一個基本的 WebView2 宿主控制項，包含網址列

    public class WebView2Host : UserControl
    {
        public WebView2 webView { get; private set; }
        public CoreWebView2Environment sharedEnv { get; private set; }

        // 加上網址列
        public TextBox edUrl { get; private set; }

        // 加上關閉按鈕
        public Button btClose { get; private set; }

        public WebView2Form ParentForm { get;  set; }
        public TabPage ParentTagPage { get; set; }

        // 大正藏秀圖採用的參數，若網址相同，就不用再重新載入
        public String lastURL { get; set; } = "";
        
        // 大正藏秀圖採用的參數，預設 0.001 之後會隨使用者的調整而調整
        public double lastZoom { get; set; } = 0.001;

        // 大正藏秀圖採用的參數，換頁後會設為 isLoadNewImage 為 true
        public bool isLoadNewImage = true;
        public WebView2Host()
        {
            //webView = new WebView2 { Dock = DockStyle.Fill };
            webView = new WebView2 {
                Left = 0,
                Top = 30,
                //Height = 26,
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height - 30,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
            };
            Controls.Add(webView);

            edUrl = new TextBox {
                Left = 0,
                Top = 0,
                Height = 30,
                Width = this.ClientSize.Width - 30,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                // 設定 font size 為 11pt
                Font = new System.Drawing.Font(Font.FontFamily, 13),
                ReadOnly = true
            };

            Controls.Add(edUrl);
            edUrl.Width = this.ClientSize.Width - 30;


            btClose = new Button {
                Text = "X",
                Width = 30,
                Height = 30,
                Left = this.ClientSize.Width - Width,
                Top = 0,
                Anchor = AnchorStyles.Top | AnchorStyles.Right

            };
            btClose.Click += (s, e) =>
            {
                // 關閉所在的 TabPage 或 Form
                if (this.Parent is Form) {
                    var f = this.Parent as Form;
                    f.Close();
                    f.Dispose();
                    return;
                }
                if (this.Parent is TabPage) {
                    var tp = this.Parent as TabPage;
                    if (tp != null) {
                        var tc = tp.Parent as TabControl;
                        if (tc != null) {
                            tc.TabPages.Remove(tp);
                            tp.Dispose();
                        }
                    }
                }
            };
            Controls.Add(btClose);
            btClose.Left = this.ClientSize.Width - btClose.Width;
        }

        /// <summary>
        /// 初始化 WebView2，可傳入主環境共用
        /// </summary>
        public async Task InitializeAsync(CoreWebView2Environment sharedEnv = null)
        {
            this.sharedEnv = sharedEnv;

            if (sharedEnv != null)
                await webView.EnsureCoreWebView2Async(sharedEnv);
            else {
                var env = await CoreWebView2Environment.CreateAsync();
                await webView.EnsureCoreWebView2Async(env);
                this.sharedEnv = env;
            }

            // 當導覽發生變化時，更新網址列
            webView.CoreWebView2.SourceChanged += (s, e) =>
            {
                edUrl.Text = webView.Source?.AbsoluteUri ?? "";
            };

            // 也可以在 NavigationCompleted 時再更新一次（確保成功導覽）
            webView.CoreWebView2.NavigationCompleted += (s, e) =>
            {
                edUrl.Text = webView.Source?.AbsoluteUri ?? "";
            };

            // 使用者可以在網址列輸入網址並按 Enter 跳轉
            // 暫時不開放此功能
            /*
            edUrl.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) {
                    Navigate(edUrl.Text);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
            */
        }

        /// <summary>
        /// 導航到指定網址，可附加額外參數
        /// </summary>
        public async void Navigate(string url)
        {
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

            // 特別處理佛光大藏經搜尋
            if (url.Contains("https://etext.fgs.org.tw/sutra_02.aspx")) {
                await OpenFoguangSearchAsync(webView, extraPara);
                return;
            }

            // 特別處理 Dharmamitra 翻譯
            if (url.Contains("https://dharmamitra.org/zh-hant?input_sentence")) {
                await DoDharmaMitraTranslateAsync(webView, url);
                return;
            }

            // 特別處理 Dharmamitra 翻譯
            if (url.Contains("https://dharmamitra.org/zh-hant")) {
                await DoDharmaMitraTranslateAsync2(webView, url, extraPara);
                return;
            }

            // 特別處理大正藏圖檔, 會傳入欄與行，例如 "a03"
            if (url.Contains("https://dia.dila.edu.tw/uv3/index.html")) {
                await ShowTaishoImage(webView, url, extraPara);
                return;
            }

            // 特別處理自動標點，會傳入要標點的句子
            if (url.Contains("{auto_punct}")) {
                await AutoPunct(webView, url, extraPara);
                return;
            }

            // 特別處理 CBETA Online
            if (url.Contains("{cbeta_online}")) {
                url = url.Replace("{cbeta_online}", "https://cbetaonline.dila.edu.tw/zh/");
                url += extraPara;
            }

            if (webView.CoreWebView2 != null)
                webView.CoreWebView2.Navigate(url);
            else
                webView.Source = new Uri(url);
            edUrl.Text = url;
        }

        // 自動翻譯 Dharmamitra 文言文

        async Task DoDharmaMitraTranslateAsync(WebView2 webView, string url)
        {
            await webView.EnsureCoreWebView2Async();

            var tcs = new TaskCompletionSource<bool>();

            void onLoaded(object s, CoreWebView2DOMContentLoadedEventArgs e)
            {
                webView.CoreWebView2.DOMContentLoaded -= onLoaded;
                tcs.TrySetResult(true);
            }

            webView.CoreWebView2.DOMContentLoaded += onLoaded;
            webView.Source = new Uri(url);

            // 等待載入完成
            await tcs.Task;

            // 等待 React/MUI 把按鈕渲染出來（最多 5 秒）
            for (int i = 0; i < 25; i++) {
                string exists = await webView.CoreWebView2.ExecuteScriptAsync(
                    "document.querySelector('button[aria-label=\"翻譯\"]') !== null"
                );
                if (exists == "true") break;
                await Task.Delay(200);
            }

            // 模擬點擊按鈕
            await webView.CoreWebView2.ExecuteScriptAsync(
                "document.querySelector('button[aria-label=\"翻譯\"]')?.click();"
            );
        }

    async Task DoDharmaMitraTranslateAsync2(WebView2 webView, string url, string query)
    {
        // 1. 確保 WebView2 初始化
        await webView.EnsureCoreWebView2Async();

        // 2. 建構目標網址（方法一的思路：直接帶參數導航通常最穩，這裡混合使用以確保萬無一失）
        // 如果你只想用 JS 注入，可以保留原本的 url，但建議直接導航帶有參數的 URL，這樣網頁載入時就會自動填入
        // 底下要加問號，以免使用者跑去 https://dharmamitra.org/zh-hant/team，造成無法再次查詢
        string targetUrl = "https://dharmamitra.org/zh-hant?";

        // 檢查是否需要導航
        if (webView.Source == null || !webView.Source.AbsoluteUri.StartsWith(targetUrl)) {
            var tcs = new TaskCompletionSource<bool>();
            void OnLoaded(object s, CoreWebView2DOMContentLoadedEventArgs e)
            {
                webView.CoreWebView2.DOMContentLoaded -= OnLoaded;
                tcs.TrySetResult(true);
            }
            webView.CoreWebView2.DOMContentLoaded += OnLoaded;
            webView.Source = new Uri(targetUrl);
            await tcs.Task;
        }

        // 3. 等待 Textarea 出現
        
        bool textareaFound = false;
        for (int i = 0; i < 30; i++) // 最多等 6 秒
        {
            var result = await webView.CoreWebView2.ExecuteScriptAsync(
                "document.querySelector('textarea') != null"
            );
            if (result == "true") {
                textareaFound = true;
                break;
            }
            await Task.Delay(200);
        }

        //if (!textareaFound) throw new Exception("找不到輸入框");

        // 4. 安全處理文字
        string escaped = JsonSerializer.Serialize(query ?? "");

        // 5. 【關鍵修正】注入 JS：使用 Prototype Setter 繞過 React 限制
        // 這裡我們不使用 history.replaceState，因為那只是視覺效果

        // 這裡是 Gemini 教導如何取得 textarea 的 value 
        /*
        
        React 為了完全掌控網頁，它在啟動時，會把瀏覽器原本單純的 value 屬性功能給「偷換」掉（Override）。

        一般瀏覽器的 value：你給它什麼，它就收什麼，很單純。

        被 React 改寫過的 value：它像個警衛。當你用程式寫入 ta.value = ... 時，這個警衛會攔截下來。
        React 的邏輯通常是：「這是程式碼改的，不是使用者敲鍵盤改的，所以我先更新畫面給你看，
        但我不會把這個變更標記為『需要更新狀態』的事件。」

        所以，當你下一行執行 dispatchEvent 喊著「有東西輸入喔！」的時候： 
        React 的內部邏輯會去檢查：「咦？剛剛好像是程式碼自己改的 value，那個值我已經追蹤到了
        （或者它被視為與內部狀態同步），所以這次的事件是多餘的。」於是它就把這個事件忽略（吞掉）了。

        我的程式為什麼有效？

        JavaScript

        // 找出瀏覽器「原本」的設定功能（繞過 React 警衛）
        const nativeInputValueSetter = Object.getOwnPropertyDescriptor(window.HTMLTextAreaElement.prototype, 'value').set;

        // 用原本的功能強行寫入
        nativeInputValueSetter.call(ta, {escaped});
        這一招等於是繞過大門口的 React 警衛，直接走後門把資料塞進倉庫。 
        當你接著喊 dispatchEvent 時，React 警衛被吵醒，跑去檢查倉庫，
        發現：「天啊！倉庫裡的貨（Value）怎麼跟我的帳本（State）不一樣？」 
        這時候它別無選擇，為了同步，只能乖乖觸發更新流程。這就是為什麼要繞這一大圈的原因。
        
        */

        string jsSet = $@"
    (function() {{
        const ta = document.querySelector('textarea');
        if (!ta) return 'textarea-not-found';

        // --- 核心修正開始 ---
        // 獲取原生的 value setter，繞過 React 的覆寫
        
        const nativeInputValueSetter = Object.getOwnPropertyDescriptor(window.HTMLTextAreaElement.prototype, 'value').set;
        
        // 使用原生 setter 設定值
        nativeInputValueSetter.call(ta, {escaped});
        
        // 派發 input 事件，讓 React 接收到變更通知
        const event = new Event('input', {{ bubbles: true }});
        ta.dispatchEvent(event);
        // --- 核心修正結束 ---

        return 'ok';
    }})();
    ";

        await webView.CoreWebView2.ExecuteScriptAsync(jsSet);

        // 6. 等待狀態更新與按鈕啟用
        // React 處理狀態需要一點時間，且按鈕可能會有 debounce (防手震) 機制
        await Task.Delay(500);

        // 7. 點擊翻譯按鈕
        string jsClick = @"
    (function(){
        // 嘗試尋找翻譯按鈕 (根據你的觀察 aria-label 為 '翻譯')
        // 為了保險，增加備用選擇器
        const btn = document.querySelector('button[aria-label=""翻譯""]') || 
                    Array.from(document.querySelectorAll('button')).find(b => b.textContent.includes('翻譯'));
        
        if (btn) {
            btn.click();
            return 'clicked';
        }
        return 'button-not-found';
    })();
    ";

        string clickResult = await webView.CoreWebView2.ExecuteScriptAsync(jsClick);

        // 如果回傳 "button-not-found"，你可能需要檢查按鈕的選擇器是否改變
        System.Diagnostics.Debug.WriteLine($"Click Result: {clickResult}");
    }


        async Task OpenFoguangSearchAsync(WebView2 webView, string query)
        {
            // 確保 CoreWebView2 已初始化
            await webView.EnsureCoreWebView2Async();

            if (webView.CoreWebView2 == null)
                throw new InvalidOperationException("CoreWebView2 尚未初始化。");

            // 每次 document 建立時先設定 flag（初始為 false）
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(
                "window.__fgsSearched = false;"
            );

            // 如果目前 webView 不在目標頁面，則導航並等待 DOMContentLoaded
            if (webView.Source == null ||
                !webView.Source.AbsoluteUri.Contains("etext.fgs.org.tw")) {
                var tcs = new TaskCompletionSource<bool>();

                void onLoaded(object s, CoreWebView2DOMContentLoadedEventArgs e)
                {
                    // 解除綁定並完成 tcs
                    webView.CoreWebView2.DOMContentLoaded -= onLoaded;
                    tcs.TrySetResult(true);
                }

                webView.CoreWebView2.DOMContentLoaded += onLoaded;
                webView.Source = new Uri("https://etext.fgs.org.tw/sutra_02.aspx");

                // 等待載入完成（由 onLoaded 解除綁定並 set result）
                await tcs.Task;
            }

            // 確保輸入框出現，等待最多 4 秒（200ms * 20）
            for (int i = 0; i < 20; i++) {
                var exists = await webView.CoreWebView2.ExecuteScriptAsync(
                    "!!document.getElementById('RadSearchBox1_Input')");
                // ExecuteScriptAsync 回傳的是字串 "true" 或 "false"
                if (exists == "true") break;
                await Task.Delay(200);
            }

            // 用 JsonSerializer 轉譯 query，避免 JS 注入
            string escaped = JsonSerializer.Serialize(query ?? "");

            string js = $@"
    (function(){{
      const input = document.getElementById('RadSearchBox1_Input');
      if (!input) return 'input-not-found';

      const kw = {escaped};
      input.focus();
      input.value = kw;

      // 每次都允許重新搜尋：先重設 false（保險）
      window.__fgsSearched = false;

      // 觸發一次 Enter keydown（RadSearchBox 應會處理）
      const ev = new KeyboardEvent('keydown', {{ key:'Enter', code:'Enter', bubbles:true }});
      input.dispatchEvent(ev);

      window.__fgsSearched = true;
      return 'ok';
    }})();";

            var result = await webView.CoreWebView2.ExecuteScriptAsync(js);
            Debug.WriteLine($"FGS Search result: {result}");
        }

        /// <summary>
        /// 呈現 DILA 大正藏圖檔
        /// </summary>
        /// <param name="webView"></param>
        /// <param name="url"></param>
        /// <param name="query">欄與行，例如："a03"</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>

        async Task ShowTaishoImage(WebView2 webView, string url, string query)
        {
            // 確保 CoreWebView2 已初始化
            await webView.EnsureCoreWebView2Async();

            if (webView.CoreWebView2 == null)
                throw new InvalidOperationException("CoreWebView2 尚未初始化。");

            // 如果目前 webView 不在目標頁面，則導航並等待 DOMContentLoaded
            //if (webView.Source == null ||
            //    !webView.Source.AbsoluteUri.Contains("dia.dila.edu.tw")) {
            var tcs = new TaskCompletionSource<bool>();

            void onLoaded(object s, CoreWebView2DOMContentLoadedEventArgs e)
            {
                // 解除綁定並完成 tcs
                webView.CoreWebView2.DOMContentLoaded -= onLoaded;
                tcs.TrySetResult(true);
            }

            webView.CoreWebView2.DOMContentLoaded += onLoaded;
            if (url != lastURL) {
                string js1 = @"myUV.extension.getViewer().viewport.getZoom();";
                var zoom = await webView.CoreWebView2.ExecuteScriptAsync(js1);
                // 第一張圖之前會傳回 null
                if(zoom != "null") {
                    lastZoom = Convert.ToDouble(zoom.Trim('"'));
                }

                webView.Source = new Uri(url);
                lastURL = url;
                isLoadNewImage = true;
                // 等待載入完成（由 onLoaded 解除綁定並 set result）
                await tcs.Task;
                //}
            }

            // 確保輸入框出現，等待最多 4 秒（200ms * 20）
            for (int i = 0; i < 100; i++) {
                var exists = await webView.CoreWebView2.ExecuteScriptAsync(
                    "!!document.getElementById('uv')");
                // ExecuteScriptAsync 回傳的是字串 "true" 或 "false"
                if (exists == "true") break;
                await Task.Delay(1000);
            }

            // 用 JsonSerializer 轉譯 query，避免 JS 注入
            string escaped = JsonSerializer.Serialize(query ?? "");
            await Task.Delay(500);
            string js_暫時不用自行生成了 = @"
(function(){
    manifest = myUV.extension.helper.manifest.id;
    cv = myUV.extension.helper.canvasIndex;
    // xywh = myUV.options.data.xywh;
    myUV = createUV('#uv', {iiifResourceUri: manifest,
      configUri: 'uv-config.json',
      canvasIndex: cv,
      xywh: '0,0,950,850'
    }, new UV.URLDataProvider());
})();";

            // 計算欄與行的座標
            // 第一欄第二行 xywh=1883, 226
            // 第二欄第三行 xywh=1822, 1021
            // 第三欄第29行 xywh=175, 1814
            // 平均每行寬度約 63 （1883-175）/ 27
            // 第 1 行大概在 1883 + 63 = 1946
            // 第 0 行大概在 1946 + 63 = 2009

            int col = 0;
            if(query[0] == 'a') col = 226 + 400;    // 移到欄的中間
            else if(query[0] == 'b') col = 1021 + 400;
            else if(query[0] == 'c') col = 1814 + 400;

            int line = Convert.ToInt32(query.Substring(1));
            line = 2009 - (line * 63);

            // Viewport API
            // https://openseadragon.github.io/docs/OpenSeadragon.Viewport.html

            if (isLoadNewImage) {
                string js1 = $@"myUV.extension.getViewer().viewport.zoomTo({lastZoom});";
                _ = await webView.CoreWebView2.ExecuteScriptAsync(js1);
                isLoadNewImage = false;
            }

            string js = $@"
myUV.extension.getViewer().viewport.panTo(new OpenSeadragon.Point({line}, {col}), true);
";

            var result = await webView.CoreWebView2.ExecuteScriptAsync(js);
        }


        async Task AutoPunct(WebView2 webView, string url, string query)
        {
            // 確保 CoreWebView2 已初始化
            await webView.EnsureCoreWebView2Async();

            if (webView.CoreWebView2 == null)
                throw new InvalidOperationException("CoreWebView2 尚未初始化。");

            url = "https://ocr.gj.cool/get_punct";

            // 3. 準備 POST 的內容
            // 網頁上的 <textarea name="text"> 對應這裡的 key 為 "text"
            // 必須進行 URL 編碼，避免特殊符號導致傳輸錯誤
            string postData = "text=" + Uri.EscapeDataString(query);

            // 將字串轉為 Byte Array，再轉為 MemoryStream
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            MemoryStream stream = new MemoryStream(byteArray);

            // 4. 建立 WebResourceRequest
            // 參數說明: URL, Method, PostDataStream
            CoreWebView2WebResourceRequest request =
                webView.CoreWebView2.Environment.CreateWebResourceRequest(
                    url,
                    "POST",
                    stream, // 需要轉為 WinRT 的 Stream
                    "Content-Type: application/x-www-form-urlencoded" // 必要 Header
                );

            // 5. 導航 (這會在目前的 WebView 中載入結果)
            webView.CoreWebView2.NavigateWithWebResourceRequest(request);
            
        }
    }
}
