using Repository.DataConcerns;
using Repository.Interfaces;

namespace Repository
{
    public class RolesRepository : IRoleRepository
    {
        private readonly EmployeeDBContext _context;
        public RolesRepository(EmployeeDBContext context)
        {
            _context = context;
        }
        // Adding a role starts here
        public void AddingRole(Role r)
        {
                _context.Roles.Add(r);
                _context.SaveChanges();
        }
        // Adding a role ends here

        // Displaying all/a single role starts here
        public List<Role> DisplayRoles(int inputId)
        {
                if (inputId == 0)
                {
                    var roles = _context.Roles.ToList();
                    return roles;
                }
                else
                {
                    var role = _context.Roles.Where(r => r.Id == inputId).ToList();
                    return role;
                }
        }
        // Displaying all/a single role ends here

        // Updating an role starts here
        public void UpdatingARole(int id, Role role)
        {
                var roleToUpdate = _context.Roles.SingleOrDefault(r => r.Id == id);

                if (roleToUpdate is not null)
                {
                    roleToUpdate.RoleName = role.RoleName;
                    roleToUpdate.Department = role.Department;
                    roleToUpdate.RoleDescription = role.RoleDescription;
                    roleToUpdate.Location = role.Location;
                    _context.Roles.Update(roleToUpdate);
                    _context.SaveChanges();
                }
        }

        // Deleting an Employee starts here
        public void DeletingARole(int inputId)
        {

                var role = _context.Roles.SingleOrDefault(r => r.Id == inputId);
                if (role is not null)
                {
                    _context.Roles.Remove(role);
                    _context.SaveChanges();
                }
        }
        // Deleting an Employee ends here
    }
}
