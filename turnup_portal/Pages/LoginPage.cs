using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_portal.Utilities;

namespace turnup_portal.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            //OPEN URL AND MAXIMIZE THE BROWSER
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();

            //FINDING ELEMENTS AND STORING IN WEBELEMENT
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));

            //ACTIONS THE USER PERFORMS
            usernameTextbox.SendKeys("hari");
            passwordTextbox.SendKeys("123123");
            loginButton.Click();
        }
    }
}