using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;


namespace WebLink
{
    public partial class WebView2Form : Form
    {
        public WebView2Host host = null;

        /// <summary>
        /// 可選：共用主 WebView2 的環境
        /// </summary>
        private CoreWebView2Environment sharedEnv = null;

        public WebView2Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            ShowInTaskbar = true;
            InitializeWebView2Host();
        }

        public WebView2Form(CoreWebView2Environment env, string url, int width, int height, string title = "")
        {
            InitializeComponent();
            sharedEnv = env;
            Width = width;
            Height = height;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            ShowInTaskbar = true;

            InitializeWebView2Host();

            if (!string.IsNullOrEmpty(title))
                Text = title;

            if (!string.IsNullOrEmpty(url))
                _ = Navigate(url);
        }

        /// <summary>
        /// 建立並加入 WebView2Host
        /// </summary>
        private async void InitializeWebView2Host()
        {
            host = new WebView2Host { Dock = DockStyle.Fill };
            await host.InitializeAsync(sharedEnv);
            host.btClose.Visible = false;
            Controls.Add(host);
        }

        /// <summary>
        /// 導航至指定網址
        /// </summary>
        public async Task Navigate(string url)
        {
            if (host == null)
                return;

            //await host.InitializeAsync(sharedEnv);
            host.Navigate(url);
        }

        /// <summary>
        /// 允許外部直接取用內部 WebView 控制項
        /// </summary>
        public Microsoft.Web.WebView2.WinForms.WebView2 WebView => host.webView;

        private void WebView2Form_Shown(object sender, EventArgs e)
        {

        }
    }
}
