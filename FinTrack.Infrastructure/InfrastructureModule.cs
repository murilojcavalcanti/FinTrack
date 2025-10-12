using FinTrack.Core.Repositories;
using FinTrack.Core.UnitOfWork;
using FinTrack.Infrastructure.Persistence;
using FinTrack.Infrastructure.Persistence.Repository;
using FinTrack.Infrastructure.Persistence.unitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinTrack.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrasctructure( this IServiceCollection services,IConfiguration configuration)
        {
            services.AddData(configuration).AddRepositories(configuration).AddUnitOfWork(configuration);
            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            string conString = configuration.GetConnectionString("FinTrackApp");
            services.AddDbContext<FinTrackDbContext>(opts=>opts.UseSqlServer(conString));

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUoF,UoF>();
            return services;
        }
    }
}
