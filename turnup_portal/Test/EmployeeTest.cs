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
    [Parallelizable]
    public class EmployeeTest:CommonDriver
    {
        HomePage homePageObj = new HomePage();
        EmployeePage empObj = new EmployeePage();

        
        [Test, Order(1)]
        public void CurrentUserTest()
        {
            homePageObj.ConfirmCurrentUser(driver);
        }

        [Test, Order(2)]
        public void CreateEmployeeTest() 
        {
            homePageObj.NavigateToEmployee(driver);
            empObj.CreateEmployee(driver);
        }

        [Test,Order(3)]
        public void EditEmployeeTest()
        {
            homePageObj.NavigateToEmployee(driver);
            empObj.EditEmployee(driver);
        }

        [Test,Order(4)]
        public void DeleteEmployeeTest()
        {
            homePageObj.NavigateToEmployee(driver);
            empObj.DeleteEmployee(driver);
        }
        
    }
}
