using FinalAutomation.Core.Keywords;
using NPOI.SS.Formula.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Test.Pages
{
    public class BasePage
    {

        public IWebDriver driver;
        public WebDriverWait wait;
        public ActionKeywords keyword;
        const int timeout = 60;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
            keyword = new ActionKeywords(this.driver, timeout);
        }

        #region Elements
        private IWebElement btnMenu => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#react-burger-menu-btn")));
        private IWebElement lnkAllItems => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#inventory_sidebar_link")));
        private IWebElement lnkAbout => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#about_sidebar_link")));
        private IWebElement lnkLogout => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#logout_sidebar_link")));
        private IWebElement lnkResetAppState => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#reset_sidebar_link")));
        private IWebElement btnCheckout => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test = 'shopping-cart-link']")));
        private IWebElement lblNumberOfItemInCart => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test = 'shopping-cart-badge']")));
        #endregion
        #region Actions
        public int GetNumberOfItemInCart()
        {
            return Int32.Parse(lblNumberOfItemInCart.Text);
        }
        public BasePage ClickOnCartButton() 
        {
            keyword.Click(btnCheckout);
            return this;
        }
        public Boolean IsNumberOfItemDisplay() 
        {
            wait.Timeout = TimeSpan.FromSeconds(2);
            try 
            {
                string text = lblNumberOfItemInCart.Text;
                return true;
            }catch (Exception ex) 
            {
                return false;
            }
        }

        public BasePage ClickMenu() 
        {
            keyword.Click(btnMenu);
            Thread.Sleep(300);
            return this;
        }
        public BasePage ClickResetAppState() 
        {
            keyword.Click(lnkResetAppState);
            return this;
        }
        #endregion
    }

}
