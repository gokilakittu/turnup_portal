using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_portal.Pages;
using turnup_portal.Utilities;

namespace turnup_portal.Test
{
    [TestFixture]
    //[Parallelizable]
    public class EmployeeTest:CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        EmployeePage empObj = new EmployeePage();

        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
            loginPageObj.LoginSteps(driver);
            homePageObj.NavigateToEmployee();
        }
        
        [Test, Order(1)]
        public void currentUserTest()
        {
            homePageObj.ConfirmCurrentUser();
        }
        [Test, Order(2)]
        public void CreateEmployeeTest() { 
            empObj.CreateEmployee();
        }
        [Test,Order(3)]
        public void EditEmployeeTest()
        {
            empObj.EditEmployee();
        }

        [Test,Order(4)]
        public void DeleteEmployeeTest()
        {
            empObj.DeleteEmployee();
        }
        [TearDown]
        public void Quitbrowser()
        {
            empObj.Quitbrowser();
        }
    }
}
