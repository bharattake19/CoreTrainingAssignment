using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlRepository.Abstraction
{
    public interface IBookingRepository : IRepository<Booking>
    {
        bool CheckFlight(DateTime dateOfJourney,int flightId);
    }
}
