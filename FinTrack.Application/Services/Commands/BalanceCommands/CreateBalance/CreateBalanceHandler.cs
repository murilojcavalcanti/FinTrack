using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.BalanceCommands.CreateBalance
{
    public class CreateBalanceHandler : IRequestHandler<CreateBalanceCommand, ResultViewModel<int>>
    {
        private readonly IUoF _uof;

        public CreateBalanceHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBalanceCommand request, CancellationToken cancellationToken)
        {
            Balance balance = request.ToEntity();
            await _uof.BalanceRepository.Insert(balance);
            _uof.Commit();
            return ResultViewModel<int>.Success(balance.Id);
        }
    }
}
