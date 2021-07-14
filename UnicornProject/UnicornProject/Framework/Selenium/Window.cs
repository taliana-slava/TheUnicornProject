using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using UnicornProject.Selenium;

namespace UnicornProject.Framework.Selenium
{
    public class Window
    {
        public ReadOnlyCollection<string> CurrentWindow => Driver.Current.WindowHandles;

        public void SwitchTo(int windowInx)
        {
            Driver.Current.SwitchTo().Window(CurrentWindow[windowInx]);
        }

        public Size ScreenSize
        {
            get
            {
                var js = "return [window.screen.availWidth, window.screen.availHeight];";
                var jse = (IJavaScriptExecutor)Driver.Current;

                dynamic dimensions = jse.ExecuteScript(js, null);

                var x = Convert.ToInt32(dimensions[0]);
                var y = Convert.ToInt32(dimensions[1]);

                return new Size(x, y);
            }
        }

        public void Maximize()
        {
            Driver.Current.Manage().Window.Position = new Point(0, 0);
            Driver.Current.Manage().Window.Size = ScreenSize;
        }
    }
}
