using Microsoft.EntityFrameworkCore.Migrations;

namespace AirflightsDataAccess.Migrations
{
    public partial class RolesCodeIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Roles_Code",
                table: "Roles",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_Code",
                table: "Roles");
        }
    }
}
