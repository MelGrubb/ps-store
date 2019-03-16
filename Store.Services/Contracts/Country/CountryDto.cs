using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Store.Services.Contracts.State;
using Store.Services.Framework;

namespace Store.Services.Contracts.Country
{
    public class CountryDto : LookupDto
    {
        public CountryDto()
        {
            States = new HashSet<StateDto>();
        }

        [StringLength(3)]
        public string Abbreviation { get; set; }

        [StringLength(50)]
        public string PostalCodeLabel { get; set; }

        [StringLength(50)]
        public string StateLabel { get; set; }

        public ICollection<StateDto> States { get; set; }
    }
}
