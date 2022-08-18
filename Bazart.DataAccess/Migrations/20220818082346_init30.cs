using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazart.DataAccess.Migrations
{
    public partial class init30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_User.Id",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCarts_ProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_User.Id",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "User.Id",
                table: "ShoppingCarts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_User.Id",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_UserId");

            migrationBuilder.RenameColumn(
                name: "User.Id",
                table: "Events",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_User.Id",
                table: "Events",
                newName: "IX_Events_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_OwnerId",
                table: "Events",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_OwnerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCarts",
                newName: "User.Id");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_User.Id");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Events",
                newName: "User.Id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_OwnerId",
                table: "Events",
                newName: "IX_Events_User.Id");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_User.Id",
                table: "Events",
                column: "User.Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCarts_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_User.Id",
                table: "ShoppingCarts",
                column: "User.Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
