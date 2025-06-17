using PropositionManager.Application.Abstraction.Repositories;
using PropositionManager.Application.Abstraction.Services;
using PropositionManager.Model.Entities;

namespace PropositionManager.Application.Services;

public class PriceService(IPriceRepository priceRepository) : IPriceService
{
    public async Task<List<Price>> GetPricesBySupplierIdAsync(int supplierId)
    {
        return await priceRepository.GetPricesBySupplierIdAsync(supplierId);
    }
}