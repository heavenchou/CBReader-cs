using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CBReader
{
    // 所有的 ComboBox 的歷史記錄
    class AllComboBoxHistory
    {
        private Dictionary<string, ComboBoxHistory> allHistory = new Dictionary<string, ComboBoxHistory>();

        public void Add(ComboBox comboBox)
        {
            ComboBoxHistory history = new ComboBoxHistory(comboBox);
            allHistory[comboBox.Name] = history;
        }
        public void AddHistory(ComboBox comboBox)
        {
            string key = comboBox.Name;
            allHistory[key].Add(comboBox.Text);
        }

        public Array Keys()
        {
            return allHistory.Keys.ToArray();
        }

        public void LoadAllHistoryFromIni()
        {
            // 實現從.ini文件載入所有歷史記錄的邏輯
        }

        public void SaveAllHistoryToIni()
        {
            // 實現儲存所有歷史記錄到.ini文件的邏輯
        }
        public string GetHistory(string item)
        {
            return allHistory[item].GetHistory();
        }
        public void SetHistory(string item, string str)
        {
            allHistory[item].SetHistory(str);
        }
    }

    // 單一 ComboBox 的歷史記錄
    class ComboBoxHistory
    {
        private List<string> history = new List<string>();
        ComboBox comboBox = null;

        public ComboBoxHistory(ComboBox obj)
        {
            comboBox = obj;
            comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // 插入一筆，而且放在最前面
        public void Add(string item)
        {
            if (item == "") return;
            history.Remove(item);
            history.Insert(0, item);
            comboBox.Items.Clear();
            comboBox.Items.AddRange (history.ToArray());
        }

        public string GetHistory()
        {
            return string.Join("❣", history);
        }
        public void SetHistory(string str)
        {
            if (str == "") return;
            history = new List<string>(str.Split('❣'));
            comboBox.Items.Clear();
            comboBox.Items.AddRange(history.ToArray());
        }

        public List<string> StringToList(string input)
        {
            return new List<string>(input.Split('❣'));
        }

    }
}
