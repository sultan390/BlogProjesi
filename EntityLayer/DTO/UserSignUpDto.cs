using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class UserSignUpDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsAcceptTheContract { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
