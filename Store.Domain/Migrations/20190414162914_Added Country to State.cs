using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Domain.Migrations
{
    public partial class AddedCountrytoState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "States",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCodeLabel",
                table: "Countries",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateLabel",
                table: "Countries",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PostalCodeLabel", "StateLabel" },
                values: new object[] { "PostalCode", "State" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PostalCodeLabel", "StateLabel" },
                values: new object[] { "Postal Code", "Province/Territory" });

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 17,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 18,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 19,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 20,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 21,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 22,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 23,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 24,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 25,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 26,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 27,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 28,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 29,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 30,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 31,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 32,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 33,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 34,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 35,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 36,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 37,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 38,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 39,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 40,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 41,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 42,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 43,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 44,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 45,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 46,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 47,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 48,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 49,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 50,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 51,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 52,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 53,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 54,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 55,
                column: "CountryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 56,
                column: "CountryId",
                value: 1);

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "CountryId", "Description", "Name" },
                values: new object[,]
                {
                    { 67, "NT", 2, null, "Northwest Territories" },
                    { 66, "SK", 2, null, "Saskatchewan" },
                    { 65, "QC", 2, null, "Quebec" },
                    { 64, "PE", 2, null, "Prince Edward Island" },
                    { 63, "ON", 2, null, "Ontario" },
                    { 61, "NL", 2, null, "Newfoundland and Labrador" },
                    { 68, "NU", 2, null, "Nunavut" },
                    { 60, "NB", 2, null, "New Brunswick" },
                    { 59, "MB", 2, null, "Manitoba" },
                    { 58, "BC", 2, null, "British Columbia" },
                    { 57, "AB", 2, null, "Alberta" },
                    { 62, "NS", 2, null, "Nova Scotia" },
                    { 69, "YT", 2, null, "Yukon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryId",
                table: "States");

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "PostalCodeLabel",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "StateLabel",
                table: "Countries");
        }
    }
}
