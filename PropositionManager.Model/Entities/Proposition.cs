using PropositionManager.Model.Base;
using PropositionManager.Model.Shared;

namespace PropositionManager.Model.Entities;

public class Proposition : BaseEntity
{
    private readonly List<PropositionPrice> _propositionPrices = new();
    
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public Period MarketPeriod { get; set; }
    public IReadOnlyCollection<PropositionPrice> PropositionPrices { get; set; }
}