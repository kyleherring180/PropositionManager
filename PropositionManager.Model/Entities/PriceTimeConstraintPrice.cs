namespace PropositionManager.Model.Entities;

public class PriceTimeConstraintPrice
{
    public Guid Id { get; init; }
    public Price Price { get; init; }
    public PriceTimeConstraint PriceTimeConstraint { get; init; }
    
    private PriceTimeConstraintPrice() { /*Required for EF Core */ }

    public PriceTimeConstraintPrice(Price price, PriceTimeConstraint constraint)
    {
        Id = Guid.NewGuid();
        Price = price ?? throw new ArgumentNullException(nameof(price));
        PriceTimeConstraint = constraint ?? throw new ArgumentNullException(nameof(constraint));
    }
}
