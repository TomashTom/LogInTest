using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogInTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInTest.Tests
{
    [TestClass()]
    public class LogInTestsTests
    {
        [TestMethod()]
        public void LogInTest_SuccessTest()
        {
            var loginTest = new LogInTests();
            loginTest.StartSetup(); // Set up the WebDriver
            loginTest.LogInTest_Success(); // Run the login process
            loginTest.PageLoaderTimeTest();
            loginTest.Teardown(); // Quit the WebDriver
        }
    }
}