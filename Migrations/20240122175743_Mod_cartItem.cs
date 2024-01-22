using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommersShop.Migrations
{
    /// <inheritdoc />
    public partial class Mod_cartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "CartItems",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<int>(
                name: "PriceProduct",
                table: "CartItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceProduct",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "CartItems",
                newName: "Price");
        }
    }
}
