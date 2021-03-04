using DAL;
using DAL.Entities;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlRepository.Implementation
{
    public class FlightDetailRepository : Repository<FlightDetail>, IFlightDetailRepository
    {
        private BookingDatabaseContext _context;
        public FlightDetailRepository(BookingDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<FlightDetail> Search(string filters)
        {
            var flightDetails = _context.FlightDetails.Where(t => t.SourceLocation.Contains(filters) ||
                                    t.DestinationLocation.Contains(filters)).ToList();            
           
            return flightDetails;
        }
    }
}
