namespace Transport.Models
{
    public class UserRolesDTO
    {
        public string RoleId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsSelected { get; set; }
    }
}
