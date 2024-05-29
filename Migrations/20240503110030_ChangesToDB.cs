using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1092a818-211b-4797-97d0-02b8f451ed4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a45253f-862b-41c7-90c7-864e85b72918");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ba28fa7-c422-4a2b-b042-0eb9714dc4e3", null, "User", "USER" },
                    { "c2cb32ef-359e-4718-a2a7-22cfb3a6b64d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1092a818-211b-4797-97d0-02b8f451ed4b", null, "User", "USER" },
                    { "2a45253f-862b-41c7-90c7-864e85b72918", null, "Admin", "ADMIN" }
                });
        }
    }
}
