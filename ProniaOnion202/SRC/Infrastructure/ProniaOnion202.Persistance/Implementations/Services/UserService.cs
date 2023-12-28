using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Tokens;
using ProniaOnion202.Applicatin.DTOs.Users;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _uManager;
        private readonly IMapper _map;
        private readonly ITokenHandler _handler;

        public UserService(UserManager<AppUser> uManager,IMapper map,ITokenHandler handler)
        {
            _uManager = uManager;
            _map = map;
           _handler = handler;
            
        }

        public async Task<TokenResponseDto> Login(LoginDto rdto)
        {
            AppUser user = await _uManager.FindByNameAsync(rdto.UserNameOrEmail);
            if (user == null)
            {
                user = await _uManager.FindByEmailAsync(rdto.UserNameOrEmail);
                if (user == null) throw new Exception("UserName,Email or Password is incorrect");

            }
            if (!await _uManager.CheckPasswordAsync(user, rdto.Password)) throw new Exception("UserName,Email or Password is incorrect");
            return _handler.CreateToken(user, 60);
           
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
       

    }
}
