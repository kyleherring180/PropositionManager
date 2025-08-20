namespace PropositionManager.Contracts.v1.Request;

public class PropositionRequest
{
    public Guid? PropositionId { get; set; }
    public string Name { get; set; }
    public DateTimeOffset MartketStartDate { get; set; }
    public DateTimeOffset? MarketEndDate { get; set; }
    public int SupplierId { get; set; }
}