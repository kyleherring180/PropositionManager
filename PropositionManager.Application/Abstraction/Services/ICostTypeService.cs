using PropositionManager.Application.Enums;
using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Abstraction.Services;

public interface ICostTypeService
{
    /// <summary>
    /// Retrieves a list of <see cref="Price"/> entities associated with a specific supplier ID.
    /// </summary>
    /// <param name="costTypeId"></param>
    /// <returns></returns>
    Task<List<CostType>> GetCostTypeByIdAsync(int costTypeId);

    /// <summary>
    /// Creates a new <see cref="CostType"/> in the system.
    /// </summary>
    /// <param name="costTypeName"></param>
    /// <param name="costTypeId"></param>
    /// <returns></returns>
    Task<EntityUpdateStatus> CreateOrUpdateCostTypeAsync(string costTypeName, int? costTypeId = null);
}