using PropositionManager.Model.Shared;

namespace PropositionManager.Model.Entities;

public class Proposition
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public Period MarketPeriod { get; set; }
    private IReadOnlyCollection<PropositionPrice> _propositionPrices { get; set; }
}