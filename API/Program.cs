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
//Plant EndPoints
app.MapGet("api/LabManager/plant/", async (LabManagerDBContext context) =>
{
	var plants = await context.Plants.Include(p => p.Protocols).ToListAsync();
	return Results.Ok(plants);
});

app.MapGet("api/LabManager/plant/{id}", async (LabManagerDBContext context, int id) =>
{
	var plants = await context.Plants.FirstOrDefaultAsync(pl => pl.Id == id);
	return Results.Ok(plants);
});


app.MapPost("api/LabManager/plant/", async (LabManagerDBContext context, Plant plant) =>
{
	await context.Plants.AddAsync(plant);

	await context.SaveChangesAsync();

	return Results.Created($"api/LabManager/plant/{plant.Id}", plant);

});

app.MapPut("api/LabManager/plant/{id}/", async (LabManagerDBContext context, Plant plant) =>
{
	var plantModel = await context.Plants.FirstOrDefaultAsync(pl => pl.Id == plant.Id);
	if (plantModel == null)
	{
		return Results.NotFound();
	}
	plantModel.Name = plant.Name;
	plantModel.MotherPlantsQt = plant.MotherPlantsQt;
	plantModel.ForSale = plant.ForSale;

	plantModel.ForSaleQt = plant.ForSaleQt;

	plantModel.InTS = plant.InTS;
	plantModel.InTSQt = plant.InTSQt;
	plantModel.Protocols = plant.Protocols;
	plantModel.TotalQt = plant.MotherPlantsQt + plant.ForSaleQt + plant.InTSQt;

	await context.SaveChangesAsync();

	return Results.NoContent();

});

app.MapDelete("api/LabManager/plant/{id}", async (LabManagerDBContext context, int id) =>
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

//Protocol Endpoints

app.MapGet("api/LabManager/protocols", async (LabManagerDBContext context) =>
{
	var protocols = await context.Protocols.Include(p => p.Plants)
		.ToListAsync();
	return Results.Ok(protocols);
});
app.MapGet("api/LabManager/protocols/{id}", async (LabManagerDBContext context, int id) =>
{
	var protocols = await context.Protocols.FirstOrDefaultAsync(pl => pl.Id == id);
	return Results.Ok(protocols);
});

app.MapPost("api/LabManager/protocols/", async (LabManagerDBContext context, Protocol protocol) =>
{
	await context.Protocols.AddAsync(protocol);

	await context.SaveChangesAsync();

	return Results.Created($"api/LabManager/plant/{protocol.Id}", protocol);

});

app.MapPut("api/LabManager/protocols/{id}/", async (LabManagerDBContext context, Protocol protocol) =>
{
	var protocolModel = await context.Protocols.FirstOrDefaultAsync(pr => pr.Id == protocol.Id);
	if (protocolModel == null)
	{
		return Results.NotFound();
	}
	protocolModel.Media = protocol.Media;
	protocolModel.Resource = protocol.Resource;
	protocolModel.Plants = protocol.Plants;



	await context.SaveChangesAsync();

	return Results.NoContent();

});

app.MapDelete("api/LabManager/protocols/{id}", async (LabManagerDBContext context, int id) =>
{
	var protocolModel = await context.Protocols.FirstOrDefaultAsync(pr => pr.Id == id);
	if (protocolModel == null)
	{
		return Results.NotFound();
	}
	context.Protocols.Remove(protocolModel);
	await context.SaveChangesAsync();
	return Results.NoContent();
});

//Media endpoint

app.MapPost("api/LabManager/media/", async (LabManagerDBContext context, Media media) =>
{
	await context.Media.AddAsync(media);

	await context.SaveChangesAsync();

	return Results.Created($"api/LabManager/plant/{media.Id}", media);

});


//
app.Run();

