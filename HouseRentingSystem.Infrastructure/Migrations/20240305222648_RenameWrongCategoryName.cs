using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class RenameWrongCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Categories_CategortId",
                table: "Houses");

            migrationBuilder.RenameColumn(
                name: "CategortId",
                table: "Houses",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_CategortId",
                table: "Houses",
                newName: "IX_Houses_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Categories_CategoryId",
                table: "Houses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Categories_CategoryId",
                table: "Houses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Houses",
                newName: "CategortId");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_CategoryId",
                table: "Houses",
                newName: "IX_Houses_CategortId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Categories_CategortId",
                table: "Houses",
                column: "CategortId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
