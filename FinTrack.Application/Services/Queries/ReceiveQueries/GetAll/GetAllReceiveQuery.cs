using FinTrack.Application.Models.ReceiveModel;
using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.ReceiveQueries.GetAll
{
    public class GetAllReceiveQuery: IRequest<ResultViewModel<List<ReceiveViewModel>>>
    {
    }
}
