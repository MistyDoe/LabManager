using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
	/// <inheritdoc />
	public partial class MediaprotocolMediaStageRemoved : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
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
				name: "TotalQt",
				table: "Plants",
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

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Media_Protocols_protocolId",
				table: "Media");

			migrationBuilder.DropColumn(
				name: "Stage",
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
				name: "TotalQt",
				table: "Plants",
				type: "INTEGER",
				nullable: false,
				defaultValue: 0,
				oldClrType: typeof(int),
				oldType: "INTEGER",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "StageId",
				table: "Media",
				type: "INTEGER",
				nullable: true);

			migrationBuilder.CreateTable(
				name: "Stage",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Stagetype = table.Column<string>(type: "TEXT", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Stage", x => x.Id);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Media_StageId",
				table: "Media",
				column: "StageId");

			migrationBuilder.AddForeignKey(
				name: "FK_Media_Protocols_ProtocolId",
				table: "Media",
				column: "ProtocolId",
				principalTable: "Protocols",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Media_Stage_StageId",
				table: "Media",
				column: "StageId",
				principalTable: "Stage",
				principalColumn: "Id");
		}
	}
}
