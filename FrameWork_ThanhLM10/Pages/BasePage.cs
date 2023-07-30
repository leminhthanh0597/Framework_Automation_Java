using AutomationWebDriver.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace Framework_AutomationTest.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected TimeSpan timeout = TimeSpan.FromSeconds(10);

        // Constructor to initialize the driver instance
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, timeout);
        }

        // Clicks on an element identified by the specified locator
        public void ClickOnElement(By locator)
        {
            var element = WaitForElementToBeClickable(locator);
            element.Click();
        }

        // Waits for an element identified by the specified locator to be visible and returns it
        public IWebElement WaitForElementToBeVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // Waits for an element identified by the specified locator to be clickable and returns it
        public IWebElement WaitForElementToBeClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // Waits for an element identified by the specified locator to become invisible
        public void WaitForElementToBeInvisible(By locator)
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        // Enters the specified text into an element identified by the specified locator
        public void EnterText(By locator, string text)
        {
            // Wait for the element to be visible, clear its current value, and enter the new text
            var element = WaitForElementToBeVisible(locator);
            element.Clear();
            driver.GetWebElement(locator).SendKeys(text);
        }

        // Returns the text of an element identified by the specified locator
        public string GetElementText(By locator)
        {
            // Wait for the element to be visible and return its text
            var element = WaitForElementToBeVisible(locator);
            return element.Text;
        }

        // Clears the text of an element identified by the specified locator
        public void ClearText(By locator)
        {
            var element = WaitForElementToBeVisible(locator);
            element.Clear();
            string value = element.GetAttribute("value");
            while (!string.IsNullOrEmpty(value))
            {
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Backspace);
                value = element.GetAttribute("value");
            }
        }

        // Returns a list of elements identified by the specified XPath
        public IList<IWebElement> GetElements(By xpathString)
        {
            return wait.Until(drv => drv.FindElements(xpathString));
        }
    }
}
