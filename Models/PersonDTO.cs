using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Transport.Models;

namespace Transport.Models
{
    public class PersonDTO
    {
        [Display(Name = "DNI")]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        public required string Dni {  get; set; }

        [Required, PersonalData]
        [Display(Name = "Nombres")]
        public required string Name { get; set; }

        [Required, PersonalData]
        [Display(Name = "Apellidos")]
        public required string Surnames { get; set; }

        [Display(Name = "Correo")]
        public string? Email {  get; set; }

        [Display(Name = "Usuario")]
        public string? UserName { get; set; }
    }
}
