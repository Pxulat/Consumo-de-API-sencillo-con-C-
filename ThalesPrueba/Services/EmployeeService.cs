using Newtonsoft.Json;
using NuGet.Protocol;
using System.Xml.Serialization;
using ThalesPrueba.Data;

namespace ThalesPrueba.Services
{
    public class EmployeeService
    {
        private static List<Employee> employe = new List<Employee>();
        // obtener la lista de empleados
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string ids = "";
                    client.BaseAddress = new Uri("https://dummy.restapiexample.com/api/v1/employees?ids={ids} ");
                    HttpResponseMessage response = await client.GetAsync("employees");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(responseBody);
                    employe = root.data;
                    return employe;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return null;
            }
        }


        // obtener los datos de un empleado por ID
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                Employee employee = new Employee();
                GetEmployeesAsync();
                foreach (Employee item in employe)
                {
                    if (item.Id == id)
                    {
                        employee.Id = item.Id;
                        employee.employee_name = item.employee_name;
                        employee.employee_salary = item.employee_salary;
                        employee.AnnualSalary = item.AnnualSalary;
                        employee.employee_age = item.employee_age;
                        employee.profile_image = item.profile_image;
                    }
                }
                return employee;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return null;
            }
        }
    }
}
