﻿using Microsoft.EntityFrameworkCore;

namespace GYMVCProject.Models
{
    public class Products 
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }

        public bool IsPublish { get; set; }

        public int Expire { get; set; }
    }
}
