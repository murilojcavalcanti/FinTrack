using FinTrack.Core.Entities;

namespace FinTrack.Application.Models.UserModel
{
    public class UserLoginModel
    {
        public UserLoginModel(string password, string email)
        {
            Password = password;
            Email = email;
        }

        public string Password { get; set; }
        public string Email { get; set; }
        public static UserLoginModel FromEntity(User user)=> new (user.Password,user.Email);
    }
}
