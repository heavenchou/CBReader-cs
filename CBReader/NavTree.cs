using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBReader
{
	class CNavTree
	{
		TreeView TreeView;   // 傳入的 TreeView
		List<SNavItem> TreeRoot = new List<SNavItem>(); // 樹狀目錄, 內容即是 NavItem
		CNavXML NavXML;

		public string XMLFile; // XML 檔名

		public CNavTree(string sFile)
		{
			XMLFile = sFile;
			NavXML = new CNavXML(XMLFile);
			NavXML.SaveToTree(TreeRoot); // 將 XML 載入 TreeRoot
		}

		// 將資料呈現在樹狀目錄上, 傳入樹及要連結的函式
		public void SaveToTreeView(TreeView tvTreeView)
		{
			TreeView = tvTreeView;
			TreeView.Nodes.Clear();

			TreeNode ParentItem = null;  // 第一個 ParentItem 是 TreeView
			int iPreLevel = -1;  // 前一個 item 的層次, 預設為 0

			for (int i = 0; i < TreeRoot.Count; i++) {
				SNavItem nItem = TreeRoot[i];
				int iThisLevel = nItem.Level;   // 要建立的層次

				// 若是下一層, 則此 Item 就是前一個 Item 的子層
				// 若不是下一層, 則要往上找
				// ex . 前一層是 4 , 這層也是 4 , 所以這層的父層就是 3
				//    若前一層是 4 , 這層也是 2 , 所以這層的父層就是 1

				if (iThisLevel != iPreLevel + 1) {
					for (int j = 0; j < iPreLevel - iThisLevel + 1; j++) {
						ParentItem = ParentItem.Parent;
					}
				}

				TreeNode tvItem;

				if (iThisLevel == 0) {
					tvItem = TreeViewAddItem(TreeView.Nodes, nItem);
				} else {
					tvItem = TreeViewAddItem(ParentItem.Nodes, nItem);
				}

				ParentItem = tvItem;
				iPreLevel = iThisLevel;
			}
		}

		// 設定 Item 內容, 並加到 NavTreeView 之中, 最後傳回節點位置
		TreeNode TreeViewAddItem(TreeNodeCollection tvItem, SNavItem nItem)
		{
			TreeNode newItem = new TreeNode();
			newItem.Text = nItem.Title;       // 標題
											  // newItem->TagString = nItem->URL;    // URL
			newItem.Tag = nItem;    // nItem->Type;         // Type

			if (nItem.Type == ENavItemType.nit_Title) {
				newItem.ImageIndex = 0;        // 目錄
			} else if (nItem.Type == ENavItemType.nit_NavLink) {
				newItem.ImageIndex = 1;        // 另一個目錄
			} else if (nItem.Type == ENavItemType.nit_CBLink) {
				newItem.ImageIndex = 3;        // CBETA 經文
			} else if (nItem.Type == ENavItemType.nit_NormalLink) {
				newItem.ImageIndex = 2;        // 一般經文
			}
			
			newItem.SelectedImageIndex = newItem.ImageIndex;
			tvItem.Add(newItem);
			return newItem;
		}
	}
}
