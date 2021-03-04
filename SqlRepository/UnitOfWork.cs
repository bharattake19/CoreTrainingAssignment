using DAL;
using SqlRepository.Abstraction;
using SqlRepository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private BookingDatabaseContext _context;
        public UnitOfWork(BookingDatabaseContext context)
        {
            _context = context;
        }
        private IFlightDetailRepository _productRepo;
        public IFlightDetailRepository FlightDetailsRepo
        {
            get
            {
                if (_productRepo == null)
                    _productRepo = new FlightDetailRepository(_context);

                return _productRepo;
            }
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
