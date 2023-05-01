using Newtonsoft.Json;

namespace ThalesPrueba.Data
{

    public class Employee
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("employee_name")]
        public string employee_name { get; set; }
        [JsonProperty("employee_salary")]
        public float employee_salary { get; set; }
    
        public float AnnualSalary { get; internal set; }
        [JsonProperty("employee_age")]

        public int employee_age { get; set; }
        [JsonProperty("profile_image")]

        public string profile_image { get; set; }

        public static implicit operator Employee(List<Employee> v)
        {
            throw new NotImplementedException();
        }
    }


}
