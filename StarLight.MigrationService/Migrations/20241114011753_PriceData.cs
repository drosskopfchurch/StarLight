using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarLight.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class PriceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HistoricalPrices",
                columns: new[] { "DateTime", "Symbol", "Price" },
                values: new object[,]
                {
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "AAPL", 150.0 },
                    { new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ADBE", 185.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "AMZN", 3200.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 4, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "BRK.B", 300.0 },
                    { new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "DIS", 135.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "GOOGL", 2800.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "HD", 300.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "JNJ", 160.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "JPM", 130.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "META", 200.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MSFT", 250.0 },
                    { new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NFLX", 35.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NVDA", 500.0 },
                    { new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PEP", 85.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PG", 140.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "UNH", 450.0 },
                    { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "V", 220.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "AAPL" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ADBE" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "AMZN" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 4, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "BRK.B" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "DIS" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "GOOGL" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "HD" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "JNJ" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "JPM" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "META" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MSFT" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NFLX" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NVDA" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PEP" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PG" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "UNH" });

            migrationBuilder.DeleteData(
                table: "HistoricalPrices",
                keyColumns: new[] { "DateTime", "Symbol" },
                keyValues: new object[] { new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "V" });
        }
    }
}
