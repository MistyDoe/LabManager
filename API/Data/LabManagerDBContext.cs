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
		public DbSet<Protocol> Protocols => Set<Protocol>();
		public DbSet<Media> Media => Set<Media>();
		public DbSet<Ingredient> Ingredients => Set<Ingredient>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Protocol>()
				.HasOne(_ => _.Plant)
				.WithMany(p => p.Protocols)
				.HasForeignKey(p => p.PlantId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Media>()
				.HasOne(_ => _.Protocol)
				.WithMany(p => p.Media)
				.HasForeignKey(p => p.ProtocolId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Ingredient>()
				.HasMany(i => i.Media)
				.WithMany(m => m.Ingredients);

			modelBuilder.Entity<PlantInTS>()
				.HasOne(_ => _.Protocol)
				.WithMany(_ => _.PlantInTs)
				.HasForeignKey(p => p.ProtocolId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<PlantInTS>()
				.HasOne(_ => _.Plant)
				.WithMany(_ => _.PlantInTs)
				.HasForeignKey(p => p.PlantId)
				.OnDelete(DeleteBehavior.Cascade);


			modelBuilder.Entity<PlantInTS>()
				.HasOne(_ => _.Media)
				.WithMany(_ => _.PlantInTs)
				.HasForeignKey(p => p.MediaId)
				.OnDelete(DeleteBehavior.Cascade);

		}

		public DbSet<API.Models.PlantInTS>? PlantInTS { get; set; }
		public DbSet<API.Models.IngredientBase> IngredientBase { get; set; } = default!;

	}
}
