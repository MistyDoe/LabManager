using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ProtocolsController : ControllerBase
	{
		private readonly LabManagerDBContext _context;
		private readonly IMapper _mapper;

		public ProtocolsController(LabManagerDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Protocols
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Protocol>>> GetProtocols()
		{
			var protocols = await _context.Protocols.Include(p => p.Plant)
		  .ToListAsync();
			return Ok(protocols);
		}
		[HttpGet("/ForPlant{id}")]
		public async Task<ActionResult<IEnumerable<Protocol>>> GetProtocolsForPlant(int id)
		{
			var protocols = await _context.Protocols
				.Where(p => p.PlantId == id)
				.ToListAsync();
			return Ok(protocols);
		}

		// GET: api/Protocols/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Protocol>> GetProtocol(int id)
		{
			if (_context.Protocols == null)
			{
				return NotFound();
			}
			var protocol = await _context.Protocols.FirstOrDefaultAsync(pr => pr.Id == id);

			if (protocol == null)
			{
				return NotFound();
			}

			return protocol;
		}

		// PUT: api/Protocols/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPatch("{id}")]
		public async Task<IActionResult> PutProtocol(int id, ProtocolDTO protocolDTO)
		{
			var updatedProtocol = _mapper.Map<Protocol>(protocolDTO);
			_context.Update(updatedProtocol);
			await _context.SaveChangesAsync();
			return Ok();
		}

		// POST: api/Protocols
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Protocol>> PostProtocol(ProtocolDTO protocolDTO)
		{
			if (_context.Protocols == null)
			{
				return Problem("Entity set 'LabManagerDBContext.Protocols'  is null.");
			}
			var updatedProtocol = _mapper.Map<Protocol>(protocolDTO);
			_context.Update(updatedProtocol);
			await _context.SaveChangesAsync();
			return Ok();

		}

		// DELETE: api/Protocols/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProtocol(int id)
		{
			if (_context.Protocols == null)
			{
				return NotFound();
			}
			var protocol = await _context.Protocols.FindAsync(id);
			if (protocol == null)
			{
				return NotFound();
			}

			_context.Protocols.Remove(protocol);
			await _context.SaveChangesAsync();

			return NoContent();
		}

	}
}
