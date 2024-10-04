namespace Transport.Models
{
    public class RoleClaimsDTO
    {
        public RoleClaimsDTO()
        {
            Claims = new List<RoleClaim>();
        }
        public string RoleId { get; set; } = string.Empty;
        public List<RoleClaim> Claims { get; set; }
    }
}
