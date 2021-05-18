using System;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace SimpleApp.Appium.Core
{
    [AllureNUnit]
    public class TestMainPage<T, W>: AppiumTest<T, W>
        where T : AppiumDriver<W>
        where W : IWebElement
    {
        public TestMainPage(string testName): base(testName)
        {
        }

        protected override T GetDriver()
        {
            // Implemented by platform specific class
            throw new NotImplementedException();
        }

        protected override void InitAppiumOptions(AppiumOptions appiumOptions)
        {
            // Implemented by platform specific class
            throw new NotImplementedException();
        }

        [SetUp()]
        public void SetupTest()
        {
            //appiumDriver.CloseApp();
            //appiumDriver.LaunchApp();
        }

        [Test()]

        public void TestLogin()
        {
            appiumDriver.FindElementByAccessibilityId("Login").Click();
            appiumDriver.FindElementByAccessibilityId("UserName").SendKeys("user@email.com");
            appiumDriver.FindElementByAccessibilityId("Password").SendKeys("Password");

            appiumDriver.FindElementByAccessibilityId("LoginButton").Click();
            var text = GetElementText("StatusLabel"); // Android is "text"

            Assert.IsNotNull(text);
            Assert.IsTrue(text.StartsWith("Logging in", StringComparison.CurrentCulture));  
        }

        [Test()]
        public void TestAddItem()
        {
            appiumDriver.FindElementByAccessibilityId("Browse").Click();
            appiumDriver.FindElementByAccessibilityId("AddToolbarItem").Click();
            var itemNameField = appiumDriver.FindElementByAccessibilityId("ItemNameEntry");
            itemNameField.SendKeys("todo");

            var itemDesriptionField = appiumDriver.FindElementByAccessibilityId("ItemDescriptionEntry");
            itemDesriptionField.SendKeys("todo description");

            appiumDriver.FindElementByAccessibilityId("SaveToolbarItem").Click();
        }

        [Test()]
        public void TestAbout()
        {
            appiumDriver.FindElementByAccessibilityId("About").Click(); // works for iOS
        }
    }
}
