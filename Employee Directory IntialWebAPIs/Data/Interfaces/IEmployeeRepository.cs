using Repository.DataConcerns;

namespace Repository.Interfaces
{

    public interface IEmployeeRepository
    {
        void AddingEmployee(Employee emp);

        List<Employee> DisplayEmployees(string letter);

        List<Employee> GetSortedEmployees(string sortBy, string sortOrder);

        List<Employee> FilteredEmployees(string[] locations, string[] departments);

        void UpdatingAnEmployee(int employeeIdToEdit, Employee emp);

        void DeletingAnEmployee(int inputId);
    }
}
