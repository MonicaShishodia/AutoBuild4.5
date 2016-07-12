using TestCI;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        IPrintMessage ipm = new GetData();
        [TestMethod()]
        public void GetMessageTest()
        {           
            Assert.IsNotNull(ipm.GetMessage());
        }
        [TestMethod()]
        public void GetExecutionTime()
        {
            System.Threading.Thread.Sleep(10000);
        }
    }
}
