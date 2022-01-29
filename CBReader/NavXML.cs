using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CBReader
{
    // NavTree 樹狀結構分枝的每一個項目的總類
    public enum ENavItemType
    {
        nit_Title, // 沒有連結的純文字
        nit_NormalLink, // 一般的連結
        nit_NavLink, // 連結另一個目錄
        nit_CBLink // 連結 CBETA 的經文
    }

    // NavTree 樹狀結構分枝的每一個項目
    public struct SNavItem
    {
		public int Level; // 層次, 由 0 開始好了
		public ENavItemType Type; // 總類
		public string Title; // 標題
		public string URL; // 連結的位置

        public override string ToString() => Title;
    }


	class CNavXML
	{
		string XMLFile; // XML 檔名
		List<SNavItem> TreeRoot;
		XmlDocument Document = new XmlDocument();

		// Parse 過程中需要暫存的資料
		int ThisLevel = 0;
		SNavItem ThisItem = new SNavItem();

		public CNavXML(string sFile)
		{
			XMLFile = sFile;
			ClearThisItem();
			Document.PreserveWhitespace = true;
			Document.Load(sFile);
		}

		// 處理 NavItem

		// 清除 ThisItem
		void ClearThisItem()
		{
			ThisItem.Level = -1;
			ThisItem.Type = ENavItemType.nit_Title;
			ThisItem.Title = "";
			ThisItem.URL = "";
		}

		// 將目前的 ThisItem 加入 Tree 並清除
		void AddThisItem()
		{
			SNavItem item = new SNavItem();
			if (ThisItem.Title.StartsWith(" ")) {
				ThisItem.Title = ThisItem.Title.Remove(0, 1);
			}
			item = ThisItem;
			TreeRoot.Add(item);
		}

		public void SaveToTree(List<SNavItem> root)
		{
			TreeRoot = root;
			ParseXML();
		}

		// 處理 XML

		// 解析 XML , 儲存到 TreeRoot 中
		void ParseXML()
		{
			XmlNode node;
			TreeRoot.Clear();

			// 遍歷 XML

			node = Document.DocumentElement.GetElementsByTagName("body")[0];

			if (node.ChildNodes.Count == 0) {
				MessageBox.Show("錯誤：導覽文件找不到 body 標記。");
			} else {
				ParseNode(node);
				if (ThisItem.Level != -1) {
					AddThisItem();
				}
			}
		}

		void ParseNode(XmlNode node) // 解析 XML Node
		{
			XmlNodeType nodetype = node.NodeType;

			/* Node Type
            1	ELEMENT_NODE
            2	ATTRIBUTE_NODE
            3	TEXT_NODE
            4	CDATA_SECTION_NODE
            5	ENTITY_REFERENCE_NODE
            6	ENTITY_NODE
            7	PROCESSING_INSTRUCTION_NODE
            8	COMMENT_NODE
            9	DOCUMENT_NODE
            10	DOCUMENT_TYPE_NODE
            11	DOCUMENT_FRAGMENT_NODE
            12	NOTATION_NODE
            */

			if (nodetype == XmlNodeType.Element) {
				// 一般節點
				string sTagName = node.Name;

				if (sTagName == "nav") {
					tagNav(node);
				} else if (sTagName == "ol") {
					tagOl(node);
				} else if (sTagName == "li") {
					tagLi(node);
				} else if (sTagName == "a") {
					tagA(node);
				} else if (sTagName == "cblink") {
					tagCblink(node);
				} else if (sTagName == "navlink") {
					tagNavlink(node);
				} else {
					tagDefault(node);
				}
			} else if (nodetype == XmlNodeType.Text) {
				// 文字節點
				ThisItem.Title += node.Value;
			}
		}
		void parseChild(XmlNode node) // 解析 XML Child
		{
			for (int i = 0; i < node.ChildNodes.Count; i++) {
				XmlNode n = node.ChildNodes[i];
				ParseNode(n);
			}
		}

		// 處理標記
		void tagNav(XmlNode node)
		{
			// 處理標記

			// 遇到 nav 標記要先儲存前一筆資料
			if (ThisItem.Level != -1) {
				AddThisItem();
			}

			ClearThisItem();
			ThisLevel = 0; // 回到最上層
			ThisItem.Level = 0; // 設定新的 Item

			parseChild(node); // 處理內容
			// 結束標記
		}
		void tagOl(XmlNode node)
		{
			// 處理標記
			ThisLevel++; // 回到最上層
			parseChild(node); // 處理內容
			// 結束標記
			ThisLevel--;
		}
		void tagLi(XmlNode node)
		{
			// 遇到 li 標記要先儲存前一筆資料
			if (ThisItem.Level != -1) {
				AddThisItem();
			}
			ClearThisItem();
			ThisItem.Level = ThisLevel;
			parseChild(node); // 處理內容
		}
		void tagA(XmlNode node)
		{
			// 讀取 href 屬性
			string sAttr = node.Attributes["href"].Value;
			if (sAttr != "") {
				ThisItem.URL = sAttr;
				ThisItem.Type = ENavItemType.nit_NormalLink; // 一般的連結
			}
			parseChild(node); // 處理內容
		}
		void tagCblink(XmlNode node)
		{   
			// 讀取 href 屬性
			string sAttr = node.Attributes["href"].Value;
			if (sAttr != "") {
				ThisItem.URL = sAttr;
				ThisItem.Type = ENavItemType.nit_CBLink; // 一般的連結
			}
			parseChild(node); // 處理內容
		}
		void tagNavlink(XmlNode node)
		{
			// 讀取 href 屬性
			String sAttr = node.Attributes["href"].Value;
			if (sAttr != "") {
				ThisItem.URL = sAttr;
				ThisItem.Type = ENavItemType.nit_NavLink; // 一般的連結
			}
			parseChild(node); // 處理內容
		}
		void tagDefault(XmlNode node)
		{
			parseChild(node); // 處理內容
		}
	}
}
