using System.ComponentModel.DataAnnotations.Schema;
using PropositionManager.Data.Shared;
using PropositionManager.Model.Enums;

namespace PropositionManager.Data.Enums;

[Table("Dictionary_Currency")]
public class CurrencyEntity : AbstractEnumTable<Currency>
{
}