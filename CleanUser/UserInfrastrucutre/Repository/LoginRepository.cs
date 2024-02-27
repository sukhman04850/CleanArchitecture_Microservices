using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.Interfaces;
using UserDomain.Entity;

namespace UserInfrastrucutre.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly List<Users> _users;
        public LoginRepository()
        {
            _users = new List<Users>
        {
            new Users
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Email = "admin@example.com",
                Pwd = "adminpassword",
                Role = "admin"
            },
            new Users
            {
                Id =  Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Email = "user@example.com",
                Pwd = "userpassword",
                Role = "user"
            }
        };

        }

        public Task<Users> GetUserById(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new Exception();
            }
            return Task.FromResult(user);
        }

        public Users LoginUser(Login login)
        {
            var user = _users.FirstOrDefault(x => x.Email == login.Email);
            if (user == null)
            {
                throw new Exception();
            }


            return user;
        }
    }
}
