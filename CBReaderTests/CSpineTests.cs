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
    public class CSpineTests
    {
        CSpine spine = new CSpine(@"d:\Data\csharp\CBReader\CBReaderTests\TestData\spine.txt");

        [TestMethod()]
        public void CSpineTest()
        {
            Assert.AreEqual(spine.Count, 20190);
            Assert.AreEqual(spine.Files[1], "XML/T/T01/T01n0001_002.xml , 0011a02");

            // 錯誤測試
            CSpine spine2;
            try {
                spine2 = new CSpine("abc.txt");
            } catch(Exception ex) {
                Assert.AreEqual(ex.Message.IndexOf("Spine 文件不存在"), 0);
            }

            // 由經卷去找 XML 檔名

            CJuanLine juanLine = new CJuanLine(spine);
            Func<string, string, string, string, string> f = spine.CBGetFileNameBySutraNumJuan;

            Assert.AreEqual(spine.CBGetFileNameBySutraNumJuan("T", "1", "1"), "XML/T/T01/T01n0001_001.xml");
            Assert.AreEqual(f("T", "2", "99", "30"), "XML/T/T02/T02n0099_030.xml");
            Assert.AreEqual(f("T", "002", "00099", "22"), "XML/T/T02/T02n0099_022.xml");
            Assert.AreEqual(f("T", "2", "128", "1"), "XML/T/T02/T02n0128a_001.xml");
            Assert.AreEqual(f("T", "2", "128a", "1"), "XML/T/T02/T02n0128a_001.xml");
            Assert.AreEqual(f("T", "2", "128b", "1"), "XML/T/T02/T02n0128b_001.xml");
            Assert.AreEqual(f("P", "178", "1611", "4"), "XML/P/P178/P178n1611_004.xml");
            Assert.AreEqual(f("ZW", "4", "42", "1"), "XML/ZW/ZW04/ZW04n0042_001.xml");
            Assert.AreEqual(f("ZW", "4", "43", "1"), "XML/ZW/ZW04/ZW04n0043a_001.xml");
            Assert.AreEqual(f("ZW", "4", "43a", "1"), "XML/ZW/ZW04/ZW04n0043a_001.xml");
            Assert.AreEqual(f("ZW", "4", "43b", "1"), "XML/ZW/ZW04/ZW04n0043b_001.xml");
        }

        [TestMethod()]
        public void CJuanLineTest()
        {
            CJuanLine juanLine = new CJuanLine(spine);

            // XML/T/T01/T01n0001_005.xml , 0030b06
            Assert.AreEqual(spine.BookID[4], "T");
            Assert.AreEqual(spine.Vol[4], "T01");
            Assert.AreEqual(spine.VolNum[4], "01");
            Assert.AreEqual(spine.Sutra[4], "0001");
            Assert.AreEqual(spine.Juan[4], "005");

            //   8: XML/T/T01/T01n0001_008.xml , 0047a14
            // 215: XML / T / T02 / T02n0099_001.xml , 0001a01
            Assert.AreEqual(juanLine.Vol["T01"].PageLine[7], "0047a14");
            Assert.AreEqual(juanLine.Vol["T01"].SerialNo[7], 7);
            Assert.AreEqual(juanLine.Vol["T02"].PageLine[0], "0001a01");
            Assert.AreEqual(juanLine.Vol["T02"].SerialNo[0], 214);

            // 新頁碼行數
            Assert.AreEqual(juanLine.GetNewPageLine("c0123b01"), "1c0123b01");
            Assert.AreEqual(juanLine.GetNewPageLine("1234a33"), "21234a33");
            Assert.AreEqual(juanLine.GetNewPageLine("y7890c25"), "2y7890c25");

            // 傳入檔名, 找出書,冊,經,卷
            var (b, v, s, j) = juanLine.GetBookVolSutraJuan("XML/T/T01/T01n0001_001.xml");
            Assert.AreEqual(b, "T");
            Assert.AreEqual(v, "01");
            Assert.AreEqual(s, "0001");
            Assert.AreEqual(j, "001");
            (b, v, s, j) = juanLine.GetBookVolSutraJuan("XML/ZW/ZW123/ZW123n2345a_042.xml");
            Assert.AreEqual(b, "ZW");
            Assert.AreEqual(v, "123");
            Assert.AreEqual(s, "2345a");
            Assert.AreEqual(j, "042");
            (b, v, s, j) = juanLine.GetBookVolSutraJuan("XML/K/K012/K012n2345b789.xml ,---");
            Assert.AreEqual(b, "K");
            Assert.AreEqual(v, "012");
            Assert.AreEqual(s, "2345b");
            Assert.AreEqual(j, "789");

            // 由冊頁欄行找 Spine 的 Index
            Assert.AreEqual(juanLine.CBGetSpineIndexByVolPageColLine("T", "331", "0034", "a", "22"), -1);
            Assert.AreEqual(juanLine.CBGetSpineIndexByVolPageColLine("T", "01", "23", "c", "2"), 2);
            Assert.AreEqual(juanLine.CBGetSpineIndexByVolPageColLine("T", "01", "0023", "c", "03"), 3);
        }
    }
}