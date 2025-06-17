using PropositionManager.Model.Enums;
using PropositionManager.Model.Shared;

namespace PropositionManager.Model.Dtos;

public class PriceDto
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