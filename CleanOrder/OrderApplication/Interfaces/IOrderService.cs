using OrderApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Interfaces
{
    public interface IOrderService
    {
        OrdersDTO AddOrder(OrdersDTO order);
        List<OrdersDTO> GetOrdersByUserId(Guid userId);
    }
}
