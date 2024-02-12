using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientBasesController : ControllerBase
    {
        private readonly LabManagerDBContext _context;

        public IngredientBasesController(LabManagerDBContext context)
        {
            _context = context;
        }

        // GET: api/IngredientBases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientBase>>> GetIngredientBase()
        {
            return await _context.IngredientBase.ToListAsync();
        }

        // GET: api/IngredientBases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientBase>> GetIngredientBase(int id)
        {
            var ingredientBase = await _context.IngredientBase.FindAsync(id);

            if (ingredientBase == null)
            {
                return NotFound();
            }

            return ingredientBase;
        }

        // PUT: api/IngredientBases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientBase(int id, IngredientBase ingredientBase)
        {
            if (id != ingredientBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredientBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientBaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IngredientBases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientBase>> PostIngredientBase(IngredientBase ingredientBase)
        {
            _context.IngredientBase.Add(ingredientBase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientBase", new { id = ingredientBase.Id }, ingredientBase);
        }

        // DELETE: api/IngredientBases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientBase(int id)
        {
            var ingredientBase = await _context.IngredientBase.FindAsync(id);
            if (ingredientBase == null)
            {
                return NotFound();
            }

            _context.IngredientBase.Remove(ingredientBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientBaseExists(int id)
        {
            return _context.IngredientBase.Any(e => e.Id == id);
        }
    }
}
