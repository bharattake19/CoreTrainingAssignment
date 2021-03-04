using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlRepository
{
    public interface IUnitOfWork
    {
        IFlightDetailRepository FlightDetailsRepo { get; }
        IBookingRepository BookingRepo { get; }
        void Commit();
    }
}
