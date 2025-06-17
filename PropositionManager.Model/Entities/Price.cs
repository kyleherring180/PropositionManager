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
    
    public int CostTypeId { get; private set; }
    public CostType CostType { get; set; }
    public Currency Currency { get; private set; }
    public decimal Amount { get; private set; }
    
    public int TariffDurationId { get; private set; }
    public TariffDuration PriceDuration { get; private set; }
    public PriceStatus PriceStatus { get; private set; }
    
    public int SupplierId { get; private set; }
    public Supplier Supplier { get; private set; }
    
    public IReadOnlyCollection<PropositionPrice> PropositionPrices => _propositionPrices.AsReadOnly();
    public IReadOnlyCollection<PriceTimeConstraintPrice> PriceTimeConstraintPrices => _priceTimeConstraintPrices.AsReadOnly();
    
    private Price() { /*Required for EF Core */ }
    
    public Price(
        string name, 
        Period pricePeriod, 
        ProductType productType,
        Currency currency, 
        decimal amount,
        int tariffDurationId,
        int costTypeId,
        int supplierId)
    {
        Id = Guid.NewGuid();
        Name = name;
        PricePeriod = pricePeriod;
        ProductType = productType;
        Currency = currency;
        Amount = amount;
        PriceStatus = PriceStatus.Created;
        TariffDurationId = tariffDurationId;
        CostTypeId = costTypeId;
        SupplierId = supplierId;
    }
}

