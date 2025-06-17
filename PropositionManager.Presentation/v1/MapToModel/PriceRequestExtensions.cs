namespace PropositionManager.Presentation.v1.MapToModel;

public static class PriceRequestExtensions
{
    public static Model.Dtos.PriceDto ToModel(this PropositionManager.Contracts.v1.Request.PriceRequest request)
    {
        return new Model.Dtos.PriceDto
        {
            Name = request.Name,
            PricePeriod = request.PricePeriod.ToModel(),
            Amount = request.Amount,
            ProductType = request.ProductType.ToModel(),
            Currency = request.Currency.ToModel(),
            TariffDurationId = request.TariffDurationId,
            CostTypeId = request.CostTypeId,
            SupplierId = request.SupplierId
        };
    }
    
    private static Model.Shared.Period ToModel(this PropositionManager.Contracts.v1.Shared.Period period)
    {
        return new Model.Shared.Period(period.From, period.Until);
    }
    
    private static Model.Enums.ProductType ToModel(this PropositionManager.Contracts.v1.Enums.ProductType productType)
    {
        return productType switch
        {
            PropositionManager.Contracts.v1.Enums.ProductType.Electricity => Model.Enums.ProductType.Electricity,
            PropositionManager.Contracts.v1.Enums.ProductType.Gas => Model.Enums.ProductType.Gas,
            PropositionManager.Contracts.v1.Enums.ProductType.Internet => Model.Enums.ProductType.Internet,
            PropositionManager.Contracts.v1.Enums.ProductType.MobileData => Model.Enums.ProductType.MobileData,
            PropositionManager.Contracts.v1.Enums.ProductType.MobileMinutes => Model.Enums.ProductType.MobileMinutes,
            _ => throw new ArgumentOutOfRangeException(nameof(productType), productType, null)
        };
    }
    
    private static Model.Enums.Currency ToModel(this PropositionManager.Contracts.v1.Enums.Currency currency)
    {
        return currency switch
        {
            PropositionManager.Contracts.v1.Enums.Currency.UsDollar => Model.Enums.Currency.UsDollar,
            PropositionManager.Contracts.v1.Enums.Currency.Euro => Model.Enums.Currency.Euro,
            PropositionManager.Contracts.v1.Enums.Currency.SwissFranc => Model.Enums.Currency.SwissFranc,
            _ => throw new ArgumentOutOfRangeException(nameof(currency), currency, null)
        };
    }
}