using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;

namespace TestCI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //IWebDriver driver = new FirefoxDriver();
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

        //[TestMethod]
        //public void SeleniumTest()
        //{
        //    try
        //    {
        //        string url = System.Configuration.ConfigurationManager.AppSettings["StagingURL"];
        //        driver.Navigate().GoToUrl(url + "TestCI");
        //        IWebElement element = driver.FindElement(By.Id("txtBox"));
        //        element.SendKeys("Test");
        //    }
        //    catch (Exception e)
        //    { }
        //    finally { driver.Close(); }
        //}
    }
}
