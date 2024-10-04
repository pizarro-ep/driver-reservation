using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public enum Status { Bueno, Regular, Malo }
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La licencia es necesaria.")]
        [RegularExpression(@"^[A-Z0-9]+[A-Z0-9]*$")]
        [Display(Name = "Licencia")]
        public string License { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo del vehiculo es requerido")]
        [Display(Name = "Modelo")]
        public string Model { get; set; } = string.Empty ;

        [Required, Display(Name = "Capacidad")]
        public int Capacity { get; set; }

        [Required, Display(Name = "Estado")]
        public Status? Status { get; set; }

        public required string DriverID { get; set; }     // FK


        [Display(Name = "Conductor")]
        public Person? Drivers { get; set; }        // Vehicle(1) --> Driver(1)

        public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
    }
}
