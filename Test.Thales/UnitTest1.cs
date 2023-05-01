using ThalesPrueba.Data;

namespace Test.Thales
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestMethod]
        public void CalcularSalarioAnual_EmpleadoConSalarioValido_RetornaValorCorrecto()
        {
            Employee empleado = new Employee();
            empleado.employee_salary = 1500;

            // Act
            double salarioAnual = empleado.AnnualSalary;

            // Assert
            Assert.AreEqual(18000, salarioAnual);
        }
    }
}