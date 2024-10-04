using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class RegisterDTO
    {
        [Required]
        [Display(Name = "Documento de identidad")]
        [RegularExpression(@"^[0-9]+[0-9]*$"), StringLength(8, ErrorMessage = "El DNI debe tener 8 dígitos")]
        public required string Dni {  get; set; }

        [Required, PersonalData, Display(Name = "Nombres")]
        public required string Name { get; set; }

        [Required, PersonalData, Display(Name ="Apellidos")]
        public required string Surnames { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        [Display(Name = "Correo")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña repetidas no son iguales")]
        [Display(Name = "Repetir Contraseña")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
