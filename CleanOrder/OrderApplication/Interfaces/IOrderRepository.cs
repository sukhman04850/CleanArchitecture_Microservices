using OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Interfaces
{
    public interface IOrderRepository
    {
        Orders AddOrder(Orders order);
        List<Orders> GetOrdersByUserId(Guid userId);
    }
}
