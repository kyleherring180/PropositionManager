using Microsoft.EntityFrameworkCore;
using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Repositories;

public class CostTypeRepository(PropositionManagerContext context) : ICostTypeRepository
{
    public async Task CreateCostTypeAsync(CostType costType)
    {
        await context.CostTypes.AddAsync(costType);
    }

    public async Task<CostType> GetCostTypeByIdAsync(int costTypeId)
    {
        return await context.CostTypes.FirstOrDefaultAsync(ct => ct.Id == costTypeId);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}