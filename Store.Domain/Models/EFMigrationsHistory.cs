using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class EFMigrationsHistory : Model
    {
        /// <summary>Uniquely identifies the migration.</summary>
        /// <value>A <see cref="string" /> that uniquely identifies the migration.</value>
        public string MigrationId { get; set; }

        /// <summary>The version of Entity Framework used to produce this migration.</summary>
        /// <value>A <see cref="string" /> containing the version of Entity Framework used to produce this migration.</value>
        public string ProductVersion { get; set; }
    }
}
