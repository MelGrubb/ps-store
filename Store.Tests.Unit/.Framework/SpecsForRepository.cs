using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SpecsFor.StructureMap;
using Store.Domain.Framework;
using Store.Domain.Models;
using StructureMap;

namespace Store.Tests.Unit.Framework
{
    public abstract class SpecsForRepository<TRepository> : SpecsFor<TRepository> where TRepository : Repository
    {
        protected override void AfterEachTest()
        {
            base.AfterEachTest();

            _connection.Close();
        }

        protected readonly int AdminUserId = 1;
        private SqliteConnection _connection;

        public override void ConfigureContainer(Container container)
        {
            base.ConfigureContainer(container);
            container.Configure(x => x.For<StoreContext>().Use(CreateStoreContext()));
        }

        protected StoreContext CreateStoreContext()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var builder = new DbContextOptionsBuilder<StoreContext>()
                .EnableSensitiveDataLogging()
                .UseSqlite(_connection);
            var context = new StoreContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }
}
