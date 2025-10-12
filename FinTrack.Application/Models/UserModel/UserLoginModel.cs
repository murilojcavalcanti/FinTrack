using FinTrack.Core.Entities;
using FinTrack.Core.Enums;

namespace FinTrack.Application.Models.UserModel
{
    public class UserLoginModel
    {
        public UserLoginModel(string password, string email, EnumRole role)
        {
            Password = password;
            Email = email;
            Role = role;
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public EnumRole Role { get; set; }
        public static UserLoginModel FromEntity(User user) => new(user.Password, user.Email, user.Role);
    }
}
