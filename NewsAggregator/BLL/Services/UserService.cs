using AutoMapper;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class UserService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
           //     cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<UserDTO, User>();
               
            });
            return new Mapper(config);
        }
        public static bool Create(UserDTO obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.Role = "User";
            obj.Status = true;
            var data = GetMapper().Map<User>(obj);
            return DataAccess.UserData().Create(data);
        }

    }
}
