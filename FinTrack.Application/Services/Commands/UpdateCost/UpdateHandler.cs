using FinTrack.Application.Models;
using FinTrack.Application.Services.Commands.DeleteCost;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.UpdateCost
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, ResultViewModel>
    {
        private readonly IUoF _Uof;

        public UpdateHandler(IUoF uof)
        {
            _Uof = uof;
        }
        public async Task<ResultViewModel> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var Cost = _Uof.CostRepository.Get(c => c.Id == request.IdCost);
            if (Cost.Result is null) return ResultViewModel.Error("Cost Not Found!");
            Cost.Result.Update(request.PriceCost,request.DescriptionCost);
            _Uof.CostRepository.Update(Cost.Result);
            return ResultViewModel.Success();
        }
    }
}
