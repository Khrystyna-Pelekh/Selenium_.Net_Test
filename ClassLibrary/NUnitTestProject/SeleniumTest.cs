using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestProject
{
    [TestFixture]
    public class SeleniumTest
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver("C:\\ChromeWebDriver");
            _driver.Url = "https://www.seleniumeasy.com/";
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void Test()
        {
            IWebElement element = _driver.FindElement(By.CssSelector("input#edit-search-block-form--2"));
            IWebElement button = _driver.FindElement(By.CssSelector("#search-block-form .btn-danger"));
            element.SendKeys("NUnit");
            button.Click();

            Assert.AreEqual("https://www.seleniumeasy.com/search/node/NUnit", _driver.Url);
        }
    }
}