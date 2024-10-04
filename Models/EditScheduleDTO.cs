using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class EditScheduleDTO
    {
        public int Id { get; set; }

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
    }
}
