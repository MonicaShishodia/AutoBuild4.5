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


namespace NUnit
{
    [TestFixture]
   public class NUnitTest
    {
        IWebDriver driver = null;
        [SetUp]
        public void OpenURL()
        {
            driver = new FirefoxDriver();
           
        }
        [Test]
        public void NunitSeleniumTest()
        {
            try
            {
                driver.Navigate().GoToUrl("http://localhost/TestCI");
                IWebElement element = driver.FindElement(By.Id("txtBox"));
                element.SendKeys("Test");
            }
            catch (Exception e)
            { }
            finally { }
        }
        [TearDown]
        public void Cleanup()
        {
            driver.Close();
        }
    }
}
