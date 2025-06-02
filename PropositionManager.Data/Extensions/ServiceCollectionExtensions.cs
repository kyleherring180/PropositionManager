using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PropositionManager.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PropositionManagerContext>(o => o.UseSqlServer(connectionString));

        services.AddDataWithoutContext();
        return services;
    }

    public static IServiceCollection AddDataWithoutContext(this IServiceCollection services)
    {
        services.AddScoped<Func<DateTime>>(f => () => DateTime.Now);
        
        //Add Repository methods

        return services;
    }
}