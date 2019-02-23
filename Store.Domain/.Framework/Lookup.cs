using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Framework
{
    /// <summary>Base class for all lookups.</summary>
    public abstract class Lookup : Model
    {
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
