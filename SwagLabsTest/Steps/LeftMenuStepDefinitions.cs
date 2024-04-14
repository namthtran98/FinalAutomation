using OpenQA.Selenium;
using Swag_Labs_Test.Pages;
using System;
using TechTalk.SpecFlow;

namespace Swag_Labs_Test.Steps
{
    [Binding]
    public class LeftMenuStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IWebDriver driver;
        private Iventory iventoryPage;

        public LeftMenuStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)this.scenarioContext["WebDriver"];
            iventoryPage = new Iventory(driver);
        }

        [When(@"I click on Reset App State")]
        public void WhenIClickOnResetAppState()
        {
            iventoryPage.ClickMenu();
            iventoryPage.ClickResetAppState();
        }

        [Then(@"The button Remove of ""([^""]*)"" item is change to Add to cart")]
        public void ThenTheButtonRemoveOfItemIsChangeToAddToCart(string item)
        {
            Assert.True(iventoryPage.IsAddToCartButtonDisplayed(item));
        }
    }
}
