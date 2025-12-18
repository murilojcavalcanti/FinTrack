using FinTrack.Core.Auth;
using FinTrack.Core.Repositories;
using FinTrack.Core.UnitOfWork;
using FinTrack.Infrastructure.Auth;
using FinTrack.Infrastructure.InfraServices.Repositories;
using FinTrack.Infrastructure.Persistence;
using FinTrack.Infrastructure.Persistence.Repository;
using FinTrack.Infrastructure.Persistence.unitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FinTrack.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrasctructure( this IServiceCollection services,IConfiguration configuration)
        {
            services.AddData(configuration)
                .AddRepositories(configuration)
                .AddUnitOfWork(configuration)
                .AddServices()
                .AddAuth(configuration);
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
            //services.AddScoped<IRabbitMqRepository,RabbitMqRepository>();
            services.AddScoped<IReceiveRepository, ReceiveRepository>();
            services.AddScoped<IBalanceRepository, BalanceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICostRepository, CostRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUoF,UoF>();
            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
        /*
            services.AddAuthentication(JwtBearerDefaults.AtuthenticationScheme)
                .AddJwtBearer(Opts =>
                {
                    Opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience=true,
                        validateLifetime=true,
                        ValidateIssuerSiningKey=true,
                        ValidateIssuer = configuration["Jwt:Issuer"],
                        ValidateAudience= configuration["Jwt:Audience"],
                        IssuerSigningkey = new SymmetricSecurityKey(configuration["Jwt:Key"])

                    };

                });
        */
            return services;
        }


    }
}
