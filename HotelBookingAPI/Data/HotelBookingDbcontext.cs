using HotelBookingAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace HotelBookingAPI.Data
{
    public class HotelBookingDbcontext : DbContext
    {
        public HotelBookingDbcontext(DbContextOptions<HotelBookingDbcontext> options) : base(options)
        { 
        
        
        
        }

        public DbSet<HotelBooking> HotelBookings { get; set; }


       
    }
}
