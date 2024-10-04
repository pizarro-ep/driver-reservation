using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class EditVehicleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La licencia es necesaria.")]
        [RegularExpression(@"^[A-Z0-9]+[A-Z0-9]*$")]
        [Display(Name = "Licencia")]
        public string License { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo del vehiculo es requerido")]
        [Display(Name = "Modelo")]
        public string ModelVehicle { get; set; } = string.Empty;

        [Required, Display(Name = "Capacidad")]
        public int Capacity { get; set; }

        [Required, Display(Name = "Estado")]
        public Status? Status { get; set; }

        [Required, Display(Name = "Conductor")]
        public required string DriverID { get; set; }
    }
}
