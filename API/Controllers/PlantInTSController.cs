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
    public class PlantInTSController : ControllerBase
    {
        private readonly LabManagerDBContext _context;

        public PlantInTSController(LabManagerDBContext context)
        {
            _context = context;
        }

        // GET: api/PlantInTS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantInTS>>> GetPlantInTS()
        {
          if (_context.PlantInTS == null)
          {
              return NotFound();
          }
            return await _context.PlantInTS.ToListAsync();
        }

        // GET: api/PlantInTS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantInTS>> GetPlantInTS(int id)
        {
          if (_context.PlantInTS == null)
          {
              return NotFound();
          }
            var plantInTS = await _context.PlantInTS.FindAsync(id);

            if (plantInTS == null)
            {
                return NotFound();
            }

            return plantInTS;
        }

        // PUT: api/PlantInTS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantInTS(int id, PlantInTS plantInTS)
        {
            if (id != plantInTS.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantInTS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantInTSExists(id))
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

        // POST: api/PlantInTS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlantInTS>> PostPlantInTS(PlantInTS plantInTS)
        {
          if (_context.PlantInTS == null)
          {
              return Problem("Entity set 'LabManagerDBContext.PlantInTS'  is null.");
          }
            _context.PlantInTS.Add(plantInTS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantInTS", new { id = plantInTS.Id }, plantInTS);
        }

        // DELETE: api/PlantInTS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantInTS(int id)
        {
            if (_context.PlantInTS == null)
            {
                return NotFound();
            }
            var plantInTS = await _context.PlantInTS.FindAsync(id);
            if (plantInTS == null)
            {
                return NotFound();
            }

            _context.PlantInTS.Remove(plantInTS);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantInTSExists(int id)
        {
            return (_context.PlantInTS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
