﻿using API.Models;
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
				.HasForeignKey(p => p.PlantId);
		}

	}
}
