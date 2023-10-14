using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CBReader
{
    public class BookmarkItemRoot : BookmarkItem
    {
        [JsonPropertyName("label")]
        public override string Title { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("online_ver")]
        public int Online_Ver { get; set; }

        [JsonPropertyName("cbrwin_ver")]
        public int CBRWin_Ver { get; set; }

        [JsonPropertyName("cbrmac_ver")]
        public int CBRMac_Ver { get; set; }

        [JsonPropertyName("updated-at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("updated-by")]
        public string UpdatedBy { get; set; }

        [JsonPropertyName("data")]
        public override List<BookmarkItem> Children { get; set; } // 子書籤列表

        // 添加一个無参數構造函数，這是要給 JSON 載入資料用的
        public BookmarkItemRoot() : base()
        {
        }

        public BookmarkItemRoot(string title): base(title)
        {
        }

        public void SaveToFile(string filename, bool bForCompare = false)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8)) {
                sw.Write(ToString(bForCompare));
            }
        }

        // ForComp 表示只是用來比較有沒有更新，不用輸出版本、時間等等
        public string ToString(bool bForCompare = false)
        {
            string sJson = "";

            // 為了比較書籤有沒有更新
            if(bForCompare) {
                // 比對是否相同，所以不需要版本等資料
                sJson += "{\n";
                sJson += $"  \"label\": \"{Title}\",\n";
                sJson += $"  \"data\": [";
            } else {

                CBRWin_Ver += 1;

                //var culture = new CultureInfo("en-US");
                //string now = DateTime.UtcNow.ToString(culture); 
                // AI 教我的
                string now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss (UTC)");

                sJson += "{\n";
                sJson += $"  \"label\": \"{Title}\",\n";
                sJson += $"  \"version\": \"{CGlobalVal.BookmarkVersion}\",\n";
                sJson += $"  \"online_ver\": {Online_Ver},\n";
                sJson += $"  \"cbrwin_ver\": {CBRWin_Ver},\n";
                sJson += $"  \"cbrmac_ver\": {CBRMac_Ver},\n";
                sJson += $"  \"updated-at\": \"{now}\",\n";
                sJson += $"  \"updated-by\": \"CBReader Win\",\n";
                sJson += $"  \"data\": [";
            }
            
            // 處理子層
            int count = 0;
            foreach (BookmarkItem item in Children) {
                if (count > 0) {
                    sJson += ",";
                }
                count++;
                sJson += item.ToString(1);
            }

            sJson += "]\n";
            sJson += "}";

            return sJson;
        }

        // 比對二組書籤是否相同
        public bool IsSameWith(BookmarkItemRoot root)
        {
            if(root == null) return false;

            string output1 = ToString(true);
            string output2 = root.ToString(true);
            if(output1 == output2) {
                return true;
            }
            return false;
        }
    }

    public class BookmarkItem
    {
        [JsonPropertyName("title")]
        public virtual string Title { get; set; }   // 書籤標題

        [JsonPropertyName("link_target")]
        public string URL { get; set; }     // 書籤網址
                                            // public string Keyword { get; set; } // 關鍵詞
        [JsonPropertyName("isFolder")] 
        public bool IsFolder { get; set; } // 是否是目錄
        // public List<string> Tag { get; set; }     // 標籤

        [JsonPropertyName("children")]
        public virtual List<BookmarkItem> Children { get; set; } // 子書籤列表
        public BookmarkItem Parent { get; set; } // 父書籤

        // 添加一个無参數構造函数，這是要給 JSON 載入資料用的
        public BookmarkItem()
        {
            //Children = new List<BookmarkItem>();
        }

        // 宣告一個網址
        public BookmarkItem(string title, string url)
        {
            Title = title;
            URL = url;
            // Keyword = "";
            IsFolder = false;
            // Tag = new List<string>();
            //Children = new List<BookmarkItem>();
            Parent = null;
        }

        // 宣告一個目錄
        public BookmarkItem(string title)
        {
            Title = title;
            URL = "";
            // Keyword = "";
            IsFolder = true;
            // Tag = null;
            Children = new List<BookmarkItem>();
            Parent = null;
        }

        // 加入書籤到指定的父書籤
        public void addBookmark(BookmarkItem newBookmark)
        {
            if (Children == null) { return; }
            Children.Add(newBookmark);
            newBookmark.Parent = this; // 設定新書籤的父書籤
        }

        /*
         {
            "label": "醫藥",
            "data": [{
                    "title": "阿含部",
                    "isFolder": true,
                    "children": [{
                        "title": "〔醫術與藥學〕",
                        "isFolder": true,
                        "children": [{
                                "title": "阿摩尼-藥",
                                "link_target": "T01n0026_p0713a12.1-T01n0026_p0713a14"
         */
        public virtual string ToString(int level)
        {
            string sJson = "";
            string space0 = string.Concat(Enumerable.Repeat("  ", level));  // 父層空白
            string space1 = string.Concat(Enumerable.Repeat("  ", level + 1));  // 子層空白

            if (level == 0) {
                sJson += "{\n";
                sJson += space1 + $"\"label\": \"{Title}\",\n";
                sJson += space1 + $"\"data\": [";
            } else {
                sJson += "{\n";
                sJson += space1 + $"\"title\": \"{Title}\",\n";
                if (IsFolder) {
                    sJson += space1 + $"\"isFolder\": true,\n";
                    sJson += space1 + $"\"children\": [";
                } else {
                    string newURL = URL.Replace("\\", "\\\\").Replace("\"", "\\\"");
                    sJson += space1 + $"\"link_target\": \"{newURL}\"\n";
                    sJson += space0 + "}";
                }
            }

            if (IsFolder) {
                // 處理子層
                int count = 0;
                foreach (BookmarkItem item in Children) {
                    if (count > 0) {
                        sJson += ",";
                    }
                    count++;
                    sJson += item.ToString(level + 1);
                }

                sJson += "]\n";
                sJson += space0 + "}";
            }

            return sJson;
        }

        // 載入 JSON 後要重設 Parent

        public void ResetAllParent()
        {
            if (Children == null) {
               // Children = new List<BookmarkItem>();
            }
            if (IsFolder) {
                foreach (BookmarkItem item in Children) {
                    item.Parent = this;
                    item.ResetAllParent();
                }
            }
        }
    }
}
