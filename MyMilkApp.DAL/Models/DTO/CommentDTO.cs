﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Models.DTO
{
    public class CommentDTO
    {
        public int commentId { get; set; }
        public string commentDetail { get; set; }
        public int Rating { get; set; }
        public DateOnly Date { get; set; }
        public int productId { get; set; }
        public string Id { get; set; }
    }
}
