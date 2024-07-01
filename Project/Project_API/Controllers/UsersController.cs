using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Models;
using Project_API.Models.DTO;
using System.Data;
using System;
using System.Collections.Generic;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        PRN231_Group10_SE1701Context context = new PRN231_Group10_SE1701Context();

        [HttpPost("login")]
        public IActionResult Login(string gmail, string password)
        {
            //Input: string gmail, string password
            try
            {

                User? user = context.Users.FirstOrDefault(x => x.Gmail == gmail.Trim().ToLower());
                if (user == null)
                {
                    return NotFound("Account does not exist");
                }

                if (user.Status == 0)
                {
                    return BadRequest("Account disabled. Please contact manager.");
                }

                user = context.Users.FirstOrDefault(x => x.Gmail == gmail.Trim().ToLower() && x.Password == password.Trim());
                if (user == null)
                {
                    return NotFound("Incorrect password");
                }

                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("create")]
        public IActionResult Create(UserDTO userDTO, string user_id)
        {

            try
            {
                //Input: string fullname, string phone, string gmail, string password,
                //string address, int role

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 0 || u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }
                User user = new User();
                user.Fullname = userDTO.Fullname;
                user.Phone = userDTO.Phone;
                user.Gmail = userDTO.Gmail;
                user.Password = userDTO.Password;
                user.Address = userDTO.Address;
                user.Role = userDTO.Role;
                user.CreatedTime = DateTime.Now;
                user.Status = 1;
                context.Users.Add(user);
                context.SaveChanges();

                return Ok(user);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("getall")]
        public IActionResult GetAll(string user_id)
        {
            try
            {
                //Output: int id, string fullname, string phone, string gmail, string password,
                //string address, int role, int status
                //Note: Role có 3 role với 0 là staff, 1 là manager và 2 là customer.
                //Status có 2 trạng thái 0 là deactive và 1 là active.

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }


                var data = context.Users.Select(c => new
                {
                    Id = c.Id,
                    Fullname = c.Fullname,
                    Gmail = c.Gmail,
                    Phone = c.Phone,
                    Password = c.Password,
                    Address = c.Address,
                    Role = c.Role,
                    Status = c.Status
                }).ToList();
                return Ok(data);
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
                //Output: int id, string fullname, string phone, string gmail,
                //string password, string address, int role, int status
                //Note: Role có 3 role với 0 là staff, 1 là manager và 2 là customer.
                //Status có 2 trạng thái 0 là deactive và 1 là active.

                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }

                User? user = context.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return NotFound("Not found user");
                }
                var data = context.Users.Where(o => o.Id == id).Select(c => new
                {
                    Id = c.Id,
                    Fullname = c.Fullname,
                    Gmail = c.Gmail,
                    Phone = c.Phone,
                    Password = c.Password,
                    Address = c.Address,
                    Role = c.Role,
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
        public IActionResult Update(UserDTO userDTO, string user_id)
        {
            try
            {

                //Input: int id, string fullname, string phone, string gmail, string password,
                //string address, int role
                User? u = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id.Trim()));
                if (u != null && u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }


                User? userExist = context.Users.FirstOrDefault(x => x.Id == userDTO.Id);
                if (userExist == null)
                {
                    return BadRequest("User does not exists");
                }

                userExist.Fullname = userDTO.Fullname;
                userExist.Phone = userDTO.Phone;
                userExist.Gmail = userDTO.Gmail;
                userExist.Address = userDTO.Address;
                userExist.Role = userDTO.Role;
                userExist.UpdatedTime = DateTime.Now;

                context.Entry<User>(userExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(userExist);

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
                if (u != null && u.Role != 1)
                {
                    return BadRequest("You do not have access");
                }


                User? userExist = context.Users.FirstOrDefault(x => x.Id == id);
                if (userExist == null)
                {
                    return BadRequest("User does not exists");
                }

                if (userExist.Status == 1)
                {
                    userExist.Status = 0;
                } else
                {
                    userExist.Status = 1;
                }

                userExist.UpdatedTime = DateTime.Now;

                context.Entry<User>(userExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(userExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("search")]
        public IActionResult Search(string? gmail, string? phone)
        {
            try
            {

                //Input: string gmail, string phone
                var data = context.Users.AsQueryable();

                if (!string.IsNullOrEmpty(gmail))
                {
                    data = data.Where(o => o.Gmail.Trim().ToLower() == gmail.Trim().ToLower());
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    data = data.Where(o => o.Phone.Trim() == phone.Trim());
                }


                var result = data.Select(c => new
                {
                    Id = c.Id,
                    Fullname = c.Fullname,
                    Gmail = c.Gmail,
                    Phone = c.Phone,
                    Password = c.Password,
                    Address = c.Address,
                    Role = c.Role,
                    Status = c.Status
                }).ToList();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("filter")]
        public IActionResult Filter(int? role)
        {
            try
            {

                //Input: int role
                var data = context.Users.AsQueryable();

                if (role != null)
                {
                    data = data.Where(o => o.Role == role);
                }



                var result = data.Select(c => new
                {
                    Id = c.Id,
                    Fullname = c.Fullname,
                    Gmail = c.Gmail,
                    Phone = c.Phone,
                    Password = c.Password,
                    Address = c.Address,
                    Role = c.Role,
                    Status = c.Status
                }).ToList();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("profile")]
        public IActionResult Profile(string user_id)
        {
            try
            {
                //Output: string fullname, string phone, string gmail, string address

                int id = Int32.Parse(user_id.Trim());
                User? user = context.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return NotFound("Not found information");
                }

                var data = context.Users.Where(o => o.Id == id).Select(o => new 
                {
                    Id = o.Id,
                    Fullname = o.Fullname,
                    Phone = o.Phone,
                    Gmail = o.Gmail,
                    Address = o.Address,
                });
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("updateprofile")]
        public IActionResult UpdateProfile(UserDTO user)
        {
            try
            {
                //Input: string fullname, string phone, string gmail, string address

                User? userExist = context.Users.FirstOrDefault(x => x.Id == user.Id);
                if (userExist == null)
                {
                    return BadRequest("User does not exists");
                }

                userExist.Fullname = user.Fullname;
                userExist.Phone = user.Phone;
                userExist.Gmail = user.Gmail;
                userExist.Address = user.Address;
                userExist.UpdatedTime = DateTime.Now;

                context.Entry<User>(userExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok(userExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("updatepassword")]
        public IActionResult UpdatePassword(string oldPassword, string newPassword, string reNewPassword, string user_id)
        {
            try
            {
                //Input: string old password, string new password, string re-new password

                User? userExist = context.Users.FirstOrDefault(x => x.Id == Int32.Parse(user_id));
                if (userExist == null)
                {
                    return BadRequest("User does not exists");
                }

                if (userExist.Password == oldPassword.Trim())
                {
                    if (newPassword.Trim().Equals(reNewPassword.Trim()))
                    {
                        userExist.Password = newPassword;
                        userExist.UpdatedTime = DateTime.Now;
                        context.Entry<User>(userExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    } else
                    {
                        return BadRequest("New passwords do not match");
                    }
                } else
                {
                    return BadRequest("Wrong password");
                }

                
                return Ok(userExist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
