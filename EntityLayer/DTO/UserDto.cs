﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class UserDto
    {
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public IFormFile ProfileImageFile { get; set; } 

    }
}
