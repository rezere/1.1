using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace Lab1_1
{
    public class Tests
    {
        //[TestFixture()]
        public class Test
        {
            [Test]
            public void TestCase()
            {
                string actualUrl= "https://pastebin.com";
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl(actualUrl);
                driver.FindElement(By.Id("postform-text")).SendKeys("Lab 1 New Paste");
                driver.FindElement(By.Id("select2-postform-expiration-container")).Click();
                driver.FindElement(By.CssSelector("#select2-postform-expiration-results>li:nth-child(3)")).Click();
                driver.FindElement(By.Id("postform-name")).SendKeys("Lab 1 Title");
                driver.FindElement(By.XPath("//*[contains(text(), 'Create New Paste')]")).Click();
                string expectedUrl = driver.Url;
                Assert.AreNotEqual(actualUrl, expectedUrl);
                //driver.Quit();

            }

            [Test()]
            public void Test2()
            {
                string actualUrl = "https://demowebshop.tricentis.com";
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl(actualUrl);
                driver.FindElement(By.XPath("//a[contains(text(), 'My account')]")).Click();
                driver.FindElement(By.Id("Email")).SendKeys("test@gmail.com");
                driver.FindElement(By.Id("Password")).SendKeys("0123456789");
                actualUrl = driver.Url;
                driver.FindElement(By.XPath("//*[@class='button-1 login-button']")).Click();
                string expectedUrl = driver.Url;
                Assert.AreEqual(actualUrl, expectedUrl);
            }
        }
    }
}