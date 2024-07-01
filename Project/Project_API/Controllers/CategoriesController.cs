using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Models;
using Project_API.Models.DTO;
using System;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        PRN231_Group10_SE1701Context context = new PRN231_Group10_SE1701Context();

        
        [HttpPost("getall")]
        public IActionResult GetAll()
        {
            try
            {
                //Output: int id, string name, string description, int status
                //Note: status có 2 trạng thái với 0 là deactive và 1 là active


                var data = context.Categories.Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
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
        public IActionResult Create(CategoryDTO categoryDTO, string user_id)
        {

            try
            {
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }
                Category category = new Category();
                category.Name = categoryDTO.Name;
                category.Description = categoryDTO.Description;
                category.CreatedTime = DateTime.Now;
                category.CreatedUserId = Int32.Parse(user_id);
                category.Status = 1;
                context.Categories.Add(category);
                context.SaveChanges();

                return Ok(category);


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
                //Input: int id
                //Output: int id, string name, string description, int status

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }

                Category? category = context.Categories.FirstOrDefault(x => x.Id == id);
                if (category == null)
                {
                    return NotFound("Not found category");
                }

                var data = context.Categories.Where(o => o.Id == id).Select(o => new
                {
                    Id = o.Id,
                    Name = o.Name,
                    Description = o.Description,
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
        public IActionResult Update(CategoryDTO category, string user_id)
        {
            try
            {
                //Input: int id, string name, string description
                //Note: id không được thay đổi

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }


                Category? cateExist = context.Categories.FirstOrDefault(x => x.Id == category.Id);
                if (cateExist == null)
                {
                    return BadRequest("Category does not exists");
                }

                cateExist.Name = category.Name;
                cateExist.Description = category.Description;
                cateExist.UpdatedTime = DateTime.Now;
                cateExist.UpdatedUserId = Int32.Parse(user_id);

                context.Entry<Category>(cateExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(cateExist);

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


                Category? cateExist = context.Categories.FirstOrDefault(x => x.Id == id);
                if (cateExist == null)
                {
                    return BadRequest("Category does not exists");
                }

                if (cateExist.Status == 1)
                {
                    cateExist.Status = 0;
                } else
                {
                    cateExist.Status = 1;
                }

                context.Entry<Category>(cateExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(cateExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("search")]
        public IActionResult Search(string name)
        {
            try
            {
                var data = context.Categories.Where(c => c.Name.Trim().ToLower().Contains(name.Trim().ToLower()))
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        CreatedTime = c.CreatedTime,
                        CreatedUser = c.CreatedUser.Fullname,
                        UpdatedTime = c.UpdatedTime,
                        UpdatedUser = c.UpdatedUser.Fullname,
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
        public IActionResult Filter(int status)
        {
            try
            {
                var data = context.Categories.Where(c => c.Status == status)
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        CreatedTime = c.CreatedTime,
                        CreatedUser = c.CreatedUser.Fullname,
                        UpdatedTime = c.UpdatedTime,
                        UpdatedUser = c.UpdatedUser.Fullname,
                        Status = c.Status
                    }).ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
