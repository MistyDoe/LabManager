using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProtocolId",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MediaId",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "PlantInTS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "Contaminated",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

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

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProtocolId",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MediaId",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "PlantInTS",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Contaminated",
                table: "PlantInTS",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

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
        }
    }
}
