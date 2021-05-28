using Microsoft.EntityFrameworkCore.Migrations;

namespace License.DataAccess.Migrations
{
    public partial class IsBlockedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Subcategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Categories");
        }
    }
}
