using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;

namespace Transport.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /*
        public DbSet<Driver> Drivers { get; set; }*/
        public DbSet<Person> Persons { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            // Cambiar nombre de las tablas
            /*
            builder.Entity<Driver>().ToTable("tr_Drivers");*/
            builder.Entity<Person>().ToTable("Tbl_Persons");
            builder.Entity<Vehicle>().ToTable("Tbl_Vehicles");
            builder.Entity<Road>().ToTable("Tbl_Roads");
            builder.Entity<Schedule>().ToTable("Tbl_Schedules");
            builder.Entity<Reservation>().ToTable("Tbl_Reservations");
            builder.Entity<Payment>().ToTable("Tbl_Payments");

            // Configuración de relaciones entre tablas
            base.OnModelCreating(builder);

            // Relación entre ApplicationUser y ApplicationRole
            builder.Entity<IdentityUserRole<string>>()
                   .HasOne<ApplicationRole>()
                   .WithMany()
                   .HasForeignKey(ur => ur.RoleId)
                   .OnDelete(DeleteBehavior.NoAction); // OnDelete(DeleteBehavior.Restrict); // OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Person>()
                   .HasOne(p => p.Users)
                   .WithOne(u => u.Persons)
                   .HasForeignKey<Person>(p => p.UserID)
                   .OnDelete(DeleteBehavior.Cascade);       // Eliminar

            /*builder.Entity<Driver>()
                   .HasOne(d => d.Persons)
                   .WithOne(p => p.Drivers)
                   .HasForeignKey<Driver>(d => d.PersonID)
                   .OnDelete(DeleteBehavior.NoAction);*/

            builder.Entity<Vehicle>()
                   .HasOne(v => v.Drivers)
                   .WithMany(d => d.Vehicles)
                   .HasForeignKey(v => v.DriverID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Schedule>()
                   .HasOne(s => s.Vehicles)
                   .WithMany(v => v.Schedules)
                   .HasForeignKey(s => s.VehicleID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Schedule>()
                   .HasOne(s => s.Roads)
                   .WithMany(r => r.Schedules)
                   .HasForeignKey(s => s.RoadID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
                   .HasOne(r => r.Clients)
                   .WithMany(u => u.Reservations)
                   .HasForeignKey(r => r.ClientID)
                   .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Reservation>()
                   .HasOne(r => r.Schedules)
                   .WithMany(s => s.Reservations)
                   .HasForeignKey(r => r.ScheduleID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Payment>()
                   .HasOne(p => p.Reservations)
                   .WithOne(r => r.Payment)
                   .HasForeignKey<Payment>(p => p.ReservationID)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }


}
