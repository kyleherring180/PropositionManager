using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Data.Enums;
using PropositionManager.Data.Extensions;
using PropositionManager.Model.Entities;
using PropositionManager.Model.Enums;

namespace PropositionManager.Data.Configurations;

public class PriceConfiguration : IEntityTypeConfiguration<Price>
{
    internal const string FkPrice = "PriceId";
    
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.HasOne<CurrencyEntity>().WithMany().HasForeignKey(x => x.Currency);
        builder.HasOne<PriceStatusEntity>().WithMany().HasForeignKey(p => p.PriceStatus);
        builder.HasOne<ProductTypeEntity>().WithMany().HasForeignKey(p => p.ProductType);
        builder.Property(p => p.Amount).HasStandardPrecision();
        builder.HasMany(p => p.PropositionPrices).WithOne(pp => pp.Price).HasForeignKey(FkPrice);
        builder.ComplexProperty(p => p.PricePeriod, y => y.ConfigurePeriod());
        builder.ComplexProperty(p => p.PriceDuration, y => y.ConfigureTariffDuration());
        builder.ConfigureVersionConcurrency();
    }
}