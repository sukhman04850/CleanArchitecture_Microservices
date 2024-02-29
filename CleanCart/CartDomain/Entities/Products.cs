using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartDomain.Entities
{
    public class Products
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public decimal Price { get; set; }
    }
}
