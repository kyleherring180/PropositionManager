using System.ComponentModel.DataAnnotations;

namespace PropositionManager.Data.Shared;

public abstract class AbstractEnumTable<TEnum> where TEnum : System.Enum
{
    [Key]
    public TEnum Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
}