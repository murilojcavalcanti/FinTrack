using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand:IRequest<ResultViewModel>
    {
        public int UserId { get; set; }
    }
}
