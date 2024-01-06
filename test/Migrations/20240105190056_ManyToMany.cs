using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_IdentityUserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_IdentityUserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "IdFood",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TableRevenue",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRevenue", x => new { x.UserId, x.CartId });
                    table.ForeignKey(
                        name: "FK_TableRevenue_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableRevenue_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableRevenue_CartId",
                table: "TableRevenue",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableRevenue");

            migrationBuilder.DropColumn(
                name: "IdFood",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_IdentityUserId",
                table: "Cart",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_IdentityUserId",
                table: "Cart",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
