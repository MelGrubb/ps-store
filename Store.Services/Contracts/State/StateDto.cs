using System.ComponentModel.DataAnnotations;
using Store.Services.Framework;

namespace Store.Services.Contracts.State
{
    public class StateDto : Dto
    {
        public string Abbreviation { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
