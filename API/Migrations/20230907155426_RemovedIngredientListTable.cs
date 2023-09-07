using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIngredientListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Stage_StageId",
                table: "Media");

            migrationBuilder.DropTable(
                name: "IngredientIngredientsForMedia");

            migrationBuilder.DropTable(
                name: "IngredientsForMedia");

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "Media",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "IngredientMedia",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListOfIngredientsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMedia", x => new { x.IngredientsId, x.ListOfIngredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientMedia_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMedia_Media_ListOfIngredientsId",
                        column: x => x.ListOfIngredientsId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMedia_ListOfIngredientsId",
                table: "IngredientMedia",
                column: "ListOfIngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Stage_StageId",
                table: "Media",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Stage_StageId",
                table: "Media");

            migrationBuilder.DropTable(
                name: "IngredientMedia");

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "Media",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientsForMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeasurementType = table.Column<string>(type: "TEXT", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsForMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsForMedia_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id");
                });

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
                        name: "FK_IngredientIngredientsForMedia_IngredientsForMedia_ListOfIngredientsId",
                        column: x => x.ListOfIngredientsId,
                        principalTable: "IngredientsForMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientIngredientsForMedia_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientIngredientsForMedia_ListOfIngredientsId",
                table: "IngredientIngredientsForMedia",
                column: "ListOfIngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsForMedia_MediaId",
                table: "IngredientsForMedia",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Stage_StageId",
                table: "Media",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
