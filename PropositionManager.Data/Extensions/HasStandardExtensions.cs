using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PropositionManager.Data.Extensions;

public static class HasStandardExtensions
{
    public static PropertyBuilder<T> HasStandardPrecision<T>(this PropertyBuilder<T> builder)
    {
        return builder.HasPrecision(19, 6);
    }
}