using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtControl.Infrastructure.Migrations
{
    public partial class WorkSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndWorkAt",
                table: "Positions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartWorkAt",
                table: "Positions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndWorkAt", "StartWorkAt" },
                values: new object[] { 18, 9 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndWorkAt", "StartWorkAt" },
                values: new object[] { 18, 9 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndWorkAt", "StartWorkAt" },
                values: new object[] { 21, 9 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndWorkAt",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "StartWorkAt",
                table: "Positions");
        }
    }
}
