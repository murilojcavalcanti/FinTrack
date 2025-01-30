using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CostCommands.UpdateCost
{
    public class UpdateCostHandler : IRequestHandler<UpdateCostCommand, ResultViewModel>
    {
        private readonly IUoF _Uof;

        public UpdateCostHandler(IUoF uof)
        {
            _Uof = uof;
        }
        public async Task<ResultViewModel> Handle(UpdateCostCommand request, CancellationToken cancellationToken)
        {
            Cost cost = await _Uof.CostRepository.Get(c => c.Id == request.IdCost);
            if (cost is null) return ResultViewModel.Error("Cost Not Found!");
            
            Balance balance = await _Uof.BalanceRepository.Get(b => b.Id == cost.IdBalance);
            
            balance.RemoveCosts(cost.PriceCost);
            cost.Update(request.PriceCost, request.DescriptionCost,request.IdBalance);
            balance.AddCosts(request.PriceCost);
            
            await _Uof.CostRepository.Update(cost);
            await _Uof.BalanceRepository.Update(balance);
            
            _Uof.Commit();
            
            return ResultViewModel.Success();
        }
    }
}
