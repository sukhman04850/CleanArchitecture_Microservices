using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.DTO;
using UserDomain.Entity;

namespace UserApplication.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LoginDTO, Login>();
            CreateMap<LoginDTO, Login>().ReverseMap();
            CreateMap<UsersDTO, Users>();
            CreateMap<UsersDTO, Users>().ReverseMap();
        }
    }
}
