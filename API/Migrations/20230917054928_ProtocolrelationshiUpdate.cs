using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ProtocolrelationshiUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMedia_Media_ListOfIngredientsId",
                table: "IngredientMedia");

            migrationBuilder.RenameColumn(
                name: "ListOfIngredientsId",
                table: "IngredientMedia",
                newName: "ListOfMediasId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientMedia_ListOfIngredientsId",
                table: "IngredientMedia",
                newName: "IX_IngredientMedia_ListOfMediasId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMedia_Media_ListOfMediasId",
                table: "IngredientMedia",
                column: "ListOfMediasId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMedia_Media_ListOfMediasId",
                table: "IngredientMedia");

            migrationBuilder.RenameColumn(
                name: "ListOfMediasId",
                table: "IngredientMedia",
                newName: "ListOfIngredientsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientMedia_ListOfMediasId",
                table: "IngredientMedia",
                newName: "IX_IngredientMedia_ListOfIngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMedia_Media_ListOfIngredientsId",
                table: "IngredientMedia",
                column: "ListOfIngredientsId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
