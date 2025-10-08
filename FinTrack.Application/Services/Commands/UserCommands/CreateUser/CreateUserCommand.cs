using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinTrack.Application.Services.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand:IRequest<ResultViewModel<int>>
    {
        public CreateUserCommand(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public User ToEntity() => new(Name, Email, Password);
    }
}
