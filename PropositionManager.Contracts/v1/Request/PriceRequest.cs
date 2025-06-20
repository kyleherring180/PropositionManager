using PropositionManager.Contracts.v1.Enums;
using PropositionManager.Contracts.v1.Response;
using PropositionManager.Contracts.v1.Shared;

namespace PropositionManager.Contracts.v1.Request;

public class PriceRequest
{
    public string Name { get; set; }
    public Period PricePeriod { get; set; }
    public decimal Amount { get; set; }
    public ProductType ProductType { get; set; }
    public Currency Currency { get; set; }
    public int TariffDurationId { get; set; }
    public int CostTypeId { get; set; }
    public int SupplierId { get; set; }
}