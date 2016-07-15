using TestCI;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Selenium;

namespace TestCI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
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
