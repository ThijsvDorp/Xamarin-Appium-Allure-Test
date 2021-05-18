using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;


namespace SimpleApp.Appium.Core
{
    [TestFixture]
    public class TestMainPage_Droid: TestMainPage<AndroidDriver<AndroidElement>, AndroidElement>
    {
        public TestMainPage_Droid() : base("MainPageTests") {}

        protected override AndroidDriver<AndroidElement> GetDriver()
        {
           return new AndroidDriver<AndroidElement>(driverUri, appiumOptions);
        }

        protected override void InitAppiumOptions(AppiumOptions appiumOptions)
        {
            //Specify the Device name, it does not have to match your actual device name, But for clarity just name it
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus_5_API_24");
            //Specify the device UDID
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            //Specify the name of the platform
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            //To find the Apppackage, simply run the app. Check output and on the first line there should be the appPackage
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.simpleapp");
            //To find the Apppackage, simply run the app. Check output and on the first line there should be the AppActivity, right after the AppPackage
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc64d6c8ffab200b6dd1.MainActivity");

        }
    }
}