using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader
{
    public static class CGlobalMessage
    {
        static List<string> Message = new List<string>();

        static public void push(string msg)
        {
            Message.Add(msg);
        }

        static public string pop()
        {
            if(Message.Count == 0) { return ""; }

            string msg = Message.Last();            // 取出最後一筆
            Message.RemoveAt(Message.Count - 1);    // 移除最後一筆
            return msg;
        }
    }
}
