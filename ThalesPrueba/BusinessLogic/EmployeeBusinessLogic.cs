using ThalesPrueba.Data;

namespace ThalesPrueba.BusinessLogic
{
    public class EmployeeBusinessLogic
    {
        public void CalculateAnnualSalary(Employee employees)
        {
            employees.AnnualSalary = employees.employee_salary * 12;
        }


    }
}
