using PropositionManager.Model.Base;
using PropositionManager.Model.Shared;

namespace PropositionManager.Model.Entities;

public class PropositionPrice : BaseEntity
{
    public Guid Id { get; init; }
    public Proposition Proposition { get; private set; } = new();
    public Price Price { get; private set; } = new();
    public Period PropositionPricePeriod { get; set; } //??
}