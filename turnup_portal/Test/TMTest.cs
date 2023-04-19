using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml;
using turnup_portal.Pages;
using turnup_portal.Utilities;

namespace turnup_portal.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TMTests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();
        
        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
            loginPageObj.LoginSteps(driver);
            homePageObj.NavigateToTM();
        }
        /*[Test, Order(1),Description("Check the user session")]
        public void ConfirmUser()
        {
            homePageObj.ConfirmCurrentUser();
        }*/
        [Test,Order(2),Description("Time and Material-create")]
        public void CreateTM_Test()
        {
            tmPageObj.CreateTM();
        }
        [Test,Order(3), Description("Time and Material-edit")]
        public void EditTM_Test()
        {
            tmPageObj.EditTM();
        }
        [Test,Order(4) ,Description("Time and Material-delete")]
        public void DeleteTM_Test()
        {
           tmPageObj.DeleteTM();
        }
        [TearDown]
        public void Quitbrowser()
        {
            tmPageObj.Quitbrowser();
        }
    }
}





