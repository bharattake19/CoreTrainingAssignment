using DAL;
using DAL.Entities;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlRepository.Implementation
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private BookingDatabaseContext _context;
        public BookingRepository(BookingDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckFlight(DateTime dateOfJourney, int flightId)
        {
            var flightDetails = (from fd in _context.FlightDetails
                                 join b in _context.Bookings on fd.FlightId equals b.FlightId
                                 where fd.FlightId == flightId && fd.FlightDate == dateOfJourney
                                 select b).ToList();
            if (flightDetails.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
