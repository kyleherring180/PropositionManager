using PropositionManager.Contracts.v1.Shared;

namespace PropositionManager.Contracts.v1.Response;

public class PropositionPrice
{
    public Guid PropositionPriceId { get; set; }
    public Proposition Proposition { get; set; }
    public Price Price { get; set; }
    public Period PropositionPricePeriod { get; set; }
}