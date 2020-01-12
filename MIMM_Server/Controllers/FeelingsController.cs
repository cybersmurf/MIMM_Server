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
    public class FeelingsController : ControllerBase
    {
        private readonly mimmContext _context;

        public FeelingsController(mimmContext context)
        {
            _context = context;
        }

        // GET: api/Feelings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feelings>>> GetFeelings()
        {
            return await _context.Feelings.ToListAsync();
        }

        // GET: api/Feelings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feelings>> GetFeelings(uint id)
        {
            var feelings = await _context.Feelings.FindAsync(id);

            if (feelings == null)
            {
                return NotFound();
            }

            return feelings;
        }

        // PUT: api/Feelings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeelings(uint id, Feelings feelings)
        {
            if (id != feelings.Id)
            {
                return BadRequest();
            }

            _context.Entry(feelings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeelingsExists(id))
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

        // POST: api/Feelings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Feelings>> PostFeelings(Feelings feelings)
        {
            _context.Feelings.Add(feelings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeelings", new { id = feelings.Id }, feelings);
        }

        // DELETE: api/Feelings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feelings>> DeleteFeelings(uint id)
        {
            var feelings = await _context.Feelings.FindAsync(id);
            if (feelings == null)
            {
                return NotFound();
            }

            _context.Feelings.Remove(feelings);
            await _context.SaveChangesAsync();

            return feelings;
        }

        private bool FeelingsExists(uint id)
        {
            return _context.Feelings.Any(e => e.Id == id);
        }
    }
}
