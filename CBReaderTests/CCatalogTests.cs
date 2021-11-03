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
    public class CCatalogTests
    {
        CCatalog catalog = new CCatalog(@"d:\Data\csharp\CBReader\CBReaderTests\TestData\catalog.txt");

        [TestMethod()]
        public void CCatalogTest()
        {
            // A , 事彙部類 , , 091 , 1057 , 2 , 新譯大方廣佛華嚴經音義 , 唐 慧菀述
            // A , 事彙部類 , , 097 , 1267 , 2 , 大唐開元釋教廣品歷章(第3卷 - 第4卷) , 唐 玄逸撰
            // A , 事彙部類 , , 098 , 1267 , 15 , 大唐開元釋教廣品歷章(第5卷 - 第20卷) , 唐 玄逸撰
            // A , 事彙部類 , , 110 , 1490 , 2 , 天聖釋教總錄 , 宋 惟淨等編修

            Assert.AreEqual(catalog.ID.Length, 4852);
            Assert.AreEqual(catalog.ID[0], "A");
            Assert.AreEqual(catalog.Bulei[0], "事彙部類");
            Assert.AreEqual(catalog.Part[1], "");
            Assert.AreEqual(catalog.Vol[2], "098");
            Assert.AreEqual(catalog.SutraNum[2], "1267");
            Assert.AreEqual(catalog.JuanNum[3], "2");
            Assert.AreEqual(catalog.SutraName[3], "天聖釋教總錄");
            Assert.AreEqual(catalog.Byline[3], "宋 惟淨等編修");

            // 錯誤測試
            CCatalog catalog2;
            try {
                catalog2 = new CCatalog("abc.txt");
            } catch(Exception ex) {
                Assert.AreEqual(ex.Message.IndexOf("Catalog 文件不存在"), 0);
            }

            var i = catalog.FindIndexBySutraNum("T", "2", "0099");
            Assert.AreEqual(catalog.ID[i], "T");
            Assert.AreEqual(catalog.Bulei[i], "阿含部類");
            Assert.AreEqual(catalog.Part[i], "阿含部");
            Assert.AreEqual(catalog.Vol[i], "02");
            Assert.AreEqual(catalog.SutraNum[i], "0099");
            Assert.AreEqual(catalog.JuanNum[i], "50");
            Assert.AreEqual(catalog.SutraName[i], "雜阿含經");
            Assert.AreEqual(catalog.Byline[i], "劉宋 求那跋陀羅譯");

            i = catalog.FindIndexBySutraNum("T", "20", "1062B");
            Assert.AreEqual(catalog.SutraName[i], "世尊聖者千眼千首千足千舌千臂觀自在菩提薩埵怛嚩廣大圓滿無礙大悲心陀羅尼");
            Assert.AreEqual(catalog.Byline[i], "");

            i = catalog.FindIndexBySutraNum("T", "20", "1159A");
            Assert.AreEqual(catalog.SutraName[i], "[峚-大+(企-止)]𡇪大道心驅策法");

            // 找不到的情況
            i = catalog.FindIndexBySutraNum("T", "20", "1062");
            Assert.AreEqual(i, -1);

        }
    }
}