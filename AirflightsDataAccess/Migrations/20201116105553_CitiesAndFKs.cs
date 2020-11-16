using Microsoft.EntityFrameworkCore.Migrations;

namespace AirflightsDataAccess.Migrations
{
    public partial class CitiesAndFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FromCityId",
                table: "Flights",
                column: "FromCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ToCityId",
                table: "Flights",
                column: "ToCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cities_FromCityId",
                table: "Flights",
                column: "FromCityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cities_ToCityId",
                table: "Flights",
                column: "ToCityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cities_FromCityId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cities_ToCityId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Flights_FromCityId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_ToCityId",
                table: "Flights");
        }
    }
}
