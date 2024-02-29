using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Entity;

namespace UserApplication.Interfaces
{
    public interface ILoginRepository
    {
        Users LoginUser(Login login);
        Task<Users> GetUserById(Guid id);
    }
}
