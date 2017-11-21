using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triz.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triz.Model;

namespace Triz.BLL.Tests
{
    [TestClass()]
    public class FunctionElementLogicTests
    {
        [TestMethod()]
        public void ScanTreeTest()
        {
            FunctionElementLogic FunctionElementLogic = new FunctionElementLogic();
            FunctionElementLogic.ScanTree("31");
        }

        [TestMethod()]
        public void QueryLeafsTest()
        {
            FunctionElementLogic FunctionElementLogic = new FunctionElementLogic();
            List<FunctionElementInfo> aaa = FunctionElementLogic.QueryLeafs("31");
        }
    }
}