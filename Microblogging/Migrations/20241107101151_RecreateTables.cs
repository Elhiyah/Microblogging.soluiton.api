using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microblogging.Migrations
{
    /// <inheritdoc />
    public partial class RecreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Users__3214EC0719610809",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUsers");

            migrationBuilder.RenameIndex(
                name: "UQ__Users__C9F2845611D43C9C",
                table: "AppUsers",
                newName: "UQ__AppUsers__C9F2845611D43C9C");

            migrationBuilder.RenameIndex(
                name: "UQ__Users__A9D10534449B1C77",
                table: "AppUsers",
                newName: "UQ__AppUsers__A9D10534449B1C77");

            migrationBuilder.AddPrimaryKey(
                name: "PK__AppUsers__3214EC0719610809",
                table: "AppUsers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__AppUsers__3214EC0719610809",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "UQ__AppUsers__C9F2845611D43C9C",
                table: "Users",
                newName: "UQ__Users__C9F2845611D43C9C");

            migrationBuilder.RenameIndex(
                name: "UQ__AppUsers__A9D10534449B1C77",
                table: "Users",
                newName: "UQ__Users__A9D10534449B1C77");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users__3214EC0719610809",
                table: "Users",
                column: "Id");
        }
    }
}
