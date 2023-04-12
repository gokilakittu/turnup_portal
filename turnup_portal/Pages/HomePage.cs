using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnup_portal.Pages
{
    public class HomePage
    {
        public void NavigateToTM(IWebDriver driver)
        {
            /*Check the current user*/
            //IWebElement currentuser = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            IWebElement currentuser = driver.FindElement(By.LinkText("Hello hari!"));
            String str_username = currentuser.Text;
            Console.WriteLine("Current user name " + str_username);
            /* CHECK IF THE ELEMENT IS PREESENT OR NOT
            IWebElement tmpElement = driver.FindElement(By.LinkText("Hello hari!"));
            bool Element_Displayed = tmpElement.Displayed;
            if (Element_Displayed == true)
            {
                Console.WriteLine("present");
            }
            else
            {
                Console.WriteLine("absent");
                driver.Quit();
            }
            IF THE ANCHOR IS NOT CONVERTED INTO TEXT
            if (currentuser.Text== "Hello hari!")
            {
                Console.WriteLine("User logged in");
            }
            else
            {
                Console.WriteLine("User not logged in");
            }
            */
            if (currentuser.Text == "Hello hari!")
            {
                Console.WriteLine("User logged in");
            }
            else
            {
                Console.WriteLine("User not logged in");
            }

            /*Navigate to time and material page in menu*/
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
            driver.FindElement(By.LinkText("Time & Materials")).Click();
        }
    }
}