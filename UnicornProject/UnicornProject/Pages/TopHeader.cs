using OpenQA.Selenium;
using UnicornProject.Framework.Selenium;
using UnicornProject.Selenium;

namespace UnicornProject.Pages
{
    public abstract class TopHeader
    {

        Element AccountIconXpath => Driver.FindElement(By.XPath("//*[@aria-label='Account']/../.."), "Account Icon");
        Element LogOutButtonXpath => Driver.FindElement(By.XPath("//*[text()='Log Out']/.."), "Log Out Button");

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
