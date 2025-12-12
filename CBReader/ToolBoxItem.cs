using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebLink
{
    internal class ToolboxItem
    {
        [JsonPropertyName("group")]
        public string Group { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("runMode")]
        public string RunMode { get; set; }

        [JsonIgnore]
        // 預設為 null，當 RunMode 為 WebView2 時會初始化
        // 用來判斷是否已經有對應的 WebView2Host
        // 可能同時存在兩個 WebView2Host，分別對應 Dock 與 Float 模式
        public WebView2Host dockWebViewHost { get; set; } = null;
        public WebView2Host floatWebViewHost { get; set; } = null;

        // 用來存放工具箱項目的 UI 元素
        public Panel panel { get; set; } = null;
        public PictureBox img { get; set; } = null;
        public Label lbTitle { get; set; } = null;
        public Label lbDescription { get; set; } = null;
        public Label lblSendText { get; set; } = null;
        public Label lblSendTitle { get; set; } = null;

        // 添加一个無参數構造函数，這是要給 JSON 載入資料用的
        public ToolboxItem()
        {
        }
    }
}
