using Concerns;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services
{

    public class EmployeeServices : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Adding employee starts here
        public void AddEmployee(Employee emp)
        {
            _employeeRepository.AddingEmployee(ConvertToRepositoryEmployee(emp));
        }
        // Adding employee ends here
        
        // View all employees starts here
        public List<Employee> ViewAllEmployees()
        {
            return ConvertToConcernsEmployee(_employeeRepository.DisplayEmployees(null));
        }
        // View all employees ends here

        // Button filtering starts here
        public List<Employee> ButtonFilteredEmployees(string letter)
        {
            return ConvertToConcernsEmployee(_employeeRepository.DisplayEmployees(letter));
        }
        // Button filtering ends here

        //Sorting starts here
        public List<Employee> SortedEmployees(string sortBy, string sortOrder)
        {
            return ConvertToConcernsEmployee(_employeeRepository.GetSortedEmployees(sortBy, sortOrder));
        }

        // Multiselect filtering starts here
        public List<Employee> MultiselectFilteredEmployees(string[] locations,string[] departments)
        {
            return ConvertToConcernsEmployee(_employeeRepository.FilteredEmployees(locations, departments));
        }
        // Edit employee details starts here
        public void EditEmployee(int employeeToEdit, Employee emp)
        {
            _employeeRepository.UpdatingAnEmployee(employeeToEdit, ConvertToRepositoryEmployee(emp));
        }
        // Edit employee details ends here

        // Delete an Employee starts here
        public void DeleteEmployee(int employeeIdToDelete)
        {
            _employeeRepository.DeletingAnEmployee(employeeIdToDelete);
        }
        // Delete an employee ends here


        // Converting from Concerns.Employee to Repository.DataConcerns.Employee
        private static Repository.DataConcerns.Employee ConvertToRepositoryEmployee(Employee concernsEmployee)
        {
            Repository.DataConcerns.Employee RepositoryEmployee = new Repository.DataConcerns.Employee();
            RepositoryEmployee.Id = concernsEmployee.ID;
            RepositoryEmployee.FirstName = concernsEmployee.FirstName;
            RepositoryEmployee.LastName = concernsEmployee.LastName;
            RepositoryEmployee.DateOfBirth = concernsEmployee.DateOfBirth;
            RepositoryEmployee.Email = concernsEmployee.Email;
            RepositoryEmployee.Phone = concernsEmployee.Phone;
            RepositoryEmployee.JoinDate = concernsEmployee.JoinDate;
            RepositoryEmployee.Location = concernsEmployee.Location;
            RepositoryEmployee.JobTitle = concernsEmployee.JobTitle;
            RepositoryEmployee.Department = concernsEmployee.Department;
            RepositoryEmployee.Manager = concernsEmployee.Manager;
            RepositoryEmployee.Project = concernsEmployee.Project;
            return RepositoryEmployee;
        }
        // Ends here

        // Converting from Concerns.MultiselectFilters to Repository.DataConcerns.MultiselectFilter
        private static Repository.DataConcerns.MultiselectFilter ConvertToRepositoryMultiselectFilters(MultiselectFilter concernsMultiselectFilters)
        {
            Repository.DataConcerns.MultiselectFilter RepositoryMultiSelectFilters = new Repository.DataConcerns.MultiselectFilter();
            RepositoryMultiSelectFilters.Locations= concernsMultiselectFilters.Locations;
            RepositoryMultiSelectFilters.Departments = concernsMultiselectFilters.Departments;
            return RepositoryMultiSelectFilters;
        }

        // Converting from Repository.DataConcerns.Employee to Concerns.Employee
        private static List<Employee> ConvertToConcernsEmployee(List<Repository.DataConcerns.Employee> RepositoryEmployees)
        {
            List<Employee> concernsEmployees = new List<Employee>();

            foreach (var RepositoryEmployee in RepositoryEmployees)
            {
                Employee concernsEmployee = new Employee();
                concernsEmployee.ID = RepositoryEmployee.Id;
                concernsEmployee.FirstName = RepositoryEmployee.FirstName;
                concernsEmployee.LastName = RepositoryEmployee.LastName;
                concernsEmployee.DateOfBirth = RepositoryEmployee.DateOfBirth;
                concernsEmployee.Email = RepositoryEmployee.Email;
                concernsEmployee.Phone = RepositoryEmployee.Phone;
                concernsEmployee.JoinDate = RepositoryEmployee.JoinDate;
                concernsEmployee.Location = RepositoryEmployee.Location;
                concernsEmployee.JobTitle = RepositoryEmployee.JobTitle;
                concernsEmployee.Department = RepositoryEmployee.Department;
                concernsEmployee.Manager = RepositoryEmployee.Manager;
                concernsEmployee.Project = RepositoryEmployee.Project;

                concernsEmployees.Add(concernsEmployee);
            }
            return concernsEmployees;
        }
        // Ends here

        //Converting from Repository.DataConcerns.MultiselectFilter to Concerns.MultiselectFilters
        private static List<MultiselectFilter> ConvertToConcernsMultiselect (List<Repository.DataConcerns.MultiselectFilter> RepositoryFilters)
        {
            List<MultiselectFilter> ConcernsMultiselectFilters = new List<MultiselectFilter>();

            foreach(var Repositoryfilter in RepositoryFilters)
            {
                MultiselectFilter concernsMultiselectFilter = new MultiselectFilter();
                concernsMultiselectFilter.Locations = Repositoryfilter.Locations;
                concernsMultiselectFilter.Departments = Repositoryfilter.Departments;

                ConcernsMultiselectFilters.Add(concernsMultiselectFilter);
            }
            return ConcernsMultiselectFilters;
        }
        //Ends here
    }
}