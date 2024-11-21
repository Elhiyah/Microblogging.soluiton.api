using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microblogging.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFollowRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Follows__Followe__37A5467C",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK__Follows__UserId__36B12243",
                table: "Follows");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Follower",
                table: "Follows",
                column: "FollowerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_User",
                table: "Follows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Follower",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_User",
                table: "Follows");

            migrationBuilder.AddForeignKey(
                name: "FK__Follows__Followe__37A5467C",
                table: "Follows",
                column: "FollowerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Follows__UserId__36B12243",
                table: "Follows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
