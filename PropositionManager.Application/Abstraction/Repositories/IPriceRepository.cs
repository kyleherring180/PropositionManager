using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Abstraction.Repositories;

public interface IPriceRepository
{
    /// <summary>
    /// Create a new <see cref="Price"/> in the database.
    /// </summary>
    /// <param name="price"></param>
    /// <returns></returns>
    Task CreatePriceAsync(Price price);
    
    /// <summary>
    /// Retrieves a <see cref="Price"/> by its ID.
    /// </summary>
    /// <param name="priceId"></param>
    /// <returns></returns>
    Task<Price> GetPriceByIdAsync(Guid priceId);
    
    /// <summary>
    /// Retrieves a <see cref="Price"/> by its associated supplier ID.
    /// </summary>
    /// <param name="supplierId"></param>
    /// <returns></returns>
    Task<List<Price>> GetPricesBySupplierIdAsync(int supplierId);
    
    /// <summary>
    /// Retrieves a <see cref="Price"/> by its associated supplier ID.
    /// </summary>
    /// <param name="costTypeId"></param>
    /// <returns></returns>
    Task<List<Price>> GetPricesByCostTypeIdAsync(int costTypeId);
    
    /// <summary>
    /// Persists all changes made in the repository to the database.
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
}