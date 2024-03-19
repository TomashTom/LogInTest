using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace LogInTest
{
    public class LogInTests
    {
        private IWebDriver driver;

        [SetUp]
        public void StartSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LogInTest_Success()
        {
            driver.Navigate().GoToUrl("https://app.digiklase.lt");
            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("smolskijt@gmail.com");

            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("$q&*9gqxKh6n3UhZxewd");

            
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            loginButton.Click();
        }
        [Test]
        public void PageLoadPerformanceTest()
        {
            long totalLoadTime = 0;
            int iterations = 5; 

            for (int i = 0; i < iterations; i++)
            {
                driver.Navigate().GoToUrl("https://app.digiklase.lt");
                WaitForPageLoadComplete(driver);

                var jsExecutor = (IJavaScriptExecutor)driver;
                var performanceTiming = jsExecutor.ExecuteScript("return window.performance.timing") as Dictionary<string, object>;

                long navigationStart = Convert.ToInt64(performanceTiming["navigationStart"]);
                long loadEventEnd = Convert.ToInt64(performanceTiming["loadEventEnd"]);
                long pageLoadTime = loadEventEnd - navigationStart;

                totalLoadTime += pageLoadTime;
            }

            long averageLoadTime = totalLoadTime / iterations;
            Console.WriteLine($"Average Page Load Time: {averageLoadTime} ms");

            Assert.That(averageLoadTime, Is.LessThan(5000), "Average page load time is longer than expected."); 
        }

        public void WaitForPageLoadComplete(IWebDriver driver, int timeoutSec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        [TearDown]
        public void Teardown()
        {
            
            //driver.Quit();
        }
    }
}