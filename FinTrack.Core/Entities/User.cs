using FinTrack.Core.Enums;

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

        public User(string name, string email, string password, EnumRole role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public EnumRole Role { get; private set; }
        public List<Balance> Balances { get; private set; }
        public void Update(string name, string email,EnumRole enumRole, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = enumRole;
        }
    }
}
