using Repository.DataConcerns;
using Repository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;
        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }
        //Adding an employee starts here
        public void AddingEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }
        //Adding an employee ends here

        // Selecting all Employees/Single employee starts here
        public List<Employee> DisplayEmployees(string letter)
        {
            if (letter == null)
            {
                var employees = _context.Employees.ToList();
                return employees;
            }
            else
            {
                var employee = _context.Employees.AsEnumerable().Where(e => e.FirstName.StartsWith(letter, StringComparison.OrdinalIgnoreCase)).ToList();
                return employee;
            }
        }
        // Selecting all Employees/Single employee ends here

        public List<Employee> GetSortedEmployees(string sortBy, string sortOrder)
        {
            if (sortBy == null || sortOrder == null)
            {
                var employees = _context.Employees.ToList();
                return employees;
            }
            else
            {
                var employees = _context.Employees.ToList();
                switch (sortBy.ToLower())
                {
                    case "users":
                        employees = sortOrder == "asc" ? employees.OrderBy(e => e.FirstName).ToList() : employees.OrderByDescending(e => e.FirstName).ToList();
                        break;
                    case "location":
                        employees = sortOrder == "asc" ? employees.OrderBy(e => e.Location).ToList() : employees.OrderByDescending(e => e.Location).ToList();
                        break;
                    case "department":
                        employees = sortOrder == "asc" ? employees.OrderBy(e => e.Department).ToList() : employees.OrderByDescending(e => e.Department).ToList();
                        break;
                    case "role":
                        employees = sortOrder == "asc" ? employees.OrderBy(e => e.JobTitle).ToList() : employees.OrderByDescending(e => e.JobTitle).ToList();
                        break;
                    case "emp.no":
                        employees = sortOrder == "asc" ? employees.OrderBy(e => e.Id).ToList() : employees.OrderByDescending(e => e.Id).ToList();
                        break;
                    case "join dt":
                        employees = sortOrder == "asc" ? employees.OrderBy(e => e.JoinDate).ToList() : employees.OrderByDescending(e => e.JoinDate).ToList();
                        break;
                    default:
                        break;
                }
                return employees;
            }
        }
        // Multiselect filtering starts here
        public List<Employee> FilteredEmployees(string[] locations, string[] departments)
        {
            var employees = _context.Employees.AsQueryable();

            if (locations != null && locations.Any())
            {
                employees = employees.Where(e => locations.Contains(e.Location));
            }
            if (departments != null && departments.Any())
            {
                employees = employees.Where(e => departments.Contains(e.Department));
            }
            return employees.ToList();
        }
        // Multiselect filtering ends here


        // Editing an Employee starts here
        public void UpdatingAnEmployee(int employeeIdToEdit, Employee emp)
        {
            var employeeToUpdate = _context.Employees.SingleOrDefault(e => e.Id == employeeIdToEdit);

            if (employeeToUpdate is not null)
            {
                employeeToUpdate.FirstName = emp.FirstName;
                employeeToUpdate.LastName = emp.LastName;
                employeeToUpdate.DateOfBirth = emp.DateOfBirth;
                employeeToUpdate.Email = emp.Email;
                employeeToUpdate.Phone = emp.Phone;
                employeeToUpdate.JoinDate = emp.JoinDate;
                employeeToUpdate.Location = emp.Location;
                employeeToUpdate.JobTitle = emp.JobTitle;
                employeeToUpdate.Department = emp.Department;
                employeeToUpdate.Manager = emp.Manager;
                employeeToUpdate.Project = emp.Project;
                _context.Employees.Update(employeeToUpdate);
                _context.SaveChanges();
            }
        }
        // Editing an Employee ends here

        // Deleting an Employee starts here
        public void DeletingAnEmployee(int inputId)
        {
            var employee = _context.Employees.SingleOrDefault(emp => emp.Id == inputId);
            if (employee is not null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
        // Deleting an Employee ends here
    }
}
