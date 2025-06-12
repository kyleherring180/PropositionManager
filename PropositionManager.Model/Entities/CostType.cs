namespace PropositionManager.Model.Entities;

public class CostType
{
    private readonly List<Price> _prices = new();
    public int Id { get; init; }
    public string Name { get; private set; }
    public IReadOnlyCollection<Price> Prices => _prices.AsReadOnly();
    
    private CostType() { /*Required for EF Core */ }
    
    public CostType(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        
        Name = name;
    }
}