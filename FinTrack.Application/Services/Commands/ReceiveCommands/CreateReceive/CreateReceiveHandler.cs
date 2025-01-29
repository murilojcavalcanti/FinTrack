using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.ReceiveCommands.CreateReceive
{
    public class CreateReceiveHandler : IRequestHandler<CreateReceiveCommand, ResultViewModel<int>>
    {
        private readonly IUoF _uoF;

        public CreateReceiveHandler(IUoF uoF)
        {
            _uoF = uoF;
        }

        public async Task<ResultViewModel<int>> Handle(CreateReceiveCommand request, CancellationToken cancellationToken)
        {
            Receive Receive = request.ToEntity();
            Balance balance = await _uoF.BalanceRepository.Get(b=>b.Id==request.IdBalance);
            balance.AddReceives(Receive.ValueReceive);
            balance.CalculateAmountBalance();
            await _uoF.ReceiveRepository.Insert(Receive);
            await _uoF.BalanceRepository.Update(balance);
            _uoF.Commit();
            return ResultViewModel<int>.Success(Receive.Id);
        }
    }
}
