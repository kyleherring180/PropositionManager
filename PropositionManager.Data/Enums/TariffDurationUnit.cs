using System.ComponentModel.DataAnnotations.Schema;
using PropositionManager.Data.Shared;
using PropositionManager.Model.Enums;

namespace PropositionManager.Data.Enums;

[Table("Dictionary_TariffDurationUnit")]
public class TariffDurationUnitEntity : AbstractEnumTable<TariffDurationUnit>
{
}