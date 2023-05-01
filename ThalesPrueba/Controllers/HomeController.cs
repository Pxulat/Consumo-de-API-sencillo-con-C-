using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ThalesPrueba.BusinessLogic;
using ThalesPrueba.Data;
using ThalesPrueba.Models;
using ThalesPrueba.Services;

namespace ThalesPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Employee> employe = new List<Employee>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://dummy.restapiexample.com/api/v1/");
                HttpResponseMessage response = await httpClient.GetAsync("employees");
                string responseBody = await response.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(responseBody);
                employe = root.data;
                Debug.WriteLine($"Response: {responseBody}");


                // Debugging messages
                foreach (var employee in employe)
                {
                    Debug.WriteLine($"Name: {employee.employee_name}, Salary: {employee.employee_salary}");
                    EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();
                    employeeBusinessLogic.CalculateAnnualSalary(employee);
                }
                return View(employe.ToList());
                return View(employe);
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            int employeeId;
            bool isInt = int.TryParse(formCollection["employeeId"], out employeeId);
            if (isInt)
            {
                return RedirectToAction("SearchById", new { employeeId = employeeId });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // Obtiene datos de empleados por ID

        [HttpGet]
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