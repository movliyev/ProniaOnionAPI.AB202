using ProniaOnion202.Applicatin.DTOs.Tokens;
using ProniaOnion202.Applicatin.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Abstractions.Services
{
    public interface IUserService
    {
        Task Registr(RegistrDto rdto);
        Task<TokenResponseDto> Login(LoginDto rdto);
    }
}
