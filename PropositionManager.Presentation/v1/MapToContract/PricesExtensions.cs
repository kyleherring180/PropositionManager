using PropositionManager.Contracts.v1.Enums;
using PropositionManager.Contracts.v1.Response;
using PropositionManager.Contracts.v1.Shared;

namespace PropositionManager.Presentation.v1.MapToContract;

public static class PricesExtensions
{
    public static List<Price> ToContract(this List<PropositionManager.Model.Entities.Price> prices)
    {
        return prices.Select(price => price.ToContract()).ToList();
    }
    
    public static Price ToContract(this PropositionManager.Model.Entities.Price price)
    {
        return new Price
        {
            PriceId = price.Id,
            Name = price.Name,
            TariffDuration = price.PriceDuration.ToContract(),
            Currency = price.Currency.ToContract(),
            PricePeriod = price.PricePeriod.ToContract(),
            Amount = price.Amount,
            ProductType = price.ProductType.ToContract(),
        };
    }
    
    private static TariffDuration ToContract(this PropositionManager.Model.Entities.TariffDuration tariffDuration)
    {
        return new TariffDuration
        {
            Id = tariffDuration.Id,
            TariffDurationUnit = tariffDuration.TariffDurationUnit.ToContract(),
            Quantity = tariffDuration.Quantity
        };
    }
    
    private static TariffDurationUnit ToContract(this PropositionManager.Model.Enums.TariffDurationUnit tariffDurationUnit)
    {
        return tariffDurationUnit switch
        {
            PropositionManager.Model.Enums.TariffDurationUnit.Day => TariffDurationUnit.Day,
            PropositionManager.Model.Enums.TariffDurationUnit.Month => TariffDurationUnit.Month,
            PropositionManager.Model.Enums.TariffDurationUnit.Year => TariffDurationUnit.Year,
            _ => throw new ArgumentOutOfRangeException(nameof(tariffDurationUnit), tariffDurationUnit, null)
        };
    }
    
    private static Currency ToContract(this PropositionManager.Model.Enums.Currency currency)
    {
        return currency switch
        {
            PropositionManager.Model.Enums.Currency.UsDollar => Currency.UsDollar,
            PropositionManager.Model.Enums.Currency.Euro => Currency.Euro,
            PropositionManager.Model.Enums.Currency.SwissFranc => Currency.SwissFranc,
            _ => throw new ArgumentOutOfRangeException(nameof(currency), currency, null)
        };
    }
    
    private static PropositionManager.Contracts.v1.Shared.Period ToContract(this PropositionManager.Model.Shared.Period period)
    {
        return new Period
        {
            From = period.From,
            Until = period.Until
        };
    }
    
    private static ProductType ToContract(this PropositionManager.Model.Enums.ProductType productType)
    {
        return productType switch
        {
            PropositionManager.Model.Enums.ProductType.Electricity => ProductType.Electricity,
            PropositionManager.Model.Enums.ProductType.Gas => ProductType.Gas,
            PropositionManager.Model.Enums.ProductType.Internet => ProductType.Internet,
            PropositionManager.Model.Enums.ProductType.MobileData => ProductType.MobileData,
            PropositionManager.Model.Enums.ProductType.MobileMinutes => ProductType.MobileMinutes,
            _ => throw new ArgumentOutOfRangeException(nameof(productType), productType, null)
        };
    }
}