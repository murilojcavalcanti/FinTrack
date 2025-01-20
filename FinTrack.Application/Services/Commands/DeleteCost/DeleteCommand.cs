using FinTrack.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Commands.DeleteCost
{
    public class DeleteCommand:IRequest<ResultViewModel>
    {
        public DeleteCommand(int costId)
        {
            CostId = costId;
        }
        public int CostId { get; set; }

    }
}
