using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.Entities
{
    public class User : BaseEntity
    {
        public User(DateTime createdAt, string name, string email, string password) : base(createdAt)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; 
    }
}
