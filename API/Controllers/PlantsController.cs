using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Route("api/LabManager/[controller]")]
[ApiController]
public class PlantsController : ControllerBase
{
	private readonly LabManagerDBContext _context;
	private readonly IMapper _mapper;

	public PlantsController(LabManagerDBContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		return _context.Plants != null ? Ok(
					await _context.Plants
					.Include(p => p.Protocols)
					.ToListAsync()) : NotFound();

	}

	[HttpGet]
	[Route("api/LabManager/[controller]/{id}")]
	public async Task<IActionResult> Details(int? id)
	{
		if (id == null || _context.Plants == null)
		{
			return NotFound();
		}

		var plant = await _context.Plants
			.Include(p => p.Protocols)
			.FirstOrDefaultAsync(pl => pl.Id == id);
		if (plant == null)
		{
			return NotFound();
		}

		return Ok(plant);
	}



	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(PlantDTO plantDTO)
	{
		var plant = _mapper.Map<Plant>(plantDTO);
		plant.TotalQt = plantDTO.InTSQt + plantDTO.MotherPlantsQt;

		await _context.Plants.AddAsync(plant);

		await _context.SaveChangesAsync();

		return Ok(plant);

	}

	// GET: Plants/Edit/5
	[HttpPatch]
	public async Task<IActionResult> Edit(PlantDTO plantDTO)
	{
		Plant updatedPlant = new Plant();

		updatedPlant = _mapper.Map<Plant>(plantDTO);
		updatedPlant.TotalQt = plantDTO.InTSQt + plantDTO.MotherPlantsQt + plantDTO.ForSaleQt;
		_context.Update(updatedPlant);
		await _context.SaveChangesAsync();
		return Ok();
	}

	// GET: Plants/Delete/5
	[HttpDelete]
	public async Task<IActionResult> Delete(int? id)
	{
		var plantModel = await _context.Plants.FirstOrDefaultAsync(pl => pl.Id == id);
		if (plantModel == null)
		{
			return BadRequest("Plant not found");
		}
		_context.Plants.Remove(plantModel);
		await _context.SaveChangesAsync();
		return Ok();
	}

}
