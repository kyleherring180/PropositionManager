using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Abstraction.Repositories;

public interface ICostTypeRepository
{
    /// <summary>
    /// Created a new <see cref="CostType"/> in the database.
    /// </summary>
    /// <param name="costType"></param>
    /// <returns></returns>
    Task CreateCostTypeAsync(CostType costType);
    
    /// <summary>
    /// Retrieves a <see cref="CostType"/> by its ID.
    /// </summary>
    /// <param name="costTypeId"></param>
    /// <returns></returns>
    Task<CostType> GetCostTypeByIdAsync(int costTypeId);
    
    /// <summary>
    /// Persists all changes made in the repository to the database.
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
}