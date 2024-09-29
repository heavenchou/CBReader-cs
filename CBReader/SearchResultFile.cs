using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

/* 

舊版格式
<檔案描述>CBReader Search Result File
<檔案版本>3
<原始字串>&6709;&70BA;&6CD5;&0020;&002B;&0020;&5922;&5E7B;&6CE1;&5F71;
<處理字串>有為法 + 夢幻泡影
<樣版字串>S+S
<字詞個數>2
<W>有為法
<W>夢幻泡影
<列表數量>190
<C>1
<B>T
<V>08
<N>0235
<J>1

新版格式

{
    "file_type": "CBReader Search Result File",
    "version": 4,
    "search_string": "有為法 + 夢幻泡影"
    "search_sutra": [
        "T,02,0099,22",
        "T,08,0235,1",
        "T,08,0235,3"
    ]
}
*/

namespace CBReader
{
    internal class SearchResultFile
    {
        
        [JsonPropertyName("file_type")]
        public string FileType { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("search_string")]
        public string SearchString { get; set; }

        [JsonPropertyName("search_sutra")]
        public List<string> SearchSutra { get; set; }

        public string FileName = "";
        public bool IsUpdate = false;

        // 添加一个無参數構造函数，這是要給 JSON 載入資料用的
        public SearchResultFile()
        {
        }

        public SearchResultFile(string searchString)
        {
            FileType = "CBReader Search Result File";
            SearchString = searchString;
            SearchSutra = new List<string>();
        }

        public void AddSutra(string sutra)
        {
            SearchSutra.Add(sutra);
        }

        public override string ToString()
        {
            Version = 4;
            string sJson = "";

            sJson += "{\n";
            sJson += $"  \"file_type\": \"{FileType}\",\n";
            sJson += $"  \"version\": {Version},\n";
            sJson += $"  \"search_string\": \"{SearchString}\",\n";
            sJson += $"  \"search_sutra\": [\n";

            // 使用 string.Join() 來將 List<string> 格式化為 JSON
            sJson += string.Join(",\n", SearchSutra.Select(sutra => $"    \"{sutra}\""));

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
