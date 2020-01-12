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
    public class FeelingsController : Controller
    {
        private readonly mimmContext _context;

        public FeelingsController(mimmContext context)
        {
            _context = context;
        }

        // GET: Feelings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feelings.ToListAsync());
        }

        // GET: Feelings/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feelings = await _context.Feelings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feelings == null)
            {
                return NotFound();
            }

            return View(feelings);
        }

        // GET: Feelings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feelings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Feelings feelings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feelings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feelings);
        }

        // GET: Feelings/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feelings = await _context.Feelings.FindAsync(id);
            if (feelings == null)
            {
                return NotFound();
            }
            return View(feelings);
        }

        // POST: Feelings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Name")] Feelings feelings)
        {
            if (id != feelings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feelings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeelingsExists(feelings.Id))
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
            return View(feelings);
        }

        // GET: Feelings/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feelings = await _context.Feelings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feelings == null)
            {
                return NotFound();
            }

            return View(feelings);
        }

        // POST: Feelings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var feelings = await _context.Feelings.FindAsync(id);
            _context.Feelings.Remove(feelings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeelingsExists(uint id)
        {
            return _context.Feelings.Any(e => e.Id == id);
        }
    }
}
