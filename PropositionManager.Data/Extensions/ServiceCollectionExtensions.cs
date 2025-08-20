using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Data.Repositories;

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
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IPriceRepository, PriceRepository>();
        services.AddScoped<ICostTypeRepository, CostTypeRepository>();
        services.AddScoped<IPropositionRepository, PropositionRepository>();

        return services;
    }
}