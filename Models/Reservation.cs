using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public enum ReservationStatus { Confirmada, Cancelada, Completada}
    public class Reservation
    {
        public int Id { get; set; }

        [Required, Display(Name = "Número de asiento")]
        public int SeatNumber { get; set; }

        [Required, Display(Name = "Fecha de reserva")]
        public TimeSpan ReservationDate { get; set; }

        [Required, Display(Name = "Estado de reserva")]
        public ReservationStatus Status { get; set; }

        public required string ClientID { get; set; }      // FK
        public required int ScheduleID { get; set; }     // FK


        public Person? Clients { get; set; }     // Reservation(1) --> User(1)
        
        public Schedule? Schedules { get; set; } // Reservation(1) --> Schedule(1)

        public Payment? Payment { get; set; }   // Reservation(1) --> Payment(1)
    }
}
