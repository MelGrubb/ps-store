using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Domain.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Abbreviation = table.Column<string>(nullable: true),
                    StateLabel = table.Column<string>(maxLength: 50, nullable: true),
                    PostalCodeLabel = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Abbreviation = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    DeletedById = table.Column<int>(nullable: true),
                    DeletedUtc = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "Decimal(10, 2)", nullable: false),
                    ProductStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductStatuses_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "ProductStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    DeletedById = table.Column<int>(nullable: true),
                    DeletedUtc = table.Column<DateTime>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Line1 = table.Column<string>(nullable: true),
                    Line2 = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    DeletedById = table.Column<int>(nullable: true),
                    DeletedUtc = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    BillingAddressId = table.Column<int>(nullable: true),
                    OrderStatusId = table.Column<int>(nullable: false),
                    ShippingAddressId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedUtc = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(10, 2)", nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 1, null, "Clothing", null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Abbreviation", "Description", "Name", "PostalCodeLabel", "StateLabel" },
                values: new object[,]
                {
                    { 1, "USA", "The United States of America", "The United States of America", "Zipcode", "State" },
                    { 2, "CAN", "Canada", "Canada", "Postal Code", "Province" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Order has been received, but not yet processed.", "Received" },
                    { 2, "Order has been processed, but not yet shipped.", "Processing" },
                    { 3, "Order is in the process of being shipped.", "Shipping" },
                    { 4, "Order has been shipped.", "Shipped" }
                });

            migrationBuilder.InsertData(
                table: "ProductStatuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Product is available to order.", "In-Stock" },
                    { 2, "Product can be ordered, but delivery time is unknown.", "Back-Ordered" },
                    { 3, "Product is unavailable for ordering.", "Discontinued" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "CountryId", "Description", "Name" },
                values: new object[,]
                {
                    { 41, "SD", null, null, "South Dakota" },
                    { 40, "SC", null, null, "South Carolina" },
                    { 39, "RI", null, null, "Rhode Island" },
                    { 38, "PA", null, null, "Pennsylvania" },
                    { 37, "OR", null, null, "Oregon" },
                    { 32, "NY", null, null, "New York" },
                    { 35, "OH", null, null, "Ohio" },
                    { 34, "ND", null, null, "North Dakota" },
                    { 33, "NC", null, null, "North Carolina" },
                    { 42, "TN", null, null, "Tennessee" },
                    { 31, "NM", null, null, "New Mexico" },
                    { 36, "OK", null, null, "Oklahoma" },
                    { 43, "TX", null, null, "Texas" },
                    { 48, "WV", null, null, "West Virginia" },
                    { 45, "VT", null, null, "Vermont" },
                    { 46, "VA", null, null, "Virginia" },
                    { 47, "WA", null, null, "Washington" },
                    { 30, "NJ", null, null, "New Jersey" },
                    { 49, "WI", null, null, "Wisconsin" },
                    { 50, "WY", null, null, "Wyoming" },
                    { 51, "DC", null, null, "District of Columbia" },
                    { 52, "AS", null, null, "American Samoa" },
                    { 53, "GU", null, null, "Guam" },
                    { 54, "MP", null, null, "Northern Mariana Islands" },
                    { 55, "PR", null, null, "Puerto Rico" },
                    { 56, "VI", null, null, "U.S. Virgin Islands" },
                    { 44, "UT", null, null, "Utah" },
                    { 29, "NH", null, null, "New Hampshire" },
                    { 24, "MS", null, null, "Mississippi" },
                    { 27, "NE", null, null, "Nebraska" },
                    { 1, "AL", null, null, "Alabama" },
                    { 2, "AK", null, null, "Alaska" },
                    { 3, "AZ", null, null, "Arizona" },
                    { 4, "AR", null, null, "Arkansas" },
                    { 5, "CA", null, null, "California" },
                    { 6, "CO", null, null, "Colorado" },
                    { 7, "CT", null, null, "Connecticut" },
                    { 8, "DE", null, null, "Delaware" },
                    { 9, "FL", null, null, "Florida" },
                    { 10, "GA", null, null, "Georgia" },
                    { 11, "HI", null, null, "Hawaii" },
                    { 12, "ID", null, null, "Idaho" },
                    { 28, "NV", null, null, "Nevada" },
                    { 13, "IL", null, null, "Illinois" },
                    { 15, "IA", null, null, "Iowa" },
                    { 16, "KS", null, null, "Kansas" },
                    { 17, "KY", null, null, "Kentucky" },
                    { 18, "LA", null, null, "Louisiana" },
                    { 19, "ME", null, null, "Maine" },
                    { 20, "MD", null, null, "Maryland" },
                    { 21, "MA", null, null, "Massachusetts" },
                    { 22, "MI", null, null, "Michigan" },
                    { 23, "MN", null, null, "Minnesota" },
                    { 25, "MO", null, null, "Missouri" },
                    { 26, "MT", null, null, "Montana" },
                    { 14, "IN", null, null, "Indiana" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedById", "CreatedUtc", "DeletedById", "DeletedUtc", "FirstName", "LastName", "MiddleName", "ModifiedById", "ModifiedUtc", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", "Admin", null, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "987-654-3210", "admin" },
                    { 2, null, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "John", "Customer", "Q", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "987-654-3210", "customer" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CreatedById", "CreatedUtc", "DeletedById", "DeletedUtc", "Line1", "Line2", "ModifiedById", "ModifiedUtc", "StateId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Anytown", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Billing Dept.", "123 Any St.", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "12345" },
                    { 2, "Anytown", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Receiving Dept.", "123 Any St.", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "12345" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, null, "Men's", 1 },
                    { 3, null, "Women's", 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BillingAddressId", "CreatedById", "CreatedUtc", "ModifiedById", "ModifiedUtc", "OrderStatusId", "ShippingAddressId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 1 },
                    { 2, 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 3, 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 1 },
                    { 4, 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedById", "CreatedUtc", "DeletedById", "DeletedUtc", "Description", "ModifiedById", "ModifiedUtc", "Name", "Price", "ProductStatusId" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "A men's t-shirt", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T-Shirt", 1.00m, 1 },
                    { 2, 3, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "A wommen's t-shirt", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T-Shirt", 2.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedById", "CreatedUtc", "ModifiedById", "ModifiedUtc", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1.00m, 1, 1 },
                    { 2, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1.00m, 2, 1 },
                    { 3, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1.00m, 1, 1 },
                    { 4, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1.00m, 2, 1 },
                    { 5, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1.00m, 1, 1 },
                    { 6, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1.00m, 2, 1 },
                    { 7, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1.00m, 1, 1 },
                    { 8, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1.00m, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStatusId",
                table: "Products",
                column: "ProductStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductStatuses");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
