using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.IO;

namespace AcceptanceTests.Support
{
    public static class GuiDriver
    {
        private static WindowsDriver<WindowsElement> _driver;

        public static WindowsDriver<WindowsElement> Get() => _driver;

        public static WindowsDriver<WindowsElement> GetOrCreate()
        {
            if (_driver == null) _driver = Create();
            return _driver;
        }

        public static void Dispose()
        {
            foreach (var wh in _driver.WindowHandles)
            {
                _driver.SwitchTo().Window(wh);
                _driver.CloseApp();
            }
            _driver.Quit();
            _driver.Dispose();
            _driver = null;
        }

        private static WindowsDriver<WindowsElement> Create()
        {
            var options = new AppiumOptions();
            string path = Path.Combine("..", "..", "..", "..", "..", "SQL-Database-Generator.exe");

            options.AddAdditionalCapability("app", Path.GetFullPath(path));
            options.AddAdditionalCapability("deviceName", Environment.MachineName);

            var wd = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            return wd;
        }
    }
}
