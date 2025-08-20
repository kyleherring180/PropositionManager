using PropositionManager.Model.Entities;

namespace PropositionManager.Presentation.v1.MapToContract;

public static class PropositionExtensions
{
    public static Contracts.v1.Response.Proposition ToContract(this Proposition proposition)
    {
        return new Contracts.v1.Response.Proposition
        {
            PropositionId = proposition.Id,
            Name = proposition.Name,
            MarketPeriod = new Contracts.v1.Shared.Period
            {
                From = proposition.MarketPeriod.From,
                Until = proposition.MarketPeriod.Until
            },
            SupplierId = proposition.Supplier.Id,
            SupplierName = proposition.Supplier.Name,
            
            //TODO: Implement mapping for PropositionPrices
        };
    }
}