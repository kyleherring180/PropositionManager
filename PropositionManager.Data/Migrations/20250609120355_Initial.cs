using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PropositionManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionary_Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dictionary_PriceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary_PriceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dictionary_ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dictionary_TariffDurationUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary_TariffDurationUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PeriodUntil = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TariffDurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffDurationUnit = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffDurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffDurations_Dictionary_TariffDurationUnit_TariffDurationUnit",
                        column: x => x.TariffDurationUnit,
                        principalTable: "Dictionary_TariffDurationUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,6)", precision: 19, scale: 6, nullable: false),
                    TariffDurationId = table.Column<int>(type: "int", nullable: false),
                    PriceStatus = table.Column<int>(type: "int", nullable: false),
                    PeriodFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PeriodUntil = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Dictionary_Currency_Currency",
                        column: x => x.Currency,
                        principalTable: "Dictionary_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_Dictionary_PriceStatus_PriceStatus",
                        column: x => x.PriceStatus,
                        principalTable: "Dictionary_PriceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_Dictionary_ProductType_ProductType",
                        column: x => x.ProductType,
                        principalTable: "Dictionary_ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_TariffDurations_TariffDurationId",
                        column: x => x.TariffDurationId,
                        principalTable: "TariffDurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropositionPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PeriodUntil = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropositionPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropositionPrices_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropositionPrices_Propositions_PropositionId",
                        column: x => x.PropositionId,
                        principalTable: "Propositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dictionary_Currency",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Euro" },
                    { 2, "SwissFranc" },
                    { 3, "UsDollar" }
                });

            migrationBuilder.InsertData(
                table: "Dictionary_PriceStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Created" },
                    { 2, "InReview" },
                    { 3, "Approved" },
                    { 4, "Rejected" },
                    { 5, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "Dictionary_ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Electricity" },
                    { 2, "Gas" },
                    { 3, "Internet" },
                    { 4, "MobileMinutes" },
                    { 5, "MobileData" }
                });

            migrationBuilder.InsertData(
                table: "Dictionary_TariffDurationUnit",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Second" },
                    { 2, "Minute" },
                    { 3, "Hour" },
                    { 4, "Day" },
                    { 5, "Month" },
                    { 6, "Year" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_Currency",
                table: "Prices",
                column: "Currency");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_PriceStatus",
                table: "Prices",
                column: "PriceStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ProductType",
                table: "Prices",
                column: "ProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_TariffDurationId",
                table: "Prices",
                column: "TariffDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_PropositionPrices_PriceId",
                table: "PropositionPrices",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PropositionPrices_PropositionId",
                table: "PropositionPrices",
                column: "PropositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffDurations_TariffDurationUnit",
                table: "TariffDurations",
                column: "TariffDurationUnit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropositionPrices");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Propositions");

            migrationBuilder.DropTable(
                name: "Dictionary_Currency");

            migrationBuilder.DropTable(
                name: "Dictionary_PriceStatus");

            migrationBuilder.DropTable(
                name: "Dictionary_ProductType");

            migrationBuilder.DropTable(
                name: "TariffDurations");

            migrationBuilder.DropTable(
                name: "Dictionary_TariffDurationUnit");
        }
    }
}
