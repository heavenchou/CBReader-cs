using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CBReader
{
    /*
     * [{"title":"T 大正新脩大藏經",
        "children":[
	        {"title":"T01 阿含部上 T0001-0098",
	        "children":[
		        {"title":"T0001 長阿含經"},
		        {"title":"T0002 七佛經"},
		        {"title":"T0003 毘婆尸佛經"}
            ]}
        ]}
        ]
     */
    internal class SearchLimitedRange
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("children")]
        public List<SearchLimitedRange> Children { get; set; }
         // 添加一个無参數構造函数，這是要給 JSON 載入資料用的
        public SearchLimitedRange()
        {
        }
    }

    /* 
        儲存的檔案
        {"file_type":"Search Limited Range File",
         "page": "Sutra Single",
         "children":[
            "T0001",
            "T0026",
            "T0125"
         ]
        }
    */
    internal class SearchLimitedRangeFile
    {
        [JsonPropertyName("file_type")]
        public string FileType { get; set; }

        [JsonPropertyName("page")]
        public string Page { get; set; }

        [JsonPropertyName("children")]
        public List<string> Children { get; set; }

        // 添加一个無参數構造函数，這是要給 JSON 載入資料用的
        public SearchLimitedRangeFile()
        {
        }

        public void Initial()
        {
            FileType = "Search Limited Range File";
            Page = "Sutra Single";
            Children = new List<string>();
        }

        // 載入舊版的格式
        /*
        [ActivePage]
        ActivePage=tsSearchByBuleiSingle
        [SearchRange]
        。。。。
        [BuleiSingle]
        0=T01n0001
        1=T01n0005
        2=T01n0006
        3=
        [SutraSingle]
        */

        public void LoadFromOldFile(string[] lines)
        {
            Initial();
            bool bStartLoading = false;
            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];

                if (line == "[SutraSingle]") {
                    return;
                }

                // 開始載入
                if (bStartLoading) {
                    Match m = Regex.Match(line, @"\d+=([A-Z]+)\d+n(\S*)");
                    if (m.Success) {
                        string s = m.Groups[1].Value + m.Groups[2].Value;
                        Children.Add(s);
                    }
                }

                // 遇到 [BuleiSingle] 就開始處理
                if (line == "[BuleiSingle]") {
                    bStartLoading = true;
                }
            }
        }

        public void AddSutra(string str)
        {
            Children.Add(str);
        }

        public override string ToString()
        {
            string sJson = "";

            sJson += "{\n";
            sJson += $"  \"file_type\": \"{FileType}\",\n";
            sJson += $"  \"page\": \"{Page}\",\n";
            sJson += $"  \"children\": [\n";

            // 使用 string.Join() 來將 List<string> 格式化為 JSON
            sJson += string.Join(",\n", Children.Select(sutra => $"    \"{sutra}\""));

            sJson += "\n  ]\n";
            sJson += "}";

            return sJson;
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, new UTF8Encoding(false))) {
                sw.Write(ToString());
            }
        }
    }
}
