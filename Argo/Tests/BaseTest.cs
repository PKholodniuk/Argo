using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Argo.Tests
{
    public class BaseTest
    {

        public IWebDriver Driver { get; private set; }
        protected void Waiting(double a)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(a);
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        [Obsolete]
        public void Setup()
        {
            Logger.Debug("*************************************** TEST STARTED");
            Logger.Debug("*************************************** TEST STARTED");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            //Driver = new FirefoxDriver();

            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("headless");
            //chromeOptions.AcceptInsecureCertificates = true;
            //Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            //var options = new ChromeOptions();
            //options.AddArguments("headless");
            ////options.AddArgument("test-type");
            //options.AcceptInsecureCertificates = true;
            ////options.AddAdditionalCapability("acceptInsecureCerts", true, true);
            ////options.AddArguments("--ignore-certificate-errors");




            //Driver = new ChromeDriver(options);
            

            
            
            //capabilities.AcceptInsecureCerts(true);  
            //Configuration.browserCapabilities = capabilities;

            Driver = new ChromeDriver();
            //Driver = new EdgeDriver();

            /*Argo*/
            Driver.Navigate().GoToUrl("https://argo.com.ua/");
            Driver.Manage().Window.Maximize();

            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }

        [TestCleanup]
        public void TearDownForEverySingleTestMethod()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.TestName);
                Logger.Debug("*************************************** TEST STOPPED");
                Logger.Debug("*************************************** TEST STOPPED");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }
        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }
    }
}