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

namespace FinTrack.Application.Services.Queries.ReceiveQueries.GetAll
{
    public class GetAllReceiveHandler : IRequestHandler<GetAllReceiveQuery, ResultViewModel<List<ReceiveViewModel>>>
    {
        private readonly IUoF _Uof;

        public GetAllReceiveHandler(IUoF uof)
        {
            _Uof = uof;
        }

        public async Task<ResultViewModel<List<ReceiveViewModel>>> Handle(GetAllReceiveQuery request, CancellationToken cancellationToken)
        {
            List<Receive> lstReceive =  _Uof.ReceiveRepository.GetAll().Result.ToList();
            List<ReceiveViewModel> lstReceiveViewModel = lstReceive.Select(r => ReceiveViewModel.FromEntity(r)).ToList();
            return ResultViewModel<List<ReceiveViewModel>>.Success(lstReceiveViewModel);
        }
    }
}
