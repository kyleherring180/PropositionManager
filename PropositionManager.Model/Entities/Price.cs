using PropositionManager.Model.Enums;
using PropositionManager.Model.Shared;

namespace PropositionManager.Model.Entities;

public class Price
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public Period PricePeriod { get; private set; }
    public ProductType ProductType { get; private set; }
    public Currency Currency { get; private set; }
    public decimal Amount { get; private set; }
    public TariffDuration PriceDuration { get; private set; }
    public PriceStatus PriceStatus { get; private set; }
}