using System;
using System.Threading;
using Argo.Classes;
using Argo.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Argo
{
    [TestClass]
    [TestCategory("LoginArgo")]

    public class TestUserLoginArgo : BaseTest
    {

        [TestMethod]
        public void LoginValid()
        {
            Method meth = new Method(Driver);
            WebDriverAction act = new WebDriverAction(Driver);

            Thread.Sleep(2000);
            act.ClickElement(Profile, "User (блок авторизация)");
            Login("qaaniart@gmail.com", "iYWV9bRvkr8ZUdP");
            act.ClickElement(Profile, "User (блок авторизация)");

            Assert.IsTrue(meth.IsAts(PhoneNumber, "+380672471013"), "Text present in the cart");
        }


        [TestMethod]
        public void LoginInvalid()
        {
            Method meth = new Method(Driver);
            WebDriverAction act = new WebDriverAction(Driver);

            act.ClickElement(Profile, "User (блок авторизация)");
            Login("qaaniart@gmail.com", "iYWV9bRvkr8Z***");

            Assert.IsTrue(meth.IsAts(ErrorMessage, "Неверный логин или пароль."), "Text present in the cart");
        }


        public IWebElement Lang => Driver.FindElement(By.XPath("//span[.='Читайте Википедию на своём языке']"));
        public IWebElement Lang2 => Driver.FindElement(By.XPath("//span[.='Викисклад']"));
        [TestMethod]
        public void CheckHeadless()
        {
            WebDriverAction act = new WebDriverAction(Driver);

            act.ClickElement(Lang, "click element on the site");
            act.ClickElement(Lang2, "click element on the site");
        }




        public void Login(string email, string password)
        {
            Thread.Sleep(2000);
            Reporter.LogPassingTestStepToBugLogger("Fill in the form of login with click button");
            InputUserData("//input[@name='AUTH-LOGIN']", email);
            InputUserData("//*[@id='auth_form_login']/div/div[2]/div[2]/input", password);
            ClickButtonEnter("auth_login_submit");

        }

        /* This methods use for method Login */

        private void InputUserData(string Xpath, string value)
        {
            var user = Driver.FindElement(By.XPath(Xpath));
            user.SendKeys(value);
        }
        private void ClickButtonEnter(string Id)
        {
            Driver.FindElement(By.Id(Id)).Click(); Thread.Sleep(3000);
        }
        public IWebElement Profile => Driver.FindElements(By.Id("f8be8771-343f-47be-b17a-3901f3d24095"))[0];
        public IWebElement PhoneNumber => Driver.FindElement(By.XPath("//input[@value='++380672471013']"));
        public IWebElement ErrorMessage => Driver.FindElement(By.XPath("//*[contains (text(), 'Неверный логин или пароль.')]"));
    }
}