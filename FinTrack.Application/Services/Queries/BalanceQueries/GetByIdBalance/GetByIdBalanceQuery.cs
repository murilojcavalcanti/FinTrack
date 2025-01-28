using FinTrack.Application.Models;
using FinTrack.Application.Models.BalanceModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.BalanceQueries.GetByIdBalance
{
    public class GetByIdBalanceQuery : IRequest<ResultViewModel<BalanceDetailsViewModel>>
    {
        public int BalanceId { get; set; }

        public GetByIdBalanceQuery(int balanceId)
        {
            BalanceId = balanceId;
        }
    }
}
