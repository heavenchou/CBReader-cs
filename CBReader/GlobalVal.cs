using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    static public class CGlobalVal
    {
        [DllImport("user32.dll")]
        static extern uint GetDpiForSystem();

        // CBETA 版
        // 更新版本注意事項, 要改底下資訊,
        // 還有 project 的版本號碼，主要 icon，各 Form 的 icom
        // 還有 About 畫面的版本與日期資料
        // 跨年要改 project 的著作權及商標年份

        ///*
        static public string ProgramTitle = "CBReader 毘舍離版";
        static public string ApplicationTitle = "CBReader";
        static public string Version = "0.8.4.0";         // 末位 .1 是全西蓮, .2 是西蓮+CBETA
        //*/

        // 西蓮淨苑版
        // 更新版本注意事項, 要改底下資訊,
        // 還有 project 的版本號碼，主要 icon，各 Form 的 icom
        // 還有 About 畫面的版本與日期資料 （程式會自動將 CBReader 改成 SLReader）
        // 程式檔要改 SLReader.exe
        // 跨年要改 project 的著作權及商標年份

        /*
        static public string ProgramTitle = "SLReader 毘舍離版";
        static public string ApplicationTitle = "SLReader";
        static public string Version = "0.8.3.1";         // 末位 .1 是全西蓮, .2 是西蓮+CBETA
        //*/

        //static public string ProgramTitle = "CBETA 漢文電子佛典集成";  // 改由 Serial.Title 提供
       
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
        static public bool restart = false;       // 如果要重新啟動程式，就設為 true

        static public float scaleFactor = 1.0f;        // windows 縮放比

        // 設定目錄初值
        static public void initialPath()
        {
            // 程式主目錄
            MyFullPath = pathAddSlash(AppDomain.CurrentDomain.BaseDirectory);

            // Temp 目錄
            if (ApplicationTitle == "SLReader") {
                MyTempPath = Path.GetTempPath() + "SLReader\\";
            } else {
                MyTempPath = Path.GetTempPath() + "CBReader\\";
            }

            if(!Directory.Exists(MyTempPath)) {
                Directory.CreateDirectory(MyTempPath);
            }

            // 使用者個人目錄
            // C:\\Users\\Heaven\\AppData\\Roaming\\
            MyHomePath = pathAddSlash(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            // 設定檔目錄
            MySettingPath = MyHomePath + "CBETA\\";
            if (!Directory.Exists(MySettingPath)) {
                Directory.CreateDirectory(MySettingPath);
            }

            if (ApplicationTitle == "SLReader") {
                MySettingPath = MySettingPath + "SLReader2X\\";
            } else {
                MySettingPath = MySettingPath + "CBReader2X\\";
            }

            if (!Directory.Exists(MySettingPath)) {
                Directory.CreateDirectory(MySettingPath);
            }

            // 設定檔
            if (ApplicationTitle == "SLReader") {
                SettingFile = MySettingPath + "slreader.ini";
            } else {
                SettingFile = MySettingPath + "cbreader.ini";
            }

            // 查 windows 縮放比
            // 獲取系統 DPI 值
            uint dpi = GetDpiForSystem();
            // 計算縮放比例
            scaleFactor = (float)dpi / 96.0f;
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
