using Microsoft.Extensions.DependencyInjection;
using Onyx.Application.Commands;
using Onyx.Application.Queries;
using Onyx.Domain.Interfaces.Commands;
using Onyx.Domain.Interfaces.Queries;

namespace Onyx.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<IExpenseCommands, ExpenseCommands>()
            .AddScoped<IExpenseQueries, ExpenseQueries>();
        return services;
    }
}