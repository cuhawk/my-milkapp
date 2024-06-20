﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public int Price { get; set; }
        public string productDescription { get; set; }
        public string Image { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category? Category { get; set; }

        public int originId { get; set; }
        [ForeignKey("originId")]
        public Origin? Origin { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
