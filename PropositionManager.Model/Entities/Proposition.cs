using PropositionManager.Model.Base;
using PropositionManager.Model.Shared;

namespace PropositionManager.Model.Entities;

public class Proposition : BaseEntity
{
    private readonly List<PropositionPrice> _propositionPrices = new();
    
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public Period MarketPeriod { get; private set; }
    public Supplier Supplier { get; private set; }
    public IReadOnlyCollection<PropositionPrice> PropositionPrices => _propositionPrices.AsReadOnly();


    private Proposition() { /*Required for EF Core */ }
    
    public Proposition(string name, Period marketPeriod, Supplier supplier)
    {
        Id = Guid.NewGuid();
        Name = name;
        MarketPeriod = marketPeriod;
        Supplier = supplier;
    }
    
    public void Update(string name, Period marketPeriod, Supplier supplier)
    {
        bool changed = false;
        
        changed |= UpdateName(name);
        changed |= UpdateMarketPeriod(marketPeriod);
        changed |= UpdateSupplier(supplier);

        if (changed)
            UpdateVersion();
    }
    
    public void AddPrice(PropositionPrice propositionPrice)
    {
        if (_propositionPrices.Any(p => p.Id == propositionPrice.Id))
            return;

        _propositionPrices.Add(propositionPrice);
        UpdateVersion();
    }
    
    private bool UpdateName(string name)
    {
        if (Name == name)
            return false;
        
        Name = name;
        return true;
    }
    
    private bool UpdateMarketPeriod(Period marketPeriod)
    {
        if (MarketPeriod == marketPeriod)
            return false;
        
        MarketPeriod = marketPeriod;
        return true;
    }
    
    private bool UpdateSupplier(Supplier supplier)
    {
        if (Supplier == supplier)
            return false;

        Supplier = supplier;
        return true;
    }
    
    private void UpdateVersion()
    {
        Version++;
    }
}