using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ProtocolrelationshiUpdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_Plants_PlantsId",
                table: "Protocols");

            migrationBuilder.RenameColumn(
                name: "PlantsId",
                table: "Protocols",
                newName: "PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Protocols_PlantsId",
                table: "Protocols",
                newName: "IX_Protocols_PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Protocols_Plants_PlantId",
                table: "Protocols",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_Plants_PlantId",
                table: "Protocols");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "Protocols",
                newName: "PlantsId");

            migrationBuilder.RenameIndex(
                name: "IX_Protocols_PlantId",
                table: "Protocols",
                newName: "IX_Protocols_PlantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Protocols_Plants_PlantsId",
                table: "Protocols",
                column: "PlantsId",
                principalTable: "Plants",
                principalColumn: "Id");
        }
    }
}
