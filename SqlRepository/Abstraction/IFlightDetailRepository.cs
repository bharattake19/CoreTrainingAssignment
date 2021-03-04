using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlRepository.Abstraction
{
    public interface IFlightDetailRepository : IRepository<FlightDetail>
    {        
        IEnumerable<FlightDetail> Search(string filters);
    }
}
