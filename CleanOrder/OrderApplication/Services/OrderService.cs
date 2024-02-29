using AutoMapper;
using OrderApplication.DTO;
using OrderApplication.Interfaces;
using OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper??throw new ArgumentNullException(nameof(mapper)); ;
            _orderRepository = orderRepository??throw new ArgumentNullException(nameof(orderRepository)); ;
            
        }
        public OrdersDTO AddOrder(OrdersDTO order)
        {
            var newOrder = _mapper.Map<Orders>(order);
            var response = _orderRepository.AddOrder(newOrder);
            var addedOrder = _mapper.Map<OrdersDTO>(response);
            return addedOrder;
        }

        public List<OrdersDTO> GetOrdersByUserId(Guid userId)
        {
            var getOrder = _orderRepository.GetOrdersByUserId(userId);
            var orderById = _mapper.Map<List<OrdersDTO>>(getOrder);
            return orderById;
        }

    }
}
