using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PropositionManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Dictionary_DaysOfWeek_Enum_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dictionary_DayOfWeek",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 4, "Wednesday" },
                    { 8, "Thursday" },
                    { 16, "Friday" },
                    { 31, "Weekdays" },
                    { 32, "Saturday" },
                    { 64, "Sunday" },
                    { 96, "Weekends" },
                    { 127, "AllDays" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Dictionary_DayOfWeek",
                keyColumn: "Id",
                keyValue: 127);
        }
    }
}
