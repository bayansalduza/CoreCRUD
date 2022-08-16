using Data.Context;
using Data.Dto;
using Data.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presantation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        MasterContext masterContext = new MasterContext();
        public UserController()
        {

        }

        [HttpPost("AddUser")]
        public string AddUser(SaveUserDto saveUserDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext)) 
            {
                User user = new User()
                {
                    Id = saveUserDto.Id,
                    Name = saveUserDto.Name,
                    Password = saveUserDto.Password,
                    Username = saveUserDto.Username
                };
                unitOfWork.GetRepository<User>().Add(user);
                unitOfWork.SaveChanges();
                return "Kayıt başarılı";
            }
        }
        [HttpGet("GetUser")]
        public User GetUser (int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                return unitOfWork.GetRepository<User>().Get(Id);
            }
        }

        [HttpPut("SetUser")]
        public string SetUser(SaveUserDto saveUserDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                User user = unitOfWork.GetRepository<User>().Get(saveUserDto.Id);
                user.Name = saveUserDto.Name ;



                user.Password = saveUserDto.Password ;
                user.Username = saveUserDto.Username ;
                unitOfWork.GetRepository<User>().Update(user);
                unitOfWork.SaveChanges();
                return "Güncelleme başarılı";
            }
        }

        [HttpDelete("DeleteUser")]
        public string DeleteUser(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                User user = unitOfWork.GetRepository<User>().Get(id);
                unitOfWork.GetRepository<User>().Delete(user);
                unitOfWork.SaveChanges();
                return "Kayıt silindi";
            }
        }
    }
}
