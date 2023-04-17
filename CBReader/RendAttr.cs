using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
	// 傳入這類字串
	// "no-marker border bold large"
	// 產生相對應的 style 內容及 class 內容

	public class CRendAttr
	{
		string Rend;
		public string NewStyle = "";   // 由 Rend 的內容自動產生相對應的 Style
		public string NewClass = "";   // 由 Rend 的內容自動產生相對應的 Class
								//List<string> RendList = new List<string>(); // 存放每一組 Rend
		string[] RendList;
		public CRendAttr(string sStr) {
			// 移除最前面的空格
			Rend = sStr.Trim();
			if (Rend != "") {
				RendList = Rend.Split(' ');
				CreateStyle();  // 產生相對應的 Style
			}
		}

		// 產生相對應的 Style
		void CreateStyle() {
			foreach (string sStr in RendList) {
				// 處理 Style
				if (sStr == "border") {
					NewStyle += "border:1px black solid;";
				} else if (sStr == "no-border") {
					NewStyle += "border:0;";
				} else if (sStr == "no-marker") {
					NewStyle += "list-style:none;";
				} else if (sStr == "bold") {
					NewStyle += "font-weight:bold;";
				} else if (sStr == "italic") {
					NewStyle += "font-style:italic;";
				} else if (sStr == "small") {
					NewStyle += "font-size:18px;";	// ???? 要檢討, 及如何應對未來自訂大小
				} else if (sStr == "large") {
					NewStyle += "font-size:24px;";  // ???? 要檢討, 及如何應對未來自訂大小
				} else if (sStr == "circle-above") {
					NewStyle += "text-emphasize:circle-above;";
				} else if (sStr == "text-left") {
					NewStyle += "text-align:left;";
				} else if (sStr == "text-center") {
					// 因為 p 設為 center 會空四格，head 整段空二格，所以要用 0 去取消
					NewStyle += "text-align:center; text-indent:0em !important; margin-left:0em !important;";
				} else if (sStr == "text-right") {
					NewStyle += "text-align:right;";
				} else if (sStr == "mingti" || sStr == "songti") {
					// SimSun/NSimSun 簡體宋體
					// Songti TC Mac 宋體
					NewStyle += "font-family:\"Times New Roman\",MingLiU,細明體,PMingLiU,新細明體,SimSun,NSimSun,\"Songti TC\";";
				} else if (sStr == "kaiti") {
					// STKaiti 是簡體楷體
					// Kaiti TC Mac 楷體
					NewStyle += "font-family:\"Times New Roman\",DFKai-SB,標楷體,STKaiti,\"Kaiti TC\";";
				} else if (sStr == "heiti") {
					// simhei 簡體黑體, Microsoft YaHei 微軟雅黑
					// Heiti TC Mac 黑體
					NewStyle += "font-family:\"Times New Roman\",\"Microsoft JhengHei\",微軟正黑體,\"Microsoft YaHei\",simhei,\"Heiti TC\";";

                    // 處理成 Class

                } else if (sStr.StartsWith("pl-")) {
                    // pl-1 , pl-2 , .....
                    NewClass += sStr + " ";
                } else if (sStr == "under") {
                    NewStyle += "text-decoration:underline;";
                } else if (sStr == "over") {
                    NewStyle += "text-decoration:overline;";
                } else if (sStr == "del") {
                    NewStyle += "text-decoration:line-through;";
                }
            }
		}

		// 在 RendList 找到某字串
		public bool Find(string sStr) {
			if(RendList == null) {
				return false;
            }
			return RendList.Contains(sStr);
		}
	}
}
