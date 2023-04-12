using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnup_portal.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            /*Create the new time and material record*/
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"TypeCode_option_selected\"]")).Click();

            driver.FindElement(By.Id("Code")).SendKeys("test-code");
            driver.FindElement(By.Id("Description")).SendKeys("testdata-Description");
            /*
            driver.FindElement(By.Id("Price")).Click();
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys("testdata");
            */
            IWebElement priceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceOverlap.Click();

            driver.FindElement(By.Id("Price")).SendKeys("100");
            driver.FindElement(By.Id("SaveButton")).Click();

            /*Check if the data is been saved in the table*/
            Thread.Sleep(4000);

            IWebElement goto_last_row = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goto_last_row.Click();

            Thread.Sleep(3000);
            Console.WriteLine("thread sleep finished");

            /* whole data of the first row*/
            IWebElement whole_last_row = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]"));
            string whole_last_row_content = whole_last_row.Text;
            Console.WriteLine("whole row content " + whole_last_row_content);

            /*last row but just the first column*/
            IWebElement last_row = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            string last_row_code = last_row.Text;
            Console.WriteLine("code of the last row " + last_row_code);

            if (last_row_code == "test-code")
            {
                Console.WriteLine("Reocord was added to the table");
            }
            else
            {
                Console.WriteLine("the last row of the table is different from the data you just added");
            }
        }
        public void EditTM(IWebDriver driver)
        {
            /* Edit the last of the table*/
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")).Click();

            driver.FindElement(By.Id("Code")).SendKeys("-time");
            driver.FindElement(By.Id("Description")).SendKeys("-time");

            IWebElement priceOverlap_edit = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceOverlap_edit.Click();

            driver.FindElement(By.Id("Price")).SendKeys("24");
            //priceOverlap_edit.Click();
            driver.FindElement(By.Id("SaveButton")).Click();
        }
        public void DeleteTM(IWebDriver driver)
        {
            /*Delete the last row of the table*/
            Thread.Sleep(4000);

            IWebElement goto_last_row_edit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goto_last_row_edit.Click();

            /*whole data of the last row that was edited*/
            IWebElement edit_whole_row = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]"));
            string editwhole_last_row_content = edit_whole_row.Text;
            Console.WriteLine("whole row content after editing " + editwhole_last_row_content);
            Thread.Sleep(4000);

            /*last row but just the first column that was edited*/
            IWebElement edited_last_row = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            string edited_last_row_code = edited_last_row.Text;
            Console.WriteLine("code of the last row after editing  " + edited_last_row_code);
            Thread.Sleep(4000);

            if (edited_last_row_code == "test-code-time")
            {
                Console.WriteLine("Reocord was added to the table");
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]")).Click();
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine("the Reocord was deleted from the table");
            }
            else
            {
                Console.WriteLine("the last row of the table is different from the data you just edited");
            }
            /*quit the browser*/
            //driver.Quit();
        }

    }
}