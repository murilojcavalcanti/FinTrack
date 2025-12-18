using FinTrack.Application.Models;
using FinTrack.Application.Services.Commands.CostCommands.CreateCost;
using FinTrack.Core.Auth;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinTrack.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();

            return services;
        }


        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Config => Config.RegisterServicesFromAssemblyContaining<CreateCostHandler>());
            
            return services;
        }
    }
}
