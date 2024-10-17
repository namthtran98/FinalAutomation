using Allure.Net.Commons;
using FinalAutomation.Core.Configuration;
using FinalAutomation.Core.Driver;
using NPOI.HPSF;
using OpenQA.Selenium;
using Org.BouncyCastle.Crypto.Tls;
using TechTalk.SpecFlow;

namespace Swag_Labs_Test.Hooks
{
    [Binding]
    public sealed class Hooks1 : IDisposable
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        private readonly AllureLifecycle allureLifecycle;

        public Hooks1(ScenarioContext scenarioContext, AllureLifecycle allureLifecycle)
        {
            this.scenarioContext = scenarioContext;
            this.allureLifecycle = allureLifecycle;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
            this.driver = DriverFactory.GetDriver(Configuration.GetBrowser());
            driver.Url = Configuration.GetEnviroment();
            driver.Navigate();
            scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void Dispose()
        {
            //if (scenarioContext.ScenarioInfo.Tags.Contains("failed"))
            //{
            //    // Take screenshot when failed
            //    var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
            //    var fileName = scenarioContext.ScenarioInfo.Title + "_screenshot_" + DateTime.Now.Ticks + ".png";
            //    string pathName = "ScreenShot";
            //    string path = Directory.GetCurrentDirectory() + pathName + fileName;
            //    if (!Directory.Exists(pathName))
            //    {
            //        Directory.CreateDirectory(pathName);
            //    }
            //    screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            //    scenarioContext.Add("ScreenshotPath", path);
            //    allureLifecycle.add(filename, "image/png", path);

            //}
            //TODO: implement logic that has to run after executing each scenario
            if (scenarioContext["WebDriver"] is IWebDriver driver)
            {
                driver.Quit();
            }
        }
    }
}