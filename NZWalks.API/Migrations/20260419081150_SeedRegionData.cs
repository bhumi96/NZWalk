using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedRegionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "RegionId", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("15a85ab3-0153-4021-8cea-2ef6ffd56598"), "Region3", "Region East", null },
                    { new Guid("920b4881-b3b6-4422-aa07-8e00b0069b0e"), "Region1", "Region North", null },
                    { new Guid("f5af8551-16cc-4e1e-bef5-12a4d7afec77"), "Region2", "Region South", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "RegionId",
                keyValue: new Guid("15a85ab3-0153-4021-8cea-2ef6ffd56598"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "RegionId",
                keyValue: new Guid("920b4881-b3b6-4422-aa07-8e00b0069b0e"));

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "RegionId",
                keyValue: new Guid("f5af8551-16cc-4e1e-bef5-12a4d7afec77"));
        }
    }
}
