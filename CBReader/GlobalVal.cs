using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    static public class CGlobalVal
    {
        // 更新版本注意事項, 要改底下, 還有 project 的版本
        // 還有 About 畫面的版本與日期資料

        static public string ApplicationTitle = "CBReader";
        static public string ProgramTitle = "CBETA 漢文電子佛典集成";
        static public string Version = "0.6.2.0";         // 末位 .1 是全西蓮, .2 是西蓮+CBETA
        static public string DebugString = "Heaven";      // debug 口令
        static public bool IsDebug = false;             // debug 變數

        // 目錄
        static public string MyFullPath = "";     // 程式主目錄
        static public string MyTempPath = "";     // Temp 目錄
        static public string MyHomePath = "";     // 使用者個人目錄
        static public string MySettingPath = "";  // 設定檔目錄
        static public string MyDesktopPath = "";  // 桌面目錄
        static public string SettingFile = "";    // 設定檔

        // 更新
        static public string updateString = "";   // 更新時取得的字串

        // 設定目錄初值
        static public void initialPath()
        {
            // 程式主目錄
            MyFullPath = pathAddSlash(AppDomain.CurrentDomain.BaseDirectory);

            // Temp 目錄
            MyTempPath = Path.GetTempPath() + "CBReader\\";

            if(!Directory.Exists(MyTempPath)) {
                Directory.CreateDirectory(MyTempPath);
            }

            // 使用者個人目錄
            // C:\\Users\\Heaven\\AppData\\Roaming\\
            MyHomePath = pathAddSlash(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            // 設定檔目錄
            // TODO: 目錄要考慮要不要改名？
            MySettingPath = MyHomePath + "CBETA\\";
            if (!Directory.Exists(MySettingPath)) {
                Directory.CreateDirectory(MySettingPath);
            }
            MySettingPath = MyHomePath + "CBReader2X\\";
            if (!Directory.Exists(MySettingPath)) {
                Directory.CreateDirectory(MySettingPath);
            }

            // 設定檔
            SettingFile = MySettingPath + "cbreader.ini";
        }

        // 目錄結尾加上 / 斜線
        static public string pathAddSlash(string path)
        {
            if (path.EndsWith("\\")) {
                return path;
            }
            return path + "\\";
        }
    }
}
