using DAL;
using DAL.Entities;
using FlightBooking.ResultTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlRepository;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightDetailController : ControllerBase
    {
        private readonly BookingDatabaseContext context;
        IUnitOfWork uow;

        public FlightDetailController(BookingDatabaseContext _context, IUnitOfWork _uow)
        {
            context = _context;
            uow = _uow;
        }

        [Route("searchFlight/{filter}")]
        [HttpGet]
        public IEnumerable<FlightDetail> SearchFlightDetails(string filter)
        {
            return uow.FlightDetailsRepo.Search(filter);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddFlightDetails([FromBody] FlightDetail flightDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            uow.FlightDetailsRepo.Add(flightDetail);
            uow.Commit();

            return Ok(new InsertResult() { Message = "Flight details saved successfully" });
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<FlightDetail> GetAll()
        {
            var result = uow.FlightDetailsRepo.GetAll();
            return result;
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateFlightDetails([FromBody] FlightDetail flightDetail)
        {
            uow.FlightDetailsRepo.Update(flightDetail);
            uow.Commit();
            return Ok(new InsertResult() { Message = "Flight details updated successfully" });

        }

        [Route("delete/{flightId}")]
        [HttpDelete]
        public IActionResult DeleteFlightDetails(int flightId)
        {
            var isDelete = uow.FlightDetailsRepo.Delete(flightId);
            uow.Commit();
            if (isDelete)
            {
                return Ok(new InsertResult() { Message = "Flight details deleted successfully" });
            }
            return Ok(new InsertResult() { Message = "Flight details deletion failed" });
        }
    }
}
