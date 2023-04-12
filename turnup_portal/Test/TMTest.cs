using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml;
using turnup_portal.Pages;

IWebDriver driver = new ChromeDriver();

LoginPage loginPageObj = new LoginPage();
loginPageObj.LoginSteps(driver);

HomePage homePageObj = new HomePage();
homePageObj.NavigateToTM(driver);

TMPage tmPageObj =new TMPage();
tmPageObj.CreateTM(driver);
tmPageObj.EditTM(driver);
tmPageObj.DeleteTM(driver);
tmPageObj.Quitbrowswe(driver);





