﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.DTOs.Users
{
    public record LoginDto(string UserNameOrEmail,string  Password);
   
}
