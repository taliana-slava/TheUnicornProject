using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UnicornProject.Framework.Selenium;
using UnicornProject.Selenium;

namespace UnicornProject.Pages
{
    public class HomePage: TopHeader
    {
        Element LoginInputId => Driver.FindElement(By.Id("email"), "Login");

        public void SetLogin(string value)
        {
            LoginInputId.SendKeys(value);
        }
    }
}
