using AutoMapper;
using ProductApplication.DTO;
using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductsDTO, Products>();
            CreateMap<ProductsDTO, Products>().ReverseMap();
        }
    }
}
