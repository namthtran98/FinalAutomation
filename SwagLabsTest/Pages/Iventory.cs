using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Test.Pages
{
    public class Iventory : BasePage
    {
        public Iventory(IWebDriver driver) : base(driver)
        {
        }

        #region Elements
        private IWebElement ddlFilter => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test = 'product-sort-container']")));
        private IWebElement lnkItem(string nameOfItem) => wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[text() = '{nameOfItem}']")));
        private IWebElement btnAddToCart(string nameOfItem) => wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[text() = '{nameOfItem}']//ancestor::div[@class='inventory_item']//button[text() = 'Add to cart']")));
        private IWebElement btnRemove(string nameOfItem) => wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[text() = '{nameOfItem}']//ancestor::div[@class='inventory_item']//button[text() = 'Remove']")));
        private IWebElement lblItemPrice(string nameOfItem) => wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[text() = '{nameOfItem}']//ancestor::div[@class='inventory_item']//div[@data-test = 'inventory-item-price']")));
        #endregion
        #region Actions
        public Iventory AddProductToCart(string nameOfItem) 
        {
            keyword.Click(btnAddToCart(nameOfItem));
            return this;
        }
        public Boolean IsRemoveButtonDisplayed(string nameOfItem) 
        {
            wait.Timeout = TimeSpan.FromSeconds(2);
            try
            {
                Boolean text = btnRemove(nameOfItem).Displayed;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string GetItemPrice(string nameOfItem) 
        {
            return lblItemPrice(nameOfItem).Text;
        }
        public Iventory ClickRemoveButton(string nameOfItem) 
        {
            keyword.Click(btnRemove(nameOfItem));
            return this;
        }
        public Boolean IsAddToCartButtonDisplayed(string nameOfItem) 
        {
            wait.Timeout = TimeSpan.FromSeconds(2);
            try
            {
                Boolean text = btnAddToCart(nameOfItem).Displayed;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
