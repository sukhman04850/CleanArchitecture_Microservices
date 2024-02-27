using CartDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApplication.DTO
{
    public class CartDTO
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
