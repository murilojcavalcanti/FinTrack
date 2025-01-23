using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.CostCommands.DeleteCost
{
    public class DeleteCostCommand : IRequest<ResultViewModel>
    {
        public DeleteCostCommand(int costId)
        {
            CostId = costId;
        }
        public int CostId { get; set; }

    }
}
