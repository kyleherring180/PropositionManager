using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Application.Enums;
using PropositionManager.Model.Dtos;
using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Services;

public class PriceService(IPriceRepository priceRepository) : IPriceService
{
    public async Task<List<Price>> GetPricesBySupplierIdAsync(int supplierId)
    {
        return await priceRepository.GetPricesBySupplierIdAsync(supplierId);
    }

    /// <summary>
    /// TODO - Implement this method to retrieve a list of <see cref="CostType"/>
    /// entities associated with a specific cost type ID.
    /// </summary>
    /// <param name="costTypeId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<List<CostType>> GetPricesByCostTypeIdAsync(int costTypeId)
    {
        throw new NotImplementedException();
    }

    public async Task<EntityUpdateStatus> CreatePriceAsync(PriceDto pricedto)
    {
        ValidatePriceDto(pricedto);

        var price = new Price(
            pricedto.Name, 
            pricedto.PricePeriod, 
            pricedto.ProductType,
            pricedto.Currency,
            pricedto.Amount,
            pricedto.TariffDurationId,
            pricedto.CostTypeId,
            pricedto.SupplierId);

        await priceRepository.CreatePriceAsync(price);
        await priceRepository.SaveChangesAsync();
        
        return EntityUpdateStatus.Success;
    }
    
    private void ValidatePriceDto(PriceDto pricedto)
    {
        // Validate the PriceDto object to ensure it meets the required criteria.
    }
}