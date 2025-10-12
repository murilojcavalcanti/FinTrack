using FinTrack.Application.Models;
using FinTrack.Core.Enums;
using MediatR;

namespace FinTrack.Application.Services.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand:IRequest<ResultViewModel>
    {
        public UpdateUserCommand(string name, string email, string password, int userId, EnumRole role)
        {
            Name = name;
            Email = email;
            Password = password;
            this.userId = userId;
            Role = role;
        }

        public int userId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EnumRole Role {  get; set; }
        public string Password { get; set; }
    }
}
