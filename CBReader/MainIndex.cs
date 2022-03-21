using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    public class CMainIndex
    {
        public FileStream FileStream = null;            // 主索引檔
        public string FileName;
        public long Size = 0;

        public CMainIndex(string sFileName)
        {
            FileName = sFileName;
            if(!File.Exists(FileName)) {
                return;
            }
            FileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            Size = FileStream.Length;
        }

        ~CMainIndex()
        {
            if(FileStream != null) {
                FileStream.Close();
            }
        }
    }
}
