using OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.DTO
{
    public class OrdersDTO
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public List<Products> Products { get; set; } = new List<Products>();
    }
}
