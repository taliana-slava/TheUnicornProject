using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UnicornProject.Selenium;

namespace UnicornProject.Pages
{
    public abstract class TopHeader: BasePage
    {

        IWebElement AccountIconXpath => Driver.FindElement(By.XPath("//*[@aria-label='Account']/../.."));
        IWebElement LogOutButtonXpath => Driver.FindElement(By.XPath("//*[text()='Log Out']/.."));

        public void ExpandAccountIcon()
        {
            AccountIconXpath.Click();
        }

        public void ClickLogOutButton()
        {
            LogOutButtonXpath.Click();
        }

        public void LogOut()
        {
            ExpandAccountIcon();
            ClickLogOutButton();
        }

    }
}
