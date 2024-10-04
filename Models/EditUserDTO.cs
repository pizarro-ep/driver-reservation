using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class EditUserDTO
    {

        // El constructor inicializa Claims y Roles con una lista vacía
        public EditUserDTO() {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Nombre")]
        public string? Name { get; set; } = string.Empty;

        [Display(Name = "Apellidos")]
        public string? Surnames { get; set; } = string.Empty;

        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
    }
}