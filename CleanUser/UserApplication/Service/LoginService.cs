using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.DTO;
using UserApplication.Interfaces;
using UserDomain.Entity;

namespace UserApplication.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        public LoginService(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<UsersDTO> GetUserById(Guid id)
        {
            var userId = _loginRepository.GetUserById(id);
            var userDTO = _mapper.Map<UsersDTO>(userId);
            return userDTO;

        }

        public UsersDTO LoginUser(LoginDTO login)
        {
            var loginUser = _mapper.Map<Login>(login);
            var user = _loginRepository.LoginUser(loginUser);
            var userLogin = _mapper.Map<UsersDTO>(user);
            return userLogin;
        }

    }
}
