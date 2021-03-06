using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class AddToCartTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheAddToCartTestCaseTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/5-virtual-gift-card");
            driver.FindElement(By.XPath("//img[@alt='Tricentis Demo Web Shop']")).Click();
            driver.FindElement(By.LinkText("Gift Cards")).Click();
            driver.FindElement(By.XPath("//div[3]/div/div/div/a/img")).Click();
            driver.FindElement(By.Id("giftcard_1_RecipientName")).Click();
            driver.FindElement(By.Id("giftcard_1_RecipientName")).Clear();
            driver.FindElement(By.Id("giftcard_1_RecipientName")).SendKeys("Marko");
            driver.FindElement(By.Id("giftcard_1_RecipientEmail")).Click();
            driver.FindElement(By.Id("giftcard_1_RecipientEmail")).Clear();
            driver.FindElement(By.Id("giftcard_1_RecipientEmail")).SendKeys("lukac.ivan99@gmail.com");
            driver.FindElement(By.Id("add-to-cart-button-1")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
