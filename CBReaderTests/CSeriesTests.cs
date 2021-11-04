using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBReader.Tests
{
    [TestClass()]
    public class CSeriesTests
    {
        CSeries series = new CSeries(@"d:\Data\csharp\CBReader\CBReaderTests\TestData\");

        [TestMethod()]
        public void LoadMetaDataTest()
        {
            Assert.AreEqual(series.ID, "CBETA");
            Assert.AreEqual(series.Title, "CBETA漢文電子佛典集成");
            Assert.AreEqual(series.BookDataFile, "bookdata.txt");

            // 錯誤測試
            CSeries series2;
            try {
                series2 = new CSeries(@"d:\Data\csharp\CBReader\CBReaderTests\TestData\---");
            } catch(Exception ex) {
                Assert.AreEqual(ex.Message.IndexOf("書籍目錄不存在"), 0);
            }
        }

        [TestMethod()]
        public void CBGetFileNameBySutraNumJuanTest()
        {
            // 由經卷去找經文, Vol 可以是空的, 但有跨冊的經文就要指定
            Assert.AreEqual(series.CBGetFileNameBySutraNumJuan("T", "02", "99"), "XML/T/T02/T02n0099_001.xml");

            // XML/GA/GA001/GA001n0004_007.xml , 0549a01
            Assert.AreEqual(series.CBGetFileNameBySutraNumJuan("GA", "", "4", "7", "549", "a", "3"), "XML/GA/GA001/GA001n0004_007.xml#p0549a03");
        }

        [TestMethod()]
        public void CBGetFileNameByVolPageColLineTest()
        {
            // 由冊頁欄行找經文
            Assert.AreEqual(series.CBGetFileNameByVolPageColLine("GA", "1", "549", "a", "3"), "XML/GA/GA001/GA001n0004_007.xml#p0549a03");

        }
    }
}