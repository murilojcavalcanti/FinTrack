using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;

namespace FinTrack.Application.Services.Commands.BalanceCommands.DeleteBalance
{
    public class DeleteBalanceHandler : IRequestHandler<DeleteBalanceCommand, ResultViewModel>
    {
        private readonly IUoF _uof;

        public DeleteBalanceHandler(IUoF uof)
        {
            _uof = uof;
        }

        public async Task<ResultViewModel> Handle(DeleteBalanceCommand request, CancellationToken cancellationToken)
        {
            Balance balance = await _uof.BalanceRepository.Get(b => b.Id == request.BalanceId);
            if (balance is null) return ResultViewModel.Error("Balance NotFound");
            await _uof.BalanceRepository.Delete(balance);
            _uof.Commit();
            return ResultViewModel.Success();
        }
    }
}
