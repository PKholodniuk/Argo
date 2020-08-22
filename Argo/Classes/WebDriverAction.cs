using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Argo.Classes
{
    public class WebDriverAction : Drivers
    {
        public WebDriverAction(IWebDriver driver) : base(driver)
        {
        }
        public void NavigateElement(IWebElement name, string describe, double a = 1)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(a);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(6));
            wait.Until(ExpectedConditions.ElementToBeClickable(name));
            //((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", name);
            new Actions(Driver).MoveToElement(name).Perform();
            Reporter.LogPassingTestStepToBugLogger($"Navigate to element: {describe}");
        }
        //public void ClickElement(IWebElement name, string explainIWebElement, double a = 1)
        public void ClickElement(IWebElement name, string explainIWebElement)
        {
            Reporter.LogPassingTestStepToBugLogger($"Click an element: {explainIWebElement}");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(name));
            name.Click();

        }

        public void ClickLinksText(string name, double a = 1)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(a);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            IWebElement Linkos = Driver.FindElement(By.LinkText(name));
            wait.Until(ExpectedConditions.ElementToBeClickable(Linkos));
            Linkos.Click();
            Reporter.LogPassingTestStepToBugLogger($"Click linkText: {name}");
        }

        public void InpuData(IWebElement name, string value, double a = 1)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(a);
            name.Clear();
            name.SendKeys(value);
            Reporter.LogPassingTestStepToBugLogger($"Input text data in search: {value}");
        }



        //public int GetActualPercentOfBonus(string explain)
        //{
        //    Reporter.LogPassingTestStepToBugLogger($"Assert: {explain}");
        //    var bonusText = Driver.FindElement(By.XPath("//p[@id='bonus_summ']")).Text;
        //    int summBonus = Convert.ToInt32(bonusText);

        //    var PrizeText = Driver.FindElement(By.XPath("//span[@class='price-contain']")).Text;
        //    int PrizeUah = Convert.ToInt32(PrizeText);

        //    int actual = summBonus * 100 / PrizeUah;
        //    return actual;
        //}

        //internal bool IsAts(IWebElement name, string message)
        //{
        //    Reporter.LogPassingTestStepToBugLogger($"The item: {message} is displayed");
        //    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5)); Thread.Sleep(500);
        //    wait.Until(ExpectedConditions.ElementToBeClickable(name)); 
        //    return name.Displayed;
        //}

        //internal bool IsSelected(IWebElement name, string message)
        //{
        //    Reporter.LogPassingTestStepToBugLogger($"The item: {message} is displayed");
        //    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5)); Thread.Sleep(500);
        //    wait.Until(ExpectedConditions.ElementToBeClickable(name));
        //    return name.Selected;
        //}

        //public bool IsElementVisible(IWebElement name)
        //{
        //    try
        //    {
        //        var iv = name.Displayed;
        //        if (iv == true) { return false; } else { return true; }
        //        //if (iv == false) { return true; } else { return false; }
        //    }
        //    catch (NoSuchElementException) { return false; } // если элемент вообще не найден (для assert IsFalse)
        //}
        //public void DeleteFromFavorites()
        //{
        //    var count = Driver.FindElements(By.XPath("//*[@class='one-item-fav']")).Count;

        //    if (count != 0)
        //    {
        //        for (int i = 0; i < count; i++)
        //        {
        //            ClickElement(DeleteFavorite, "Удаление  (с избранного)"); Thread.Sleep(1000);
        //        }
        //    }
        //    Reporter.LogPassingTestStepToBugLogger($"Delete item from favorite (auth page)");
        //}

    }
}