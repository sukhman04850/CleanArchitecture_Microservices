using AutoMapper;
using CartApplication.DTO;
using CartDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApplication.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderItemsDTO, OrderItems>();
            CreateMap<OrderItemsDTO, OrderItems>().ReverseMap();
            CreateMap<CartDTO, Cart>();
            CreateMap<CartDTO, Cart>().ReverseMap();
            CreateMap<CartItemDTO, CartItem>();
            CreateMap<CartItemDTO, CartItem>().ReverseMap();
            CreateMap<ProductsDTO, Products>();
            CreateMap<Products, ProductsDTO>().ReverseMap();
        }
    }
}
