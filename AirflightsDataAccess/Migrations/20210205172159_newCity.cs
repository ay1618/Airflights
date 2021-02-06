using Microsoft.EntityFrameworkCore.Migrations;

namespace AirflightsDataAccess.Migrations
{
    public partial class newCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 4, "SEU", "Сеул" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
