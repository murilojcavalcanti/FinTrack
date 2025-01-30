using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password) : base()
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public void Update(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
