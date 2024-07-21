using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Concerns;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics.Metrics;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            return _employeeService.ViewAllEmployees();
        }

        //GET api/<EmployeesController>/a
        [HttpGet("{letter}")]
        public List<Employee> GetEmployee(string letter)
        {
            return _employeeService.ButtonFilteredEmployees(letter);
        }

        // Multiselect filtered employees
        [HttpPost("filter")]
        public IActionResult GetFilteredEmployees([FromBody] MultiselectFilter filters)
        {
            var filteredEmployees = _employeeService.MultiselectFilteredEmployees(filters.Locations, filters.Departments);
            return Ok(filteredEmployees);
        }

        //Sorting on columns
        [HttpGet("Sorting")]
        public List<Employee> EmployeesAfterSorting (string sortby, string  sortorder)
        {
            return _employeeService.SortedEmployees(sortby, sortorder);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _employeeService.AddEmployee(emp);
            return Ok("Employee added successfully.");
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put([FromRoute] int id, Employee emp)
        {
            _employeeService.EditEmployee(id, emp);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}
