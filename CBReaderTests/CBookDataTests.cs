using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CBReader.Tests
{
    [TestClass()]
    public class CBookDataTests
    {
        CBookData bookData = new CBookData(@"d:\Data\csharp\CBReader\CBReaderTests\TestData\bookdata.txt");

        [TestMethod()]
        public void CBookDataTest()
        {
            /*
            A,3,【金藏】,趙城金藏,Jin Edition of the Canon
            B,2,【補編】,大藏經補編,Supplement to the Dazangjing
            C,3,【中華】,中華大藏經（中華書局版）,Zhonghua Canon(Chunghwa Book Edition)
            D,2,【國圖】,國家圖書館善本佛典,Selections from the Taipei National Central Library Buddhist Rare Book Collection
            F,2,【房山】,房山石經,Fangshan shijing
            G,3,【佛教】,佛教大藏經,Fojiao Canon
            GA,3,【志彙】,中國佛寺史志彙刊,Zhongguo Fosi Shizhi Huikan
            GB,3,【志叢】,中國佛寺志叢刊,Zhongguo Fosizhi Congkan
            */

            Assert.AreEqual(bookData.Count, 23);
            Assert.AreEqual(bookData.ID[0], "A");
            Assert.AreEqual(bookData.VolCount[2], "3");
            Assert.AreEqual(bookData.VerName[4], "【房山】");
            Assert.AreEqual(bookData.BookName[5], "佛教大藏經");
            Assert.AreEqual(bookData.BookEngName[7], "Zhongguo Fosizhi Congkan");

            // 錯誤測試
            CBookData bookData2;
            try {
                bookData2 = new CBookData("abc.txt");
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message.IndexOf("BookData 文件不存在"), 0);
            }
        }

        [TestMethod()]
        public void GetBookIndexTest()
        {
            Assert.AreEqual(bookData.GetBookIndex("B"), 1);
            Assert.AreEqual(bookData.GetBookIndex("D"), 3);
            Assert.AreEqual(bookData.GetBookIndex("E"), -1);
        }

        [TestMethod()]
        public void GetFullVolStringTest()
        {
            Assert.AreEqual(bookData.GetFullVolString("A", "2"), "A002");
            Assert.AreEqual(bookData.GetFullVolString("A", "03"), "A003");
            Assert.AreEqual(bookData.GetFullVolString("A", "32"), "A032");
            Assert.AreEqual(bookData.GetFullVolString("A", "034"), "A034");
            Assert.AreEqual(bookData.GetFullVolString("A", "0035"), "A035");
        }

        [TestMethod()]
        public void GetVerNameTest()
        {
            Assert.AreEqual(bookData.GetVerName("T"), "【大】");
            Assert.AreEqual(bookData.GetVerName("E"), "");
        }

        [TestMethod()]
        public void GetBookNameTest()
        {
            Assert.AreEqual(bookData.GetBookName("D"), "國家圖書館善本佛典");
            Assert.AreEqual(bookData.GetBookName("E"), "");
        }

        [TestMethod()]
        public void BookToVerNameMapTest()
        {
            Dictionary<string, string> map = bookData.BookToVerNameMap();

            Assert.AreEqual(map["A"], "【金藏】");
            Assert.AreEqual(map["T"], "【大】");
        }
    }
}