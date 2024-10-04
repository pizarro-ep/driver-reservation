using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class CreateVehicleDTO
    {
        [Required(ErrorMessage = "La licencia es necesaria.")]
        [RegularExpression(@"^[A-Z0-9]+[A-Z0-9]*$")]
        [Display(Name = "Licencia")]
        public string License { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo del vehiculo es requerido")]
        [Display(Name = "Modelo")]
        public string Model { get; set; } = string.Empty;

        [Required, Display(Name = "Capacidad")]
        public int Capacity { get; set; }

        [Required, Display(Name = "Estado")]
        public Status? Status { get; set; }

        [Required]
        public required string DriverID { get; set; }

        [Display(Name = "Conductores")]
        public ICollection<Person> Drivers { get; set; } = new HashSet<Person>();
    }
}
