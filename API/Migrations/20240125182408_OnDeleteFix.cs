using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantInTS_Media_MediaId",
                table: "PlantInTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantInTS_Plants_PlantId",
                table: "PlantInTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantInTS_Protocols_ProtocolId",
                table: "PlantInTS");

            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_Plants_PlantId",
                table: "Protocols");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantInTS_Media_MediaId",
                table: "PlantInTS",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantInTS_Plants_PlantId",
                table: "PlantInTS",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantInTS_Protocols_ProtocolId",
                table: "PlantInTS",
                column: "ProtocolId",
                principalTable: "Protocols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Protocols_Plants_PlantId",
                table: "Protocols",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantInTS_Media_MediaId",
                table: "PlantInTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantInTS_Plants_PlantId",
                table: "PlantInTS");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantInTS_Protocols_ProtocolId",
                table: "PlantInTS");

            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_Plants_PlantId",
                table: "Protocols");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantInTS_Media_MediaId",
                table: "PlantInTS",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantInTS_Plants_PlantId",
                table: "PlantInTS",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantInTS_Protocols_ProtocolId",
                table: "PlantInTS",
                column: "ProtocolId",
                principalTable: "Protocols",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Protocols_Plants_PlantId",
                table: "Protocols",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");
        }
    }
}
