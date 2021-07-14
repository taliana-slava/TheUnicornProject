using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Driver.GoTo(FW.Config.Test.Url);
        }

        [TearDown]
        public virtual void AfterEach()
        {
            try
            {
                if (loadApplication() == null)
                {
                    Driver.GoTo(FW.Config.Test.Url);
                    loadApplication().LogOut();
                }
                else
                {
                    loadApplication().LogOut();
                }
            }
            finally
            {
                if (Driver.Current != null)
                {
                    var outcome = TestContext.CurrentContext.Result.Outcome.Status;
                    var message = TestContext.CurrentContext.Result.Message;
                    var stackTrace = TestContext.CurrentContext.Result.StackTrace;
                    var war = TestContext.CurrentContext.Result.WarningCount;


                    if (outcome == TestStatus.Passed)
                    {
                        FW.Log.Info("Outcome: Passed");
                    }
                    else if(outcome == TestStatus.Failed)
                    {
                        Driver.TakeScreenshot("test_failed");
                        FW.Log.Info($"Outcome: Failed");
                        FW.Log.Info($"Message: {message}");
                        FW.Log.Info($"StackTrace: {stackTrace}");
                    }
                    else
                    {
                        FW.Log.Warning($"Outcome: {outcome}");
                    }

                    Driver.Quit();
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
