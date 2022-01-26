using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    // 傳入這類字串
    // margin-left:1em;text-indent:1em;inline;border:1px
    // 找出 margin-left , text-indent 數字及是否有 inline
    // border 後面取出的是字串, 不是數字
    public class CStyleAttr
    {
        string Style = "";
        public string NewStyle = "";    // 移除 段首空白與行首空白之後剩的 Style
        public int MarginLeft = 0;
        public int TextIndent = 0;
        public bool HasMarginLeft = false; // 用來判斷有沒有這個屬性
        public bool HasTextIndent = false;

        public CStyleAttr(string sStr)
        {
            // 初值
            Style = sStr;
            if (Style != "") {
                Analysis(); // 進行分析
            }
        }

        void Analysis()
        {
            string sMarginLeft = "";
            string sTextIndent = "";
            string[] StyleList = Style.Split(';');

            foreach (string str in StyleList) {
                // 處理 Style
                string sStr = str.Trim();
                if (sStr.StartsWith("margin-left:")) {
                    sMarginLeft = sStr;
                } else if (sStr.StartsWith("text-indent:")) {
                    sTextIndent = sStr;
                } else if (sStr != "") {
                    NewStyle += sStr + ";";
                }
            }

            // 如果有 MarginLeft:
            if (sMarginLeft != "") {
                // 支援 style="margin-left:1em" 格式
                if (sMarginLeft.Contains("em")) {
                    sMarginLeft = sMarginLeft.Replace("margin-left:", "");
                    sMarginLeft = sMarginLeft.Replace("em", "");
                    HasMarginLeft = true;
                }

                // 因為可能有小數點，所以改用 ToDouble
                try {
                    MarginLeft = (int)Convert.ToDouble(sMarginLeft);
                } catch {
                    MarginLeft = 0;
                }
            }

            // 如果有 sTextIndent:
            if (sTextIndent != "") {
                if (sTextIndent.Contains("em")) {
                    sTextIndent = sTextIndent.Replace("text-indent:", "");
                    sTextIndent = sTextIndent.Replace("em", "");
                    HasTextIndent = true;
                }
                try {
                    TextIndent = (int)Convert.ToDouble(sTextIndent);
                } catch {
                    TextIndent = 0;
                }
            }
        }
    }
}
