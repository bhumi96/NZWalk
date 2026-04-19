using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("6372c198-ccb1-47f5-b420-9111a98c5cf8"), "Hard" },
                    { new Guid("7a2de582-caf2-46fa-a3c2-ff395c2078a7"), "Easy" },
                    { new Guid("e4cb354e-15b2-4061-b7b0-7581f0c74926"), "Medium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: new Guid("6372c198-ccb1-47f5-b420-9111a98c5cf8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: new Guid("7a2de582-caf2-46fa-a3c2-ff395c2078a7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "DifficultyId",
                keyValue: new Guid("e4cb354e-15b2-4061-b7b0-7581f0c74926"));
        }
    }
}
