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
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();
        
        
        [Test, Order(1),Description("Check the user session")]
        public void ConfirmUserTest()
        {
            homePageObj.ConfirmCurrentUser(driver);
        }

        [Test,Order(2),Description("Time and Material-create")]
        public void CreateTMTest()
        {
            homePageObj.NavigateToTM(driver);
            tmPageObj.CreateTM(driver);
        }

        [Test,Order(3), Description("Time and Material-edit")]
        public void EditTMTest()
        {
            homePageObj.NavigateToTM(driver);
            tmPageObj.EditTM(driver);
        }

        [Test,Order(4) ,Description("Time and Material-delete")]
        public void DeleteTMTest()
        {
            homePageObj.NavigateToTM(driver);
            tmPageObj.DeleteTM(driver);
        }
    }
}





