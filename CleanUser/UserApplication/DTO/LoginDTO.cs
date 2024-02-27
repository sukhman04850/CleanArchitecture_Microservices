using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApplication.DTO
{
    public class LoginDTO
    {
        public required string Email { get; set; }
        public required string Pwd { get; set; }
    }
}
