 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project_API.Models;
using System.Numerics;
using System.Xml.Linq;
using System;
using Project_API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        PRN231_Group10_SE1701Context context = new PRN231_Group10_SE1701Context();

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Output: int id, string customer name, string customer phone,
            //datetime eating time, total people, total table, int status
            //Note: status có 2 trạng thái với 0 là đã hủy và 1 là đã đặt.

            try
            {
                var data = context.Bookings.Include(o => o.TableBookings).Select(c => new
                {
                    Id = c.Id,
                    CustomerName = c.BookedUser.Fullname,
                    CustomerPhone = c.BookedUser.Phone,
                    EatingTime = c.EatingTime,
                    TotalPeople = c.TotalNumberOfPeople,
                    TotalTable = c.TotalNumberOfTable,
                    TableList = c.TableBookings.Select(o => new
                    {
                        TableId = o.Id,
                        TableNumber = o.Table.Number,
                    }),
                    Status = c.Status
                }).OrderByDescending(o => o.EatingTime).ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("create")]
        public IActionResult Create(BookingDTO bookingDTO, string user_id)
        {
            //Input: string customer phone, string name, datetime eating time,
            //int total people, int total table

            try
            {
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }

                User? customer = context.Users.FirstOrDefault(x => x.Phone.Equals(bookingDTO.CustomerPhone) 
                && x.Fullname.ToLower().Equals(bookingDTO.CustomerName));
                if (customer == null) 
                { 
                    User user = new User();
                    user.Fullname = bookingDTO.CustomerName;
                    user.Phone = bookingDTO.CustomerPhone;
                    user.Role = 2;
                    user.CreatedTime = DateTime.Now;
                    user.Status = 1;
                    context.Users.Add(user);
                    context.SaveChanges();

                    customer = context.Users.FirstOrDefault(x => x.Phone.Equals(bookingDTO.CustomerPhone)
                    && x.Fullname.ToLower().Equals(bookingDTO.CustomerName));
                }

                Booking booking = new Booking();
                booking.BookedUserId = customer.Id;
                booking.EatingTime = bookingDTO.EatingTime;
                booking.TotalNumberOfPeople = bookingDTO.TotalNumberOfPeople;
                booking.TotalNumberOfTable = bookingDTO.TotalNumberOfTable;
                booking.CreatedTime = DateTime.Now;
                booking.CreatedUserId = Int32.Parse(user_id.Trim());
                booking.Status = 1;
                context.Bookings.Add(booking);
                context.SaveChanges();

                Booking? bookingAfterCreate = context.Bookings.FirstOrDefault(x => x.BookedUserId == customer.Id
                && x.EatingTime == bookingDTO.EatingTime);
                
                if (bookingDTO.TableList != null)
                {
                    foreach (int i in bookingDTO.TableList)
                    {
                        TableBooking tableBooking = new TableBooking();
                        tableBooking.TableId = i;
                        tableBooking.BookingId = bookingAfterCreate?.Id;
                        tableBooking.Status = 1;
                        context.TableBookings.Add(tableBooking);
                        context.SaveChanges();
                    }
                }
                

                return Ok(booking);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("detail")]
        public IActionResult Detail(int id, string user_id)
        {
            try
            {
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }

                Booking? booking = context.Bookings.FirstOrDefault(x => x.Id == id);
                if (booking == null)
                {
                    return NotFound("Not found booking");
                }

                var data = context.Bookings
                    .Where(o => o.Id == id)
                    .Include(o => o.TableBookings).Select(c => new
                {
                    Id = c.Id,
                    CustomerName = c.BookedUser.Fullname,
                    CustomerPhone = c.BookedUser.Phone,
                    EatingTime = c.EatingTime,
                    TotalPeople = c.TotalNumberOfPeople,
                    TotalTable = c.TotalNumberOfTable,
                    TableList = c.TableBookings.Select(o => new
                    {
                        TableId = o.Id,
                        TableNumber = o.Table.Number,
                    }),
                    Status = c.Status
                }).ToList();
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("update")]
        public IActionResult Update(BookingDTO bookingDTO, string user_id)
        {
            try
            {
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }


                Booking? bookingExist = context.Bookings.FirstOrDefault(x => x.Id == bookingDTO.Id);
                if (bookingExist == null)
                {
                    return BadRequest("Booking does not exists");
                }

                User? customer = context.Users.FirstOrDefault(o => o.Phone.Equals(bookingDTO.CustomerPhone.Trim())
                    && o.Fullname.Equals(bookingDTO.CustomerName.Trim().ToLower()));
                if (bookingExist.BookedUserId != customer.Id)
                {
                    return BadRequest("Can not change the booked customer");
                }

                bookingExist.EatingTime = bookingDTO.EatingTime;
                bookingExist.TotalNumberOfPeople = bookingDTO.TotalNumberOfPeople;
                bookingExist.TotalNumberOfTable = bookingDTO.TotalNumberOfTable;
                bookingExist.UpdatedTime = DateTime.Now;
                bookingExist.UpdatedUserId = Int32.Parse(user_id.Trim());



                context.Entry<Booking>(bookingExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();


                if (bookingDTO.TableList != null)
                {
                    List<TableBooking> existTableBooking = context.TableBookings.Where(o => o.BookingId == bookingDTO.Id).ToList();
                    foreach (TableBooking booking in existTableBooking)
                    {
                        context.Remove(booking);
                        context.SaveChanges();
                    }
                    foreach (int i in bookingDTO.TableList)
                    {
                        TableBooking tableBooking = new TableBooking();
                        tableBooking.TableId = i;
                        tableBooking.BookingId = bookingExist.Id;
                        tableBooking.Status = 1;
                        context.TableBookings.Add(tableBooking);
                        context.SaveChanges();
                    }
                }
                return Ok(bookingExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("cancel")]
        public IActionResult Cancel(int id, string user_id)
        {
            try
            {
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }

                Booking? bookingExist = context.Bookings.FirstOrDefault(c => c.Id == id);
                if (bookingExist != null)
                { 
                    List<TableBooking?> tableBookingList = context.TableBookings
                        .Where(o => o.BookingId == bookingExist.Id)
                        .ToList();
                    if (tableBookingList != null)
                    {
                        foreach (TableBooking i in tableBookingList)
                        {
                            if (i.Status == 2)
                            {
                                return BadRequest("The customer has arrived. You can not cancel booking");
                            }
                        }
                        foreach (TableBooking i in tableBookingList)
                        {
                            context.Remove(i);
                            context.SaveChanges();

                        }
                    }
                    
                    bookingExist.UpdatedTime = DateTime.Now;
                    bookingExist.UpdatedUserId = Int32.Parse(user_id);
                    bookingExist.Status = 0;

                    context.Entry<Booking>(bookingExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return Ok("Disable booking successfully");
                }
                else
                {
                    return BadRequest("Booking doesn't exist");
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("searchbydate")]
        public IActionResult SearchByDate(DateTime? startEatingTime, DateTime? endEatingTime)
        {
            //Output: int id, string customer name, string customer phone,
            //datetime eating time, total people, total table, int status
            //Note: status có 2 trạng thái với 0 là đã hủy và 1 là đã đặt.

            try
            {
                var data = context.Bookings.Include(o => o.TableBookings).Select(c => new
                {
                    Id = c.Id,
                    CustomerName = c.BookedUser.Fullname,
                    CustomerPhone = c.BookedUser.Phone,
                    EatingTime = c.EatingTime,
                    TotalPeople = c.TotalNumberOfPeople,
                    TotalTable = c.TotalNumberOfTable,
                    TableList = c.TableBookings.Select(o => new
                    {
                        TableId = o.Id,
                        TableNumber = o.Table.Number,
                    }),
                    Status = c.Status
                }).OrderByDescending(o => o.EatingTime).ToList();

                if (startEatingTime != null && endEatingTime != null)
                {
                    data = context.Bookings.Include(o => o.TableBookings)
                        .Where(o => o.EatingTime >= startEatingTime
                        && o.EatingTime <= endEatingTime)
                        .Select(c => new
                    {
                        Id = c.Id,
                        CustomerName = c.BookedUser.Fullname,
                        CustomerPhone = c.BookedUser.Phone,
                        EatingTime = c.EatingTime,
                        TotalPeople = c.TotalNumberOfPeople,
                        TotalTable = c.TotalNumberOfTable,
                        TableList = c.TableBookings.Select(o => new
                        {
                            TableId = o.Id,
                            TableNumber = o.Table.Number,
                        }),
                        Status = c.Status
                    }).OrderByDescending(o => o.EatingTime).ToList();
                }

                else if (startEatingTime != null && endEatingTime == null)
                {
                    data = context.Bookings.Include(o => o.TableBookings)
                        .Where(o => o.EatingTime >= startEatingTime)
                        .Select(c => new
                        {
                            Id = c.Id,
                            CustomerName = c.BookedUser.Fullname,
                            CustomerPhone = c.BookedUser.Phone,
                            EatingTime = c.EatingTime,
                            TotalPeople = c.TotalNumberOfPeople,
                            TotalTable = c.TotalNumberOfTable,
                            TableList = c.TableBookings.Select(o => new
                            {
                                TableId = o.Id,
                                TableNumber = o.Table.Number,
                            }),
                            Status = c.Status
                        }).OrderByDescending(o => o.EatingTime).ToList();
                }

                else if (startEatingTime == null && endEatingTime != null)
                {
                    data = context.Bookings.Include(o => o.TableBookings)
                        .Where(o => o.EatingTime <= endEatingTime)
                        .Select(c => new
                        {
                            Id = c.Id,
                            CustomerName = c.BookedUser.Fullname,
                            CustomerPhone = c.BookedUser.Phone,
                            EatingTime = c.EatingTime,
                            TotalPeople = c.TotalNumberOfPeople,
                            TotalTable = c.TotalNumberOfTable,
                            TableList = c.TableBookings.Select(o => new
                            {
                                TableId = o.Id,
                                TableNumber = o.Table.Number,
                            }),
                            Status = c.Status
                        }).OrderByDescending(o => o.EatingTime).ToList();
                }
                else
                {

                }


                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("searchbycustomerphone")]
        public IActionResult SearchByCustomerPhone(string? customerPhone)
        {
            //Output: int id, string customer name, string customer phone,
            //datetime eating time, total people, total table, int status
            //Note: status có 2 trạng thái với 0 là đã hủy và 1 là đã đặt.

            try
            {
                var data = context.Bookings.Include(o => o.TableBookings).Select(c => new
                {
                    Id = c.Id,
                    CustomerName = c.BookedUser.Fullname,
                    CustomerPhone = c.BookedUser.Phone,
                    EatingTime = c.EatingTime,
                    TotalPeople = c.TotalNumberOfPeople,
                    TotalTable = c.TotalNumberOfTable,
                    TableList = c.TableBookings.Select(o => new
                    {
                        TableId = o.Id,
                        TableNumber = o.Table.Number,
                    }),
                    Status = c.Status
                }).OrderByDescending(o => o.EatingTime).ToList();

                if (customerPhone != null)
                {
                    data = context.Bookings.Include(o => o.TableBookings)
                        .Where(o => o.BookedUser.Phone.Trim().Equals(customerPhone.Trim())
                        && o.BookedUser.Role == 2)
                        .Select(c => new
                        {
                            Id = c.Id,
                            CustomerName = c.BookedUser.Fullname,
                            CustomerPhone = c.BookedUser.Phone,
                            EatingTime = c.EatingTime,
                            TotalPeople = c.TotalNumberOfPeople,
                            TotalTable = c.TotalNumberOfTable,
                            TableList = c.TableBookings.Select(o => new
                            {
                                TableId = o.Id,
                                TableNumber = o.Table.Number,
                            }),
                            Status = c.Status
                        }).OrderByDescending(o => o.EatingTime).ToList();
                }
                else
                {

                }


                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("filterbystatus")]
        public IActionResult FilterByStatus(int? status)
        {
            //Output: int id, string customer name, string customer phone,
            //datetime eating time, total people, total table, int status
            //Note: status có 2 trạng thái với 0 là đã hủy và 1 là đã đặt.

            try
            {
                var data = context.Bookings.Include(o => o.TableBookings).Select(c => new
                {
                    Id = c.Id,
                    CustomerName = c.BookedUser.Fullname,
                    CustomerPhone = c.BookedUser.Phone,
                    EatingTime = c.EatingTime,
                    TotalPeople = c.TotalNumberOfPeople,
                    TotalTable = c.TotalNumberOfTable,
                    TableList = c.TableBookings.Select(o => new
                    {
                        TableId = o.Id,
                        TableNumber = o.Table.Number,
                    }),
                    Status = c.Status
                }).OrderByDescending(o => o.EatingTime).ToList();

                if (status != null)
                {
                    data = context.Bookings.Include(o => o.TableBookings)
                        .Where(o => o.Status == status)
                        .Select(c => new
                        {
                            Id = c.Id,
                            CustomerName = c.BookedUser.Fullname,
                            CustomerPhone = c.BookedUser.Phone,
                            EatingTime = c.EatingTime,
                            TotalPeople = c.TotalNumberOfPeople,
                            TotalTable = c.TotalNumberOfTable,
                            TableList = c.TableBookings.Select(o => new
                            {
                                TableId = o.Id,
                                TableNumber = o.Table.Number,
                            }),
                            Status = c.Status
                        }).OrderByDescending(o => o.EatingTime).ToList();
                }
                else
                {

                }


                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


    }
}
