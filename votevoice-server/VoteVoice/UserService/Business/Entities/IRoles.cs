namespace UserService.Business.Entities
{
    public interface IRoles
    {
        long RoleId { get; set; }
        string RoleName { get; set; }
        bool IsActive { get; set; }
    }
}
