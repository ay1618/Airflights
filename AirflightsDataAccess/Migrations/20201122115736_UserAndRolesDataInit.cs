using Microsoft.EntityFrameworkCore.Migrations;

namespace AirflightsDataAccess.Migrations
{
    public partial class UserAndRolesDataInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password" },
                values: new object[] { 1, "admin", "Admin", "AQAAAAEAACcQAAAAEBMDOiXZl57nI8xcAYWpxLzBRP8OlfGCf+EnL9QzPZMpFXt2aLpcO+7ZHhh+hJpusw==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password" },
                values: new object[] { 2, "moderator", "Moderator", "AQAAAAEAACcQAAAAEIkwxfF9NSVv3tltY7ATSH6RVnrgkm5WpK5WXCjGT2hOopo3t1T41U5gJe62ic/WWQ==" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
