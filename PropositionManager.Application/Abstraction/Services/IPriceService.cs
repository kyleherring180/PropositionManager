using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Abstraction.Services;

public interface IPriceService
{
    /// <summary>
    /// Retrieves a list of <see cref="Price"/> entities associated with a specific supplier ID.
    /// </summary>
    /// <param name="supplierId"></param>
    /// <returns></returns>
    Task<List<Price>> GetPricesBySupplierIdAsync(int supplierId);
}