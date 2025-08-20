using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Enums;
using PropositionManager.Model.Entities;
using PropositionManager.Model.Shared;

namespace PropositionManager.Application.Services;

public class PropositionService(
    IPropositionRepository propositionRepository, 
    ISupplierRepository supplierRepository,
    IPriceRepository priceRepository) : IPropositionService
{
    public async Task<Proposition?> GetPropositionByIdAsync(Guid propositionId)
    {
        var proposition = await propositionRepository.GetPropositionByIdAsync(propositionId);
        
        return proposition;
    }
    
    public async Task<List<Proposition>> GetAllPropositionsAsync()
    {
        var propositions = await propositionRepository.GetAllPropositionsAsync();
        
        return propositions;
    }

    public async Task<EntityUpdateStatus> CreateOrUpdatePropositionAsync(string name, Period marketPeriod, int supplierId,
        Guid? propositionId = null)
    {
        //TODO - pass supplier object in request to avoid multiple calls to db.
        var supplier = await supplierRepository.GetSupplierByIdAsync(supplierId);
        
        if(propositionId == null)
        {
            // Create new proposition
            var newProposition = new Proposition(name, marketPeriod, supplier);

            await propositionRepository.AddPropositionAsync(newProposition);
        }
        else
        {
            // Update existing proposition
            var existingProposition =  await GetPropositionByIdAsync(propositionId.Value);
            if (existingProposition == null)
            {
                return await Task.FromResult(EntityUpdateStatus.NotFound);
            }

            existingProposition.Update(name, marketPeriod, supplier);
        }
        
        await propositionRepository.SaveChangesAsync();
        return await Task.FromResult(EntityUpdateStatus.Success);
    }

    public async Task<EntityUpdateStatus> CreateOrUpdatePropositionPrice(Guid propositionId, Guid priceId)
    {
        var proposition = await propositionRepository.GetPropositionByIdAsync(propositionId);
        var price = await priceRepository.GetPriceByIdAsync(priceId);
    
        if (proposition == null || price == null)
        {
            return EntityUpdateStatus.NotFound;
        }

        var propositionPrice = new PropositionPrice(proposition, price);
        await propositionRepository.AddPropositionPriceAsync(propositionPrice);
        
        return await Task.FromResult(EntityUpdateStatus.Success);
    }
}