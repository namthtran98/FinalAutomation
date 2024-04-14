using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomation.Core.Driver
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    var options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    options.AddArgument("--incognito");
                    return new ChromeDriver(options);
                case "ff":
                    return new FirefoxDriver();
                default:
                    return new ChromeDriver();
            }
        }
    }
}
