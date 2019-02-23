using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Domain.Framework
{
    public interface IEntity : IModel
    {
        /// <summary>The Id of the user that created this object.</summary>
        int? CreatedById { get; set; }

        /// <summary>The date that this object was created.</summary>
        DateTime CreatedUtc { get; set; }

        /// <summary>The Id of the user that last modified this object.</summary>
        int? ModifiedById { get; set; }

        /// <summary>The date that this object was last modified.</summary>
        DateTime ModifiedUtc { get; set; }
    }

    public abstract class Entity : Model, IEntity
    {
        /// <inheritdoc />
        public int? CreatedById { get; set; }

        /// <inheritdoc />
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedUtc { get; set; }

        /// <inheritdoc />
        public int? ModifiedById { get; set; }

        /// <inheritdoc />
        [Column(TypeName = "DateTime2")]
        public DateTime ModifiedUtc { get; set; }
    }

    public interface ISoftDeleteable : IModel
    {
        /// <summary>The Id of the user that deleted the record.</summary>
        int? DeletedById { get; set; }

        /// <summary>The date that the record was deleted.</summary>
        DateTime? DeletedUtc { get; set; }
    }

    public abstract class SoftDeleteableEntity : Entity, ISoftDeleteable
    {
        public bool IsDeleted => DeletedUtc.HasValue;

        /// <summary>The Id of the user that deleted the record.</summary>
        public int? DeletedById { get; set; }

        /// <summary>The date that the record was deleted.</summary>
        public DateTime? DeletedUtc { get; set; }
    }
}
