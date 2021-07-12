using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using UnicornProject.Framework;
using UnicornProject.Pages;
using UnicornProject.Selenium;
using UnicornProject.TestData;

namespace UnicornProject.UITests
{
    public abstract class BaseTest
    {
        private readonly string FACEBOOK_URL = Environment.GetEnvironmentVariable("Facebook");

        [OneTimeSetUp]
        public void BeforeAll()
        {
            FW.CreateTestResultsDirectory();
        
        }

        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            FW.Log.Info(FACEBOOK_URL);
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
                    FW.Log.Info("Close Brower");
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
            new LoginToFacebookPage().LoginToFacebook(user);
        }

        public void Launch(User user)
        {
            var facebook = new LoginToFacebookPage();
            facebook.LoginToFacebook(user);
        }
    }
}
