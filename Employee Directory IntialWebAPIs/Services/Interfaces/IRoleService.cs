using Concerns;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        public void AddRole(Role role);

        public List<Role> DisplayAll();

        public List<Role> DisplayRole(int id);

        public void EditingARole(int id, Role role);

        public void DeleteRole(int Id);


    }
}
