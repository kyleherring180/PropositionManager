using PropositionManager.Application.Enums;
using PropositionManager.Model.Entities;
using PropositionManager.Model.Shared;

namespace PropositionManager.Application.Abstraction.Repositories;

public interface IPropositionRepository
{
    /// <summary>
    /// Retrieves a <see cref="Proposition"/> by its ID.
    /// </summary>
    /// <param name="propositionId"></param>
    /// <returns></returns>
    Task<Proposition?> GetPropositionByIdAsync(Guid propositionId);
    
    /// <summary>
    /// Retrieves all propositions from the database.
    /// </summary>
    /// <returns></returns>
    Task<List<Proposition>> GetAllPropositionsAsync();
    
    /// <summary>
    /// Adds a new proposition to the database context.
    /// </summary>
    /// <param name="proposition"></param>
    /// <returns></returns>
    Task AddPropositionAsync(Proposition proposition);
    
    /// <summary>
    /// Adds a new proposition price to the database context.
    /// </summary>
    /// <param name="propositionPrice"></param>
    /// <returns></returns>
    Task AddPropositionPriceAsync(PropositionPrice propositionPrice);
    
    /// <summary>
    /// Saves all changes made in the service to the database.
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
}