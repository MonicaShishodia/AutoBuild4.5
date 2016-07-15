using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TestCI;

namespace NUnit
{
    [TestFixture]
    public class NUnitTest
    {
        IWebDriver driver = null;
        IPrintMessage ipm = new GetData();
        [SetUp]
        public void OpenURL()
        {


        }
        //[Test]
        //public void NunitSeleniumTest()
        //{
            //try
            //{
                //driver = new FirefoxDriver();
                //driver.Navigate().GoToUrl("http://localhost/TestCI");
                //IWebElement element = driver.FindElement(By.Id("txtBox"));
              //  element.SendKeys("Test");
            //}
            //catch (Exception e)
            //{ }
          //  finally { driver.Close(); }
        //}
        [Test]
        public void GetMessageTest()
        {
            Assert.IsNotNull(ipm.GetMessage());
        }
        [Test]
        public void GetExecutionTime()
        {
            System.Threading.Thread.Sleep(10000);
        }

        [TearDown]
        public void Cleanup()
        {

        }
    }
}
