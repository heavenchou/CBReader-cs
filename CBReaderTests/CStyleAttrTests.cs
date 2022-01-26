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
    public class CStyleAttrTests
    {
        CStyleAttr myStyle1 = new CStyleAttr("margin-left: 1.7em; color:red;");
        CStyleAttr myStyle2 = new CStyleAttr("margin-left: 3em;color:blue; ");
        CStyleAttr myStyle3 = new CStyleAttr("text-indent: 2 em; color:green;");

        [TestMethod()]
        public void CStyleAttrTest()
        {
            Assert.AreEqual(myStyle1.MarginLeft, 1);
            Assert.AreEqual(myStyle1.NewStyle, "color:red;");
            Assert.AreEqual(myStyle1.TextIndent, 0);
            Assert.AreEqual(myStyle1.HasMarginLeft, true);
            Assert.AreEqual(myStyle1.HasTextIndent, false);

            Assert.AreEqual(myStyle2.MarginLeft, 3);
            Assert.AreEqual(myStyle2.NewStyle, "color:blue;");
            Assert.AreEqual(myStyle2.TextIndent, 0);
            Assert.AreEqual(myStyle2.HasMarginLeft, true);
            Assert.AreEqual(myStyle2.HasTextIndent, false);

            Assert.AreEqual(myStyle3.MarginLeft, 0);
            Assert.AreEqual(myStyle3.NewStyle, "color:green;");
            Assert.AreEqual(myStyle3.TextIndent, 2);
            Assert.AreEqual(myStyle3.HasMarginLeft, false);
            Assert.AreEqual(myStyle3.HasTextIndent, true);
        }
    }
}