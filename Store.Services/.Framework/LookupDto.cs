using System.ComponentModel.DataAnnotations;

namespace Store.Services.Framework
{
    public abstract class LookupDto : Dto
    {
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
