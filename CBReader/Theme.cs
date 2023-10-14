using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
//sing System.Windows.Controls;
using System.Windows.Forms;
//using System.Windows.Media;

namespace CBReader
{
    // 一開始只要給目錄，讓它取得所有的語系檔名及語系名稱
    // 更換語系時，就是切換檔名，再更換所有元件文字，取得所有訊息
    public class Theme
    {
        Dictionary<string, Color> DarkColor = new Dictionary<string, Color>();
        Dictionary<string, Color> LightColor = new Dictionary<string, Color>();
        bool IsDarkMode = false;

        public struct myColors
        {
            // 此處說明以亮系為主

            public Color PanelBack;   // Panel 一般色系
            public Color PanelLight;    // Panel 更亮的顏色
            public Color PanelDark;     // Panel 更暗的顏色

            public Color FormBack;

            public Color ButtonBack;
            public Color ButtonText;

            public Color LabelText;
            public Color CheckBoxText;
            public Color RadioButtonText;
            public Color GroupBoxText;

            public Color TabPageBack;

            public Color TreeViewBack;
            public Color TreeViewText;

            public Color DataGridViewBack;
            public Color DataGridViewText;
            public Color DataGridViewRowBack;
            public Color DataGridViewRowText;
            public Color DataGridViewColumnBack;
            public Color DataGridViewColumnText;

            public Color TextBoxBack;
            public Color TextBoxText;

            public Color ComboBoxBack;
            public Color ComboBoxText;

            public Color ListBoxBack;
            public Color ListBoxText;

            public Color MenuItemBack;
            public Color MenuItemText;

            public Color ToolStripBack;
        }

        myColors darkColors;
        myColors lightColors;

        public Theme() // 建構函式, 傳入語系檔目錄
        {
            InitialColors();
        }

        void InitialColors()
        {
            lightColors.FormBack = SystemColors.Control;

            lightColors.PanelBack = SystemColors.Control;
            lightColors.PanelLight = SystemColors.ButtonHighlight;
            lightColors.PanelDark = Color.LightGray;

            lightColors.ButtonText = SystemColors.ControlText;

            lightColors.LabelText = SystemColors.ControlText;
            lightColors.CheckBoxText = SystemColors.ControlText;
            lightColors.RadioButtonText = SystemColors.ControlText;
            lightColors.GroupBoxText = SystemColors.ControlText;

            lightColors.TabPageBack = SystemColors.ButtonHighlight;

            lightColors.TreeViewBack = SystemColors.Window;
            lightColors.TreeViewText = SystemColors.WindowText;

            lightColors.DataGridViewBack = SystemColors.AppWorkspace;
            lightColors.DataGridViewText = SystemColors.WindowText;
            lightColors.DataGridViewRowBack = SystemColors.Window;
            lightColors.DataGridViewRowText = SystemColors.WindowText;

            lightColors.TextBoxBack = SystemColors.Window;
            lightColors.TextBoxText = SystemColors.WindowText;

            lightColors.ComboBoxBack = SystemColors.Window;
            lightColors.ComboBoxText = SystemColors.WindowText;

            lightColors.ListBoxBack = SystemColors.Window;
            lightColors.ListBoxText = SystemColors.WindowText;

            lightColors.MenuItemBack = Color.Transparent;
            lightColors.MenuItemText = SystemColors.ControlText;

            lightColors.ToolStripBack = SystemColors.Window;

            // =======================

            darkColors.FormBack = Color.FromArgb(50, 50, 50);
            darkColors.PanelBack = Color.FromArgb(50, 50, 50);
            darkColors.PanelLight = Color.FromArgb(30, 30, 30);
            darkColors.PanelDark = Color.FromArgb(80, 80, 80);

            darkColors.ButtonBack = Color.FromArgb(90, 90, 90);
            darkColors.ButtonText = Color.FromArgb(220, 220, 220);

            darkColors.LabelText = Color.FromArgb(220, 220, 220);
            darkColors.CheckBoxText = Color.FromArgb(220, 220, 220);
            darkColors.RadioButtonText = Color.FromArgb(220, 220, 220);
            darkColors.GroupBoxText = Color.FromArgb(220, 220, 220);

            darkColors.TabPageBack = Color.FromArgb(30, 30, 30);

            darkColors.TreeViewBack = Color.FromArgb(30, 30, 30);
            darkColors.TreeViewText = Color.FromArgb(220, 220, 220);

            darkColors.DataGridViewBack = Color.FromArgb(50, 50, 50);
            darkColors.DataGridViewText = Color.FromArgb(220, 220, 220);
            darkColors.DataGridViewRowBack = Color.FromArgb(30, 30, 30);
            darkColors.DataGridViewRowText = Color.FromArgb(220, 220, 220);
            darkColors.DataGridViewColumnBack = Color.FromArgb(80, 80, 80);
            darkColors.DataGridViewColumnText = Color.FromArgb(220, 220, 220);

            darkColors.TextBoxBack = Color.FromArgb(30, 30, 30);
            darkColors.TextBoxText = Color.FromArgb(220, 220, 220);

            darkColors.ComboBoxBack = Color.FromArgb(30, 30, 30);
            darkColors.ComboBoxText = Color.FromArgb(220, 220, 220);

            darkColors.ListBoxBack = Color.FromArgb(30, 30, 30);
            darkColors.ListBoxText = Color.FromArgb(220, 220, 220);

            darkColors.MenuItemBack = Color.FromArgb(160, 160, 160);
            darkColors.MenuItemText = SystemColors.ControlText;

            darkColors.ToolStripBack = Color.FromArgb(200, 200, 200);
        }

        // mode : dark, orig
        public void ChangeTheme(bool isDarkMode, params Form[] forms)
        {
            IsDarkMode = isDarkMode;
            foreach (Form form in forms) {
                ChangeFormTheme(form);
            }
        }

        // 更新所有 form 的語系
        public void ChangeFormTheme(Form form)
        {
            if (IsDarkMode) {
                EachControl(lightColors, darkColors, form.Name, form);
            } else {
                EachControl(darkColors, lightColors, form.Name, form);
            }
        }

        void EachControl(myColors oldColors, myColors newColors, string formName, Control c)
        {
            if (c is Form) {
                if (c.BackColor == oldColors.FormBack) {
                    c.BackColor = newColors.FormBack;
                }
            } else if (c is Panel) {
                if (c.BackColor == oldColors.PanelBack) {
                    c.BackColor = newColors.PanelBack;
                } else if (c.BackColor == oldColors.PanelLight) {
                    c.BackColor = newColors.PanelLight;
                } else if (c.BackColor == oldColors.PanelDark) {
                    c.BackColor = newColors.PanelDark;
                }
            } else if (c is Button) {
                if(IsDarkMode) {
                    c.BackColor = darkColors.ButtonBack;
                    c.ForeColor = darkColors.ButtonText;
                } else {
                    ((Button)c).UseVisualStyleBackColor = true;
                    c.ForeColor = lightColors.ButtonText;
                }
            } else if (c is Label) {
                if (c.ForeColor == oldColors.LabelText) {
                    c.ForeColor = newColors.LabelText;
                }
            } else if (c is CheckBox) {
                if (c.ForeColor == oldColors.CheckBoxText) {
                    c.ForeColor = newColors.CheckBoxText;
                }
            } else if (c is RadioButton) {
                if (c.ForeColor == oldColors.RadioButtonText) {
                    c.ForeColor = newColors.RadioButtonText;
                }
            } else if (c is GroupBox) {
                if (c.ForeColor == oldColors.GroupBoxText) {
                    c.ForeColor = newColors.GroupBoxText;
                } else {
                    c.ForeColor = newColors.GroupBoxText;   //???? 不知有些沒變色？所以才用此行
                }
            } else if (c is TabControl) {
                for (int i = 0; i < ((TabControl)c).TabCount; i++) {
                    TabPage tp = ((TabControl)c).TabPages[i];
                    if(IsDarkMode) {
                        tp.BackColor = darkColors.TabPageBack;
                        ((TabControl)c).DrawMode = TabDrawMode.OwnerDrawFixed;
                    } else {
                        tp.BackColor = lightColors.TabPageBack;
                        ((TabControl)c).DrawMode = TabDrawMode.Normal;
                    }
                }
            } else if (c is TreeView) {
                if (c.BackColor == oldColors.TreeViewBack) {
                    c.BackColor = newColors.TreeViewBack;
                }
                if (c.ForeColor == oldColors.TreeViewText) {
                    c.ForeColor = newColors.TreeViewText;
                }
            } else if (c is ListView) {
                if (c.BackColor == oldColors.TreeViewBack) {
                    c.BackColor = newColors.TreeViewBack;
                }
                if (c.ForeColor == oldColors.TreeViewText) {
                    c.ForeColor = newColors.TreeViewText;
                }
            } else if (c is DataGridView) {
                DataGridView dg = (DataGridView)c;
                if (IsDarkMode) {
                    dg.EnableHeadersVisualStyles = false;
                    dg.BackgroundColor = darkColors.DataGridViewBack;
                    //dg.ForeColor = darkColors.DataGridViewText;
                    dg.RowsDefaultCellStyle.BackColor = darkColors.DataGridViewRowBack;
                    dg.RowsDefaultCellStyle.ForeColor = darkColors.DataGridViewText;
                    dg.ColumnHeadersDefaultCellStyle.BackColor = darkColors.DataGridViewColumnBack;
                    dg.ColumnHeadersDefaultCellStyle.ForeColor = darkColors.DataGridViewColumnText;
                } else {
                    dg.EnableHeadersVisualStyles = true;
                    dg.BackgroundColor = lightColors.DataGridViewBack;
                    //dg.ForeColor = darkColors.DataGridViewText;
                    dg.RowsDefaultCellStyle.BackColor = lightColors.DataGridViewRowBack;
                    dg.RowsDefaultCellStyle.ForeColor = lightColors.DataGridViewText;
                }
            } else if (c is TextBox) {
                if (c.BackColor == oldColors.TextBoxBack) {
                    c.BackColor = newColors.TextBoxBack;
                }
                if (c.ForeColor == oldColors.TextBoxText) {
                    c.ForeColor = newColors.TextBoxText;
                }
            } else if (c is ComboBox) {
                if (c.ForeColor == oldColors.ComboBoxText) {
                    c.ForeColor = newColors.ComboBoxText;
                }
                if (IsDarkMode) {
                    c.BackColor = darkColors.ComboBoxBack;
                    ((ComboBox)c).FlatStyle = FlatStyle.Popup;
                } else {
                    c.BackColor = lightColors.ComboBoxBack;
                    ((ComboBox)c).FlatStyle = FlatStyle.Standard;
                }
            } else if (c is ListBox) {
                if (c.BackColor == oldColors.ListBoxBack) {
                    c.BackColor = newColors.ListBoxBack;
                }
                if (c.ForeColor == oldColors.ListBoxText) {
                    c.ForeColor = newColors.ListBoxText;
                }
            } else if (c is MenuStrip) {
                if (IsDarkMode) {
                    c.BackColor = darkColors.MenuItemBack;
                } else {
                    c.BackColor = lightColors.MenuItemBack;
                }
                EachMenuItems(formName, (c as ToolStrip).Items);
            } else if (c is ToolStripPanel) {
                if (c.BackColor == oldColors.PanelBack) {
                    c.BackColor = newColors.PanelBack;
                } else if (c.BackColor == oldColors.PanelLight) {
                    c.BackColor = newColors.PanelLight;
                } else if (c.BackColor == oldColors.PanelDark) {
                    c.BackColor = newColors.PanelDark;
                }
            } else if (c is ToolStrip) {
                if (IsDarkMode) {
                    c.BackColor = darkColors.ToolStripBack;
                } else {
                    c.BackColor = lightColors.ToolStripBack;
                }
            }

            // 檢查 ContextMenuStrip

            ContextMenuStrip cms = c.ContextMenuStrip;
            if (cms != null) {
                if (IsDarkMode) {
                    cms.BackColor = darkColors.MenuItemBack;
                    cms.ForeColor = darkColors.MenuItemText;
                } else {
                    cms.BackColor = lightColors.MenuItemBack;
                    cms.ForeColor = lightColors.MenuItemText;
                }
                EachMenuItems(formName, cms.Items);
            }

            // 檢查下層元件

            foreach (Control cs in c.Controls) {
                EachControl(oldColors, newColors, formName, cs);
            }
        }

        void EachMenuItems(string formName, ToolStripItemCollection items)
        {
            foreach (ToolStripMenuItem item in items) {
                ChangeMenuItemLang(formName, item);
                if (item.HasDropDownItems) {
                    EachMenuItems(formName, item.DropDownItems);
                }
            }
        }

        // 更新選單的語系
        void ChangeMenuItemLang(string formName, ToolStripMenuItem item)
        {
            if (IsDarkMode) {
                item.BackColor = darkColors.MenuItemBack;
                item.ForeColor = darkColors.MenuItemText;
            } else {
                item.BackColor = lightColors.MenuItemBack;
                item.ForeColor = lightColors.MenuItemText;
            }
        }
    }
}
