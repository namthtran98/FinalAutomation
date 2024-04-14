using OpenQA.Selenium;
using Swag_Labs_Test.Pages;
using System;
using TechTalk.SpecFlow;

namespace Swag_Labs_Test.Steps
{
    [Binding]
    public class AddToCartStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IWebDriver driver;
        private Login loginPage;
        private Iventory iventoryPage;
        private Cart cartPage;
        private CheckoutYourInformation checkoutYourInformationPage;
        private CheckoutOverview checkoutOverviewPage;
        private double itemPriceInIventoryPage;

        public AddToCartStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)this.scenarioContext["WebDriver"];
            loginPage = new Login(driver);
            iventoryPage = new Iventory(driver);
            cartPage = new Cart(driver);
            checkoutYourInformationPage = new CheckoutYourInformation(driver);
            checkoutOverviewPage = new CheckoutOverview(driver);
        }

        [When(@"I click on Remove button of item ""([^""]*)""")]
        public void WhenIClickOnRemoveButtonOfItem(string item)
        {
            iventoryPage.ClickRemoveButton(item);
        }


        [Then(@"The cart item is displayed without number")]
        public void ThenTheCartItemIsDisplayedWithoutNumber()
        {
            Assert.True(iventoryPage.IsNumberOfItemDisplay() == false);
        }
    }
}
