using HotelBookingAPI.Data;
using HotelBookingAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        public readonly HotelBookingDbcontext  _db;

        public HotelBookingController(HotelBookingDbcontext db)
        {
            _db = db;
        }


        //create
        [HttpPost]
        public JsonResult create(HotelBooking hotelBooking)
        {
            if (hotelBooking.Id == 0)
            {
                _db.HotelBookings.Add(hotelBooking);
            }
            else
            {
                var BookingId = _db.HotelBookings.Find(hotelBooking.Id);
                if (BookingId == null)
                    return new JsonResult(NotFound());
                BookingId = hotelBooking;
            }
            _db.SaveChanges();
            return new JsonResult(Ok(hotelBooking));

        }

        //Get
        [HttpGet]
        public JsonResult Get(int Id)
        {
            var result = _db.HotelBookings.Find(Id);

            if (result == null)
                return new JsonResult(NotFound());


            return new JsonResult(Ok(result));

        }
        [HttpDelete]
        public JsonResult Delete(int Id)
        {
            var result = _db.HotelBookings.Find(Id);
            if (result == null)
                return new JsonResult(NotFound());
            _db.HotelBookings.Remove(result);
            _db.SaveChanges();

            return new JsonResult(NoContent());


        }
        [HttpGet]
        public JsonResult Edite(int Id)
        {
            HotelBooking result = _db.HotelBookings.Find(Id);
            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
        [HttpPost]
        public JsonResult Edite(HotelBooking hotelBooking)
        {
            _db.HotelBookings.Update(hotelBooking);
            _db.SaveChanges();

            return new JsonResult(Ok(hotelBooking));

        }

        [HttpGet()]
        public JsonResult Getall()
        {
            var result = _db.HotelBookings.ToList();

            return new JsonResult(Ok(result));
        }
    } 

    


}
