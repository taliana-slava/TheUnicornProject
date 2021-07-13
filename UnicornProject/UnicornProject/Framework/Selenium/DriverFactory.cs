using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnicornProject.Framework.Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Build(string browserName)
        {
            FW.Log.Info($"Brower: {browserName}");
            switch(browserName)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-notifications"); // to disable notification
                    return new ChromeDriver(FW.WORKSPACE_DIRECTORY, options);
                case "firefox":
                    return new FirefoxDriver();
                default:
                    throw new ArgumentException($"{browserName} is not supported!");
            }
        }
    }
}
