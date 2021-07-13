using OpenQA.Selenium;
using UnicornProject.Framework.Selenium;
using UnicornProject.Selenium;
using UnicornProject.TestData;

namespace UnicornProject.Pages
{
    public class LoginToFacebookPage: TopHeader
    {

        Element LoginInputId => Driver.FindElement(By.Id("email"), "Login");
        Element PasswordInputId => Driver.FindElement(By.Id("pass"), "Password");
        Element LoginButton => Driver.FindElement(By.Name("login"), "Login Button");

        public void SetLogin(string value)
        {
            LoginInputId.SendKeys(value);
        }

        public void SetPassword(string value)
        {
            PasswordInputId.SendKeys(value);
        }

        public void LoginToFacebook(User user)
        {
            SetLogin(user.Login);
            SetPassword(user.Password);
            LoginButton.Click();
        }

    }
}
