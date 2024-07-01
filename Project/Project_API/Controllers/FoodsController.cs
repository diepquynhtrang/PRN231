using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Models;
using Project_API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        PRN231_Group10_SE1701Context context = new PRN231_Group10_SE1701Context();

        [HttpPost("getall")]
        public IActionResult GetAll()
        {
            try
            {
                //Output: int id, string name, string description, float price,
                //int category id, string category name, int status
                //Note: status có 2 trạng thái với 0 là deactive và 1 là active



                var data = context.Foods.Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    Status = c.Status
                }).ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("create")]
        public IActionResult Create(FoodDTO foodDTO, string user_id)
        {

            try
            {
                //Input: string name, string description, int category id, float price

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }

                Food food = new Food();
                food.Name = foodDTO.Name;
                food.Description = foodDTO.Description;
                food.Price = foodDTO.Price;
                food.CategoryId = foodDTO.CategoryId;
                food.CreatedTime = DateTime.Now;
                food.CreatedUserId = Int32.Parse(user_id.Trim());
                food.Status = 1;
                context.Foods.Add(food);
                context.SaveChanges();

                return Ok(food);


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

                //Output: int id, string name, string description, float price,int category id,
                //string category name, int status
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }

                Food? food = context.Foods.FirstOrDefault(x => x.Id == id);
                if (food == null)
                {
                    return NotFound("Not found food");
                }

                var data = context.Foods.Where(o => o.Id == id).Select(o => new
                {
                    Id = o.Id,
                    Name = o.Name,
                    Description = o.Description,
                    Price = o.Price,
                    CategoryId = o.CategoryId,
                    CategoryName = o.Category.Name,
                    Status = o.Status
                });
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("update")]
        public IActionResult Update(FoodDTO food, string user_id)
        {
            try
            {
                //Input: int id, string name, string description, int category id, float price

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }


                Food? foodExist = context.Foods.FirstOrDefault(x => x.Id == food.Id);
                if (foodExist == null)
                {
                    return BadRequest("Food does not exists");
                }

                foodExist.Name = food.Name;
                foodExist.Description = food.Description;
                foodExist.Price = food.Price;
                foodExist.CategoryId = food.CategoryId;
                foodExist.UpdatedTime = DateTime.Now;
                foodExist.UpdatedUserId = Int32.Parse(user_id);

                context.Entry<Food>(foodExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(foodExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("changestatus")]
        public IActionResult ChangeStatus(int id, string user_id)
        {
            try
            {
                //Input: int id

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }


                Food? foodExist = context.Foods.FirstOrDefault(x => x.Id == id);
                if (foodExist == null)
                {
                    return BadRequest("Food does not exists");
                }

                if (foodExist.Status == 1)
                {
                    foodExist.Status = 0;
                } else
                {
                    foodExist.Status = 1;
                }

                foodExist.UpdatedTime = DateTime.Now;
                foodExist.UpdatedUserId = Int32.Parse(user_id);

                context.Entry<Food>(foodExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(foodExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpPost("search")]
        public IActionResult Search(string? name)
        {
            try
            {
                //Input: string name
                //Output: Như view list

                var data = context.Foods.Where(o =>
                o.Name.Trim().ToLower().Contains(name.Trim().ToLower())).Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    Status = c.Status
                }).ToList();

                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("filter")]
        public IActionResult Filter(int? categoryId, int? status)
        {
            try
            {
                //Input: int category id, int status
                //Output: như view list

                var data = context.Foods.Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    Status = c.Status
                });

                if (categoryId != null)
                {
                    data = data.Where(o => o.CategoryId == categoryId);
                }

                if (status != null)
                {
                    data = data.Where(o => o.Status == status);
                }

                return Ok(data.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
