using PropositionManager.Contracts.v1.Shared;

namespace PropositionManager.Contracts.v1.Response;

public class Proposition
{
    public Guid PropositionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Period MarketPeriod { get; set; } = new();
    public IEnumerable<PropositionPrice> PropositionPrices { get; set; } = new List<PropositionPrice>();
}