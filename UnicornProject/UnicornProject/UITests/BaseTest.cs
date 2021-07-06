using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using UnicornProject.Pages;
using UnicornProject.Selenium;
using UnicornProject.TestData;

namespace UnicornProject.UITests
{
    public abstract class BaseTest
    {
        private readonly string FACEBOOK_URL = Environment.GetEnvironmentVariable("Facebook");

        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            Driver.Current.Url = FACEBOOK_URL;
        }

        [TearDown]
        public void AfterEach()
        {
            try
            {
                if (loadApplication() != null)
                {
                    Driver.Current.Url = FACEBOOK_URL;
                    loadApplication().LogOut();
                }
            }
            finally
            {
                if (Driver.Current != null)
                {
                    Driver.Current.Quit();
                }
            }
        }

        public HomePage loadApplication()
        {
            return new HomePage();
        }

        public void Launch()
        {
            var user = new UserRepository().GetDefaultUser();           
            var facebook = new LoginToFacebookPage();
            facebook.LoginToFacebook(user.Login, user.Password);
        }

        public void Launch(User user)
        {
            var facebook = new LoginToFacebookPage();
            facebook.LoginToFacebook(user.Login, user.Password);
        }
    }
}
