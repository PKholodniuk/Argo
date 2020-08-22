using OpenQA.Selenium;
using System.Threading;
using AventStack.ExtentReports;
using NLog;

namespace Argo.Classes
{
    public class Author : Drivers

    {
        public Author(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string email, string password)
        {
            Thread.Sleep(2000);
            Reporter.LogPassingTestStepToBugLogger("Fill in the form of login with click button");
            InputUserData("email", email);
            InputUserData("password", password);
            ClickButtonEnter("#auth_block > div.header-login-outer > div.outer-cart-container > " +
                                "div > div.user-login.log-fields.act > div > div.submit-area > div > span");

        }
        // This methods use for method Login

        private void InputUserData(string Id, string value)
        {
            var user = Driver.FindElement(By.Id(Id));
            user.SendKeys(value);
        }
        private void ClickButtonEnter(string CSS)
        {
            Driver.FindElement(By.CssSelector(CSS)).Click(); Thread.Sleep(3000);
        }
    }
}