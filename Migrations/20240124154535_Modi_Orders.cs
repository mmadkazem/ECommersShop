using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommersShop.Migrations
{
    /// <inheritdoc />
    public partial class Modi_Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestPays_Users_UserId1",
                table: "RequestPays");

            migrationBuilder.DropIndex(
                name: "IX_RequestPays_UserId1",
                table: "RequestPays");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RequestPays");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RequestPays",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "RefId",
                table: "RequestPays",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_RequestPays_UserId",
                table: "RequestPays",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestPays_Users_UserId",
                table: "RequestPays",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestPays_Users_UserId",
                table: "RequestPays");

            migrationBuilder.DropIndex(
                name: "IX_RequestPays_UserId",
                table: "RequestPays");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "RequestPays",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "RefId",
                table: "RequestPays",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "RequestPays",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestPays_UserId1",
                table: "RequestPays",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestPays_Users_UserId1",
                table: "RequestPays",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
