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
    public class VerifyDeleteEmployee : BaseTest
    {
        private LoginPage _loginPage;
        private ExcelHelper _excelHelperForLoginPage;
        private ExcelHelper _excelHelperForPIMPage;


        private PIMPage _pimPage;

        [SetUp]
        public void Setup()
        {
            // Initialize the LoginPage object and set the Excel file for the login page
            _loginPage = new LoginPage(driver);
            _loginPage.NavigateToLoginPage();
            _excelHelperForLoginPage = new ExcelHelper();
            _excelHelperForLoginPage.SetExcelFile("../../../DataSource/Test_Data.xlsx","Sheet1");


            // Initialize the PIMPage object and set the Excel file for the PIM page
            _pimPage = new PIMPage(driver);
            _excelHelperForPIMPage = new ExcelHelper();
            _excelHelperForPIMPage.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet2");
        }
        [Test]
        public void VerifyDeleteEmployeeSuccessfully()
        {
            // Step 1: Login
            _loginPage.PerformLogin(_excelHelperForLoginPage.GetCellData("Username", 1), _excelHelperForLoginPage.GetCellData("Password", 1));

            // Step 2: Click on the PIM button
            _pimPage.ClickPIMButton();

            // Step 3: Click on the Add button
            //_pimPage.ClickSearchEmployee(_excelHelperForPIMPage.GetCellData("FirstName", 1) + " " + _excelHelperForPIMPage.GetCellData("MiddleName", 1) + " " + _excelHelperForPIMPage.GetCellData("LastName", 1));

            // Step 4: Click Delete Button
            _pimPage.ClickDeleteButton();

            // Step 5: Click Confirm Yes
            _pimPage.ClickConfirmYes();

            // Step 6: Verify success message
            string message = _pimPage.GetTextMessage();
            message.Should().Be("Success");
        }
    }
}
