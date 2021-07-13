using NUnit.Framework;
using System;
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
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        
        }

        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            FW.Log.Info(FW.Config.Test.Url);
            Driver.Current.Url = FW.Config.Test.Url;
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
