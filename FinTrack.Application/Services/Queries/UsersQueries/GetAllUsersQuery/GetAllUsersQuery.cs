using FinTrack.Application.Models;
using FinTrack.Application.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.UsersQueries.GetAllUsersQuery
{
    public  class GetAllUsersQuery:IRequest<ResultViewModel<List<UserViewModel>>>
    {
    }
}
