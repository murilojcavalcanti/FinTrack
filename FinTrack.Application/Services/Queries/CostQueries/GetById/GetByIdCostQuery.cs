using FinTrack.Application.Models;
using FinTrack.Application.Models.CostModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.CostQueries.GetById
{
    public class GetByIdCostQuery : IRequest<ResultViewModel<CostViewModel>>
    {
        public int CostId { get; set; }

        public GetByIdCostQuery(int costId)
        {
            CostId = costId;
        }
    }
}
