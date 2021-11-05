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
    public class CSettingTests
    {
        CSetting setting = new CSetting(@"d:\Data\csharp\CBReader\CBReaderTests\TestData\test.ini");

        [TestMethod()]
        public void CSettingTest()
        {
            // 預設值

            Assert.AreEqual(setting.ShowLineFormat, false);
            Assert.AreEqual(setting.CollationType, ECollationType.CBETA);
            Assert.AreEqual(setting.BookcasePath, "Bookcase");

            // 新值

            setting.ShowLineFormat = true;
            setting.CollationType = ECollationType.Orig;
            setting.BookcasePath = "testPath";

            setting.SaveToFile();

            Assert.AreNotEqual(setting.ShowLineFormat, false);
            Assert.AreNotEqual(setting.CollationType, ECollationType.CBETA);
            Assert.AreNotEqual(setting.BookcasePath, "Bookcase");

            setting.ShowLineFormat = false;
            setting.CollationType = ECollationType.CBETA;
            setting.BookcasePath = "Bookcase";

            Assert.AreEqual(setting.ShowLineFormat, false);
            Assert.AreEqual(setting.CollationType, ECollationType.CBETA);
            Assert.AreEqual(setting.BookcasePath, "Bookcase");

            // 載入新值

            setting.LoadFromFile();

            Assert.AreEqual(setting.ShowLineFormat, true);
            Assert.AreEqual(setting.CollationType, ECollationType.Orig);
            Assert.AreEqual(setting.BookcasePath, "testPath");

            // 還原

            setting.ShowLineFormat = false;
            setting.CollationType = ECollationType.CBETA;
            setting.BookcasePath = "Bookcase";

            // 存起來

            setting.SaveToFile();

            // 新值

            setting.ShowLineFormat = true;
            setting.CollationType = ECollationType.Orig;
            setting.BookcasePath = "testPath";

            Assert.AreEqual(setting.ShowLineFormat, true);
            Assert.AreEqual(setting.CollationType, ECollationType.Orig);
            Assert.AreEqual(setting.BookcasePath, "testPath");

            // 載入舊值

            setting.LoadFromFile();

            Assert.AreEqual(setting.ShowLineFormat, false);
            Assert.AreEqual(setting.CollationType, ECollationType.CBETA);
            Assert.AreEqual(setting.BookcasePath, "Bookcase");
        }
    }
}