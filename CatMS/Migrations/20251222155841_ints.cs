using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatMS.Migrations
{
    /// <inheritdoc />
    public partial class ints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPubliced",
                table: "Cats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3f18c02-f33d-431b-b9ca-93df8e818e41", "AQAAAAIAAYagAAAAENGUA8OlL6nT38wL/V5rI/IkHnX546kBbb0HUakhYIjW6qJzRlVV6RGPCUoqdmLd+w==", "76408953-f8f1-4079-b351-61c89e1f91dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "179fbe79-2417-4421-afc4-df0b6405d521", "AQAAAAIAAYagAAAAECCiSuCzjdMrY366Q9ioJl2D9pm8rAhFSCoIPfK1IKhBmBbCARsba4XO+c1vtoMeBA==", "d51cd808-056d-436b-81fd-9e550db6aeaa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPubliced",
                table: "Cats");

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
    }
}
