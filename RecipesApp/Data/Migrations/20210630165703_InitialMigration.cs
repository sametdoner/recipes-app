using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipesApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Recipes",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Recipes",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "CookingAdvic",
                table: "Recipes",
                newName: "CookingAdvice");

            migrationBuilder.AlterColumn<int>(
                name: "Ratings",
                table: "Recipes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Recipes",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Recipes",
                newName: "Images");

            migrationBuilder.RenameColumn(
                name: "CookingAdvice",
                table: "Recipes",
                newName: "CookingAdvic");

            migrationBuilder.AlterColumn<int>(
                name: "Ratings",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
