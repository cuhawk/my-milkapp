﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Models.DTO
{
    public class CreateUserModel
    {
        public string FullName { get; set; }
        /*public string UserName { get; set; }*/
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
