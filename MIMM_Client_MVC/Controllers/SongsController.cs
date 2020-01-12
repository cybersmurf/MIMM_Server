using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MIMM_Shared.Models;

namespace MIMM_Client_MVC.Controllers
{
    public class SongsController : Controller
    {
        private readonly mimmContext _context;

        public SongsController(mimmContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var mimmContext = _context.Songs.Include(s => s.IdtracksNavigation);
            return View(await mimmContext.ToListAsync());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .Include(s => s.IdtracksNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            ViewData["Idtracks"] = new SelectList(_context.Tracks, "Id", "Name");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Whispertime,Idtracks,Idfeeling")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtracks"] = new SelectList(_context.Tracks, "Id", "Name", songs.Idtracks);
            return View(songs);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }
            ViewData["Idtracks"] = new SelectList(_context.Tracks, "Id", "Name", songs.Idtracks);
            return View(songs);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Whispertime,Idtracks,Idfeeling")] Songs songs)
        {
            if (id != songs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongsExists(songs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtracks"] = new SelectList(_context.Tracks, "Id", "Name", songs.Idtracks);
            return View(songs);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .Include(s => s.IdtracksNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songs = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(songs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
