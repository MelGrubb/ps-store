using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Domain.Framework
{
    public interface IModel
    {
        int Id { get; set; }
    }

    /// <summary>Base class for all models.</summary>
    /// <seealso cref="IModel" />
    public abstract class Model : IModel
    {
        public bool IsNew => Id.Equals(0);

        /// <summary>The primary key / identity column.</summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
