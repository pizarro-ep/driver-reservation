using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required, Display(Name = "Hora de salida")]
        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        [Required, Display(Name = "Hora de llegada")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        [Display(Name = "Vehiculo")]
        public int VehicleID { get; set; }

        public int RoadID { get; set; }

        
        [Display(Name = "Vehiculo")]
        public Vehicle? Vehicles { get; set; }      // Schedule(1) --> Vehicle(1)

        [Display(Name = "Ruta")]
        public Road? Roads { get; set; }       // Schedule(1) --> Road(1)

        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>(); // Schedule(1) --> Reservation(n)
    }
}
