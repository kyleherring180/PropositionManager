using Microsoft.Extensions.DependencyInjection;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Services;

namespace PropositionManager.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services here
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IPriceService, PriceService>();
        services.AddScoped<ICostTypeService, CostTypeService>();
        services.AddScoped<IPropositionService, PropositionService>();

        return services;
    }
}