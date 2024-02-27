using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain.Entity
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Pwd { get; set; }
        public required string Role { get; set; }
    }
}
