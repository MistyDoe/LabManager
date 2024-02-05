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
	public class IngredientsController : ControllerBase
	{
		private readonly LabManagerDBContext _context;
		private readonly IMapper _mapper;

		public IngredientsController(LabManagerDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Ingredients
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
		{
			if (_context.Ingredients == null)
			{
				return NotFound();
			}
			return await _context.Ingredients.ToListAsync();
		}

		// GET: api/Ingredients/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Ingredient>> GetIngredient(int id)
		{
			if (_context.Ingredients == null)
			{
				return NotFound();
			}
			var ingredient = await _context.Ingredients.FirstOrDefaultAsync(pl => pl.Id == id);

			if (ingredient == null)
			{
				return NotFound();
			}

			return ingredient;
		}

		// PUT: api/Ingredients/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutIngredient(int id, Ingredient ingredient)
		{
			if (id != ingredient.Id)
			{
				return BadRequest();
			}
			_context.Entry(ingredient).State = EntityState.Modified;

			await _context.SaveChangesAsync();

			return NoContent();

		}

		// POST: api/Ingredients
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Ingredient>> PostIngredient(IngredientDTO ingredientDTO)
		{
			var ingredient = _mapper.Map<Ingredient>(ingredientDTO);
			if (_context.Ingredients == null)
			{
				return Problem("Entity set 'LabManagerDBContext.Ingredients'  is null.");
			}
			int id = new Random().Next();
			Ingredient selectedId = await _context.Ingredients.FirstOrDefaultAsync(p => p.Id == id);
			if (selectedId != null)
			{
				id = new Random().Next();
			}
			ingredient.Id = id;

			await _context.Ingredients.AddAsync(ingredient);

			await _context.SaveChangesAsync();

			return Created($"api/LabManager/ingredient/{ingredient.Name}", ingredient);

		}

		// DELETE: api/Ingredients/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteIngredient(int id)
		{
			if (_context.Ingredients == null)
			{
				return NotFound();
			}
			var ingredient = await _context.Ingredients.FindAsync(id);
			if (ingredient == null)
			{
				return NotFound();
			}

			_context.Ingredients.Remove(ingredient);
			await _context.SaveChangesAsync();

			return NoContent();
		}

	}
}
