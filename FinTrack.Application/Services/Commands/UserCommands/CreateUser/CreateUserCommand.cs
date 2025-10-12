using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinTrack.Application.Services.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand:IRequest<ResultViewModel<int>>
    {
        public CreateUserCommand(string name, string email, string password, EnumRole role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }

        public User ToEntity() => new(Name, Email, Password,Role);
    }
}
