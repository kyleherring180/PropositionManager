using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropositionManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_CostType_And_PriceTimeConstraint_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostTypeId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dictionary_DayOfWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary_DayOfWeek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceTimeConstraints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaysOfWeek = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UntilDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FromTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    UntilTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTimeConstraints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTimeConstraints_Dictionary_DayOfWeek_DaysOfWeek",
                        column: x => x.DaysOfWeek,
                        principalTable: "Dictionary_DayOfWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceTimeConstraintPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceTimeConstraintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTimeConstraintPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTimeConstraintPrices_PriceTimeConstraints_PriceTimeConstraintId",
                        column: x => x.PriceTimeConstraintId,
                        principalTable: "PriceTimeConstraints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTimeConstraintPrices_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_CostTypeId",
                table: "Prices",
                column: "CostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTimeConstraintPrices_PriceId",
                table: "PriceTimeConstraintPrices",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTimeConstraintPrices_PriceTimeConstraintId",
                table: "PriceTimeConstraintPrices",
                column: "PriceTimeConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTimeConstraints_DaysOfWeek",
                table: "PriceTimeConstraints",
                column: "DaysOfWeek");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_CostTypes_CostTypeId",
                table: "Prices",
                column: "CostTypeId",
                principalTable: "CostTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_CostTypes_CostTypeId",
                table: "Prices");

            migrationBuilder.DropTable(
                name: "CostTypes");

            migrationBuilder.DropTable(
                name: "PriceTimeConstraintPrices");

            migrationBuilder.DropTable(
                name: "PriceTimeConstraints");

            migrationBuilder.DropTable(
                name: "Dictionary_DayOfWeek");

            migrationBuilder.DropIndex(
                name: "IX_Prices_CostTypeId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "CostTypeId",
                table: "Prices");
        }
    }
}
