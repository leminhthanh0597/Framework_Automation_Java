using System;
using Framework_AutomationTest.Pages;
using OpenQA.Selenium;

namespace MockProject_ThanhLM10.Pages
{
	public class AdminPage : BasePage
	{
        // Locators for AdminPage
        private readonly By _clickButtonAdmin = By.XPath("//ul[@class='oxd-main-menu']//li//span[text()='Admin']");
        private readonly By _clickButtonAdd = By.XPath("//button[@type='button' and contains(@class,'oxd-button oxd-button--medium oxd-button--secondary')]");
        private readonly By _userRoleDropdown = By.XPath("(//div[@class='oxd-select-text oxd-select-text--active'])[1]");
        private readonly By _statusDropdown = By.XPath("(//div[@class='oxd-select-text oxd-select-text--active'])[2]");
        private readonly By _inputEmployeeName = By.XPath("//input[@placeholder='Type for hints...']");
        private readonly By _inputUserName = By.XPath("(//input[@class='oxd-input oxd-input--active' and contains(@autocomplete,'of')])[1]");
        private readonly By _inputPassWord = By.XPath("(//input[@type='password'])[1]");
        private readonly By _selectAdmin = By.XPath("//*[contains(text(),'Admin')]");
        private readonly By _selectStatusEnabled = By.XPath("//*[contains(text(),'Enabled')]");
        private readonly By _inputConfirmPassWord = By.XPath("(//input[@type='password'])[2]");
        private readonly By _clickButtonSave = By.XPath("//button[@type='submit']");
        private readonly By _txtMessage = By.CssSelector("p[class='oxd-text oxd-text--p oxd-text--toast-title oxd-toast-content-text']");

        public AdminPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAddAdmin()
        {
            ClickOnElement(_clickButtonAdmin);
            ClickOnElement(_clickButtonAdd);

        }

        public void SelectUserRole()
        {
            ClickOnElement(_userRoleDropdown);
            ClickOnElement(_selectAdmin);
        }

        public void SelectStatus()
        {
            ClickOnElement(_statusDropdown);
            ClickOnElement(_selectStatusEnabled);
        }

        public void InputEmployeeName(string employeeName)
        {
            EnterText(_inputEmployeeName, employeeName);
        }

        public void InputUserName(string userName)
        {
            EnterText(_inputUserName, userName);
        }

        public void InputPassWord(string passWord)
        {
            EnterText(_inputPassWord, passWord);
        }

        public void InputConfirmPassWord(string confirmPassWord)
        {
            EnterText(_inputConfirmPassWord, confirmPassWord);
        }

        public void ClickSave()
        {
            ClickOnElement(_clickButtonSave);
        }

        public string GetTextMessage()
        {
            return GetElementText(_txtMessage);
        }
    }
}

