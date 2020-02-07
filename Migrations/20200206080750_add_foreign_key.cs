using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_Web_Product.Migrations
{
    public partial class add_foreign_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartsId",
                table: "items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_items_CartsId",
                table: "items",
                column: "CartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_items_carts_CartsId",
                table: "items",
                column: "CartsId",
                principalTable: "carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_carts_CartsId",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_CartsId",
                table: "items");

            migrationBuilder.DropColumn(
                name: "CartsId",
                table: "items");
        }
    }
}
