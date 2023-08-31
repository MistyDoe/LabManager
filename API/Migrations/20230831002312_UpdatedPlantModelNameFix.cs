using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlantModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoredQt",
                table: "Plants",
                newName: "TotalQt");

            migrationBuilder.AlterColumn<int>(
                name: "InTSQt",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForSaleQt",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotherPlantsQt",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForSaleQt",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "MotherPlantsQt",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "TotalQt",
                table: "Plants",
                newName: "StoredQt");

            migrationBuilder.AlterColumn<int>(
                name: "InTSQt",
                table: "Plants",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
