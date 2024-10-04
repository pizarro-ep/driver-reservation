using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class ScheduleDTO
    {
        public int Id { get; set; }

        [Required, Display(Name = "Salida")]
        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        [Required, Display(Name = "Llegada")]
        [DataType(DataType.Time)]
        public TimeSpan ArrivalTime { get; set; }

        [Display(Name = "Vehiculo")]
        public string VehicleName { get; set; } = string.Empty;

        [Display(Name = "Ruta")]
        public string RoadName { get; set; } = string.Empty;

    }
}
