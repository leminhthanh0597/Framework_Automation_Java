using AutomationCore.Helpers;
using FluentAssertions;
using Framework_AutomationTest.Pages;
using Framework_AutomationTest.Test;
using FrameWork_ThanhLM10.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace FrameWork_ThanhLM10.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class VerifyEditEmployee : BaseTest
    {
        private LoginPage _loginPage;
        private ExcelHelper _excelHelperForLoginPage;

        private PIMPage _pimPage;
        private ExcelHelper _excelHelperForPIMPage;

        private EditPage _editPage;
        private ExcelHelper _excelHelperForEditPage;

        [SetUp]
        public void Setup()
        {
            // Initialize the LoginPage object and set the Excel file for the Login page
            _loginPage = new LoginPage(driver);
            _loginPage.NavigateToLoginPage();
            _excelHelperForLoginPage = new ExcelHelper();
            _excelHelperForLoginPage.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet1");


            // Initialize the PIMPage object and set the Excel file for the PIM page
            _pimPage = new PIMPage(driver);
            _excelHelperForPIMPage = new ExcelHelper();
            _excelHelperForPIMPage.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet2");


            // Initialize the EditPage object and set the Excel file for the Edit page
            _editPage = new EditPage(driver);
            _excelHelperForEditPage = new ExcelHelper();
            _excelHelperForEditPage.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet3");

        }

        [Test]
        public void VerifyEditEmployeeSuccessfully()
        {
            // Step 1: Login
            _loginPage.PerformLogin(_excelHelperForLoginPage.GetCellData("Username", 1), _excelHelperForLoginPage.GetCellData("Password", 1));

            // Step 2: Click on the PIM button
            _pimPage.ClickPIMButton();

            // Step 3: Click on the Search Employee
            _pimPage.ChooseEmployeeByLastNameOnTable(_excelHelperForPIMPage.GetCellData("LastName", 1));

            // Step 5: Enable the editing functionality for the last name field on the Edit page
            _editPage.EnableLastNameEditing();

            // Step 6: Edit Employee
            _editPage.UpdateEmployeeLastName(_excelHelperForEditPage.GetCellData("LastName", 1));

            // Step 7: Verify success message
            string message = _pimPage.GetTextMessage();
            message.Should().Be("Success");
        }
    }
}
