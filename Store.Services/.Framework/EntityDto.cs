using System;

namespace Store.Services.Framework
{
    public abstract class EntityDto : Dto
    {
        /// <summary>The Id of the user that created this object.</summary>
        public int? CreatedById { get; set; }

        /// <summary>The date that this object was created.</summary>
        public DateTime CreatedUtc { get; set; }

        /// <summary>The Id of the user that last modified this object.</summary>
        public int? ModifiedById { get; set; }

        /// <summary>The date that this object was last modified.</summary>
        public DateTime ModifiedUtc { get; set; }
    }
}
