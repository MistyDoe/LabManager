using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
	/// <inheritdoc />
	public partial class UpdatedPlantModelNameFix2 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameColumn(
				name: "NoMotherPlants",
				table: "Plants",
				newName: "MotherPlantsQt");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
