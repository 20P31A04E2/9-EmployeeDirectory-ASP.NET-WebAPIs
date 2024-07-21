using Repository;
using Concerns;
using Services.Interfaces;

namespace Services
{
    public class RoleServices : IRoleService
    {
        private readonly RolesRepository roleData;

        public RoleServices(EmployeeDBContext context)
        {
            roleData = new RolesRepository(context);
        }
        //Add role starts here
        public void AddRole(Role role)
        {
            roleData.AddingRole(ConvertToDataRole(role));
        }
        //Add role ends here

        //Display all start here
        public List<Role> DisplayAll()
        {
            return ConvertToConcernsRole(roleData.DisplayRoles(0));
        }
        // Display all ends here

        // Display a single role starts here
        public List<Role> DisplayRole(int id)
        {
            return ConvertToConcernsRole(roleData.DisplayRoles(id));
        }
        // Display a single role ends here

        // Editing a role starts here
        public void EditingARole(int id, Role role)
        {
            roleData.UpdatingARole(id, ConvertToDataRole(role));
        }
        // Editing a role ends here

         //Delete a role starts here
        public void DeleteRole(int inputId)
        {
            roleData.DeletingARole(inputId);
        }
        // Delete a role ends here

        // Converting from Concerns.Role to Data.DataConcerns.Role
        private static Repository.DataConcerns.Role ConvertToDataRole(Role concernsRole)
        {
            Repository.DataConcerns.Role dataRole = new Repository.DataConcerns.Role();
            dataRole.RoleName = concernsRole.RoleName;
            dataRole.Department = concernsRole.Department;
            dataRole.RoleDescription = concernsRole.RoleDescription;
            dataRole.Location = concernsRole.Location;
            return dataRole;
        }
        // Ends here

        // Converting from Data.DataConcerns.Role to Concerns.Role
        private static List<Role> ConvertToConcernsRole(List<Repository.DataConcerns.Role> dataRoles)
        {
            List<Role> concernsRoles = new List<Role>();

            foreach (var dataRole in dataRoles)
            {
                Role concernsRole = new Role();
                concernsRole.RoleName = dataRole.RoleName;
                concernsRole.Department = dataRole.Department;
                concernsRole.RoleDescription = dataRole.RoleDescription;
                concernsRole.Location = dataRole.Location;

                concernsRoles.Add(concernsRole);
            }

            return concernsRoles;
        }
        // Ends here
    }
}