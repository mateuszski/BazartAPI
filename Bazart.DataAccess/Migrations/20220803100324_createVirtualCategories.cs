﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazart.DataAccess.Migrations
{
    public partial class createVirtualCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductId",
                table: "Categories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductId",
                table: "Categories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Categories");
        }
    }
}
