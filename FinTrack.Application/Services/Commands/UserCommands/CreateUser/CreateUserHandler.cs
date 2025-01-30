using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.UserCommands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
    {
        private readonly IUoF _uof;

        public CreateUserHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = request.ToEntity();
            bool userIsNull =await  _uof.UserRepository.Get(u => u.Email == user.Email) is null;
            if (!userIsNull) return ResultViewModel<int>.Error("registered user!");
            await _uof.UserRepository.Insert(user);
            _uof.Commit();
            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
