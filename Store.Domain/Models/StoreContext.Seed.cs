using System;
using Microsoft.EntityFrameworkCore;

namespace Store.Domain.Models
{
    public partial class StoreContext
    {
        /// <summary>The Id of the admin user.</summary>
        public const int AdminUserId = 1;

        private static readonly DateTime _seedDateTime = new DateTime(2019, 01, 1);

        private static void Seed(ModelBuilder modelBuilder)
        {
            SeedUserTable(modelBuilder);
            SeedAddressTable(modelBuilder);
            SeedCategoryTable(modelBuilder);
            SeedProductStatusTable(modelBuilder);
            SeedProductTable(modelBuilder);
            SeedOrderStatusTable(modelBuilder);
            SeedOrderTable(modelBuilder);
            SeedOrderItemTable(modelBuilder);
            SeedCountryTable(modelBuilder);
            SeedStateTable(modelBuilder);
        }

        private static void SeedAddressTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new Address { Id = 1, Line1 = "Billing Dept.", Line2 = "123 Any St.", City = "Anytown", StateId = 1, ZipCode = "12345", CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new Address { Id = 2, Line1 = "Receiving Dept.", Line2 = "123 Any St.", City = "Anytown", StateId = 1, ZipCode = "12345", CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime }
            };

            modelBuilder.Entity<Address>(entity => entity.HasData(data));
        }

        private static void SeedCategoryTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new Category { Id = 1, Name = "Clothing", ParentCategoryId = null },
                new Category { Id = 2, Name = "Men's", ParentCategoryId = 1 },
                new Category { Id = 3, Name = "Women's", ParentCategoryId = 1 }
            };

            modelBuilder.Entity<Category>(entity => entity.HasData(data));
        }

        private static void SeedCountryTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new Country { Id = 1, Abbreviation = "USA", Name = "The United States of America", Description = "The United States of America" },
                new Country { Id = 2, Abbreviation = "CAN", Name = "Canada", Description = "Canada" }
            };

            modelBuilder.Entity<Country>(entity => entity.HasData(data));
        }

        private static void SeedOrderItemTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = 1.00m, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1, Price = 1.00m, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },

                new OrderItem { Id = 3, OrderId = 2, ProductId = 1, Quantity = 1, Price = 1.00m, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new OrderItem { Id = 4, OrderId = 2, ProductId = 2, Quantity = 1, Price = 1.00m, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },

                new OrderItem { Id = 5, OrderId = 3, ProductId = 1, Quantity = 1, Price = 1.00m, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new OrderItem { Id = 6, OrderId = 3, ProductId = 2, Quantity = 1, Price = 1.00m, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },

                new OrderItem { Id = 7, OrderId = 4, ProductId = 1, Quantity = 1, Price = 1.00m, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new OrderItem { Id = 8, OrderId = 4, ProductId = 2, Quantity = 1, Price = 1.00m, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime }
            };

            modelBuilder.Entity<OrderItem>(entity => entity.HasData(data));
        }

        private static void SeedOrderStatusTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new OrderStatus { Id = (int)OrderStatus.Ids.Received, Name = "Received", Description = "Order has been received, but not yet processed." },
                new OrderStatus { Id = (int)OrderStatus.Ids.Processing, Name = "Processing", Description = "Order has been processed, but not yet shipped." },
                new OrderStatus { Id = (int)OrderStatus.Ids.Shipping, Name = "Shipping", Description = "Order is in the process of being shipped." },
                new OrderStatus { Id = (int)OrderStatus.Ids.Shipped, Name = "Shipped", Description = "Order has been shipped." }
            };

            modelBuilder.Entity<OrderStatus>(entity => entity.HasData(data));
        }

        private static void SeedOrderTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new Order { Id = 1, OrderStatusId = (int)OrderStatus.Ids.Shipped, UserId = AdminUserId, BillingAddressId = 1, ShippingAddressId = 2, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new Order { Id = 2, OrderStatusId = (int)OrderStatus.Ids.Shipping, UserId = AdminUserId, BillingAddressId = 1, ShippingAddressId = 2, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new Order { Id = 3, OrderStatusId = (int)OrderStatus.Ids.Processing, UserId = AdminUserId, BillingAddressId = 1, ShippingAddressId = 2, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new Order { Id = 4, OrderStatusId = (int)OrderStatus.Ids.Received, UserId = AdminUserId, BillingAddressId = 1, ShippingAddressId = 2, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime }
            };

            modelBuilder.Entity<Order>(entity => entity.HasData(data));
        }

        private static void SeedProductStatusTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new ProductStatus { Id = (int)ProductStatus.Ids.InStock, Name = "In-Stock", Description = "Product is available to order." },
                new ProductStatus { Id = (int)ProductStatus.Ids.BackOrdered, Name = "Back-Ordered", Description = "Product can be ordered, but delivery time is unknown." },
                new ProductStatus { Id = (int)ProductStatus.Ids.Discontinued, Name = "Discontinued", Description = "Product is unavailable for ordering." }
            };

            modelBuilder.Entity<ProductStatus>(entity => entity.HasData(data));
        }

        private static void SeedProductTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new Product { Id = 1, Name = "T-Shirt", Description = "A men's t-shirt", ProductStatusId = (int)ProductStatus.Ids.InStock, Price = 1.00m, CategoryId = (int)Category.Ids.Mens, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new Product { Id = 2, Name = "T-Shirt", Description = "A wommen's t-shirt", ProductStatusId = (int)ProductStatus.Ids.InStock, Price = 2.00m, CategoryId = (int)Category.Ids.Womens, CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime }
            };

            modelBuilder.Entity<Product>(entity => entity.HasData(data));
        }

        private static void SeedStateTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new State { Id = 01, Abbreviation = "AL", Name = "Alabama" },
                new State { Id = 02, Abbreviation = "AK", Name = "Alaska" },
                new State { Id = 03, Abbreviation = "AZ", Name = "Arizona" },
                new State { Id = 04, Abbreviation = "AR", Name = "Arkansas" },
                new State { Id = 05, Abbreviation = "CA", Name = "California" },
                new State { Id = 06, Abbreviation = "CO", Name = "Colorado" },
                new State { Id = 07, Abbreviation = "CT", Name = "Connecticut" },
                new State { Id = 08, Abbreviation = "DE", Name = "Delaware" },
                new State { Id = 09, Abbreviation = "FL", Name = "Florida" },
                new State { Id = 10, Abbreviation = "GA", Name = "Georgia" },
                new State { Id = 11, Abbreviation = "HI", Name = "Hawaii" },
                new State { Id = 12, Abbreviation = "ID", Name = "Idaho" },
                new State { Id = 13, Abbreviation = "IL", Name = "Illinois" },
                new State { Id = 14, Abbreviation = "IN", Name = "Indiana" },
                new State { Id = 15, Abbreviation = "IA", Name = "Iowa" },
                new State { Id = 16, Abbreviation = "KS", Name = "Kansas" },
                new State { Id = 17, Abbreviation = "KY", Name = "Kentucky" },
                new State { Id = 18, Abbreviation = "LA", Name = "Louisiana" },
                new State { Id = 19, Abbreviation = "ME", Name = "Maine" },
                new State { Id = 20, Abbreviation = "MD", Name = "Maryland" },
                new State { Id = 21, Abbreviation = "MA", Name = "Massachusetts" },
                new State { Id = 22, Abbreviation = "MI", Name = "Michigan" },
                new State { Id = 23, Abbreviation = "MN", Name = "Minnesota" },
                new State { Id = 24, Abbreviation = "MS", Name = "Mississippi" },
                new State { Id = 25, Abbreviation = "MO", Name = "Missouri" },
                new State { Id = 26, Abbreviation = "MT", Name = "Montana" },
                new State { Id = 27, Abbreviation = "NE", Name = "Nebraska" },
                new State { Id = 28, Abbreviation = "NV", Name = "Nevada" },
                new State { Id = 29, Abbreviation = "NH", Name = "New Hampshire" },
                new State { Id = 30, Abbreviation = "NJ", Name = "New Jersey" },
                new State { Id = 31, Abbreviation = "NM", Name = "New Mexico" },
                new State { Id = 32, Abbreviation = "NY", Name = "New York" },
                new State { Id = 33, Abbreviation = "NC", Name = "North Carolina" },
                new State { Id = 34, Abbreviation = "ND", Name = "North Dakota" },
                new State { Id = 35, Abbreviation = "OH", Name = "Ohio" },
                new State { Id = 36, Abbreviation = "OK", Name = "Oklahoma" },
                new State { Id = 37, Abbreviation = "OR", Name = "Oregon" },
                new State { Id = 38, Abbreviation = "PA", Name = "Pennsylvania" },
                new State { Id = 39, Abbreviation = "RI", Name = "Rhode Island" },
                new State { Id = 40, Abbreviation = "SC", Name = "South Carolina" },
                new State { Id = 41, Abbreviation = "SD", Name = "South Dakota" },
                new State { Id = 42, Abbreviation = "TN", Name = "Tennessee" },
                new State { Id = 43, Abbreviation = "TX", Name = "Texas" },
                new State { Id = 44, Abbreviation = "UT", Name = "Utah" },
                new State { Id = 45, Abbreviation = "VT", Name = "Vermont" },
                new State { Id = 46, Abbreviation = "VA", Name = "Virginia" },
                new State { Id = 47, Abbreviation = "WA", Name = "Washington" },
                new State { Id = 48, Abbreviation = "WV", Name = "West Virginia" },
                new State { Id = 49, Abbreviation = "WI", Name = "Wisconsin" },
                new State { Id = 50, Abbreviation = "WY", Name = "Wyoming" },
                new State { Id = 51, Abbreviation = "DC", Name = "District of Columbia" },
                new State { Id = 52, Abbreviation = "AS", Name = "American Samoa" },
                new State { Id = 53, Abbreviation = "GU", Name = "Guam" },
                new State { Id = 54, Abbreviation = "MP", Name = "Northern Mariana Islands" },
                new State { Id = 55, Abbreviation = "PR", Name = "Puerto Rico" },
                new State { Id = 56, Abbreviation = "VI", Name = "U.S. Virgin Islands" },
            };

            modelBuilder.Entity<State>(entity => entity.HasData(data));
        }

        private static void SeedUserTable(ModelBuilder modelBuilder)
        {
            var data = new[]
            {
                new User { Id = AdminUserId, FirstName = "System", LastName = "Admin", UserName = "admin", PasswordHash = "", PhoneNumber = "987-654-3210", CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime },
                new User { Id = 2, FirstName = "John", MiddleName = "Q", LastName = "Customer", UserName = "customer", PasswordHash = "", PhoneNumber = "987-654-3210", CreatedById = AdminUserId, CreatedUtc = _seedDateTime, ModifiedById = AdminUserId, ModifiedUtc = _seedDateTime }
            };

            modelBuilder.Entity<User>(entity => entity.HasData(data));
        }
    }
}
