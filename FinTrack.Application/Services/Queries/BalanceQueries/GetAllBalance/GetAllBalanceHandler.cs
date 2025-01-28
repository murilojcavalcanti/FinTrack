using FinTrack.Application.Models;
using FinTrack.Application.Models.BalanceModel;
using FinTrack.Application.Models.CostModel;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.BalanceQueries.GetAllBalance
{
    public class GetAllBalanceHandler : IRequestHandler<GetAllBalanceQuery,ResultViewModel<List<BalanceDetailsViewModel>>>
    {
        private readonly IUoF _uof;

        public GetAllBalanceHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<List<BalanceDetailsViewModel>>> Handle(GetAllBalanceQuery request, CancellationToken cancellationToken)
        {
            List<Balance> lstBalance = _uof.BalanceRepository.GetAll().Result.ToList();
            List<BalanceDetailsViewModel> lstBalanceViewModel = lstBalance.Select(b => BalanceDetailsViewModel.FromEntity(b)).ToList();
            return ResultViewModel<List<BalanceDetailsViewModel>>.Success(lstBalanceViewModel);
        }
    }
}
