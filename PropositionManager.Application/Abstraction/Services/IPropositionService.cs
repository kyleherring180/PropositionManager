using PropositionManager.Application.Enums;
using PropositionManager.Model.Entities;
using PropositionManager.Model.Shared;

namespace PropositionManager.Application.Abstraction.Services;

public interface IPropositionService
{
    /// <summary>
    /// Get's single proposition by its ID.
    /// </summary>
    /// <param name="propositionId"></param>
    /// <returns></returns>
    Task<Proposition?> GetPropositionByIdAsync(Guid propositionId);
    
    /// <summary>
    /// Gets all propositions from the system.
    /// </summary>
    /// <returns></returns>
    Task<List<Proposition>> GetAllPropositionsAsync();

    /// <summary>
    /// Creates or updates a proposition in the system.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="marketPeriod"></param>
    /// <param name="supplierId"></param>
    /// <param name="propositionId"></param>
    /// <returns></returns>
    Task<EntityUpdateStatus> CreateOrUpdatePropositionAsync(string name, Period marketPeriod, int supplierId,
        Guid? propositionId = null);

    /// <summary>
    /// Creates or updates a proposition price in the system.
    /// </summary>
    /// <param name="propositionId"></param>
    /// <param name="priceId"></param>
    /// <returns></returns>
    Task<EntityUpdateStatus> CreateOrUpdatePropositionPrice(Guid propositionId, Guid priceId);
}