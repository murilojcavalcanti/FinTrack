using FinTrack.Application.Models;
using FinTrack.Application.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.UsersQueries.GetByIdUsersQuery
{
    public  class GetByIdUserQuery: IRequest<ResultViewModel<UserViewModel>>
    {
        public int UserId { get; set; }

        public GetByIdUserQuery(int userId)
        {
            UserId = userId;
        }
    }
}
