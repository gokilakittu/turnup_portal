using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml;

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

/* OPEN the the project URL, and enter username and password and click login*/
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
//driver.FindElement(By.Id("UserName")).SendKeys("hari");
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");
driver.FindElement(By.Id("Password")).SendKeys("123123");
driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]")).Click();

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
driver.Quit();
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
driver.Quit();