using AutomationCore.Helpers;
using FluentAssertions;
using Framework_AutomationTest.Pages;
using Framework_AutomationTest.Test;
using FrameWork_ThanhLM10.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;
using System.IO;

namespace FrameWork_ThanhLM10.Test
{
    [TestFixture]
    [AllureNUnit]
    public class VerifyLogin : BaseTest
    {
        private LoginPage _loginPage;
        private LogoutPage _logoutPage;
        private ExcelHelper _excelHelper;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage(driver);
            _loginPage.NavigateToLoginPage();
            _logoutPage = new LogoutPage(driver);
            _excelHelper = new ExcelHelper();
            _excelHelper.SetExcelFile("../../../DataSource/Test_Data.xlsx", "Sheet1");

        }

        [Test]
        [Category("smoke")]

        public void VerifyLoginSuccessfully()
        {
            // Step 1: Login
            _loginPage.PerformLogin(_excelHelper.GetCellData("Username", 1), _excelHelper.GetCellData("Password", 1));

            // Step 2: Verify login success
            var expectedUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index";
            driver.Url.Should().Be(expectedUrl);

            // Step 3: Perform logout
            _logoutPage.PerformLogout();
        }
    }
}
