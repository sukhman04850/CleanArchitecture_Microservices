using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDomain.Entities
{
    public class Orders
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public List<Products> Products { get; set; } = new List<Products>();
    }
}
