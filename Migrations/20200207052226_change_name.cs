using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_Web_Product.Migrations
{
    public partial class change_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "items");

            migrationBuilder.AddColumn<int>(
                name: "total_item_in_cart",
                table: "items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_item_in_cart",
                table: "items");

            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
