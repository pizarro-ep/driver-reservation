using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class EditRoleDTO
    {
        [Required(ErrorMessage = "El nombre del rol es requerido")]
        [Display(Name = "Nombre del rol")]
        public string Id {  get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public List<string>? Users { get; set; } = new List<string>();

        public List<string>? Claims { get; set; } = new List<string>();
    }
}
