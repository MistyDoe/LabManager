using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ProtocolrelationshiUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantProtocol");

            migrationBuilder.AddColumn<int>(
                name: "PlantsId",
                table: "Protocols",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Protocols_PlantsId",
                table: "Protocols",
                column: "PlantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Protocols_Plants_PlantsId",
                table: "Protocols",
                column: "PlantsId",
                principalTable: "Plants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_Plants_PlantsId",
                table: "Protocols");

            migrationBuilder.DropIndex(
                name: "IX_Protocols_PlantsId",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "PlantsId",
                table: "Protocols");

            migrationBuilder.CreateTable(
                name: "PlantProtocol",
                columns: table => new
                {
                    PlantsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProtocolsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantProtocol", x => new { x.PlantsId, x.ProtocolsId });
                    table.ForeignKey(
                        name: "FK_PlantProtocol_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantProtocol_Protocols_ProtocolsId",
                        column: x => x.ProtocolsId,
                        principalTable: "Protocols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantProtocol_ProtocolsId",
                table: "PlantProtocol",
                column: "ProtocolsId");
        }
    }
}
