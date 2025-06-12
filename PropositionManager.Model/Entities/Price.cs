using PropositionManager.Model.Base;
using PropositionManager.Model.Enums;
using PropositionManager.Model.Shared;

namespace PropositionManager.Model.Entities;

public class Price : BaseEntity
{
    private readonly List<PropositionPrice> _propositionPrices = new();
    private readonly List<PriceTimeConstraintPrice> _priceTimeConstraintPrices = new();
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public Period PricePeriod { get; private set; }
    public ProductType ProductType { get; private set; }
    public CostType CostType { get; set; }
    public Currency Currency { get; private set; }
    public decimal Amount { get; private set; }
    public TariffDuration PriceDuration { get; private set; }
    public PriceStatus PriceStatus { get; private set; }
    public Supplier Supplier { get; private set; }
    
    public IReadOnlyCollection<PropositionPrice> PropositionPrices => _propositionPrices.AsReadOnly();
    public IReadOnlyCollection<PriceTimeConstraintPrice> PriceTimeConstraintPrices => _priceTimeConstraintPrices.AsReadOnly();
    
    private Price() { /*Required for EF Core */ }
    
    public Price(string name, 
        Period pricePeriod, 
        ProductType productType, 
        CostType costType, 
        Currency currency, 
        decimal amount, 
        TariffDuration priceDuration,
        Supplier supplier)
    {
        Id = Guid.NewGuid();
        Name = name;
        PricePeriod = pricePeriod;
        ProductType = productType;
        CostType = costType ?? throw new ArgumentNullException(nameof(costType));
        Currency = currency;
        Amount = amount;
        PriceDuration = priceDuration;
        PriceStatus = PriceStatus.Created;
        Supplier = supplier ?? throw new ArgumentNullException(nameof(supplier));
    }
}

