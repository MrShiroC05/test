using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class CheangName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Cate_CategoryId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cate",
                table: "Cate");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "Cate",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_CategoryId",
                table: "Food",
                newName: "IX_Food_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Category_CategoryId",
                table: "Food",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Category_CategoryId",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Cate");

            migrationBuilder.RenameIndex(
                name: "IX_Food_CategoryId",
                table: "Foods",
                newName: "IX_Foods_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cate",
                table: "Cate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Cate_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "Cate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
