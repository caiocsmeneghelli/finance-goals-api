using FinanceGoals.Domain.Repositories;
using FinanceGoals.Domain.UnitOfWork;
using FinanceGoals.Infrastructure.Persistence;
using FinanceGoals.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace FinanceGoals.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories()
                .AddUnitOfWork()
                .AddDbContext(configuration);
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IGoalRepository, GoalRepository>();  
            service.AddScoped<ITransactionRepository, TransactionRepository>();

            return service;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbContextCs");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            service.AddDbContext<FinanceDbContext>(options => options.UseMySql(connectionString, serverVersion));

            return service;
        }
    }
}
