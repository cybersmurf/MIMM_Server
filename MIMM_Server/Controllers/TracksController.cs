using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIMM_Shared.Models;

namespace MIMM_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly mimmContext _context;

        public TracksController(mimmContext context)
        {
            _context = context;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tracks>>> GetTracks()
        {
            return await _context.Tracks.ToListAsync();
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tracks>> GetTracks(int id)
        {
            var tracks = await _context.Tracks.FindAsync(id);

            if (tracks == null)
            {
                return NotFound();
            }

            return tracks;
        }

        // PUT: api/Tracks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTracks(int id, Tracks tracks)
        {
            if (id != tracks.Id)
            {
                return BadRequest();
            }

            _context.Entry(tracks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TracksExists(id))
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

        // POST: api/Tracks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tracks>> PostTracks(Tracks tracks)
        {
            _context.Tracks.Add(tracks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTracks", new { id = tracks.Id }, tracks);
        }

        // DELETE: api/Tracks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tracks>> DeleteTracks(int id)
        {
            var tracks = await _context.Tracks.FindAsync(id);
            if (tracks == null)
            {
                return NotFound();
            }

            _context.Tracks.Remove(tracks);
            await _context.SaveChangesAsync();

            return tracks;
        }

        private bool TracksExists(int id)
        {
            return _context.Tracks.Any(e => e.Id == id);
        }
    }
}
