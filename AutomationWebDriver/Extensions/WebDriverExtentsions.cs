using OpenQA.Selenium;

namespace AutomationWebDriver.Extensions
{
    public static class WebDriverExtensions
    {
        // Maximizes the browser window
        public static void MaximizeWindow(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        // Navigates to the specified URL
        public static void Go(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        // Finds a web element using the specified locator within the specified timeout
        public static IWebElement GetWebElement(this IWebDriver driver, By by, int timeout = 30)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            var element = driver.FindElement(by);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            return element;
        }
    }
}
