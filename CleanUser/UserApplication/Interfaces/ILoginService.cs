using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.DTO;

namespace UserApplication.Interfaces
{
    public interface ILoginService
    {
        UsersDTO LoginUser(LoginDTO login);
        Task<UsersDTO> GetUserById(Guid id);
    }
}
