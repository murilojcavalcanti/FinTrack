using FinTrack.Application.Models;
using FinTrack.Core.Repositories;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CreateCost
{
    public class CreateCostHandler:IRequestHandler<CreateCostCommand,ResultViewModel>
    {
        private readonly IUoF _UoF;

        public CreateCostHandler(IUoF uoF)
        {
            _UoF = uoF;
        }

        public async Task<ResultViewModel> Handle(CreateCostCommand request, CancellationToken cancellationToken)
        {
            var cost = request.ToEntity();
            await   _UoF.CostRepository.Insert(cost);
            _UoF.Commit();
            return ResultViewModel<int>.Success(cost.Id);
        }
    }
}
