using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Models;
using Project_API.Models.DTO;
using System;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        PRN231_Group10_SE1701Context context = new PRN231_Group10_SE1701Context();


        [HttpPost("getall")]
        public IActionResult GetAll()
        {
            try
            {
                //Output: int id, int table id, int table number, string description, int status
                //Note: status có 2 trạng thái với 0 là deactive và 1 là active

                var data = context.Tables.Select(c => new
                {
                    Id = c.Id,
                    Number = c.Number,
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
        public IActionResult Create(TableDTO tableDTO, string user_id)
        {

            try
            {
                //Input: int table number, string description
                Table table = new Table();
                table.Number = tableDTO.Number;
                table.Description = tableDTO.Description;
                table.CreatedTime = DateTime.Now;
                table.CreatedUserId = Int32.Parse(user_id);
                table.Status = 1;
                context.Tables.Add(table);
                context.SaveChanges();

                return Ok(table);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("detail")]
        public IActionResult Detail(int id)
        {
            try
            {
                //Input: int id
                //Output: int id, int table id, int table number, string description, int status
                Table? table = context.Tables.FirstOrDefault(x => x.Id == id);
                if (table == null)
                {
                    return NotFound("Not found table");
                }
                var data = context.Tables.Where(o => o.Id == id).Select(c => new
                {
                    Id = c.Id,
                    Number = c.Number,
                    Description = c.Description,
                    Status = c.Status
                });
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("update")]
        public IActionResult Update(TableDTO tableDTO, string user_id)
        {
            try
            {
                //Input: int table id, int table number, string description
                Table? tableExist = context.Tables.FirstOrDefault(x => x.Id == tableDTO.Id);
                if (tableExist == null)
                {
                    return BadRequest("Table does not exists");
                }


                tableExist.Number = tableDTO.Number;
                tableExist.Description = tableDTO.Description;
                tableExist.UpdatedTime = DateTime.Now;
                tableExist.UpdatedUserId = Int32.Parse(user_id);

                context.Entry<Table>(tableExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(tableExist);

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
                //Input: int table id
                Table? tableExist = context.Tables.FirstOrDefault(x => x.Id == id);
                if (tableExist == null)
                {
                    return BadRequest("Table does not exists");
                }

                if (tableExist.Status == 1)
                {
                    tableExist.Status = 0;
                } else
                {
                    tableExist.Status = 1;
                }

                tableExist.UpdatedTime = DateTime.Now;
                tableExist.UpdatedUserId = Int32.Parse(user_id);

                context.Entry<Table>(tableExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(tableExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
