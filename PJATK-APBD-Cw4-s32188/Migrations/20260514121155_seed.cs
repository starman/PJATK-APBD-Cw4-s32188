using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PJATK_APBD_Cw4_s32188.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturer",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "AMD", new DateOnly(1969, 5, 1), "Advanced Micro Devices" },
                    { 2, "NV", new DateOnly(1993, 4, 5), "Nvidia Corporation" },
                    { 3, "COR", new DateOnly(1994, 1, 1), "Corsair Gaming Inc." }
                });

            migrationBuilder.InsertData(
                table: "ComponentType",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Processor" },
                    { 2, "GPU", "Graphics Card" },
                    { 3, "RAM", "Memory" }
                });

            migrationBuilder.InsertData(
                table: "PC",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 14, 14, 11, 55, 64, DateTimeKind.Local).AddTicks(3777), "Office Computer", 12, 24, 11.5f },
                    { 2, new DateTime(2026, 5, 14, 14, 11, 55, 66, DateTimeKind.Local).AddTicks(9785), "Games Machine", 3, 36, 13.5f },
                    { 3, new DateTime(2026, 5, 14, 14, 11, 55, 66, DateTimeKind.Local).AddTicks(9807), "Universal Computer", 6, 48, 11f }
                });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "CPU4567890", 1, 1, "Super fast CPU", "Ryzen 7800x" },
                    { "GPU4567890", 2, 2, "High-end graphics card", "RTX 4090" },
                    { "RAM4567890", 3, 3, "16GB RAM module", "Corsair DDR 5 16GB" }
                });

            migrationBuilder.InsertData(
                table: "PCComponent",
                columns: new[] { "ComponentCode", "PCId", "Amount" },
                values: new object[,]
                {
                    { "CPU4567890", 1, 1 },
                    { "RAM4567890", 1, 2 },
                    { "GPU4567890", 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PC",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PCComponent",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "CPU4567890", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponent",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "RAM4567890", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponent",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "GPU4567890", 2 });

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Code",
                keyValue: "CPU4567890");

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Code",
                keyValue: "GPU4567890");

            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Code",
                keyValue: "RAM4567890");

            migrationBuilder.DeleteData(
                table: "PC",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PC",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentType",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
