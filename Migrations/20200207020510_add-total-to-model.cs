using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_Web_Product.Migrations
{
    public partial class addtotaltomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "total",
                table: "carts");

            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "items");

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
