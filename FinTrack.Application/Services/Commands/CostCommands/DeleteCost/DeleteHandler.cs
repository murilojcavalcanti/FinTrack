using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CostCommands.DeleteCost
{
    public class DeleteHandler : IRequestHandler<DeleteCostCommand, ResultViewModel>
    {
        private readonly IUoF _Uof;

        public DeleteHandler(IUoF uof)
        {
            _Uof = uof;
        }


        public async Task<ResultViewModel> Handle(DeleteCostCommand request, CancellationToken cancellationToken)
        {
            Cost Cost = await _Uof.CostRepository.Get(c => c.Id == request.CostId);
            if (Cost is null) return ResultViewModel.Error("Cost Not Found!");
            _Uof.CostRepository.Delete(Cost);
            _Uof.Commit();
            return ResultViewModel.Success();
        }
    }
}
