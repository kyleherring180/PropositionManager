using Microsoft.EntityFrameworkCore;
using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Repositories;

public class PriceRepository(PropositionManagerContext context) : IPriceRepository
{
    public Task CreatePriceAsync(Price price)
    {
        if (price == null)
        {
            throw new ArgumentNullException(nameof(price));
        }

        context.Prices.Add(price);
        return Task.CompletedTask;
    }

    public async Task<Price> GetPriceByIdAsync(Guid priceId)
    {
        return await context.Prices
            .Include(pp => pp.PriceTimeConstraintPrices)
                .ThenInclude(ptc => ptc.PriceTimeConstraint)
            .FirstOrDefaultAsync(p => p.Id == priceId) 
            ?? throw new KeyNotFoundException($"Price with ID {priceId} not found.");
    }

    public async Task<List<Price>> GetPricesBySupplierIdAsync(int supplierId)
    {
        return await context.Prices.Where(p => p.Supplier.Id == supplierId)
            .Include(pp => pp.PriceTimeConstraintPrices)
                .ThenInclude(ptc => ptc.PriceTimeConstraint)
            .ToListAsync() 
            ?? throw new KeyNotFoundException($"No prices found for supplier with ID {supplierId}.");
    }

    public Task<List<Price>> GetPricesByCostTypeIdAsync(int costTypeId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}