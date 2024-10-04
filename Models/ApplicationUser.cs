using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Transport.Models;

namespace Transport.Models
{
    public class ApplicationUser:IdentityUser 
    {
        [DataType(DataType.Date)]
        public TimeSpan CreatedDate { get; set; }


        public Person? Persons { get; set; }                // User(1) --> Person(1)
    }
}
