using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropositionManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Supplier_Model_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Propositions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_SupplierId",
                table: "Propositions",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_SupplierId",
                table: "Prices",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Suppliers_SupplierId",
                table: "Prices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Propositions_Suppliers_SupplierId",
                table: "Propositions",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Suppliers_SupplierId",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Propositions_Suppliers_SupplierId",
                table: "Propositions");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Propositions_SupplierId",
                table: "Propositions");

            migrationBuilder.DropIndex(
                name: "IX_Prices_SupplierId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Propositions");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Prices");
        }
    }
}
