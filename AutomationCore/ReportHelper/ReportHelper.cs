using Allure.Commons;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationCore.ReportHelper
{
    public static class ReportHelper
    {
        /// <summary>
        /// Take screen shot when testcase fail
        /// </summary>
        /// <param name="driver"></param>
        public static void TakeScreenShot(this IWebDriver driver)
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                byte[] content = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
                var filename = "img_" + DateTime.Now.ToFileTimeUtc();
                AllureLifecycle.Instance.AddAttachment("Fail Testcase_" + filename, "image/png", content);
            }
        }
    }
}

