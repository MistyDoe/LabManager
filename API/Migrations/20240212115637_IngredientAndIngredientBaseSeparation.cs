using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class IngredientAndIngredientBaseSeparation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "IngredientBaseId",
                table: "Ingredients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientBase", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientBaseId",
                table: "Ingredients",
                column: "IngredientBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientBase_IngredientBaseId",
                table: "Ingredients",
                column: "IngredientBaseId",
                principalTable: "IngredientBase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientBase_IngredientBaseId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "IngredientBase");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientBaseId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientBaseId",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
