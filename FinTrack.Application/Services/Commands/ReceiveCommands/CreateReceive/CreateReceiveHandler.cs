using FinTrack.Application.Models;
using FinTrack.Core.Entities;
using FinTrack.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.ReceiveCommands.CreateReceive
{
    public class CreateReceiveHandler : IRequestHandler<CreateReceiveCommand, ResultViewModel<int>>
    {
        private readonly IUoF _uoF;

        public CreateReceiveHandler(IUoF uoF)
        {
            _uoF = uoF;
        }

        public async Task<ResultViewModel<int>> Handle(CreateReceiveCommand request, CancellationToken cancellationToken)
        {
            var Receive = request.ToEntity(); 
            await _uoF.ReceiveRepository.Insert(Receive);
            _uoF.Commit();
            return ResultViewModel<int>.Success(Receive.Id);
        }
    }
}
