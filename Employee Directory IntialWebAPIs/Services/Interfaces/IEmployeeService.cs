using Concerns;
namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        public void AddEmployee(Employee emp);

        public List<Employee> ViewAllEmployees();

        public List<Employee> ButtonFilteredEmployees(string letter);

        public List<Employee> SortedEmployees (string sortBy, string sortOrder);

        public List<Employee> MultiselectFilteredEmployees(string[]locations, string[]departments);

        public void EditEmployee(int employeeToEdit, Employee emp);

        public void DeleteEmployee(int Id);

    }
}
