using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace turnup_portal.Utilities
{
    public class Wait
    {
        private static int seconds;

        public static void WaitToBeVisible(IWebDriver driver, string locator, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            
            //Console.WriteLine("locator-> " + locator + "locator value-> " + locatorValue + "timeout-> " + seconds);

            if (locator == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
            if (locator == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            }
            if (locator == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
            }
            if (locator == "LinkText")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(locatorValue)));
            }
        }

        public static void WaitForTableToLoadCompletely(IWebDriver driver, string locator, string locatorValue, int timeoutSecond)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (locator == "XPath")
            {
                Console.WriteLine("waited for the page to load completely- till last page- before");
                Console.WriteLine("locator-> "+ locator + "locator value-> " +locatorValue + "timeout-> "+ timeoutSecond);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                Console.WriteLine("waited for the page to load completely- till last page");
            }
            
        }
    }
}
