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
    public class CRendAttrTests
    {
        CRendAttr myRend = new CRendAttr("border bold pl-3");

        [TestMethod()]
        public void CreateStyleTest()
        {
            Assert.AreEqual(myRend.NewStyle, "border:1px black solid;font-weight:bold;");
            Assert.AreEqual(myRend.NewClass, "pl-3 ");
            Assert.AreEqual(myRend.Find("bold"), true);
            Assert.AreEqual(myRend.Find("small"), false);
        }
    }
}