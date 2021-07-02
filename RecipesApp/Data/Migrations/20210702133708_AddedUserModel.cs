using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipesApp.Migrations
{
    public partial class AddedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeUserId",
                table: "Recipes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeUserId",
                table: "Recipes",
                column: "RecipeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_RecipeUserId",
                table: "Recipes",
                column: "RecipeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_RecipeUserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
