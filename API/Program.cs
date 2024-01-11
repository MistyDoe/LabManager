using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LabManagerDBContext>(opt =>
opt.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection")));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<JsonOptions>(options =>
{
	options.SerializerOptions.ReferenceHandler = null;
	options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddAutoMapper(typeof(Program));

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
	var plants = await context.Plants.Include(p => p.Protocols).FirstOrDefaultAsync(pl => pl.Id == id);
	return Results.Ok(plants);
});


app.MapPost("api/LabManager/plant/", async (LabManagerDBContext context, IMapper mapper, PlantDTO plantDTO) =>
{
	var plant = mapper.Map<Plant>(plantDTO);
	plant.TotalQt = plantDTO.InTSQt + plantDTO.MotherPlantsQt;

	await context.Plants.AddAsync(plant);

	await context.SaveChangesAsync();

	return Results.Created($"api/LabManager/plant/{plant.Id}", plant);

});

app.MapPut("api/LabManager/plant/{id}/", async (LabManagerDBContext context, IMapper mapper, PlantDTO plantDTO) =>
{
	Plant updatedPlant = new Plant();

	updatedPlant = mapper.Map<Plant>(plantDTO);
	updatedPlant.TotalQt = plantDTO.InTSQt + plantDTO.MotherPlantsQt + plantDTO.ForSaleQt;
	context.Update(updatedPlant);
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
	var protocols = await context.Protocols.Include(p => p.Plant)
		.ToListAsync();
	return Results.Ok(protocols);
});
app.MapGet("api/LabManager/protocols/{id}", async (LabManagerDBContext context, int id) =>
{
	var protocols = await context.Protocols.FirstOrDefaultAsync(pl => pl.Id == id);
	return Results.Ok(protocols);
});

app.MapPost("api/LabManager/protocols/", async (LabManagerDBContext context, IMapper mapper, ProtocolDTO protocolDTO) =>
{
	var protocol = mapper.Map<Protocol>(protocolDTO);

	await context.Protocols.AddAsync(protocol);

	await context.SaveChangesAsync();

	return Results.Created($"api/LabManager/plant/{protocol.Id}", protocol);

});

app.MapPut("api/LabManager/protocols/{id}/", async (LabManagerDBContext context, IMapper mapper, ProtocolDTO protocolDTO) =>
{
	var updatedProtocol = mapper.Map<Protocol>(protocolDTO);
	context.Update(updatedProtocol);
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

//Ingredient endpoint
app.MapGet("api/LabManager/ingredient", async (LabManagerDBContext context) =>
{
	var ingredients = await context.Ingredients.ToListAsync();
	return Results.Ok(ingredients);
});

app.MapGet("api/LabManager/ingredient/{name}", async (LabManagerDBContext context, string name) =>
{
	var ingredient = await context.Ingredients.FirstOrDefaultAsync(pl => pl.Name == name);
	return Results.Ok(ingredient);
});

app.MapPost("api/LabManager/ingredient", async (LabManagerDBContext context, Ingredient ingredient) =>
{
	await context.Ingredients.AddAsync(ingredient);

	await context.SaveChangesAsync();

	return Results.Created($"api/LabManager/ingredient/{ingredient.Name}", ingredient);

});

app.MapPut("api/LabManager/ingredient/{name}", async (LabManagerDBContext context, Ingredient ingredient) =>
{
	var ingredientModel = await context.Ingredients.FirstOrDefaultAsync(pr => pr.Name == ingredient.Name);
	if (ingredientModel == null)
	{
		return Results.NotFound();
	}
	ingredientModel.Quantity = ingredient.Quantity;
	if (ingredient.ListOfMedias != null)
	{
		foreach (var ingedient in ingredient.ListOfMedias)
		{
			context.Add(ingedient);
		}
		context.SaveChanges();
	}

	await context.SaveChangesAsync();

	return Results.NoContent();

});

app.MapDelete("api/LabManager/ingredient/{id}", async (LabManagerDBContext context, int id) =>
{
	var ingredient = await context.Ingredients.FirstOrDefaultAsync(pr => pr.Id == id);
	if (ingredient == null)
	{
		return Results.NotFound();
	}
	context.Ingredients.Remove(ingredient);
	await context.SaveChangesAsync();
	return Results.NoContent();
});
//
app.Run();

