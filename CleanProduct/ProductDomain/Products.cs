using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDomain
{
    public class Products
    {
        [Key]
        public Guid ProductId { get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }

        public string? Details { get; set; }
    }
}
