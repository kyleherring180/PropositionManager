using PropositionManager.Model.Base;
using PropositionManager.Model.Shared;

namespace PropositionManager.Model.Entities;

public class Proposition : BaseEntity
{
    private readonly List<PropositionPrice> _propositionPrices = new();
    
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public Period MarketPeriod { get; private set; }
    public Supplier Supplier { get; private set; }
    public IReadOnlyCollection<PropositionPrice> PropositionPrices => _propositionPrices.AsReadOnly();


    private Proposition() { /*Required for EF Core */ }
    
    public Proposition(string name, Period marketPeriod)
    {
        Id = Guid.NewGuid();
        Name = name;
        MarketPeriod = marketPeriod;
    }
}