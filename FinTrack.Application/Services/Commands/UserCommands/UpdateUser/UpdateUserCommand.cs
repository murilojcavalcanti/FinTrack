using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand:IRequest<ResultViewModel>
    {
        public UpdateUserCommand(string name, string email, string password, int userId)
        {
            Name = name;
            Email = email;
            Password = password;
            this.userId = userId;
        }

        public int userId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
