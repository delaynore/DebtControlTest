using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtControl.Infrastructure.Migrations
{
    public partial class Violations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEveningScheduleViolation",
                table: "Shifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMorningSchuduleViolation",
                table: "Shifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEveningScheduleViolation",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "IsMorningSchuduleViolation",
                table: "Shifts");
        }
    }
}
