using FinTrack.Application.Models;
using FinTrack.Core.Auth;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;

namespace FinTrack.Application.Services.Commands.UserCommands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
    {
        private readonly IUoF _uof;
        private readonly IAuthService _authService;

        public CreateUserHandler(IUoF uof, IAuthService authService)
        {
            _uof = uof;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = _authService.ComputeHash(request.Password);
            User user = request.ToEntity();
            bool userIsNull =await  _uof.UserRepository.Get(u => u.Email == user.Email) is null;
            if (!userIsNull) return ResultViewModel<int>.Error("registered user!");
            await _uof.UserRepository.Insert(user);
            _uof.Commit();
            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
