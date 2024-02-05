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
	public class MediaController : ControllerBase
	{
		private readonly LabManagerDBContext _context;
		private readonly IMapper _mapper;

		public MediaController(LabManagerDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Media
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Media>>> GetMedia()
		{
			if (_context.Media == null)
			{
				return NotFound();
			}
			return await _context.Media
				.ToListAsync();
		}

		// GET: api/Media/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Media>> GetMedia(int id)
		{
			if (_context.Media == null)
			{
				return NotFound();
			}
			var media = await _context.Media.FindAsync(id);

			if (media == null)
			{
				return NotFound();
			}

			return media;
		}

		// PUT: api/Media/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMedia(int id, Media media)
		{
			if (id != media.Id)
			{
				return BadRequest();
			}

			_context.Entry(media).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MediaExists(id))
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

		// POST: api/Media
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Media>> PostMedia(MediaDTO mediaDTO)
		{
			var media = _mapper.Map<Media>(mediaDTO);
			await _context.Media.AddAsync(media);

			await _context.SaveChangesAsync();

			return Created($"api/LabManager/plant/{media.Id}", media);
		}

		// DELETE: api/Media/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMedia(int id)
		{
			if (_context.Media == null)
			{
				return NotFound();
			}
			var media = await _context.Media.FindAsync(id);
			if (media == null)
			{
				return NotFound();
			}

			_context.Media.Remove(media);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MediaExists(int id)
		{
			return (_context.Media?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
