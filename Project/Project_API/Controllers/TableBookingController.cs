using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Models;
using System;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableBookingController : ControllerBase
    {
        PRN231_Group10_SE1701Context context = new PRN231_Group10_SE1701Context();

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Output: int id, int table id, int table number, int customer id,
            //string customer name, string customer phone, datetime eating time, int status
            //Note: status có 2 trạng thái: 0 - đã đặt, 1 - đã đến
            try
            {
                var data = context.TableBookings.Select(c => new
                {
                    Id = c.Id,
                    TableId = c.TableId,
                    TableNumber = c.Table.Number,
                    CustomerId = c.Booking.BookedUserId,
                    CustomerName = c.Booking.BookedUser.Fullname,
                    CustomerPhone = c.Booking.BookedUser.Phone,
                    EatingTime = c.Booking.EatingTime,
                    Status = c.Status
                }).OrderByDescending(o => o.EatingTime).GroupBy(o => o.TableNumber).ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
