using AutomationCore.Helpers;
using AutomationWebDriver.Extensions;
using OpenQA.Selenium;

namespace Framework_AutomationTest.Pages
{
    // LoginPage class inherits from the BasePage class
    public class LoginPage : BasePage
    {
        // Login locator
        private By _usernameInput = By.XPath("//input[@name='username']");
        private By _passwordInput = By.XPath("//input[@name='password']");
        private By _loginButton = By.XPath("//button[@type='submit']");
        
        // Constructor with driver parameter calls the base constructor
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // Navigates to the login page
        public void NavigateToLoginPage()
        {
            var url = ConfigurationHelper.GetValue<string>("url");
            driver.Go(url);
        }

        // Enters the given user name into the user name input field
        public void EnterUserName(string userName)
        {
            EnterText(_usernameInput, userName);
        }

        // Enters the given password into the password input field
        public void EnterPassword(string password)
        {
            EnterText(_passwordInput, password);
        }

        // Clicks the login button
        public void ClickOnLoginButton()
        {
           ClickOnElement(_loginButton);
        }

        // Logs in with the given user name and password
        public void PerformLogin(string userName, string password)
        {
            EnterUserName(userName);
            EnterPassword(password);
            ClickOnLoginButton();
        }
    }
}
