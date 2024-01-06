using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class AddExtend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Food",
                newName: "ExtendFood_Price");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Food",
                newName: "ExtendFood_Qut");

            migrationBuilder.RenameColumn(
                name: "Qut",
                table: "Cart",
                newName: "ExtendCart_Qut");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cart",
                newName: "ExtendCart_Price");

            migrationBuilder.AlterColumn<double>(
                name: "ExtendFood_Price",
                table: "Food",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExtendFood_Price",
                table: "Food",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ExtendFood_Qut",
                table: "Food",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ExtendCart_Qut",
                table: "Cart",
                newName: "Qut");

            migrationBuilder.RenameColumn(
                name: "ExtendCart_Price",
                table: "Cart",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Food",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
