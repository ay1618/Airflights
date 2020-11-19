using Microsoft.EntityFrameworkCore.Migrations;

namespace AirflightsDataAccess.Migrations
{
    public partial class Flight_RegNum_wasDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flights_RegNum",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "RegNum",
                table: "Flights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegNum",
                table: "Flights",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_RegNum",
                table: "Flights",
                column: "RegNum",
                unique: true);
        }
    }
}
