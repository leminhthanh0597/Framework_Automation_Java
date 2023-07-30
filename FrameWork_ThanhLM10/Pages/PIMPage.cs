using Framework_AutomationTest.Pages;
using OpenQA.Selenium;

namespace FrameWork_ThanhLM10.Pages
{
    public class PIMPage : BasePage
    {
        // PIMPage locators
        private By _btnPIM = By.XPath("//a[@class=\"oxd-main-menu-item\"]/..//span[text()=\"PIM\"]");
        private By _btnAdd = By.XPath("//button[@type=\"button\" and (contains(@class,\"oxd-button\"))]");
        private By _txtFirstName = By.XPath("//input[@name=\"firstName\"]");
        private By _txtMiddleName = By.XPath("//input[@name=\"middleName\"]");
        private By _txtLastName = By.XPath("//input[@name=\"lastName\"]");
        private By _btnSave = By.XPath("//button[@type=\"submit\"]");
        private By _txtMessage = By.CssSelector("p[class='oxd-text oxd-text--p oxd-text--toast-title oxd-toast-content-text']");
        private By _txtInputEmployeeName = By.XPath("//label[@class=\"oxd-label\" and (text()='Employee Name')]/..//following-sibling::div//input[contains(@placeholder,\"Type for hints\")]");
        private By _btnDelete = By.XPath("//div[@class=\"oxd-table-cell-actions\"]//button//i[@class=\"oxd-icon bi-trash\"]");
        private By _btnConfirmYes = By.XPath("//button[@type=\"button\" and contains(@class,\"oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin\")]");
        private By _loadingOverlay = By.CssSelector(".oxd-form-loader");
        private By _lastNameEmployees = By.XPath("//div[@class='oxd-table-card']/div/div[4]/div");

        public PIMPage(IWebDriver driver) : base(driver)
        {
        }

        // Method to click the PIM button
        public void ClickPIMButton()
        {
            WaitForElementToBeInvisible(_loadingOverlay);
            ClickOnElement(_btnPIM);
        }

        // Method to click the Add button
        public void ClickAddButton()
        {
            ClickOnElement(_btnAdd);
        }

        // Method to enter the first name
        public void InputFirstName(string firstName)
        {
            EnterText(_txtFirstName, firstName);
        }

        // Method to enter the last name
        public void InputLastName(string lastName)
        {
            
            EnterText(_txtLastName, lastName);
        }

        // Method to enter the middle name
        public void InputMiddleName(string middleName)
        {
            EnterText(_txtMiddleName, middleName);
        }

        // Method to click the Save button
        public void ClickSaveButton()
        {
            ClickOnElement(_btnSave);
        }

        // Method to search for an employee
        public void ChooseEmployeeByLastNameOnTable(string lastName)
        {
            var elements = GetElements(_lastNameEmployees);
            foreach (var element in elements)
            {
                if (element.Text == lastName)
                {
                    element.Click();
                    break;
                }
            }
        }

        // Method to click the Delete button
        public void ClickDeleteButton()
        {
            WaitForElementToBeVisible(_btnDelete);
            ClickOnElement(_btnDelete);
        }

        // Method to click the Confirm Yes button
        public void ClickConfirmYes()
        {
            WaitForElementToBeVisible(_btnConfirmYes);
            ClickOnElement(_btnConfirmYes);
        }

        // Method to get the text of the success message
        public string GetTextMessage()
        {
            return GetElementText(_txtMessage);
        }
    }
}

