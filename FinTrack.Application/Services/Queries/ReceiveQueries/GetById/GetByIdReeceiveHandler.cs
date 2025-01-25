using FinTrack.Application.Models;
using FinTrack.Application.Models.ReceiveModel;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.ReceiveQueries.GetById
{
    public class GetByIdReceiveHandler:IRequestHandler<GetByIdReceiveQuery, ResultViewModel<ReceiveViewModel>>
    {
        private readonly IUoF _uof;
        public GetByIdReceiveHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel<ReceiveViewModel>> Handle(GetByIdReceiveQuery request, CancellationToken cancellationToken)
        {
            Receive receive = await _uof.ReceiveRepository.Get(r=>r.Id == request.ReceiveId);
            if (receive == null) return ResultViewModel<ReceiveViewModel>.Error("Receive Not Found!");
            ReceiveViewModel viewModel = ReceiveViewModel.FromEntity(receive);
            return ResultViewModel<ReceiveViewModel>.Success(viewModel);
            throw new NotImplementedException();
        }
    }
}
