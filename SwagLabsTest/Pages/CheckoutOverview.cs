using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Test.Pages
{
    public class CheckoutOverview : BasePage
    {
        public CheckoutOverview(IWebDriver driver) : base(driver)
        {
        }

        #region Elements
        private IWebElement lnkItem(string nameOfItem) => wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[text() = '{nameOfItem}']")));
        private IWebElement lblItemPrice(string nameOfItem) => wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[text() = '{nameOfItem}']//ancestor::div[@class='cart_item']//div[@data-test = 'inventory-item-price']")));
        private IWebElement lblItemTotalPrice => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test='subtotal-label']")));
        private IWebElement lblTax => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test='tax-label']")));
        private IWebElement lblTotal => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test='total-label']")));
        private IWebElement btnFinish => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#finish")));
        #endregion
        #region Actions
        public Boolean IsItemInCart(string nameOfItem) 
        {
            return lnkItem(nameOfItem).Displayed;
        }
        public string GetItemPrice(string nameOfItem) 
        {
            return lblItemPrice(nameOfItem).Text;
        }
        public Boolean IsTotalEqualItemTotalPriceAndTax() 
        {
            double itemTotalPrice = double.Parse(lblItemTotalPrice.Text.Replace("Item total: $", ""));
            double tax = double.Parse(lblTax.Text.Replace("Tax: $", ""));
            double total = double.Parse(lblTotal.Text.Replace("Total: $", ""));
            return total == itemTotalPrice + tax;
        }
        public CheckoutOverview ClickContinueButton() 
        {
            keyword.Click(btnFinish);
            return this;
        }
        #endregion
    }
}
