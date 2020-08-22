using OpenQA.Selenium;
using System.CodeDom;

namespace Argo.Classes
{

    public class Drivers
    {
        protected IWebDriver Driver { get; set; }
        public Drivers(IWebDriver driver)
        {
            Driver = driver;
        }

        /******** Link text  *******/
        public IWebElement Clother => Driver.FindElement(By.LinkText("Одежда"));
      
    }
}