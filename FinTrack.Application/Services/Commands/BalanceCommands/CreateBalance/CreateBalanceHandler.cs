using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateBalanceHandler(IUoF uof, IHttpContextAccessor contextAccessor)
        {
            _uof = uof;
            _contextAccessor = contextAccessor;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBalanceCommand request, CancellationToken cancellationToken)
        {

            var claimsUser = _authService.GetUserClaimsLoged(_contextAccessor.HttpContext);
            Balance balance = request.ToEntity();
            balance.SetUser(claimsUser);
            await _uof.BalanceRepository.Insert(balance);
            _uof.Commit();
            return ResultViewModel<int>.Success(balance.Id);
        }
    }
}
