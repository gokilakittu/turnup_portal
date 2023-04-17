using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_portal.Utilities;

namespace turnup_portal.Test
{
    public class EmployeeTest
    {
        [TestFixture, Parallelizable]
        public class Employee : CommonDriver
        {
            public void CreateEmployee()
            {
                // code to create a new employee record
            }

            public void EditEmployee()
            {
                // code edit an existing employee record
            }

            public void DeleteEmployee()
            {
                // code to delete an existing employee record
            }
            public void Quitbrowser()
            {
                driver.Quit();
            }
        }
    }
}
