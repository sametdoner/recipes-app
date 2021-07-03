using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipesApp.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Recipes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Recipes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ratings",
                table: "Recipes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
