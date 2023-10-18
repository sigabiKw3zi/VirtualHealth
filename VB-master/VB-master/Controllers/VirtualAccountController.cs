using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VB.Data;
using VB.Models;

namespace VB.Controllers
{
    
    public class VirtualAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VirtualAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VirtualAccount
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
              return _context.VirtualAccount != null ? 
                          View(await _context.VirtualAccount.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.VirtualAccount'  is null.");
        }

        // GET: VirtualAccount/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VirtualAccount == null)
            {
                return NotFound();
            }

            var virtualAccount = await _context.VirtualAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (virtualAccount == null)
            {
                return NotFound();
            }

            return View(virtualAccount);
        }

        // GET: VirtualAccount/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: VirtualAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email,City")] VirtualAccount virtualAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(virtualAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(virtualAccount);
        }

        // GET: VirtualAccount/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VirtualAccount == null)
            {
                return NotFound();
            }

            var virtualAccount = await _context.VirtualAccount.FindAsync(id);
            if (virtualAccount == null)
            {
                return NotFound();
            }
            return View(virtualAccount);
        }

        // POST: VirtualAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email,City")] VirtualAccount virtualAccount)
        {
            if (id != virtualAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(virtualAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VirtualAccountExists(virtualAccount.Id))
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
            return View(virtualAccount);
        }

        // GET: VirtualAccount/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VirtualAccount == null)
            {
                return NotFound();
            }

            var virtualAccount = await _context.VirtualAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (virtualAccount == null)
            {
                return NotFound();
            }

            return View(virtualAccount);
        }

        // POST: VirtualAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VirtualAccount == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VirtualAccount'  is null.");
            }
            var virtualAccount = await _context.VirtualAccount.FindAsync(id);
            if (virtualAccount != null)
            {
                _context.VirtualAccount.Remove(virtualAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VirtualAccountExists(int id)
        {
          return (_context.VirtualAccount?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
