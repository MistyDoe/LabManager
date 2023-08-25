using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LabManagerDBContext>(opt =>
opt.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection")));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
//app.UseHttpsRedirection();

app.MapGet("api/LabManager", async (LabManagerDBContext context) =>
{
	var plants = await context.Plants.ToListAsync();
	return Results.Ok(plants);
});

app.MapPost("api/LabManager", async (LabManagerDBContext context, Plant plant) =>
{
	await context.Plants.AddAsync(plant);

	await context.SaveChangesAsync();

	return Results.Created($"api/LabManager/{plant.Id}", plant);
});

app.MapPut("api/LabManager/{id}", async (LabManagerDBContext context, int id, Plant plant) =>
{
	var plantModel = await context.Plants.FirstOrDefaultAsync(pl => pl.Id == id);
	if (plantModel == null)
	{
		return Results.NotFound();
	}
	plantModel.Name = plant.Name;
	plantModel.StoredQt = plant.StoredQt;
	plantModel.ForSale = plant.ForSale;
	plantModel.InTS = plant.InTS;

	await context.SaveChangesAsync();

	return Results.NoContent();

});

app.MapDelete("api/LabManager/{id}", async (LabManagerDBContext context, int id) =>
{
	var plantModel = await context.Plants.FirstOrDefaultAsync(pl => pl.Id == id);
	if (plantModel == null)
	{
		return Results.NotFound();
	}
	context.Plants.Remove(plantModel);
	await context.SaveChangesAsync();

	return Results.NoContent();
});
app.Run();

