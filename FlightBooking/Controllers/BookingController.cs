using DAL;
using DAL.Entities;
using FlightBooking.ResultTypes;
using Microsoft.AspNetCore.Mvc;
using SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Controllers
{
    public class BookingController : ControllerBase
    {
        private readonly BookingDatabaseContext context;
        IUnitOfWork uow;

        public BookingController(BookingDatabaseContext _context, IUnitOfWork _uow)
        {
            context = _context;
            uow = _uow;
        }

        [HttpPost]
        public IActionResult BooFlight(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (uow.BookingRepo.CheckFlight(booking.DateOfJourney, booking.FlightId))
            {
                uow.BookingRepo.Add(booking);
                uow.Commit();
            }
            else
            {
                return Ok(new InsertResult() { Message = "Flight not available" });
            }

            return Ok(new InsertResult() { Message = "Flight details saved successfully" });
        }
    }
}
