using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.ReceiveCommands.DeleteReceive
{
    public class DeleteReceiveHandler : IRequestHandler<DeleteReceiveCommand, ResultViewModel>
    {
        private readonly IUoF _uof;

        public DeleteReceiveHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel> Handle(DeleteReceiveCommand request, CancellationToken cancellationToken)
        {
            Receive receive = await _uof.ReceiveRepository.Get(r=>r.Id==request.Receiveid);
            if (receive == null) return ResultViewModel.Error("Receive Not Found!");
            _uof.ReceiveRepository.Delete(receive);
            _uof.Commit();
            return ResultViewModel.Success();

        }
    }
}
