using FinTrack.Application.Models;
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
            var Cost = _Uof.CostRepository.Get(c => c.Id == request.CostId);
            if (Cost.Result is null) return ResultViewModel.Error("Cost Not Found!");
            Cost.Result.setAsDeleted();
            _Uof.CostRepository.Update(Cost.Result);
            return ResultViewModel.Success();
        }
    }
}
