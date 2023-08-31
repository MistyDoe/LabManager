using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
	/// <inheritdoc />
	public partial class UpdatedPlantModelNameFixTotals : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameColumn(
				name: "Total",
				table: "Plants",
				newName: "TotalQt");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
