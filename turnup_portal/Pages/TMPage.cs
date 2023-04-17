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
    public class TMPage:CommonDriver
    {
        public void CreateTM()
        {
            /*Create the new time and material record*/

            IWebElement createNewTimeMaterialButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewTimeMaterialButton.Click();
            IWebElement typeCodeSelect = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            typeCodeSelect.Click();
            
            Thread.Sleep(2000);

            IWebElement typeCodeSelected = driver.FindElement(By.XPath("//*[@id=\"TypeCode_option_selected\"]"));
            typeCodeSelected.Click();

            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("test-code");
            IWebElement decriptionTextBox = driver.FindElement(By.Id("Description"));
            decriptionTextBox.SendKeys("testdata-Description");
            
            IWebElement priceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceOverlap.Click();

            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("100");
            IWebElement saveTimeMaterialButton = driver.FindElement(By.Id("SaveButton"));
            saveTimeMaterialButton.Click();

            /*Check if the data is been saved in the table*/
            Thread.Sleep(4000);

            IWebElement gotoLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotoLastPageButton.Click();
           
            Thread.Sleep(3000);
            Console.WriteLine("thread sleep finished");

            /* whole data of the first row*/
            IWebElement wholeLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]"));
            string wholeLastRowContent = wholeLastRow.Text;
            Console.WriteLine("whole row content " + wholeLastRowContent);

            /*last row but just the first column*/
            IWebElement LastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            string LastRowCode = LastRow.Text;
            Console.WriteLine("code of the last row " + LastRowCode);

            if (LastRowCode == "test-code")
            {
                Console.WriteLine("Reocord was added to the table");
            }
            else
            {
                Console.WriteLine("the last row of the table is different from the data you just added");
            }
        }
        public void EditTM()
        {
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Thread.Sleep(4000);
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "test-code")
            {
                //click on edit button
                Thread.Sleep(1000);

                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[last()]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("Record recently created hasn't been found");
            }

            //select Time option from dropdown
            IWebElement dropdownEdit = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            dropdownEdit.Click();
            Thread.Sleep(500);

            IWebElement timeOptionEdit = driver.FindElement(By.XPath("//*[@id=\"TypeCode-list\"]"));
            timeOptionEdit.Click();

            //edit code into code textbox
            IWebElement editcodeTextbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            editcodeTextbox.SendKeys("-time");

            //edit description into description boxr1q
            IWebElement editdescriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            editdescriptionTextbox.SendKeys("-time");



            //edit price into price per unit textbox
            IWebElement editpriceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editpriceTextbox = driver.FindElement(By.Id("Price"));

            editpriceOverlap.Click();
            editpriceTextbox.Clear();
            editpriceOverlap.Click();
            editpriceTextbox.SendKeys("200");

            //click on save button
            IWebElement savebuttonEdit = driver.FindElement(By.Id("SaveButton"));
            savebuttonEdit.Click();
            Thread.Sleep(2000);


            //check if Time record has been edited
            IWebElement goToEditLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToEditLastPageButton.Click();

            IWebElement editCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(editCode.Text == "test-code-time", "Record hasn't been edited.");
        }
        public void DeleteTM()
        {
            /*Delete the last row of the table*/
            Thread.Sleep(4000);

            IWebElement gotoLastEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotoLastEdit.Click();
            
            /*whole data of the last row that was edited*/
            IWebElement editwholeLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]"));
            string editWholeLastRowContent = editwholeLastRow.Text;
            Thread.Sleep(4000);

            /*last row but just the first column that was edited*/
            IWebElement editedLastRow = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            string editededitedLastRowCode = editedLastRow.Text;
            Console.WriteLine("code of the last row after editing  " + editededitedLastRowCode);
            Thread.Sleep(4000);

            if (editededitedLastRowCode == "test-code-time")
            {
                Console.WriteLine("Reocord was added to the table");
                Thread.Sleep(3000);
                IWebElement deleteTimeMaterialButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteTimeMaterialButton.Click();
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine("the Reocord was deleted from the table");
            }
            else
            {
                Console.WriteLine("the last row of the table is different from the data you just edited");
            }
            
        }
        public void Quitbrowser()
        {
            /*quit the browser*/
            driver.Quit();
        }

    }
}