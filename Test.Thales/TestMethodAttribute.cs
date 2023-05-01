using NUnit.Framework;
using ThalesPrueba.BusinessLogic;
using ThalesPrueba.Data;

namespace Test.Thales
{
    internal class TestMethodAttribute : Attribute
    {
      
        public class EmployeeBusinessLogicTests
        {
            [TestMethod]
            public void CalculateAnnualSalary_ShouldCalculateCorrectly()
            {
                // Arrange
                Employee employee = new Employee { Id = 1, employee_name = "John Doe", employee_salary = 1000, employee_age = 34 , profile_image = "d"};
                EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();

                // Act
                employeeBusinessLogic.CalculateAnnualSalary(employee);

                // Assert
                Assert.AreEqual(12000, employee.AnnualSalary);
            }
        }

    }
}