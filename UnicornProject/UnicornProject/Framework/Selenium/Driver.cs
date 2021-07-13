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
            _driver = DriverFactory.Build(FW.Config.Driver.Brower);
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
