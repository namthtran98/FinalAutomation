using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
namespace MobileTest;

public class UnitTest1 : IDisposable
{
    private AndroidDriver<IWebElement> _driver;

    public UnitTest1()
    {
        var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");
        var driverOptions = new AppiumOptions()
        {
        };
        driverOptions.AddAdditionalCapability("appPackage", "com.android.settings");
        driverOptions.AddAdditionalCapability("appActivity", ".Settings");
        driverOptions.AddAdditionalCapability("noReset", true);
        _driver = new AndroidDriver<IWebElement>(serverUri, driverOptions, TimeSpan.FromSeconds(180));
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    public void Dispose()
    {
        _driver.Dispose();
    }

    [Fact]
    public void TestBattery()
    {
        _driver.StartActivity("com.android.settings", ".Settings");
        _driver.FindElement(By.XPath("//*[@text='Battery']")).Click();
    }
}
