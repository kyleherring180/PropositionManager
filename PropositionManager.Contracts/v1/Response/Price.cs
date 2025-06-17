using PropositionManager.Contracts.v1.Enums;
using PropositionManager.Contracts.v1.Shared;

namespace PropositionManager.Contracts.v1.Response;

public class Price
{
    public Guid PriceId { get; set; }
    public string Name { get; set; }
    public TariffDuration TariffDuration { get; set; }
    public Period PricePeriod { get; set; }
    public decimal Amount { get; set; }
    public ProductType ProductType { get; set; }
    public Currency Currency { get; set; }
}