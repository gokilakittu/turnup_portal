using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_portal.Utilities;

namespace turnup_portal.Pages
{
    public class HomePage:CommonDriver
    {
        public void NavigateToTM()
        {
            /*Check the current user*/
            IWebElement currentUsername = driver.FindElement(By.LinkText("Hello hari!"));
            String currentUsernameString = currentUsername.Text;
            Console.WriteLine("Current user name " + currentUsernameString);
            
            /*IF THE ANCHOR IS NOT CONVERTED INTO TEXT*/
            if (currentUsername.Text == "Hello hari!")
            {
                Console.WriteLine("User logged in");
            }
            else
            {
                Console.WriteLine("User not logged in");
            }

            /*Navigate to time and material page in menu*/
            IWebElement administrationMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationMenu.Click();
            Wait.WaitToBeVisible(driver, "administrationMenu", "Time & Materials",2000);
            
            IWebElement timeMaterialMenu = driver.FindElement(By.LinkText("Time & Materials"));
            timeMaterialMenu.Click();
        }
    }
}