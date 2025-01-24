using FinTrack.Application.Models;
using FinTrack.Application.Models.CostModel;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.CostQueries.GetById
{
    public class GetByIdCostHandler : IRequestHandler<GetByIdCostQuery, ResultViewModel<CostViewModel>>
    {
        private readonly IUoF _Uof;

        public GetByIdCostHandler(IUoF uof)
        {
            _Uof = uof;
        }

        public async Task<ResultViewModel<CostViewModel>> Handle(GetByIdCostQuery request, CancellationToken cancellationToken)
        {
            Cost cost = await _Uof.CostRepository.Get(c => c.Id == request.CostId);
            if (cost is null) return ResultViewModel<CostViewModel>.Error("Cost Not Found!");
            CostViewModel viewModel = CostViewModel.FromEntity(cost);
            return ResultViewModel<CostViewModel>.Success(viewModel);
        }
    }
}
