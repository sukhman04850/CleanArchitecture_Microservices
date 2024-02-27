using OrderApplication.Interfaces;
using OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private static List<Orders> _ordersList = new List<Orders>();

        public Orders AddOrder(Orders order)
        {
            var newOrder = new Orders
            {
                OrderId = Guid.NewGuid(),
                UserId = order.UserId,
                Products = order.Products,
            };
            _ordersList.Add(newOrder);
            return newOrder;
        }
        public List<Orders> GetOrdersByUserId(Guid userId)
        {
            return _ordersList.Where(order => order.UserId == userId).ToList();
        }
    }
}
