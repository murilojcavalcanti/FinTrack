using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinTrack.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinTrack.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrasctructure( this IServiceCollection services,IConfiguration configuration)
        {
            services.AddData(configuration);
            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            string conString = configuration.GetConnectionString("FinTrackDb");
            services.AddDbContext<FinTrackDbContext>(opts=>opts.UseSqlServer(conString));

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            
            return services;
        }
    }
}
