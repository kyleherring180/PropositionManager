using PropositionManager.Contracts.v1.Enums;
using PropositionManager.Contracts.v1.Response;
using PropositionManager.Contracts.v1.Shared;

namespace PropositionManager.Contracts.v1.Request;

public class PriceRequest
{
    public string Name { get; set; }
    public TariffDuration TariffDuration { get; set; }
    public Period PricePeriod { get; set; }
    public decimal Amount { get; set; }
    public ProductType ProductType { get; private set; }
    public Currency Currency { get; private set; }
}