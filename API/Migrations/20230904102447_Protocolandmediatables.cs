using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Protocolandmediatables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Protocol_ProtocolId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtocol_Plants_PlantsId",
                table: "PlantProtocol");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtocol_Protocol_ProtocolsId",
                table: "PlantProtocol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantProtocol",
                table: "PlantProtocol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Protocol",
                table: "Protocol");

            migrationBuilder.RenameTable(
                name: "Protocol",
                newName: "Protocols");

            migrationBuilder.RenameColumn(
                name: "PlantsId",
                table: "PlantProtocol",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantProtocol",
                table: "PlantProtocol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Protocols",
                table: "Protocols",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Protocols_ProtocolId",
                table: "Media",
                column: "ProtocolId",
                principalTable: "Protocols",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtocol_Plants_Id",
                table: "PlantProtocol",
                column: "Id",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtocol_Protocols_ProtocolsId",
                table: "PlantProtocol",
                column: "ProtocolsId",
                principalTable: "Protocols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Protocols_ProtocolId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtocol_Plants_Id",
                table: "PlantProtocol");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantProtocol_Protocols_ProtocolsId",
                table: "PlantProtocol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantProtocol",
                table: "PlantProtocol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Protocols",
                table: "Protocols");

            migrationBuilder.RenameTable(
                name: "Protocols",
                newName: "Protocol");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlantProtocol",
                newName: "PlantsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantProtocol",
                table: "PlantProtocol",
                columns: new[] { "PlantsId", "ProtocolsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Protocol",
                table: "Protocol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Protocol_ProtocolId",
                table: "Media",
                column: "ProtocolId",
                principalTable: "Protocol",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtocol_Plants_PlantsId",
                table: "PlantProtocol",
                column: "PlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProtocol_Protocol_ProtocolsId",
                table: "PlantProtocol",
                column: "ProtocolsId",
                principalTable: "Protocol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
