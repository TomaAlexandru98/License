using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace License.DataAccess.Migrations
{
    public partial class ChangeIntToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId1",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Subcategories_CategoryId1",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Subcategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Subcategories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Subcategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "Subcategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId1",
                table: "Subcategories",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId1",
                table: "Subcategories",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
