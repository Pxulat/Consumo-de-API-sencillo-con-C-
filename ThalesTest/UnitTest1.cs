using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThalesPrueba.BusinessLogic;
using ThalesPrueba.Data;

namespace ThalesTest
{
    public class Tests
    {
        [TestMethod]
        public void TestCalculateAnnualSalary()
        {
            // Arrange
            Employee employee = new Employee
            {
                employee_salary = 1000
            };
            EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();

            // Act
            employeeBusinessLogic.CalculateAnnualSalary(employee);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(12000, employee.AnnualSalary);
        }

    }
}