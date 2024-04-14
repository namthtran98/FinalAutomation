using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swag_Labs_Test.Pages
{
    public class Login : BasePage
    {
        public Login(IWebDriver driver) : base(driver)
        {
        }

        #region Elements
        private IWebElement txtUsername => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#user-name")));
        private IWebElement txtPassword => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#password")));
        private IWebElement txaError => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test = 'error']")));
        private IWebElement btnLogin => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#login-button")));
        private IWebElement btnCloseError => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[data-test = 'error-button']")));
        #endregion
        #region Actions      
        public Login InputAndLogin(string username, string password) 
        {
            keyword.SetText(txtUsername, username);
            keyword.SetText(txtPassword, password);
            keyword.Click(btnLogin);
            return this;
        }
        public Login CloseError() 
        {
            keyword.Click(btnCloseError);
            return this;
        }
        #endregion
    }
}
