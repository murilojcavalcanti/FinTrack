using FinTrack.Application.Models;
using FinTrack.Application.Models.BalanceModel;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.BalanceQueries.GetByIdBalance
{
    public class GetByIdBalanceHandler : IRequestHandler<GetByIdBalanceQuery, ResultViewModel<BalanceDetailsViewModel>>
    {
        private readonly IUoF _uof;

        public GetByIdBalanceHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<BalanceDetailsViewModel>> Handle(GetByIdBalanceQuery request, CancellationToken cancellationToken)
        {
            Balance balance = await _uof.BalanceRepository.Get(b => b.Id == request.BalanceId); 
            BalanceDetailsViewModel balanceView = BalanceDetailsViewModel.FromEntity(balance);
            return ResultViewModel<BalanceDetailsViewModel>.Success(balanceView);
        }
    }
}
