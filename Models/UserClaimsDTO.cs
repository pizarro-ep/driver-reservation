namespace Transport.Models
{
    public class UserClaimsDTO
    {
        public UserClaimsDTO()
        {
            Claims = new List<UserClaim>();
        }
        public string UserId { get; set; } = string.Empty;
        public List<UserClaim> Claims { get; set; }
    }
}
