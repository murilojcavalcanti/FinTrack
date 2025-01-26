using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;

namespace FinTrack.Application.Services.Commands.ReceiveCommands.UpdateReceive
{
    public class UpdateReceiveHandler : IRequestHandler<UpdateReceiveCommand, ResultViewModel>
    {
        private readonly IUoF _uoF;

        public UpdateReceiveHandler(IUoF uoF)
        {
            _uoF = uoF;
        }

        public async Task<ResultViewModel> Handle(UpdateReceiveCommand request, CancellationToken cancellationToken)
        {
            Receive receive = await _uoF.ReceiveRepository.Get(r => r.Id == request.ReceiveId);
            if (receive == null) return ResultViewModel.Error("Receive Not Found!");
            receive.Update(request.ValueReceive, request.Description);
            await _uoF.ReceiveRepository.Update(receive);
            _uoF.Commit();
            return ResultViewModel.Success();
        } 
    }
}
 
