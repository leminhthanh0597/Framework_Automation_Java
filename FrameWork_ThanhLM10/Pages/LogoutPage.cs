using Framework_AutomationTest.Pages;
using OpenQA.Selenium;

namespace FrameWork_ThanhLM10.Pages
{
    // LogoutPage class inherits from the BasePage class
    public class LogoutPage : BasePage
    {
        // Logout locator
        private By _logoutDropdown = By.XPath("//li[@class=\"oxd-userdropdown\"]");
        private By _logoutButton = By.XPath("(//ul[@class=\"oxd-dropdown-menu\"]/..//li)[4]");

        // Constructor with driver parameter calls the base constructor
        public LogoutPage(IWebDriver driver) : base(driver)
        {
        }

        // Clicks the dropdown list
        public void clickDropdownList()
        {
            ClickOnElement(_logoutDropdown);
        }

        // Clicks the logout button
        public void clickButtonLogOut()
        {
            ClickOnElement(_logoutButton);
        }

        // Logs out from the system
        public void PerformLogout()
        {
            clickDropdownList();
            clickButtonLogOut();
        }
    }
}
