using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
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
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://pastebin.com");
                driver.FindElement(By.Id("postform-text")).SendKeys("Lab 1 New Paste");
                //IWebElement selectElement = driver.FindElement(By.Name("PostForm[expiration]"));
                //SelectElement ss = new SelectElement(driver.FindElement(By.Id("postform-status")));
                SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("postform-status")));
                selectElement.Options.ToList().Find(x => x.Text == "10 Minutes").Click();
                //Assert.IsTrue(driver.Url.Contains("google.com"), "Что-то не так =(");
                //driver.Quit();

            }

            //[Test()]
            //public void Test2()
            //{
            //    IWebDriver driver = new ChromeDriver();
            //    driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/login?ReturnUrl=%2fcustomer%2finfo");
            //    driver.FindElement(By.Id("Email")).SendKeys("test@gmail.com");
            //    driver.FindElement(By.Id("Password")).SendKeys("0123456789");
            //    driver.FindElement(By.Id("Password")).SendKeys("0123456789");
            //}
        }
    }
}