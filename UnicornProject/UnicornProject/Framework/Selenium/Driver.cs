using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnicornProject.Framework;

namespace UnicornProject.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            FW.Log.Info("Browser: Chrome");
            _driver = new ChromeDriver(Path.GetFullPath(@"../"), options);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("Driver is null!");

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }
    }
}
