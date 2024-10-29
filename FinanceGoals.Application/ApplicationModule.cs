using FinanceGoals.Application.Commands.Goals.CreateGoal;
using FinanceGoals.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceGoals.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediator()
                .AddMapper();
            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services) {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateGoalCommand).Assembly));
            return services;
        }

        private static IServiceCollection AddMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(TransactionProfile));
            return service;
        }
    }
}
