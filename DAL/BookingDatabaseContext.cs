using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class BookingDatabaseContext : DbContext
    {

        public BookingDatabaseContext(DbContextOptions opt) : base(opt)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightDetail>().Property(d => d.SourceLocation).IsRequired()
                .IsUnicode(false).HasMaxLength(100);

            modelBuilder.Entity<Booking>().HasKey(f => f.BookingId);

            modelBuilder.Entity<FlightDetail>().ToTable("tblFlightDetail");
            modelBuilder.Entity<Booking>().ToTable("tblBooking");

           
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<FlightDetail> FlightDetails { get; set; }
        public DbSet<Booking> Bookings { get; set; }      
    }
}
