using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class CreateScheduleDTO
    {
        [Required, Display(Name = "Hora de salida")]
        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        [Required, Display(Name = "Hora de llegada")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        [Required]
        public required int VehicleID { get; set; }

        [Display(Name = "Vehículo")]
        public Vehicle? Vehicles { get; set; }      // Schedule(1) --> Vehicle(1)

        [Required]
        public required int RoadID { get; set; }

        [Display(Name = "Ruta")]
        public Road? Roads { get; set; }       // Schedule(1) --> Road(1)


        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>(); // Schedule(1) --> Reservation(n)

        //public string Rs { get { return LastName + " " + Surname; } }
    }
}
