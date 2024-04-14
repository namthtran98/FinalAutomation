using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Test.Pages
{
    public class Cart : BasePage
    {
        public Cart(IWebDriver driver) : base(driver)
        {
        }

        #region Elements
        private IWebElement lnkNameOfItemAddToCart(string nameOfItem) => wait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[text() = '{nameOfItem}']")));
        private IWebElement btnCartCheckout => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#checkout")));
        #endregion
        #region Actions
        public Boolean IsItemInCart(string nameOfItem)
        {
            wait.Timeout = TimeSpan.FromSeconds(2);
            try
            {
                Boolean text = lnkNameOfItemAddToCart(nameOfItem).Displayed;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Cart ClickCheckoutButton() 
        {
            keyword.Click(btnCartCheckout);
            return this;
        }

        public Boolean IsCheckoutDisabled() 
        {
            return !btnCartCheckout.Enabled;
        }
        #endregion
    }
}
