using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_portal.Utilities;

namespace turnup_portal.Pages
{
    public class HomePage : CommonDriver
    {
        public void NavigateToTM()
        {
            //FINDING ELEMENTS AND STORING IN WEBELEMENT
            IWebElement administrationMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            //IWebElement timeMaterialMenu = driver.FindElement(By.LinkText("Time & Materials"));
            IWebElement timeMaterialMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));

            //USER ACTIONS
            administrationMenu.Click();
            Wait.WaitToBeVisible(driver, "administrationMenu", "Time & Materials", 2000);
            timeMaterialMenu.Click();
        }
        public void ConfirmCurrentUser()
        {
            //FINDING ELEMENTS AND STORING IN WEBELEMENT
            IWebElement currentUsername = driver.FindElement(By.LinkText("Hello hari!"));

            //DECLARE ALL THE VARIABLES
            String currentUserText = "Hello hari!";
            String actualUserText = currentUsername.Text;

            //CHECKING THE EXPECTED AND ACTUAL
            Assert.AreEqual(currentUserText, actualUserText);
        }
    }
}