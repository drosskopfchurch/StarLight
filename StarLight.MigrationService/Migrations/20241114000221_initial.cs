using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarLight.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalPrices",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalPrices", x => new { x.Symbol, x.DateTime });
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Symbol", "Name" },
                values: new object[,]
                {
                    { "AAL", "American Airlines Group Inc." },
                    { "AAPL", "Apple Inc." },
                    { "ABBV", "AbbVie Inc." },
                    { "ADBE", "Adobe Inc." },
                    { "AEE", "Ameren Corporation" },
                    { "AGR", "Avangrid, Inc." },
                    { "AMGN", "Amgen Inc." },
                    { "AMT", "American Tower Corporation" },
                    { "AMZN", "Amazon.com, Inc." },
                    { "ANTM", "Anthem, Inc." },
                    { "AVGO", "Broadcom Inc." },
                    { "AXP", "American Express Company" },
                    { "BA", "Boeing Company" },
                    { "BKNG", "Booking Holdings Inc." },
                    { "BMY", "Bristol-Myers Squibb Company" },
                    { "BRK.B", "Berkshire Hathaway Inc." },
                    { "C", "Citigroup Inc." },
                    { "CAT", "Caterpillar Inc." },
                    { "CHTR", "Charter Communications, Inc." },
                    { "CI", "Cigna Corporation" },
                    { "CMCSA", "Comcast Corporation" },
                    { "CMS", "CMS Energy Corporation" },
                    { "CNP", "CenterPoint Energy, Inc." },
                    { "COP", "ConocoPhillips" },
                    { "COST", "Costco Wholesale Corporation" },
                    { "CRM", "Salesforce.com, Inc." },
                    { "CSCO", "Cisco Systems, Inc." },
                    { "CVS", "CVS Health Corporation" },
                    { "CVX", "Chevron Corporation" },
                    { "D", "Dominion Energy, Inc." },
                    { "DAL", "Delta Air Lines, Inc." },
                    { "DIS", "Walt Disney Company" },
                    { "DTE", "DTE Energy Company" },
                    { "DUK", "Duke Energy Corporation" },
                    { "ED", "Consolidated Edison, Inc." },
                    { "ES", "Eversource Energy" },
                    { "ETR", "Entergy Corporation" },
                    { "EXC", "Exelon Corporation" },
                    { "F", "Ford Motor Company" },
                    { "FE", "FirstEnergy Corp." },
                    { "GE", "General Electric Company" },
                    { "GILD", "Gilead Sciences, Inc." },
                    { "GM", "General Motors Company" },
                    { "GOOGL", "Alphabet Inc." },
                    { "GS", "Goldman Sachs Group, Inc." },
                    { "HD", "Home Depot, Inc." },
                    { "HLT", "Hilton Worldwide Holdings Inc." },
                    { "HON", "Honeywell International Inc." },
                    { "IBM", "International Business Machines Corporation" },
                    { "INTC", "Intel Corporation" },
                    { "INTU", "Intuit Inc." },
                    { "JNJ", "Johnson & Johnson" },
                    { "JPM", "JPMorgan Chase & Co." },
                    { "KO", "Coca-Cola Company" },
                    { "LLY", "Eli Lilly and Company" },
                    { "LMT", "Lockheed Martin Corporation" },
                    { "LNT", "Alliant Energy Corporation" },
                    { "LUV", "Southwest Airlines Co." },
                    { "MA", "Mastercard Incorporated" },
                    { "MAR", "Marriott International, Inc." },
                    { "MCD", "McDonald's Corporation" },
                    { "MDLZ", "Mondelez International, Inc." },
                    { "MDT", "Medtronic plc" },
                    { "META", "Meta Platforms, Inc." },
                    { "MMM", "3M Company" },
                    { "MS", "Morgan Stanley" },
                    { "MSFT", "Microsoft Corporation" },
                    { "MU", "Micron Technology, Inc." },
                    { "NEE", "NextEra Energy, Inc." },
                    { "NFLX", "Netflix, Inc." },
                    { "NI", "NiSource Inc." },
                    { "NKE", "Nike, Inc." },
                    { "NOW", "ServiceNow, Inc." },
                    { "NVDA", "NVIDIA Corporation" },
                    { "PCG", "PG&E Corporation" },
                    { "PEG", "Public Service Enterprise Group Incorporated" },
                    { "PEP", "PepsiCo, Inc." },
                    { "PFE", "Pfizer Inc." },
                    { "PG", "Procter & Gamble Co." },
                    { "PM", "Philip Morris International Inc." },
                    { "PPL", "PPL Corporation" },
                    { "PYPL", "PayPal Holdings, Inc." },
                    { "QCOM", "Qualcomm Incorporated" },
                    { "RTX", "Raytheon Technologies Corporation" },
                    { "SBUX", "Starbucks Corporation" },
                    { "SO", "Southern Company" },
                    { "SRE", "Sempra Energy" },
                    { "SYK", "Stryker Corporation" },
                    { "T", "AT&T Inc." },
                    { "TGT", "Target Corporation" },
                    { "TMO", "Thermo Fisher Scientific Inc." },
                    { "TXN", "Texas Instruments Incorporated" },
                    { "UNH", "UnitedHealth Group Incorporated" },
                    { "UNP", "Union Pacific Corporation" },
                    { "UPS", "United Parcel Service, Inc." },
                    { "V", "Visa Inc." },
                    { "VZ", "Verizon Communications Inc." },
                    { "WMT", "Walmart Inc." },
                    { "XEL", "Xcel Energy Inc." },
                    { "XOM", "Exxon Mobil Corporation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "HistoricalPrices");
        }
    }
}
