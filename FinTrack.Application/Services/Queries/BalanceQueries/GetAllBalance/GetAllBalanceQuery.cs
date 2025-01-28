using FinTrack.Application.Models;
using FinTrack.Application.Models.BalanceModel;
using MediatR;

namespace FinTrack.Application.Services.Queries.BalanceQueries.GetAllBalance
{
    public class GetAllBalanceQuery:IRequest<ResultViewModel<List<BalanceDetailsViewModel>>>
    {
    }
}
