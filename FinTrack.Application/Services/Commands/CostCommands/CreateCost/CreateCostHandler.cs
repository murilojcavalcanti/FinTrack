using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.Repositories;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CostCommands.CreateCost
{
    public class CreateCostHandler : IRequestHandler<CreateCostCommand, ResultViewModel<int>>
    {
        private readonly IUoF _UoF;

        public CreateCostHandler(IUoF uoF)
        {
            _UoF = uoF;
        }

        public async Task<ResultViewModel<int>> Handle(CreateCostCommand request, CancellationToken cancellationToken)
        {
            Cost cost = request.ToEntity();
            Balance balance = await _UoF.BalanceRepository.Get(b => b.Id == request.IdBalance);
            balance.AddCosts(cost.PriceCost);
            await _UoF.CostRepository.Insert(cost);
            await _UoF.BalanceRepository.Update(balance);
            _UoF.Commit();
            return ResultViewModel<int>.Success(cost.Id);
        }
    }
}
