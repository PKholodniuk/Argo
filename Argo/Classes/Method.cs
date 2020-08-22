using OpenQA.Selenium;
using System.Threading;
using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using Argo.Classes;

namespace Argo.Classes
{
    public class Method : Drivers


    {
        public Method(IWebDriver driver) : base(driver)
        {
        }


        public int GetActualPercentOfBonus(string explain)
        {
            Reporter.LogPassingTestStepToBugLogger($"Assert: {explain}");
            var bonusText = Driver.FindElement(By.XPath("//p[@id='bonus_summ']")).Text;
            Double summBonus = Convert.ToDouble(bonusText);

            var PrizeText = Driver.FindElement(By.XPath("//span[@class='price-contain']")).Text;
            Double PrizeUah = Convert.ToDouble(PrizeText);

            int actual = Convert.ToInt32(summBonus * 100 / PrizeUah);
            return actual;
        }

        public string GetText(IWebElement name, string explain)
        {
            Reporter.LogPassingTestStepToBugLogger($"Assert: {explain}");
            var text = name.Text;
            return text;
        }

        public bool IsElementVisible2(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }
        internal bool IsAts(IWebElement name, string message, double a = 1)
        {
            Reporter.LogPassingTestStepToBugLogger($"The item: {message} is displayed");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(a);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(name));
            return name.Displayed;
        }

        internal bool IsSelected(IWebElement name, string message)
        {
            Reporter.LogPassingTestStepToBugLogger($"The item: {message} is displayed");
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5)); Thread.Sleep(500);
            wait.Until(ExpectedConditions.ElementToBeClickable(name));
            return name.Selected;
        }

    }
}