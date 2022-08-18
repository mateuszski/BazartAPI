using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazart.DataAccess.Migrations
{
    public partial class init32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_ParticipantListId",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "ParticipantListId",
                table: "EventUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_ParticipantListId",
                table: "EventUser",
                newName: "IX_EventUser_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_UsersId",
                table: "EventUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_UsersId",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "EventUser",
                newName: "ParticipantListId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UsersId",
                table: "EventUser",
                newName: "IX_EventUser_ParticipantListId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_ParticipantListId",
                table: "EventUser",
                column: "ParticipantListId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
