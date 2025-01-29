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
    public class GetAllBalanceHandler : IRequestHandler<GetAllBalanceQuery,ResultViewModel<List<BalanceViewModel>>>
    {
        private readonly IUoF _uof;

        public GetAllBalanceHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<List<BalanceViewModel>>> Handle(GetAllBalanceQuery request, CancellationToken cancellationToken)
        {
            List<Balance> lstBalance = _uof.BalanceRepository.GetAll().Result.ToList();
            List<BalanceViewModel> lstBalanceViewModel = lstBalance.Select(b => BalanceViewModel.FromEntity(b)).ToList();
            return ResultViewModel<List<BalanceViewModel>>.Success(lstBalanceViewModel);
        }
    }
}
