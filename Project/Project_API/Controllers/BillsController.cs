using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Models;
using System;
using System.Numerics;
using System.Xml.Linq;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        PRN231_Group10_SE1701Context context = new PRN231_Group10_SE1701Context();


        [HttpPost("getall")]
        public IActionResult GetAll()
        {
            try
            {
                //Output: int id, int customer id, string customer name,
                //string customer phone, float totalPrice,
                //datetime createdTime, int createdStaffId, string createdStaffName,
                //datetime paidTime, int updatedStaffId, string updatedStaffName, int status
                //Note: status có 2 trạng thái: 0 là chưa thanh toán và 1 là đã thanh toán

                var data = context.Bills.Select(c => new
                {
                    Id = c.Id,
                    CustomerId = c.BookedUserId,
                    CustomerName = c.BookedUser.Fullname,
                    CustomerPhone = c.BookedUser.Phone,
                    TotalPrice = c.TotalPrice,
                    CreatedTime = c.BookedTime,
                    CreatedStaffId = c.CreatedStaffId,
                    CreatedStaffName = c.CreatedStaff.Fullname,
                    PaidTime = c.PaidTime,
                    UpdatedStaffId = c.UpdatedStaffId,
                    UpdatedStaffName = c.UpdatedStaff.Fullname,
                    Status = c.Status,
                }).OrderByDescending(o => o.CreatedTime).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("create")]
        public IActionResult Create(string customerPhone, string user_id)
        {

            try
            {
                //Input: int customer phone
                //Output: int id
                //Note: status có 2 trạng thái: 0 là chưa thanh toán và 1 là đã thanh toán

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }

                User? customer = context.Users.FirstOrDefault(o => o.Phone == customerPhone);
                List<Food> foodList = new List<Food>();

                List<TableFood?> tableFood = context.TableFoods.Where(o => o.Booking.BookedUserId == customer.Id).ToList();
                if (tableFood.Count > 0)
                {
                    foreach (TableFood food in tableFood)
                    {
                        if (food.FoodId != null)
                        {
                            Food food1 = context.Foods.FirstOrDefault(x => x.Id == food.FoodId);
                            foodList.Add(food1);
                        }
                    }

                }

                double? total = 0;
                foreach (Food food in foodList)
                {
                    if (food.Price != null)
                    {
                        total += food.Price;
                    }
                }

                Bill bill = new Bill();
                bill.BookedUserId = customer.Id;
                bill.TotalPrice = total;
                bill.BookedTime = DateTime.Now;
                bill.CreatedStaffId = Int32.Parse(user_id.Trim());
                bill.Status = 0;
                context.Bills.Add(bill);
                context.SaveChanges();

                Bill billAfterAdd = context.Bills.FirstOrDefault(o => o.BookedUserId == bill.BookedUserId
                && o.BookedTime == bill.BookedTime);

                return Ok(billAfterAdd.Id);


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

                Bill? bill = context.Bills.FirstOrDefault(x => x.Id == id);
                if (bill == null)
                {
                    return NotFound("Not found bill");
                }

                var tableFoods = context.TableFoods
                    .Include(o => o.Food)
                    .Include(o => o.Table)
                    .Where(o => o.Booking.BookedUserId == bill.BookedUserId)
                    .ToList();

                var foodList = tableFoods
                    .Where(o => o.Food != null)
                    .GroupBy(o => o.Food)
                    .Select(o => new
                    {
                        Id = o.Key.Id,
                        Name = o.Key.Name,
                        Price = o.Key.Price,
                        Tables = o.Select(o => new
                        {
                            TableId = o.TableId,
                            TableNumber = o.Table?.Number
                        }).ToList()
                    })
                    .ToList();

                var data = new
                {
                    Id = bill.Id,
                    CustomerId = bill.BookedUserId,
                    CustomerName = bill.BookedUser?.Fullname,
                    CustomerPhone = bill.BookedUser?.Phone,
                    TotalPrice = bill.TotalPrice,
                    FoodList = foodList,
                    CreatedTime = bill.BookedTime,
                    CreatedStaffId = bill.CreatedStaffId,
                    CreatedStaffName = bill.CreatedStaff?.Fullname,
                    PaidTime = bill.PaidTime,
                    UpdatedStaffId = bill.UpdatedStaffId,
                    UpdatedStaffName = bill.UpdatedStaff?.Fullname,
                    Status = bill.Status,
                };

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("update")]
        public IActionResult Update(int id, int status, string user_id)
        {
            try
            {
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0)
                {
                    return BadRequest("You do not have access");
                }

                Bill? billExist = context.Bills.FirstOrDefault(x => x.Id == id);
                if (billExist == null)
                {
                    return BadRequest("Bill does not exists");
                }

                billExist.PaidTime = DateTime.Now;
                billExist.UpdatedStaffId = Int32.Parse(user_id);
                billExist.Status = (byte?)status;

                context.Entry<Bill>(billExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(billExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("search")]
        public IActionResult Search(string? customerPhone)
        {
            try
            {
                var data = context.Bills.Select(c => new
                {
                    Id = c.Id,
                    CustomerId = c.BookedUserId,
                    CustomerName = c.BookedUser.Fullname,
                    CustomerPhone = c.BookedUser.Phone,
                    TotalPrice = c.TotalPrice,
                    CreatedTime = c.BookedTime,
                    CreatedStaffId = c.CreatedStaffId,
                    CreatedStaffName = c.CreatedStaff.Fullname,
                    PaidTime = c.PaidTime,
                    UpdatedStaffId = c.UpdatedStaffId,
                    UpdatedStaffName = c.UpdatedStaff.Fullname,
                    Status = c.Status,
                }).OrderByDescending(o => o.CreatedTime).ToList();

                if (customerPhone != null)
                {
                    data = context.Bills
                        .Where(o => o.BookedUser.Phone.Equals(customerPhone.Trim()))
                        .Select(c => new
                        {
                            Id = c.Id,
                            CustomerId = c.BookedUserId,
                            CustomerName = c.BookedUser.Fullname,
                            CustomerPhone = c.BookedUser.Phone,
                            TotalPrice = c.TotalPrice,
                            CreatedTime = c.BookedTime,
                            CreatedStaffId = c.CreatedStaffId,
                            CreatedStaffName = c.CreatedStaff.Fullname,
                            PaidTime = c.PaidTime,
                            UpdatedStaffId = c.UpdatedStaffId,
                            UpdatedStaffName = c.UpdatedStaff.Fullname,
                            Status = c.Status,
                        }).OrderByDescending(o => o.CreatedTime).ToList();

                }

                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("filter")]
        public IActionResult Filter(int? status)
        {
            try
            {
                var data = context.Bills.Select(c => new
                {
                    Id = c.Id,
                    CustomerId = c.BookedUserId,
                    CustomerName = c.BookedUser.Fullname,
                    CustomerPhone = c.BookedUser.Phone,
                    TotalPrice = c.TotalPrice,
                    CreatedTime = c.BookedTime,
                    CreatedStaffId = c.CreatedStaffId,
                    CreatedStaffName = c.CreatedStaff.Fullname,
                    PaidTime = c.PaidTime,
                    UpdatedStaffId = c.UpdatedStaffId,
                    UpdatedStaffName = c.UpdatedStaff.Fullname,
                    Status = c.Status,
                }).OrderByDescending(o => o.CreatedTime).ToList();

                if (status != null)
                {
                    data = context.Bills
                        .Where(o => o.Status == status)
                        .Select(c => new
                        {
                            Id = c.Id,
                            CustomerId = c.BookedUserId,
                            CustomerName = c.BookedUser.Fullname,
                            CustomerPhone = c.BookedUser.Phone,
                            TotalPrice = c.TotalPrice,
                            CreatedTime = c.BookedTime,
                            CreatedStaffId = c.CreatedStaffId,
                            CreatedStaffName = c.CreatedStaff.Fullname,
                            PaidTime = c.PaidTime,
                            UpdatedStaffId = c.UpdatedStaffId,
                            UpdatedStaffName = c.UpdatedStaff.Fullname,
                            Status = c.Status,
                        }).OrderByDescending(o => o.CreatedTime).ToList();

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
