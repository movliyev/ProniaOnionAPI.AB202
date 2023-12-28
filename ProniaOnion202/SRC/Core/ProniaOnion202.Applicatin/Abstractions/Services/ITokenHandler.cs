using ProniaOnion202.Applicatin.DTOs.Tokens;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Abstractions.Services
{
    public interface ITokenHandler
    {
        TokenResponseDto CreateToken(AppUser user,int minutes);
    }
}
