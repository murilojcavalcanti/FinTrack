using FinTrack.Application.Models;
using FinTrack.Application.Models.ReceiveModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Services.Queries.ReceiveQueries.GetById
{
    public class GetByIdReceiveQuery : IRequest<ResultViewModel<ReceiveViewModel>>
    {
        public int ReceiveId { get; private set; }

        public GetByIdReceiveQuery(int receiveId)
        {
            ReceiveId = receiveId;
        }
    }
}
