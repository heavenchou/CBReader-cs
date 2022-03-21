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
    public class CCBSutraUtilTests
    {
        [TestMethod()]
        public void getStandardSutraNumberFormatTest()
        {
            // 測試標準經號
            Func<string, string> f = CCBSutraUtil.getStandardSutraNumberFormat;
            Assert.AreEqual(f("23"), "0023");
            Assert.AreEqual(f("12a"), "0012a");
            Assert.AreEqual(f("A12"), "A012");
            Assert.AreEqual(f("7890"), "7890");
            Assert.AreEqual(f("3456B"), "3456B");
            Assert.AreEqual(f("B023"), "B023");
            Assert.AreEqual(f("123456"), "3456");
            Assert.AreEqual(f("0000345"), "0345");
            Assert.AreEqual(f("000789B"), "0789B");
            Assert.AreEqual(f("B000234"), "B234");
        }

        [TestMethod()]
        public void getStandardPageFormatTest()
        {
            // 測試標準頁碼
            Func<string, string> f = CCBSutraUtil.getStandardPageFormat;
            Assert.AreEqual(f(""), "0001");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("1234"), "1234");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("b123"), "b123");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("1"), "0001");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("123"), "0123");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("00011"), "0011");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("20011"), "0011");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("a12"), "a012");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("b0024"), "b024");
            Assert.AreEqual(CCBSutraUtil.getStandardPageFormat("c1024"), "c024");
        }

        [TestMethod()]
        public void getStandardColFormatTest()
        {
            // 測試標準欄位
            Assert.AreEqual(CCBSutraUtil.getStandardColFormat(""), "a");
            Assert.AreEqual(CCBSutraUtil.getStandardColFormat("a"), "a");
            Assert.AreEqual(CCBSutraUtil.getStandardColFormat("abc"), "c");
            Assert.AreEqual(CCBSutraUtil.getStandardColFormat("0"), "a");
            Assert.AreEqual(CCBSutraUtil.getStandardColFormat("1"), "a");
            Assert.AreEqual(CCBSutraUtil.getStandardColFormat("3"), "c");
            Assert.AreEqual(CCBSutraUtil.getStandardColFormat("234"), "d");
        }

        [TestMethod()]
        public void getStandardLineFormatTest()
        {
            // 測試標準行數
            Assert.AreEqual(CCBSutraUtil.getStandardLineFormat(""), "01");
            Assert.AreEqual(CCBSutraUtil.getStandardLineFormat("23"), "23");
            Assert.AreEqual(CCBSutraUtil.getStandardLineFormat("5"), "05");
            Assert.AreEqual(CCBSutraUtil.getStandardLineFormat("12345"), "45");
        }

        [TestMethod()]
        public void getStandardPageColLineTest()
        {
            Assert.AreEqual(CCBSutraUtil.getStandardPageColLine("", "", ""), "");
            Assert.AreEqual(CCBSutraUtil.getStandardPageColLine("0123", "a", "45"), "0123a45");
            Assert.AreEqual(CCBSutraUtil.getStandardPageColLine("123", "a", "5"), "0123a05");
            Assert.AreEqual(CCBSutraUtil.getStandardPageColLine("123", "1", "5"), "0123a05");
            Assert.AreEqual(CCBSutraUtil.getStandardPageColLine("12", "2", "456"), "0012b56");
            Assert.AreEqual(CCBSutraUtil.getStandardPageColLine("12345", "b", "0"), "2345b00");
        }
    }
}