using FinTrack.Application.Models;
using FinTrack.Application.Models.CostModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.CostQueries.GetAll
{
    public class GetAllCostQuery : IRequest<ResultViewModel<List<CostViewModel>>>
    {
        public GetAllCostQuery()
        {
        }
    }
}
