using PropositionManager.Application.Enums;
using PropositionManager.Model.Dtos;
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
    
    /// <summary>
    /// Retrieves a list of <see cref="Price"/> entities associated with a specific supplier ID.
    /// </summary>
    /// <param name="costTypeId"></param>
    /// <returns></returns>
    Task<List<CostType>> GetPricesByCostTypeIdAsync(int costTypeId);
    
    /// <summary>
    /// Creates a new <see cref="Price"/> in the system.
    /// </summary>
    /// <param name="pricedto"></param>
    /// <returns></returns>
    Task<EntityUpdateStatus> CreatePriceAsync(PriceDto pricedto);
}