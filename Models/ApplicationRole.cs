using Microsoft.AspNetCore.Identity;

namespace Transport.Models
{
    public class ApplicationRole:IdentityRole{
        public string? Description { get; set; }
    }
}
