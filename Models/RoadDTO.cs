using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public class RoadDTO
    {
        public int Id { get; set; }

        [Required, Display(Name = "Lugar de salida")]
        public required string StartLocation { get; set; }

        [Required, Display(Name = "Lugar de llegada")]
        public required string EndLocation { get; set; }

        [Required, Display(Name = "Distancia (KM)")]
        public float Distance { get; set; }

        [Required, Display(Name = "Duración estimada")]
        [DataType(DataType.Time)]
        public TimeSpan EstimatedDuration { get; set; } 
    }
}
