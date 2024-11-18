using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Model
{
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }
        public int RoomName { get; set; }
        public string? ClientName { get; set; }  

    }
}
