using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Npgsql.NameTranslation;
using Onyx.Domain.Enums;
using Onyx.Domain.Interfaces.Repositories;
using Onyx.Infrastructure.Context;
using Onyx.Infrastructure.Repositories;

namespace Onyx.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("DefaultConnection"));
        dataSourceBuilder.MapEnum<Currency>("currency_type", nameTranslator: new NpgsqlNullNameTranslator());
        var dataSource = dataSourceBuilder.Build();
        
        services
            .AddDbContext<SpendingDbContext>(options => options.UseNpgsql(dataSource, npgsqlOptions =>
            {
                npgsqlOptions.MapEnum<Currency>("currency_type", nameTranslator: new NpgsqlNullNameTranslator());
            }))
            .AddScoped<IExpenseRepository, ExpenseRepository>();
        return services;
    }
}