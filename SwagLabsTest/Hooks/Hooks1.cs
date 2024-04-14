using FinalAutomation.Core.Configuration;
using FinalAutomation.Core.Driver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Swag_Labs_Test.Hooks
{
    [Binding]
    public sealed class Hooks1 : IDisposable
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public IWebDriver driver;
        private readonly ScenarioContext scenarioContext;

        public Hooks1(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
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
            //TODO: implement logic that has to run after executing each scenario
            if (scenarioContext["WebDriver"] is IWebDriver driver)
            {
                driver.Quit();
            }
        }
    }
}