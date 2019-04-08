using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductStatus> ProductStatuses { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.BillingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.ShippingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<OrderItem>(entity => { entity.Property(x => x.Price).HasColumnType("Decimal(10, 2)"); });

            modelBuilder.Entity<Product>(entity => { entity.Property(x => x.Price).HasColumnType("Decimal(10, 2)"); });

            modelBuilder.Entity<User>()
                .HasOne(x => x.Address)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            Seed(modelBuilder);
        }

        public int SaveChanges(int userId)
        {
            UpdateAuditFields(userId);
            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync(int userId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditFields(userId);
            var result = base.SaveChangesAsync(cancellationToken);

            return result;
        }

        /// <summary>Updates the audit fields when an entity is added or updated.</summary>
        private void UpdateAuditFields(int userId)
        {
            var now = DateTime.UtcNow;
            var entries = ChangeTracker.Entries().Where(x =>
                x.Entity is IEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (IEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedById = userId;
                    entity.CreatedUtc = now;
                }

                entity.ModifiedById = userId;
                entity.ModifiedUtc = now;
            }
        }
    }
}
