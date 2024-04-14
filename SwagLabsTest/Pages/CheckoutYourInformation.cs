using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Test.Pages
{
    public class CheckoutYourInformation : BasePage
    {
        public CheckoutYourInformation(IWebDriver driver) : base(driver)
        {
        }
        #region Elements
        private IWebElement txtFirstName => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#first-name")));
        private IWebElement txtLastName => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#last-name")));
        private IWebElement txtPostalCode => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#postal-code")));
        private IWebElement btnContinue => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#continue")));
        #endregion
        #region Actions
        public CheckoutYourInformation InputInformation(string firstName, string lastName, string postalCode) 
        {
            keyword.SetText(txtFirstName, firstName);
            keyword.SetText(txtLastName, lastName);
            keyword.SetText(txtPostalCode, postalCode);
            return this;
        }
        public CheckoutYourInformation ClickContinue() 
        {
            keyword.Click(btnContinue); 
            return this;
        }
        #endregion
    }
}
