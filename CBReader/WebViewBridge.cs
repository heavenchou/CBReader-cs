using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    // 用於向網頁註冊 C# 對象，供 JS 調用的類別
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]

    public class WebViewBridge
    {
        // javascript 呼叫的函式
        public void openNoteKey(string url)
        {
            Process.Start(url);
        }
    }
}
