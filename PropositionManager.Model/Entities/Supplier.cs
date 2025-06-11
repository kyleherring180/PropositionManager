using PropositionManager.Model.Base;

namespace PropositionManager.Model.Entities;

public class Supplier : BaseEntity
{
    private readonly List<Proposition> _propositions = new();
    private readonly List<Price> _prices = new();
    
    public int Id { get; init; }
    public string Name { get; private set; }
    
    public IReadOnlyCollection<Proposition> Propositions => _propositions.AsReadOnly();
    public IReadOnlyCollection<Price> Prices => _prices.AsReadOnly();
    
    private Supplier(){ /*Required for EF Core */ }
    
    public Supplier(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Supplier name cannot be null or empty.", nameof(name));
        }
        
        Name = name;
    }
    
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Supplier name cannot be null or empty.", nameof(name));
        }
        
        Name = name;
    }
}