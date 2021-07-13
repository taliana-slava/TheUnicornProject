using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnicornProject.Framework;
using UnicornProject.Framework.Selenium;

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


        public static Element FindElement(By by, string elementName)
        {
            return new Element(Current.FindElement(by), elementName)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
        }; 
        }
    }
}
