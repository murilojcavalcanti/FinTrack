using FinTrack.Application.Models;
using FinTrack.Application.Models.UserModel;
using MediatR;

namespace FinTrack.Application.Services.Queries.UsersQueries.GetByIdUsersQuery
{
    public  class GetByEmailUserQuery: IRequest<ResultViewModel<UserLoginModel>>
    {
        public string UserEmail { get; set; }

        public GetByEmailUserQuery(string userEmail)
        {
            UserEmail = userEmail;
        }
    }
}
