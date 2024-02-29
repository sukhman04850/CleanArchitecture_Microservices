﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.DTO
{
    public class ProductsDTO
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
