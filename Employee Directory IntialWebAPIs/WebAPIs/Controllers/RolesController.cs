using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Concerns;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        } 

        // GET: api/<RolesController>
        [HttpGet]
        public List<Role> Get()
        {
            return _roleService.DisplayAll();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public List<Role> Get(int id)
        {
            return _roleService.DisplayRole(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        public void Post(Role role)
        {
            _roleService.AddRole(role);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id,Role role)
        {
            _roleService.EditingARole(id, role);
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _roleService.DeleteRole(id);
        }
    }
}
