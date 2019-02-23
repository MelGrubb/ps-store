using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Framework;
using Store.Domain.Models;

namespace Store.Domain.Repositories
{
    /// <summary>Responsible for loading and saving of information related to the API status.</summary>
    public interface IStatusRepository : IRepository
    {
        /// <summary>Gets the latest migration asynchronously.</summary>
        /// <returns>The full name of the latest migration applied to the database.</returns>
        Task<string> GetLatestMigrationAsync();
    }

    /// <summary>Responsible for loading and saving of information related to the API status.</summary>
    /// <seealso cref="Repository" />
    /// <seealso cref="IStatusRepository" />
    public class StatusRepository : Repository, IStatusRepository
    {
        /// <summary>Initializes a new instance of the <see cref="StatusRepository" /> class.</summary>
        /// <param name="storeContext">An instance of the <see cref="StoreContext" /> class used to communicate with the database.</param>
        public StatusRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        /// <summary>Gets the latest migration asynchronously.</summary>
        /// <returns>The full name of the latest migration applied to the database.</returns>
        public async Task<string> GetLatestMigrationAsync()
        {
            var migrations = await StoreContext.Database.GetAppliedMigrationsAsync();
            var result = migrations.OrderByDescending(x => x).FirstOrDefault();

            return result;
        }
    }
}
