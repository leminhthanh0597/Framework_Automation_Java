using AutomationCore.Helpers;
using AutomationWebDriver.Enums;
using AutomationWebDriver;
using OpenQA.Selenium;
using NUnit.Framework;
using AutomationCore.ReportHelper;

namespace Framework_AutomationTest.Test
{
    [TestFixture]
    public class BaseTest
    {
        public static IWebDriver driver;

        // Method called once for the whole test assembly to initialize the driver instance
        [SetUp]
        public void OnTimeSetUp()
        {
            var browser = ConfigurationHelper.GetValue<string>("browser");
            Enum.TryParse(browser, out BrowsersType browsersType);
            driver = WebDriverFactory.OpenBrowser(browsersType);
        }

        // Method called once for the whole test assembly to clean up and quit the driver instance
        [OneTimeTearDown]
        public void OnTimeTearDown()
        {
            driver.Quit();
        }

        // Method called after each test to clean up and attach a screenshot to the test report if the test fails
        [TearDown]
        public void TearDown()
        {
            ReportHelper.TakeScreenShot(driver);
            Thread.Sleep(3330);
        }
    }
}

