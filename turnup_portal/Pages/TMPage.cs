using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_portal.Utilities;

namespace turnup_portal.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            //FIND ALL ELEMENTS AND STOREING IN THE WEBELEMENTS
            IWebElement createNewTimeMaterialButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewTimeMaterialButton.Click();
            
            IWebElement typeCodeSelect = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeSelect.Click();
            Wait.WaitToBeVisible(driver, "typeCodeSelect", "typeCodeSelected", 2000);
            Thread.Sleep(2000);
            IWebElement typeCodeSelected = driver.FindElement(By.XPath("//*[@id=\"TypeCode_option_selected\"]"));
            typeCodeSelected.Click();
            
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            IWebElement decriptionTextBox = driver.FindElement(By.Id("Description"));
            IWebElement priceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            IWebElement saveTimeMaterialButton = driver.FindElement(By.Id("SaveButton"));

            //USER ACTIONS / ACTIONS PERFORMED IN THE PAGE
            codeTextBox.SendKeys("testdata");
            decriptionTextBox.SendKeys("testdata-Description");
            priceOverlap.Click();
            priceTextBox.SendKeys("100");
            saveTimeMaterialButton.Click();

            Thread.Sleep(2000);
            IWebElement gotoLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotoLastPageButton.Click();
            Thread.Sleep(2000);
            IWebElement LastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            string LastRowCode = LastRow.Text;
            Wait.WaitForTableToLoadCompletely(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]", 2000);
            Thread.Sleep(2000);

            // CHECKING EXPECTED AND ACTUAL RESULT
            Assert.AreEqual(LastRowCode, "testdata");
        }

        public void EditTM(IWebDriver driver)
        {
            //GO TOT THE LAST PAGE TO EDIT
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            Thread.Sleep(2000);
            goToLastPageButton.Click();
            Thread.Sleep(4000);
            
            //FIND ALL ELEMENTS AND STOREING IN THE WEBELEMENTS
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            
            //USER ACTIONS / ACTIONS PERFORMED IN THE PAGE
            if (newCode.Text == "testdata")
            {
                Thread.Sleep(1000);
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[last()]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else{
                Assert.Fail("Record recently created hasn't been found");
            }
            IWebElement dropdownEdit = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
           
            Thread.Sleep(500);
            dropdownEdit.Click();
            Thread.Sleep(500);
            IWebElement timeOptionEdit = driver.FindElement(By.XPath("//*[@id=\"TypeCode-list\"]"));
            timeOptionEdit.Click();

            IWebElement editcodeTextbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            IWebElement editdescriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            IWebElement editpriceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editpriceTextbox = driver.FindElement(By.Id("Price"));
            IWebElement savebuttonEdit = driver.FindElement(By.Id("SaveButton"));
            editcodeTextbox.SendKeys("-time");
            editdescriptionTextbox.SendKeys("-time");
            editpriceOverlap.Click();
            editpriceTextbox.Clear();
            editpriceOverlap.Click();
            editpriceTextbox.SendKeys("200");
            savebuttonEdit.Click();

            //GO TOT THE LAST PAGE TO GET THE LAST ROW CONTENT-CODE
            Thread.Sleep(2000);
            IWebElement goToEditLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToEditLastPageButton.Click();
            Thread.Sleep(3000);

            IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Console.WriteLine(editCode);
            // CHECKING EXPECTED AND ACTUAL RESULT
            Assert.That(editCode.Text == "testdata-time");
       
        }
        public void DeleteTM(IWebDriver driver)
        {
            //GO TOT THE LAST PAGE TO DELETE
            Thread.Sleep(2000);
            IWebElement gotoLastEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            Thread.Sleep(4000);
            gotoLastEdit.Click();
            Thread.Sleep(4000);

            //FIND ALL ELEMENTS AND STOREING IN THE WEBELEMENTS
            IWebElement editwholeLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]"));
            IWebElement editedLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
           
            // DECLARING ALL THE VARIABLES
            string editWholeLastRowContent = editwholeLastRow.Text;
            string editededitedLastRowCode = editedLastRow.Text;

            //USER ACTIONS / ACTIONS PERFORMED IN THE PAGE
            if (editededitedLastRowCode == "testdata-time")
            {
                Thread.Sleep(3000);
                IWebElement deleteTimeMaterialButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteTimeMaterialButton.Click();
            }
            else
            {
                Assert.Fail("Record recently created hasn't been found");
            }

            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            IWebElement deleteCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Thread.Sleep(3000);
            // CHECKING EXPECTED AND ACTUAL RESULT
            Assert.AreNotEqual(deleteCode.Text,"test-code-time");
        }
        public void Quitbrowser(IWebDriver driver)
        {
            driver.Quit();
        }

    }
}