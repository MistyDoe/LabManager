using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ProtocolPlantRlelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtocol_Plants_Id",
                table: "PlantProtocol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantProtocol",
                table: "PlantProtocol");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlantProtocol",
                newName: "PlantsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantProtocol",
                table: "PlantProtocol",
                columns: new[] { "PlantsId", "ProtocolsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtocol_Plants_PlantsId",
                table: "PlantProtocol",
                column: "PlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtocol_Plants_PlantsId",
                table: "PlantProtocol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantProtocol",
                table: "PlantProtocol");

            migrationBuilder.RenameColumn(
                name: "PlantsId",
                table: "PlantProtocol",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantProtocol",
                table: "PlantProtocol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtocol_Plants_Id",
                table: "PlantProtocol",
                column: "Id",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
