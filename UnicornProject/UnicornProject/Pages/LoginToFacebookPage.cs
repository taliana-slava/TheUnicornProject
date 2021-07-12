using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UnicornProject.Framework;
using UnicornProject.Selenium;
using UnicornProject.TestData;

namespace UnicornProject.Pages
{
    public class LoginToFacebookPage: TopHeader
    {

        IWebElement LoginInputId => Driver.FindElement(By.Id("email"));
        IWebElement PasswordInputId => Driver.FindElement(By.Id("pass"));
        IWebElement LoginButton => Driver.FindElement(By.Name("login"));

        public void SetLogin(string value)
        {
            FW.Log.Step("Set Login");
            LoginInputId.SendKeys(Keys.Clear);
            LoginInputId.SendKeys(value);
        }

        public void SetPassword(string value)
        {
            FW.Log.Step("Set Password");
            PasswordInputId.SendKeys(Keys.Clear);
            PasswordInputId.SendKeys(value);
        }

        public void LoginToFacebook(User user)
        {
            SetLogin(user.Login);
            SetPassword(user.Password);
            FW.Log.Step("Click Login button");
            LoginButton.Click();
        }

    }
}
