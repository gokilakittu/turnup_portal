using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_portal.Utilities;

namespace turnup_portal.Pages
{
    public class EmployeePage 
    {
        public void CreateEmployee(IWebDriver driver)
        {
            IWebElement createEmployeeButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createEmployeeButton.Click();

            IWebElement empNameTextbox = driver.FindElement(By.Id("Name"));
            IWebElement empUsernameTextbox = driver.FindElement(By.Id("Username"));
            IWebElement empContactTextbox = driver.FindElement(By.Id("ContactDisplay"));
            IWebElement empPasswordTextbox = driver.FindElement(By.Id("Password"));
            IWebElement empRetypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));

            empNameTextbox.SendKeys("testdata");
            empUsernameTextbox.SendKeys("testdata");
            empContactTextbox.SendKeys("testdata");
            empPasswordTextbox.SendKeys("Testdata@123");
            empRetypePasswordTextbox.SendKeys("Testdata@123");

            IWebElement empSaveButton = driver.FindElement(By.Id("SaveButton"));
            empSaveButton.Click();
            Thread.Sleep(2000);

            IWebElement backtoListLink = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backtoListLink.Click();
            Thread.Sleep(3000);

            IWebElement lastEmpPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastEmpPageButton.Click();
            Thread.Sleep(4000);

            IWebElement lastEmpNameInTable = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.AreEqual("testdata", lastEmpNameInTable.Text);

        }
        public void EditEmployee(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement lastEmpPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastEmpPageButton.Click();
            Thread.Sleep(4000);

            IWebElement lastEmpNameInTable = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lastEmpNameInTable.Text == "testdata")
            {
                IWebElement lastEmpEditButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[5]/td[3]/a[1]"));
                lastEmpEditButton.Click();

                IWebElement editEmpNameTextbox = driver.FindElement(By.Id("Name"));
                IWebElement editEmpUsernameTextbox = driver.FindElement(By.Id("Username"));
                IWebElement editEmpContactTextbox = driver.FindElement(By.Id("ContactDisplay"));
                IWebElement editEmpasswordTextbox = driver.FindElement(By.Id("Password"));
                IWebElement editEmpRetypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));

                editEmpNameTextbox.Clear();
                editEmpNameTextbox.SendKeys("testdata_edit");
                editEmpUsernameTextbox.Clear();
                editEmpUsernameTextbox.SendKeys("testdata_edit");
                editEmpContactTextbox.Clear();
                editEmpContactTextbox.SendKeys("testdata_edit");
                editEmpasswordTextbox.Clear();
                editEmpasswordTextbox.SendKeys("Testdata@123");
                editEmpRetypePasswordTextbox.Clear();
                editEmpRetypePasswordTextbox.SendKeys("Testdata@123");

                IWebElement empSaveButton = driver.FindElement(By.Id("SaveButton"));
                empSaveButton.Click();
                Thread.Sleep(2000);

                IWebElement backtoListLink = driver.FindElement(By.XPath(" //*[@id=\"container\"]/div/a"));
                backtoListLink.Click();
                Thread.Sleep(3000);

                IWebElement lastEditEmpPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]"));
                lastEditEmpPageButton.Click();
                Thread.Sleep(4000);

                IWebElement lastEditEmpNameInTable = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.AreEqual("testdata_edit", lastEditEmpNameInTable.Text);
            }
            else
            {
                Assert.Fail("Record recently created hasn't been found");
            }

        }
        public void DeleteEmployee(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement lastEmpPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastEmpPageButton.Click();
            Thread.Sleep(4000);

            IWebElement lastEmpNameInTable = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lastEmpNameInTable.Text == "testdata_edit")
            {
                IWebElement lastEmpDeleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[5]/td[3]/a[2]"));
                lastEmpDeleteButton.Click();
            }
            else
            {
                Assert.Fail("Record recently created hasn't been found");
            }
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            IWebElement deleteCode = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            // CHECKING EXPECTED AND ACTUAL RESULT
            Assert.AreNotEqual(deleteCode.Text, "testdata_edit");

        }
        public void Quitbrowser(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}