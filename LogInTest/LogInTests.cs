using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using SeleniumExtras.WaitHelpers;


namespace LogInTest
{
    public class LogInTests
    {
        private IWebDriver driver;

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
            email.SendKeys("demouser@digiklase.lt");

            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("$q&*9gqxKh6n3UhZxewd");

            
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            loginButton.Click();
        }
        [Test]
        public void PageLoaderTimeTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            driver.Navigate().GoToUrl("https://app.digiklase.lt");
            stopwatch.Start();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
                ExpectedConditions.InvisibilityOfElementLocated(By.Id("loader-id")));

            stopwatch.Stop();

            long pageLoadTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Puslapio užkrovimo laikas: " + pageLoadTime + "ms");

            // Call Assert.IsTrue without assignment
            Assert.That(pageLoadTime, Is.LessThan(20000), "Puslapis užsikrovė per ilgai.");

        }
        [TearDown]
        public void Teardown()
        {
            
            //driver.Quit();
        }
    }
}