using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommersShop.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUseinRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserInRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserInRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
