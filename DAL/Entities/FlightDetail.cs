using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class FlightDetail
    {
        [Key]
        public int FlightId { get; set; }
        [Column(TypeName = "varchar(100)")]

        public string SourceLocation { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string DestinationLocation { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FlightAmount { get; set; }

        public int AvailableTickets { get; set; }
        public DateTime FlightDate { get; set; }
    }
}
