using Framework_AutomationTest.Pages;
using OpenQA.Selenium;

namespace FrameWork_ThanhLM10.Pages
{
    public class EditPage : BasePage
    {
        // EditPage locators
        private By _lastNameInputField = By.XPath("//input[@name=\"lastName\"]");
        private By _saveButton = By.XPath("//button[@type=\"submit\"]");
        private By _messageText = By.CssSelector("p[class='oxd-text oxd-text--p oxd-text--toast-title oxd-toast-content-text']");
        private By _loadingOverlayElement = By.CssSelector(".oxd-form-loader");

        public EditPage(IWebDriver driver) : base(driver)
        {
        }

        // Clicks on the input field for last name to enable editing
        public void EnableLastNameEditing()
        {
            WaitForElementToBeInvisible(_loadingOverlayElement);

            // Wait for the input field to be visible and then click on it
            WaitForElementToBeVisible(_lastNameInputField); 
            ClickOnElement(_lastNameInputField);
        }

        // Edits the employee's last name
        public void UpdateEmployeeLastName(string lastName)
        {  
            WaitForElementToBeInvisible(_loadingOverlayElement);
            ClickOnElement(_lastNameInputField);
            ClearText(_lastNameInputField);
            EnterText(_lastNameInputField, lastName);
            ClickOnElement(_saveButton);
        }
        // Retrieves the text of the success message
        public string GetSuccessMessageText()
        {
            return GetElementText(_messageText);
        }
    }
}

