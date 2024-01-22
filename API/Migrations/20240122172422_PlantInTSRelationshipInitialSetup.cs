using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class PlantInTSRelationshipInitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantInTSId",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlantInTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProtocolId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Contaminated = table.Column<bool>(type: "INTEGER", nullable: false),
                    ContamDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantInTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantInTS_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantInTS_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantInTS_Protocols_ProtocolId",
                        column: x => x.ProtocolId,
                        principalTable: "Protocols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_PlantInTSId",
                table: "Media",
                column: "PlantInTSId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantInTS_MediaId",
                table: "PlantInTS",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantInTS_PlantId",
                table: "PlantInTS",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantInTS_ProtocolId",
                table: "PlantInTS",
                column: "ProtocolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_PlantInTS_PlantInTSId",
                table: "Media",
                column: "PlantInTSId",
                principalTable: "PlantInTS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_PlantInTS_PlantInTSId",
                table: "Media");

            migrationBuilder.DropTable(
                name: "PlantInTS");

            migrationBuilder.DropIndex(
                name: "IX_Media_PlantInTSId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "PlantInTSId",
                table: "Media");
        }
    }
}
