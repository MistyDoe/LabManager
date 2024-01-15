using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RelMediaIngredientMediaProtocol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Protocols_protocolId",
                table: "Media");

            migrationBuilder.RenameColumn(
                name: "protocolId",
                table: "Media",
                newName: "ProtocolId");

            migrationBuilder.RenameIndex(
                name: "IX_Media_protocolId",
                table: "Media",
                newName: "IX_Media_ProtocolId");

            migrationBuilder.AlterColumn<int>(
                name: "ProtocolId",
                table: "Media",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Protocols_ProtocolId",
                table: "Media",
                column: "ProtocolId",
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

            migrationBuilder.RenameColumn(
                name: "ProtocolId",
                table: "Media",
                newName: "protocolId");

            migrationBuilder.RenameIndex(
                name: "IX_Media_ProtocolId",
                table: "Media",
                newName: "IX_Media_protocolId");

            migrationBuilder.AlterColumn<int>(
                name: "protocolId",
                table: "Media",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Protocols_protocolId",
                table: "Media",
                column: "protocolId",
                principalTable: "Protocols",
                principalColumn: "Id");
        }
    }
}
