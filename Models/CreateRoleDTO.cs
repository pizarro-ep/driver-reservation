using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class CreateRoleDTO
    {
        [Required]
        [Display(Name = "Nombre del rol")]
        public string RoleName { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;
    }
}
