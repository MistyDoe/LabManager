using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class IngredientRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientsForMedia_IngredientsForMediaId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_IngredientsForMediaId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "IngredientsForMediaId",
                table: "Ingredient");

            migrationBuilder.CreateTable(
                name: "IngredientIngredientsForMedia",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListOfIngredientsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientIngredientsForMedia", x => new { x.IngredientsId, x.ListOfIngredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientIngredientsForMedia_Ingredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientIngredientsForMedia_IngredientsForMedia_ListOfIngredientsId",
                        column: x => x.ListOfIngredientsId,
                        principalTable: "IngredientsForMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientIngredientsForMedia_ListOfIngredientsId",
                table: "IngredientIngredientsForMedia",
                column: "ListOfIngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientIngredientsForMedia");

            migrationBuilder.AddColumn<int>(
                name: "IngredientsForMediaId",
                table: "Ingredient",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_IngredientsForMediaId",
                table: "Ingredient",
                column: "IngredientsForMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientsForMedia_IngredientsForMediaId",
                table: "Ingredient",
                column: "IngredientsForMediaId",
                principalTable: "IngredientsForMedia",
                principalColumn: "Id");
        }
    }
}
