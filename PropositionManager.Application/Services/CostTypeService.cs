using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Enums;
using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Services;

public class CostTypeService(ICostTypeRepository costTypeRepository) : ICostTypeService
{
    public Task<List<CostType>> GetCostTypeByIdAsync(int costTypeId)
    {
        throw new NotImplementedException();
    }

    public async Task<EntityUpdateStatus> CreateOrUpdateCostTypeAsync(string costTypeName, int? costTypeId = null)
    {
        if (costTypeId == null)
        {
            //create a new cost type
            var costType = new CostType(costTypeName);
            await costTypeRepository.CreateCostTypeAsync(costType);
        }
        else
        {
            //update an existing cost type
            var costType = await costTypeRepository.GetCostTypeByIdAsync(costTypeId.Value);
            if (costType == null)
            {
                return EntityUpdateStatus.NotFound;
            }
            costType.UpdateName(costTypeName);
        }
        
        await costTypeRepository.SaveChangesAsync();
        
        return EntityUpdateStatus.Success;
    }
}