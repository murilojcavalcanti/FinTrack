using FinTrack.Application.Models;
using FinTrack.Application.Models.CostModel;
using FinTrack.Core.UnitOfWork;
using MediatR;

namespace FinTrack.Application.Services.Queries.CostQueries.GetAll
{
    public class GetAllCostHandler : IRequestHandler<GetAllCostQuery, ResultViewModel<List<CostViewModel>>>
    {
        private readonly IUoF _uoF;
        public GetAllCostHandler(IUoF uoF)
        {
            _uoF = uoF;
        }

        public async Task<ResultViewModel<List<CostViewModel>>> Handle(GetAllCostQuery request, CancellationToken cancellationToken)
        {
            var costs = await _uoF.CostRepository.GetAll();
            List<CostViewModel> result = costs.Select(cost => CostViewModel.FromEntity(cost)).ToList();
            return ResultViewModel<List<CostViewModel>>.Success(result);
        }
    }
}
