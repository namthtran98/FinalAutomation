using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomation.Core.Keywords
{
    public class ActionKeywords
    {
        
            private IWebDriver driver;
            private WebDriverWait wait;
            public ActionKeywords(IWebDriver driver, int timeout)
            {
                this.driver = driver;
                wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
            }
            ///
            public void OpenUrl(string Url)
            {
                if (!(Url.StartsWith("http://") || Url.StartsWith("https://")))
                {
                    throw new Exception("Url is missing protocal");
                }
                this.driver.Url = Url;
            }
            ///
            public void Navigate(string Url)
            {
                if (!(Url.StartsWith("http://") || Url.StartsWith("https://")))
                {
                    throw new Exception("Url is missing protocal");
                }
                this.driver.Navigate().GoToUrl(Url);
            }
            ///
            public IWebElement FindElement(By by)
            {
                return wait.Until(ExpectedConditions.ElementExists(by));
            }
            ///
            public void Click(IWebElement Element)
            {
                Actions _action = new Actions(this.driver);
                _action.MoveToElement(Element).Build().Perform();
                Element.Click();
            }
            ///
            public void SetText(IWebElement element, string text)
            {
                try
                {
                    element.Clear();
                    element.SendKeys(text);
                }
                catch (WebDriverException e)
                {
                    throw new WebDriverException("Element is not enable for set text" + "\r\n" + "error: " + e.Message);
                }
            }
            ///
            public void Select(IWebElement element, SelectType type, string options)
            {
                SelectElement select = new SelectElement(element);
                switch (type)
                {
                    case SelectType.SelectByIndex:
                        try
                        {
                            select.SelectByIndex(Int32.Parse(options));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.GetBaseException().ToString());
                            throw new ArgumentException("Please input numberic on SelictOption for Selecttype.SelectByIndex");
                        }
                        break;
                    case SelectType.SelectByText:
                        select.SelectByText(options);
                        break;
                    case SelectType.SelectByValue:
                        select.SelectByValue(options);
                        break;
                    default:
                        throw new Exception("Get error in using Selected");
                }
            }
        }
    
}
public enum SelectType
{
    SelectByIndex,
    SelectByText,
    SelectByValue,
}
