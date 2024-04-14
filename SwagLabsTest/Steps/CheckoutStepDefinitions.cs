using OpenQA.Selenium;
using Swag_Labs_Test.Pages;
using System;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace Swag_Labs_Test.Steps
{
    [Binding]
    public class CheckoutStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IWebDriver driver;
        private Login loginPage;
        private Iventory iventoryPage;
        private Cart cartPage;
        private CheckoutYourInformation checkoutYourInformationPage;
        private CheckoutOverview checkoutOverviewPage;
        private double itemPriceInIventoryPage;

        public CheckoutStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = (IWebDriver)this.scenarioContext["WebDriver"];
            loginPage = new Login(driver);
            iventoryPage = new Iventory(driver);
            cartPage = new Cart(driver);
            checkoutYourInformationPage = new CheckoutYourInformation(driver);
            checkoutOverviewPage = new CheckoutOverview(driver);
        }


        [When(@"I login")]
        public void WhenILogin(Table table)
        {
            foreach (var row in table.Rows) 
            {
                loginPage.InputAndLogin(row["username"], row["password"]);
            }
            
        }

        [Then(@"I should see the inventory page")]
        public void ThenIShouldSeeTheInventoryPage()
        {
            Assert.Equal("https://www.saucedemo.com/inventory.html", driver.Url);
        }

        [When(@"I choose ""([^""]*)"" product and add click Add to cart button")]
        public void WhenIChooseProductAndAddClickAddToCartButton(string nameOfItem)
        {
            itemPriceInIventoryPage = Double.Parse(iventoryPage.GetItemPrice(nameOfItem).Replace("$", ""));
            iventoryPage.AddProductToCart(nameOfItem);
        }

        [Then(@"The button Remove of ""([^""]*)"" item is diplayed")]
        public void ThenTheButtonRemoveOfItemIsDiplayed(string nameOfItem)
        {
            Assert.True(iventoryPage.IsRemoveButtonDisplayed(nameOfItem));
        }


        [Then(@"The cart item is displayed with number (.*)")]
        public void ThenTheCartItemIsDisplayedWithNumber(int numberOfItem)
        {
            Assert.True(iventoryPage.GetNumberOfItemInCart() == numberOfItem);
        }

        [When(@"I click on cart item")]
        public void WhenIClickOnCartItem()
        {
            iventoryPage.ClickOnCartButton();
        }

        [Then(@"I should see the Cart page")]
        public void ThenIShouldSeeTheCartPage()
        {
            Assert.Equal("https://www.saucedemo.com/cart.html", driver.Url);
        }

        [Then(@"I should see ""([^""]*)"" in the cart")]
        public void ThenIShouldSeeInTheCart(string item)
        {
            Assert.True(cartPage.IsItemInCart(item));
        }

        [When(@"I click on Checkout button")]
        public void WhenIClickOnCheckoutButton()
        {
            cartPage.ClickCheckoutButton();
        }

        [Then(@"I should see the Checkout step one page")]
        public void ThenIShouldSeeTheCheckoutStepOnePage()
        {
            Assert.Equal("https://www.saucedemo.com/checkout-step-one.html", driver.Url);
        }

        [When(@"I input my infomation")]
        public void WhenIInputMyInfomation(Table table)
        {
            foreach(var row  in table.Rows) 
            {
                checkoutYourInformationPage.InputInformation(row["First Name"], row["Last Name"], row["Postal Code"]);
            }
        }

        [When(@"I click on Continue button")]
        public void WhenIClickOnContinueButton()
        {
            checkoutYourInformationPage.ClickContinue();
        }

        [Then(@"I should see the Checkout step two page")]
        public void ThenIShouldSeeTheCheckoutStepTwoPage()
        {
            Assert.Equal("https://www.saucedemo.com/checkout-step-two.html", driver.Url);
        }

        [Then(@"the item in cart is ""([^""]*)""")]
        public void ThenTheItemInCartIs(string item)
        {
            Assert.True(checkoutOverviewPage.IsItemInCart(item));
        }

        [Then(@"the price of item ""([^""]*)"" is correct with the inventory page")]
        public void ThenThePriceOfItemIsCorrectWithTheInventoryPage(string item)
        {
            Double price = double.Parse(checkoutOverviewPage.GetItemPrice(item).Replace("$", ""));
            Assert.True(itemPriceInIventoryPage == price);
        }

        [Then(@"the total price is equal the sum of item total and tax")]
        public void ThenTheTotalPriceIsEqualTheSumOfItemTotalAndTax()
        {
            Assert.True(checkoutOverviewPage.IsTotalEqualItemTotalPriceAndTax());
        }

        [When(@"I click on Finish button")]
        public void WhenIClickOnFinishButton()
        {
            checkoutOverviewPage.ClickContinueButton();
        }

        [Then(@"I should see the Checkout complete page")]
        public void ThenIShouldSeeTheCheckoutCompletePage()
        {
            Assert.Equal("https://www.saucedemo.com/checkout-complete.html", driver.Url);
        }

        [Then(@"I cannot click Checkout button")]
        public void ThenICannotClickCheckoutButton()
        {
            Assert.True(cartPage.IsCheckoutDisabled());
        }

    }
}
