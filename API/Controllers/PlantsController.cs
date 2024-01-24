using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
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

		// GET: api/Plants
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
		{
			if (_context.Plants == null)
			{
				return NotFound();
			}
			var plants = await _context.Plants.Include(p => p.Protocols).ToListAsync();
			return Ok(plants);
		}

		// GET: api/Plants/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Plant>> GetPlant(int id)
		{
			if (_context.Plants == null)
			{
				return NotFound();
			}
			var plant = await _context.Plants.Include(p => p.Protocols).FirstOrDefaultAsync(pl => pl.Id == id);

			if (plant == null)
			{
				return NotFound();
			}
			return Ok(plant);
		}

		// PUT: api/Plants/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPatch("{id}")]
		public async Task<IActionResult> PutPlant(PlantDTO plantDTO)
		{
			Plant updatedPlant = new Plant();

			updatedPlant = _mapper.Map<Plant>(plantDTO);
			updatedPlant.TotalQt = plantDTO.InTSQt + plantDTO.MotherPlantsQt + plantDTO.ForSaleQt;
			_context.Update(updatedPlant);
			await _context.SaveChangesAsync();
			return NoContent();
		}
		// POST: api/Plants
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Plant>> PostPlant(PlantDTO plantDTO)
		{
			if (_context.Plants == null)
			{
				return Problem("Entity set 'LabManagerDBContext.Plants'  is null.");
			}
			var plant = _mapper.Map<Plant>(plantDTO);
			plant.TotalQt = plantDTO.InTSQt + plantDTO.MotherPlantsQt;

			await _context.Plants.AddAsync(plant);

			await _context.SaveChangesAsync();

			return Created($"api/LabManager/plant/{plant.Id}", plant);
		}

		// DELETE: api/Plants/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePlant(int id)
		{
			if (_context.Plants == null)
			{
				return NotFound();
			}
			var plant = await _context.Plants.FirstOrDefaultAsync(pl => pl.Id == id);

			_context.Plants.Remove(plant);
			await _context.SaveChangesAsync();

			return NoContent();


		}
	}
}
