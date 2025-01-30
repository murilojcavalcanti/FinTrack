using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.UserCommands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUoF _uoF;

        public UpdateUserHandler(IUoF uoF)
        {
            _uoF = uoF;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _uoF.UserRepository.Get(u=>u.Id==request.userId);
            if (user == null) return ResultViewModel.Error("User Not Found");
            user.Update(request.Name,request.Email,request.Password);
            await _uoF.UserRepository.Update(user);
            _uoF.Commit();
            return ResultViewModel.Success();
        }
    }
}
