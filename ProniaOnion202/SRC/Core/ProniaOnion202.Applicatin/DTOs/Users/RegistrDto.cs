﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.DTOs.Users
{
    public record RegistrDto(string UserName,string Email,string Password,string ConfirmPassword,string Name,string Surname);
    
}
