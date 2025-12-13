using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatMS.Migrations
{
    /// <inheritdoc />
    public partial class createOrdertablenew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca7b59b0-c110-4da9-914f-a937ce8d1b75", "AQAAAAIAAYagAAAAENPAlNWu5mndd4/ZKJ+EOdEAVYX1D1XM+zFvBuvRw87ARAix+viNl3dVOxlR6Onitg==", "7b92edb5-c7bc-4103-b7f7-952ae1f594c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "937f095d-958d-4a8a-934d-cb2b7df6a8af", "AQAAAAIAAYagAAAAEFHfzNRaJ/kQdhvLdm+VmuPf/H/Nj8glkd2H+4gD9OxmUy3+U1EoD3yyi+cxkUxKdg==", "f892e979-1832-4856-bd9b-ff8a1bd7ac5f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41466731-d5d2-465f-b9a4-317486d4c081", "AQAAAAIAAYagAAAAEIvl309uf939vN1io7hKFxRI7qwlnbz4MAPY2hEOgT7ezGZB4OuX03enAcl7nv1swg==", "f30ce58f-fa05-41e5-816e-c9a39e3fd848" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "527c106f-7b78-4e14-a18e-a328eb274876", "AQAAAAIAAYagAAAAEKln+peGqthMMwK1aYB3HY7ds+HfqeVa+8ZaOd2GUpsynFUfeBuSQHlfClfXrSCbkg==", "5a3cab93-9bd8-4bf6-b721-150de27cd050" });
        }
    }
}
