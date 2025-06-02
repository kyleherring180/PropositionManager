using System.ComponentModel.DataAnnotations.Schema;
using PropositionManager.Data.Shared;
using PropositionManager.Model.Enums;

namespace PropositionManager.Data.Enums;

[Table("Dictionary_ProductType")]
public class ProductTypeEntity : AbstractEnumTable<ProductType>
{
}