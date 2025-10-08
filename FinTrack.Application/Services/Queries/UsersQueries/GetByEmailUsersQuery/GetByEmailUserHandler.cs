using FinTrack.Application.Models;
using FinTrack.Application.Models.UserModel;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;

namespace FinTrack.Application.Services.Queries.UsersQueries.GetByIdUsersQuery
{
    public class GetByEmailUserHandler : IRequestHandler<GetByEmailUserQuery, ResultViewModel<UserLoginModel>>
    {
        private readonly IUoF _uof;

        public GetByEmailUserHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<UserLoginModel>> Handle(GetByEmailUserQuery request, CancellationToken cancellationToken)
        {
            User user = await _uof.UserRepository.Get(u => u.Email == request.UserEmail);
            UserLoginModel result = UserLoginModel.FromEntity(user);
            return ResultViewModel<UserLoginModel>.Success(result);
        }
    }
}
