namespace Repository.DataConcerns;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public string? Department { get; set; }

    public string? RoleDescription { get; set; }

    public string? Location { get; set; }
}
