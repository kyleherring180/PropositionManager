using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Model.Dtos;
using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Services;

public class PriceService(IPriceRepository priceRepository) : IPriceService
{
    public async Task<List<Price>> GetPricesBySupplierIdAsync(int supplierId)
    {
        return await priceRepository.GetPricesBySupplierIdAsync(supplierId);
    }

    public Task CreatePriceAsync(PriceDto pricedto)
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

        priceRepository.CreatePriceAsync(price);
        
        return Task.CompletedTask;
    }
    
    private void ValidatePriceDto(PriceDto pricedto)
    {
        // Validate the PriceDto object to ensure it meets the required criteria.
    }
}