using AutoMapper;
using OrderApplication.DTO;
using OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrdersDTO, Orders>();
            CreateMap<OrdersDTO, Orders>().ReverseMap();
            CreateMap<ProductsDTO, Products>();
            CreateMap<ProductsDTO, Products>().ReverseMap();
        }
    }
}
