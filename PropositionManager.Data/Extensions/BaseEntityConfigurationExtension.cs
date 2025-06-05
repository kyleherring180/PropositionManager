using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Model.Base;

namespace PropositionManager.Data.Extensions;

public static class BaseEntityConfigurationExtension
{
    public static void ConfigureVersionConcurrency<T>(this EntityTypeBuilder<T> baseEntityBuilder) where T : BaseEntity
    {
        baseEntityBuilder.Property(e => e.Version).IsConcurrencyToken();
    }
}