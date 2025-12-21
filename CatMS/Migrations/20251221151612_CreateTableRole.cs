using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatMS.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "NormalizedName",
                value: "Seller");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "NormalizedName",
                value: "Buyer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb83fe53-fa8c-4484-b280-f99090e08aa1", "AQAAAAIAAYagAAAAEEcIcnc1xBI8JqB7d8xB+2tHfyQgm+zV7TLcNpLqbQn434X7VxKuhbiUxd/rKAt1+Q==", "c1dbf403-1d89-4a35-8d26-7ead30eb4935" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65627f63-7d6c-416f-81d8-35606b488c2a", "AQAAAAIAAYagAAAAEAMpKlhELuO1rAXGW2BnFzyjR81A5tTnB89jK0MY835SIuDILEIgrG5dGQL29+Iuvg==", "7bf8a349-5078-49c4-a8b4-6afcd8ca7103" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "NormalizedName",
                value: "EMPLOYEE");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "NormalizedName",
                value: "CUSTOMER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e4bdb17-3c67-41df-933a-f2d5c2bd9ca2", "AQAAAAIAAYagAAAAEMvY2KHaY0reHC0NFlAplEh5eZmyqR8inWqOOCFz3xWihYj7nGFILCCDsdRV987jzA==", "f959b63f-7060-4b2c-add7-bb674f0cceef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc201702-541f-4587-a67b-2d685137fba5", "AQAAAAIAAYagAAAAENNUNeIl2LtIdFD+oWOhSKGusQ7981MLzT9C6uZe73U2QumYLHYUG3qLaUM48r3l+Q==", "9a76fc41-6fb3-4bf3-9e56-7d8db6ce8a1c" });
        }
    }
}
