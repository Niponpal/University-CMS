using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatMS.Migrations
{
    /// <inheritdoc />
    public partial class createOrdertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CatId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CatId",
                table: "Orders",
                column: "CatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a0c0fd-cb08-4f2e-b63a-8840bf60b4e5", "AQAAAAIAAYagAAAAEO0SJCXpQglveN3S5WW4EAxMV5SMgCFEq7y275brYkrZCKSopiSBA/j8CMdevK4IdA==", "e4729934-26eb-4cc9-a914-69b38c0ff25e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73663366-5c3b-4a77-9249-8def56d338e5", "AQAAAAIAAYagAAAAEPyu5nPDFVRBYH38I8L6tLcEiv9Fk4f4RWYVs/ahQ715j8oLbJXkcq3CIBBHxnOkzg==", "b01ffd07-3f98-40b3-9aca-43968b41e4a4" });
        }
    }
}
