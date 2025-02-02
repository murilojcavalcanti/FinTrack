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

namespace FinTrack.Application.Services.Queries.UsersQueries.GetAllUsersQuery
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
    {
        private readonly IUoF _uof;

        public GetAllUsersHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _uof.UserRepository.GetAll();
            List<UserViewModel> result = users.Select(u=>UserViewModel.FromEntity(u)).ToList();
            return ResultViewModel<List<UserViewModel>>.Success(result);
        }
    }
}
