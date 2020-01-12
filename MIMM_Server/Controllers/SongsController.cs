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
    public class SongsController : ControllerBase
    {
        private readonly mimmContext _context;

        public SongsController(mimmContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
            var songs = await _context.Songs.FindAsync(id);

            if (songs == null)
            {
                return NotFound();
            }

            return songs;
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Songs songs)
        {
            if (id != songs.Id)
            {
                return BadRequest();
            }

            _context.Entry(songs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsExists(id))
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

        // POST: api/Songs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
            _context.Songs.Add(songs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongs", new { id = songs.Id }, songs);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Songs>> DeleteSongs(int id)
        {
            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(songs);
            await _context.SaveChangesAsync();

            return songs;
        }

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
