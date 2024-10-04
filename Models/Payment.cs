using System.ComponentModel.DataAnnotations;

namespace Transport.Models
{
    public enum PaymentMethod { Tarjeta, Paypal, Efectivo }
    public class Payment
    {
        public int Id { get; set; }

        [Required, Display(Name = "Monto de pago")]
        public float Amount { get; set; }

        [Required, Display(Name = "Fecha de pago")]
        [DataType(DataType.Date)]
        public TimeSpan PaymentDate { get; set; }

        [Required, Display(Name = "Método de pago")]
        public PaymentMethod PaymentMethod { get; set; }

        public int ReservationID { get; set; }      // FK

        public Reservation? Reservations { get; set; }      // Payment(1) --> Reservation(1)
    }
}
