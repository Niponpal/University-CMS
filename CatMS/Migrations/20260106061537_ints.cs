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
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3eeaf948-9acb-4f07-ae43-eb85c3a08479", "AQAAAAIAAYagAAAAEHEBtpXV8jjxTqckx60Uqkto46WdgxZ9DS9KcHG3fbME8FRPpsrB3upmgRTM6dWEkw==", "19068a60-203f-4b57-907f-299993dbdadd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8bca102-0951-4fe6-93f0-332d1d91c7d0", "AQAAAAIAAYagAAAAELwegKi3YWbOv0mxlKzdagbn5xuqrq8Be/kcZZCqLVxXySj7Smnv4fCQ6V8QHUmoKA==", "429a07e2-d628-479b-85eb-847f6551105a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b33b6f9-aecd-40ff-8f83-299fe291fbde", "AQAAAAIAAYagAAAAEBv1MopVPvyndzpSfl6jDVhDaC0vweD5l3mZPDghYDSxOHjvdHweFtvaL0RZAKFjCA==", "7b0eae95-0808-448c-aead-460a39a89cd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38829836-3339-4c91-a5f0-7daad1f83547", "AQAAAAIAAYagAAAAEGnN5tmPqw3MMa/oQsqFsjI8t5LJPhT3H++hSFu19wTr+c5amsQofsuHrPSaE8rZxA==", "75937521-b8f2-4628-bf9e-106e59c4cdc3" });
        }
    }
}
