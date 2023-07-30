using AutomationWebDriver.Enums;
using AutomationWebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationWebDriver
{
    public class WebDriverFactory
    {
        public static IWebDriver OpenBrowser(BrowsersType type)
        {
            IWebDriver? driver = null;

            // Switch statement to select the appropriate browser driver based on the browser type
            switch (type)
            {
                case BrowsersType.Chrome:
                    driver = new ChromeDriver("Drivers/Chrome"); 
                    break;
                case BrowsersType.FireFox:
                    driver = new FirefoxDriver("Drivers/FireFox"); 
                    break;
                case BrowsersType.Edge:
                    driver = new EdgeDriver("Drivers/Edge");
                    break;
                default:
                    throw new Exception("Driver not found"); 
            }

            // Maximize the browser window
            driver.MaximizeWindow();

            return driver;
        }
    }
}
