using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Users;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _uManager;
        private readonly IMapper _map;

        public UserService(UserManager<AppUser> uManager,IMapper map)
        {
            _uManager = uManager;
            _map = map;
        }

        

        public async Task Registr(RegistrDto rdto)
        {

            if (await _uManager.Users.AnyAsync(u => u.UserName == rdto.UserName || u.Email == rdto.Email)) throw new Exception("Same");
            AppUser user = _map.Map<AppUser>(rdto);
            var result =await _uManager.CreateAsync(user,rdto.Password);
            if(!result.Succeeded)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    builder.AppendLine(error.Description);
                }
                throw new Exception(builder.ToString());
            }
        }
        public async Task Login(LoginDto rdto)
        {
            AppUser user = await _uManager.FindByNameAsync(rdto.UserNameOrEmail);
            if(user == null)
            {
                user = await _uManager.FindByEmailAsync(rdto.UserNameOrEmail);
                if (user == null) throw new Exception("UserNmae,Email or Password is incorrect");

            }
            if (!await _uManager.CheckPasswordAsync(user,rdto.Password)) throw new Exception("UserNmae,Email or Password is incorrect");

           
        }
    }
}
