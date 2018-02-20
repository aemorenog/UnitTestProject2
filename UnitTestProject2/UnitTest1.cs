using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Sikuli4Net.sikuli_UTIL;
using Sikuli4Net.sikuli_REST;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver webDriver = null;
        private APILauncher launcher = new APILauncher(true);

        [TestMethod]
        public void GoogleSearch()
        {
            launcher.Start();
            getWebDriver("https://www.google.cl/");

            Screen screen = new Screen();
            Pattern pattern_SearchText = new Pattern("C:/screen/SearchText.PNG");
            Pattern pattern_SearchButton = new Pattern("C:/screen/SearchButton.PNG");

            screen.Wait(pattern_SearchText, 500);
            screen.Type(pattern_SearchText, "Iphone Mobiles", KeyModifier.NONE);

            screen.Wait(pattern_SearchButton, 500);
            screen.Click(pattern_SearchButton);

            launcher.Stop();
        }

        private void getWebDriver(string url)
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
        }
    }
}
