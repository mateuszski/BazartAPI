using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazart.DataAccess.Migrations
{
    public partial class init35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerId",
                table: "Events",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_OwnerId",
                table: "Events",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_OwnerId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_OwnerId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Events");
        }
    }
}
