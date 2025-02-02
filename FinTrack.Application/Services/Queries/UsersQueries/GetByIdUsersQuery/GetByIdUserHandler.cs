using FinTrack.Application.Models;
using FinTrack.Application.Models.UserModel;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.UsersQueries.GetByIdUsersQuery
{
    public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUoF _uof;

        public GetByIdUserHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<UserViewModel>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            User user = await _uof.UserRepository.Get(u=>u.Id==request.UserId);
            UserViewModel result = UserViewModel.FromEntity(user);
            return ResultViewModel<UserViewModel>.Success(result);
        }
    }
}
