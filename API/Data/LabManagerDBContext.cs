using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class LabManagerDBContext : DbContext
	{
		public LabManagerDBContext(DbContextOptions<LabManagerDBContext> options) : base(options)
		{

		}

		public DbSet<Plant> Plants => Set<Plant>();
	}
}
