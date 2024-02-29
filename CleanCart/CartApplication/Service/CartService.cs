using AutoMapper;
using CartApplication.DTO;
using CartApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApplication.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<CartDTO> AddToCart(Guid userId, Guid productId)
        {
            var cart = _repository.AddToCart(userId, productId);
            var newCart = _mapper.Map<List<CartDTO>>(cart);
            return newCart;
        }

        public bool DeleteCartByUserId(Guid userId)
        {
            var deletedCart = _repository.DeleteCartByUserId(userId);
            return deletedCart;
        }

        public CartDTO GetCartItems(Guid userId)
        {
            var cartItems = _repository.GetCartItems(userId);
            var getCart = _mapper.Map<CartDTO>(cartItems);
            return getCart;
        }

        public List<ProductsDTO> ViewCartDetails(Guid userId)
        {
            var productDetails = _repository.ViewCartDetails(userId);
            var cartDetails = _mapper.Map<List<ProductsDTO>>(productDetails);
            return cartDetails;
        }

        public List<OrderItemsDTO> ViewOrderItems(Guid userId)
        {
            var orderList = _repository.ViewOrderItems(userId);
            var orderItems = _mapper.Map<List<OrderItemsDTO>>(orderList);
            return orderItems;
        }

    }
}
