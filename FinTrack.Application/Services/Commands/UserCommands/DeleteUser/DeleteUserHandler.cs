using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.UserCommands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        public readonly IUoF _uof;

        public DeleteUserHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _uof.UserRepository.Get(u=>u.Id == request.UserId);
            
            if (user == null) return ResultViewModel.Error("User Not Found");
            
            await _uof.UserRepository.Delete(user);
            _uof.Commit(); 
            return ResultViewModel.Success();
        }
    }
}
