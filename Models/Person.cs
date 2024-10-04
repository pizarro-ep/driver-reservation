using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Transport.Models;

namespace Transport.Models
{
    public class Person
    {
        [Key, Required]
        [Display(Name = "DNI"), RegularExpression(@"^[0-9]+[0-9]*$")]
        public required string Dni {  get; set; }

        [Required, PersonalData, Display(Name = "Nombres")]
        public required string Name { get; set; }

        [Required, PersonalData, Display(Name = "Apellidos")]
        public required string Surnames { get; set; }

        public required string UserID { get; set; }       // FK


        public ApplicationUser? Users { get; set; }         // Person(1) --> User(1)

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();   // Person(1) --> Vehicle(n)

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
