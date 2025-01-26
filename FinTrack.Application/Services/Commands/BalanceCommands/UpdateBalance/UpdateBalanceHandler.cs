using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.BalanceCommands.UpdateBalance
{
    public class UpdateBalanceHandler : IRequestHandler<UpdateBalanceCommand, ResultViewModel>
    {
        private readonly IUoF _uof;

        public UpdateBalanceHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel> Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
        {
            Balance balance = await _uof.BalanceRepository.Get(b=>b.Id==request.BalanceId);
            if (balance == null) return ResultViewModel.Error("Balance NotFound!");
            _uof.BalanceRepository.Update(balance);
            _uof.Commit();
            return ResultViewModel.Success();
        }
    }
}
