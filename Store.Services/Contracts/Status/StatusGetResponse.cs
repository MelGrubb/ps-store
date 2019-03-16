using System;
using Store.Services.Framework;

namespace Store.Services.Contracts.Status
{
    /// <summary>Represents status information about the API.</summary>
    /// <seealso cref="Response" />
    public class StatusGetResponse : Response
    {
        /// <summary>Gets or sets the API version.</summary>
        /// <value>The API version.</value>
        public string ApiVersion { get; set; }

        /// <summary>Gets or sets the date of the latest migration.</summary>
        /// <value>The latest migration date.</value>
        public DateTime LatestMigrationDate { get; set; }

        /// <summary>Gets or sets the latest migration.</summary>
        /// <value>The latest migration.</value>
        public string LatestMigrationNote { get; set; }

        /// <summary>Gets or sets a message which describes the API status.</summary>
        /// <value>A <see cref="string" /> which describes the API status.</value>
        public string Message { get; set; }

        /// <summary>Gets or sets the target framework.</summary>
        /// <value>The target framework.</value>
        public string TargetFramework { get; set; }
    }
}
