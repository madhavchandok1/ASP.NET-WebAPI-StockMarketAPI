using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ba28fa7-c422-4a2b-b042-0eb9714dc4e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2cb32ef-359e-4718-a2a7-22cfb3a6b64d");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "023be572-391f-4f09-a47b-e4281f00c3d7", null, "Admin", "ADMIN" },
                    { "5f578730-a5f0-437f-b877-047aaaae6be6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "023be572-391f-4f09-a47b-e4281f00c3d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f578730-a5f0-437f-b877-047aaaae6be6");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ba28fa7-c422-4a2b-b042-0eb9714dc4e3", null, "User", "USER" },
                    { "c2cb32ef-359e-4718-a2a7-22cfb3a6b64d", null, "Admin", "ADMIN" }
                });
        }
    }
}
