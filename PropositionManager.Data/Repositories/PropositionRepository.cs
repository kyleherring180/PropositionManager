using Microsoft.EntityFrameworkCore;
using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Application.Enums;
using PropositionManager.Model.Entities;
using PropositionManager.Model.Shared;

namespace PropositionManager.Data.Repositories;

public class PropositionRepository(PropositionManagerContext context) : IPropositionRepository
{
    public async Task<Proposition?> GetPropositionByIdAsync(Guid propositionId)
    {
        return await context.Propositions
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.Id == propositionId);
    }
    
    public async Task<List<Proposition>> GetAllPropositionsAsync()
    {
        return await context.Propositions
            .Include(p => p.Supplier)
            .ToListAsync();
    }

    public async Task AddPropositionAsync(Proposition proposition)
    {
        await context.Propositions.AddAsync(proposition);
    }
    
    public async Task AddPropositionPriceAsync(PropositionPrice propositionPrice)
    {
        await context.PropositionPrices.AddAsync(propositionPrice);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}