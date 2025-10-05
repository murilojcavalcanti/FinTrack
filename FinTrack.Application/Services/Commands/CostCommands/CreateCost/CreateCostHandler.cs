using FinTrack.Application.Models;
using FinTrack.Core.Auth;
using FinTrack.Core.Entities;
using FinTrack.Core.Repositories;
using FinTrack.Core.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CostCommands.CreateCost
{
    public class CreateCostHandler : IRequestHandler<CreateCostCommand, ResultViewModel<int>>
    {
        private readonly IUoF _UoF;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateCostHandler(IUoF uoF, IAuthService authService, IHttpContextAccessor contextAccessor)
        {
            _UoF = uoF;
            _authService = authService;
            _contextAccessor = contextAccessor;
        }

        public async Task<ResultViewModel<int>> Handle(CreateCostCommand request, CancellationToken cancellationToken)
        {
            var claimsUser = _authService.GetUserClaimsLoged(_contextAccessor.HttpContext);
            int.TryParse(claimsUser.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value,out int userId);
            Cost cost = request.ToEntity();
            Balance balance = await _UoF.BalanceRepository.Get(b => b.Id == request.IdBalance && b.User.Id == userId );
            balance.AddCosts(cost.PriceCost);
            await _UoF.CostRepository.Insert(cost);
            await _UoF.BalanceRepository.Update(balance);
            _UoF.Commit();
            return ResultViewModel<int>.Success(cost.Id);
        }
    }
}
