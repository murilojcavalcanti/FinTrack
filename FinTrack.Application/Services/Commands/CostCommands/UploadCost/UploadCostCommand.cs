using FinTrack.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FinTrack.Application.Services.Commands.CostCommands.UploadCost
{
    public class UploadCostCommand:IRequest<ResultViewModel>
    {
        public int BalanceID { get; set; }
        public IFormFile File { get; set; }
        
        public UploadCostCommand(int balanceID, IFormFile file)
        {
            BalanceID = balanceID;
            File = file;
        }
    }
}
