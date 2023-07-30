using AutomationCore.Helpers;
using FluentAssertions;
using Framework_AutomationTest.Pages;
using Framework_AutomationTest.Test;
using MockProject_ThanhLM10.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;



namespace MockProject_ThanhLM10.Tests
{
    [AllureNUnit]
    [TestFixture]
    public class VerifyAddAdmin : BaseTest
    {
        private LoginPage _loginPage;
        private ExcelHelper _excelHelperForLoginPage;

        private AdminPage _adminPage;
        private ExcelHelper _excelHelperForAdminPage;

        [SetUp]
        public void SetUp()
        {
            _loginPage = new LoginPage(driver);
            _loginPage.NavigateToLoginPage();
            _excelHelperForLoginPage = new ExcelHelper();
            _excelHelperForLoginPage.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet1");

            _adminPage = new AdminPage(driver);
            _excelHelperForAdminPage = new ExcelHelper();
            _excelHelperForAdminPage.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet4");

        }
        [Test]
        public void VerifyAddAdminSuccessfully()
        {
            // Step 1: Login
            _loginPage.PerformLogin(_excelHelperForLoginPage.GetCellData("Username", 1), _excelHelperForLoginPage.GetCellData("Password", 1));

            // Step 2: Click Add Admin
            _adminPage.ClickAddAdmin();
            
            // Step 3: Select User Role
            _adminPage.SelectUserRole();

            // Step 4: Select Status
            _adminPage.SelectStatus();

            // Step 5: Input employe name
            _adminPage.InputEmployeeName(_excelHelperForAdminPage.GetCellData("EmployeeName", 1));

            // Step 6: Input Username
            _adminPage.InputUserName(_excelHelperForAdminPage.GetCellData("UserName", 1));

            // Step 7: Input Password
            _adminPage.InputPassWord(_excelHelperForAdminPage.GetCellData("PassWord", 1));

            // Step 8: Input confirm password
            _adminPage.InputConfirmPassWord(_excelHelperForAdminPage.GetCellData("ConfirmPassWord", 1));

            // Step 9: click save
            _adminPage.ClickSave();

            // Step 10: Verify message 
            string message = _adminPage.GetTextMessage();
            message.Should().Be("Success");
        }
    }
}