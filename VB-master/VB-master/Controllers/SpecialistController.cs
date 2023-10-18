using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VB.Data;
using VB.Models;

namespace VB.Controllers
{
    public class SpecialistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Specialist
        public async Task<IActionResult> Index()
        {
              return _context.Specialist != null ? 
                          View(await _context.Specialist.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Specialist'  is null.");
        }

        // GET: Specialist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Specialist == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist
                .FirstOrDefaultAsync(m => m.SpecialistID == id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);
        }

        // GET: Specialist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialistID,Name,Description,Status")] Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialist);
        }

        // GET: Specialist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Specialist == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist.FindAsync(id);
            if (specialist == null)
            {
                return NotFound();
            }
            return View(specialist);
        }

        // POST: Specialist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialistID,Name,Description,Status")] Specialist specialist)
        {
            if (id != specialist.SpecialistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialistExists(specialist.SpecialistID))
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
            return View(specialist);
        }

        // GET: Specialist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Specialist == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist
                .FirstOrDefaultAsync(m => m.SpecialistID == id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);
        }

        // POST: Specialist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Specialist == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Specialist'  is null.");
            }
            var specialist = await _context.Specialist.FindAsync(id);
            if (specialist != null)
            {
                _context.Specialist.Remove(specialist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialistExists(int id)
        {
          return (_context.Specialist?.Any(e => e.SpecialistID == id)).GetValueOrDefault();
        }
    }
}
