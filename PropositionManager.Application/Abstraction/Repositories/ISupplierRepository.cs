using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Abstraction.Repositories;

public interface ISupplierRepository
{
    /// <summary>
    /// Created a new <see cref="Supplier"/> in the database.
    /// </summary>
    /// <param name="supplier"></param>
    /// <returns></returns>
    Task CreateSupplierAsync(Supplier supplier);
    
    /// <summary>
    /// Retrieves a <see cref="Supplier"/> by its ID.
    /// </summary>
    /// <param name="supplierId"></param>
    /// <returns></returns>
    Task<Supplier> GetSupplierByIdAsync(int supplierId);
    
    /// <summary>
    /// Persists all changes made in the repository to the database.
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
}