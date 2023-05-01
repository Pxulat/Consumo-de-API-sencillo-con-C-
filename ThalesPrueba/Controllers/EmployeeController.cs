using Microsoft.AspNetCore.Mvc;
using ThalesPrueba.BusinessLogic;
using ThalesPrueba.Data;
using ThalesPrueba.Services;

namespace ThalesPrueba.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            List<Employee> employees;
            if (string.IsNullOrEmpty(searchString))
            {
                EmployeeService employeeService = new EmployeeService();
                employees = await employeeService.GetEmployeesAsync();
            }
            else
            {
                EmployeeService employeeService = new EmployeeService();
                Employee employee = await employeeService.GetEmployeesAsync();

                if (employee != null)
                {
                    employees = new List<Employee>() { employee };
                }
                else
                {
                    employees = new List<Employee>();
                }
            }

            return View(employees);
        }

        // Obtiene datos de empleados por ID

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            EmployeeService employeeService = new EmployeeService();
            Employee employee = await employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                Console.WriteLine("No es posible encontrar este dato");
            }
            else
            {
                EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();
                employeeBusinessLogic.CalculateAnnualSalary(employee);


            }
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(EmployeeService employe)
        {
            EmployeeService employeeService = new EmployeeService();
            List<Employee> employees = await employeeService.GetEmployeesAsync();
            Employee employee = employees.FirstOrDefault();

            if (employee == null)
            {
                return NotFound();
            }

            EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();
            employeeBusinessLogic.CalculateAnnualSalary(employee);

            return Ok(employee);
        }


    }
}
