using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int FlightId { get; set; }
        public DateTime DateOfJourney { get; set; }
    }
}
