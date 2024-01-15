using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommersShop.Migrations
{
    /// <inheritdoc />
    public partial class CartMgModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_Carts_CartId",
                table: "cartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_Users_UserId",
                table: "cartItems");

            migrationBuilder.DropIndex(
                name: "IX_cartItems_UserId",
                table: "cartItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "cartItems");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "cartItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_Carts_CartId",
                table: "cartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartItems_Carts_CartId",
                table: "cartItems");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "cartItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "cartItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_UserId",
                table: "cartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_Carts_CartId",
                table: "cartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cartItems_Users_UserId",
                table: "cartItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
