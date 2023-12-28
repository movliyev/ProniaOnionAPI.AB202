using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.DTOs.Tokens
{
    public record TokenResponseDto(string Token,string UserName,DateTime ExpiredAt);
    
}
