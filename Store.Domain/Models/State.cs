using System.ComponentModel.DataAnnotations.Schema;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class State : Lookup
    {
        public string Abbreviation { get; set; }

        //public Country Country { get; set; }

        //[ForeignKey(nameof(Country))]
        //public int CountryId { get; set; }
    }
}
