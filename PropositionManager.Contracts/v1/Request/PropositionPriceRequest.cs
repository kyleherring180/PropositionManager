namespace PropositionManager.Contracts.v1.Request;

public class PropositionPriceRequest
{
    public Guid PropositionId { get; set; }
    public Guid PriceId { get; set; }
}