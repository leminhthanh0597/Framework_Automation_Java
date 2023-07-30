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
    public class VerifyAddEmployee : BaseTest
    {
        private LoginPage _loginPage;
        private ExcelHelper _excelHelperForLoginPage;

        private PIMPage _pimPage;
        private ExcelHelper _excelHelperForPIMPage;

        [SetUp]
        public void Setup()
        {
            // Initialize the LoginPage object and set the Excel file for the login page
            _loginPage = new LoginPage(driver);
            _loginPage.NavigateToLoginPage();
            _excelHelperForLoginPage = new ExcelHelper();
            _excelHelperForLoginPage.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet1");


            // Initialize the PIMPage object and set the Excel file for the PIM page
            _pimPage = new PIMPage(driver);
            _excelHelperForPIMPage = new ExcelHelper();
            _excelHelperForPIMPage.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet2");
        }

        [Test]
        public void VerifyAddSuccessfully()
        {
            // Step 1: Login
            _loginPage.PerformLogin(_excelHelperForLoginPage.GetCellData("Username", 1), _excelHelperForLoginPage.GetCellData("Password", 1));
            
            // Step 2: Click on the PIM button
            _pimPage.ClickPIMButton();
            
            // Step 3: Click on the Add button
            _pimPage.ClickAddButton();
            
            // Step 4: Input the First name
            _pimPage.InputFirstName(_excelHelperForPIMPage.GetCellData("FirstName", 1));
            
            // Step 5: Input the Last name
            _pimPage.InputLastName(_excelHelperForPIMPage.GetCellData("LastName", 1));
            
            // Step 6: Input the Middle name
            _pimPage.InputMiddleName(_excelHelperForPIMPage.GetCellData("MiddleName", 1));

            // Step 7: Click on the Save button
            _pimPage.ClickSaveButton();
            
            // Step 8: Verify Success message
            string message = _pimPage.GetTextMessage();
            message.Should().Be("Success");
        }
    }
}

