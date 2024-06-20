﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Models.DTO
{
    public class ResponseDTO
    {
        public bool IsSucceed { get; set; } = false;
        public string Message { get; set; } = "";
        public object Data { get; set; }
    }
}
