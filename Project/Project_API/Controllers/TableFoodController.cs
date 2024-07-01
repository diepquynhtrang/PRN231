using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Models;
using System.Numerics;
using System.Xml.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Project_API.Models.DTO;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableFoodController : ControllerBase
    {
        PRN231_Group10_SE1701Context context = new PRN231_Group10_SE1701Context();

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Output: int id, int table id,  int table number, string customer name, 
            //        string customer phone, string food name, int status
            //Note: status có 3 trạng thái: 0 là đã hủy, 1 là đã order và 2 là đã lên món


            try
            {
                var data = context.TableFoods.Select(c => new
                {
                    Id = c.Id,
                    TableId = c.TableId,
                    TableNumber = c.Table.Number,
                    BookingId = c.BookingId,
                    CustomerId = c.Booking.BookedUserId,
                    CustomerName = c.Booking.BookedUser.Fullname,
                    CustomerPhone = c.Booking.BookedUser.Phone,
                    FoodId = c.FoodId,
                    FoodName = c.Food.Name,
                    EatingTime = c.Booking.EatingTime,
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
        public IActionResult Create(TableFoodDTO tableFoodDTO, string user_id)
        {
            //Input: int table id, List<int> food id, int booking id

            try
            {
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }

                if (tableFoodDTO.FoodIdList != null)
                {
                    foreach (int i in tableFoodDTO.FoodIdList)
                    {
                        TableFood tableFood = new TableFood();
                        tableFood.TableId = tableFoodDTO.TableId;
                        tableFood.FoodId = i;
                        tableFood.BookingId = tableFoodDTO.BookingId;
                        tableFood.Status = 0;

                        context.TableFoods.Add(tableFood);
                        context.SaveChanges();
                    }
                }
                

                return Ok("Create successfully");


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
                //Output: int id, int table id,  int table number, int customer id,
                //string customer name, string customer phone, id food, string food name, int status

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }

                TableFood? tableFood = context.TableFoods.FirstOrDefault(x => x.Id == id);
                if (tableFood == null)
                {
                    return NotFound("Not found table food");
                }

                var data = context.TableFoods
                    .Where(o => o.Id == id).Select(c => new
                    {
                        Id = c.Id,
                        TableId = c.TableId,
                        TableNumber = c.Table.Number,
                        BookingId = c.BookingId,
                        CustomerId = c.Booking.BookedUserId,
                        CustomerPhone = c.Booking.BookedUser.Phone,
                        CustomerName = c.Booking.BookedUser.Fullname,
                        FoodId = c.FoodId,
                        FoodName = c.Food.Name,
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
        public IActionResult Update(TableFoodDTO tableFoodDTO, string user_id)
        {
            try
            {
                //Input: int table food id, int table id, int food id, int booking id

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }


                TableFood? tableFoodExist = context.TableFoods.FirstOrDefault(x => x.Id == tableFoodDTO.Id);
                if (tableFoodExist == null)
                {
                    return BadRequest("Table food does not exists");
                }

                tableFoodExist.TableId = tableFoodDTO.TableId;
                tableFoodExist.FoodId = tableFoodDTO.FoodIdUpdate;
                tableFoodExist.BookingId = tableFoodDTO.BookingId;
                context.Entry<TableFood>(tableFoodExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return Ok(tableFoodExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("changestatus")]
        public IActionResult ChangeStatus(TableFoodDTO tableFoodDTO, string user_id)
        {
            try
            {
                //Input: int id, int status

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }


                TableFood? tableFoodExist = context.TableFoods.FirstOrDefault(x => x.Id == tableFoodDTO.Id);
                if (tableFoodExist == null)
                {
                    return BadRequest("Table food does not exists");
                }

                tableFoodExist.Status = tableFoodDTO.Status;
                context.Entry<TableFood>(tableFoodExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return Ok(tableFoodExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("search")]
        public IActionResult Search(int? tableId, string? customerPhone, int? foodId)
        {
            //Input: int table id, string customer phone, int food id

            //Output: int id, int table id,  int table number, string customer name, 
            //        string customer phone, string food name, int status
            //Note: status có 3 trạng thái: 0 là đã hủy, 1 là đã order và 2 là đã lên món

            try
            {
                var data = context.TableFoods.Select(c => new
                {
                    Id = c.Id,
                    TableId = c.TableId,
                    TableNumber = c.Table.Number,
                    BookingId = c.BookingId,
                    CustomerId = c.Booking.BookedUserId,
                    CustomerName = c.Booking.BookedUser.Fullname,
                    CustomerPhone = c.Booking.BookedUser.Phone,
                    FoodId = c.FoodId,
                    FoodName = c.Food.Name,
                    EatingTime = c.Booking.EatingTime,
                    Status = c.Status
                });

                if (tableId != null)
                {
                    data = data.Where(o => o.TableId == tableId);
                }
                if (!string.IsNullOrEmpty(customerPhone))
                {
                    data = data.Where(o => o.CustomerPhone == customerPhone);
                }
                if (foodId != null)
                {
                    data = data.Where(o => o.FoodId == foodId);
                }

                var orderedData = data.OrderByDescending(o => o.EatingTime);
                var result = orderedData.ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filter")]
        public IActionResult Filter(int? status)
        {
            //Input: int status

            try
            {
                var data = context.TableFoods.Select(c => new
                {
                    Id = c.Id,
                    TableId = c.TableId,
                    TableNumber = c.Table.Number,
                    BookingId = c.BookingId,
                    CustomerId = c.Booking.BookedUserId,
                    CustomerName = c.Booking.BookedUser.Fullname,
                    CustomerPhone = c.Booking.BookedUser.Phone,
                    FoodId = c.FoodId,
                    FoodName = c.Food.Name,
                    EatingTime = c.Booking.EatingTime,
                    Status = c.Status
                });

                if (status != null)
                {
                    data = data.Where(o => o.Status == status);

                    var orderedData = data.OrderByDescending(o => o.EatingTime);
                    var result = orderedData.ToList();

                    return Ok(result);
                }
                else
                {
                    return Ok(data);
                }
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
