﻿using System;
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
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profile
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Index()
        {
              return _context.Profile != null ? 
                          View(await _context.Profile.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Profile'  is null.");
        }

        // GET: Profile/Details/5
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profile == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .FirstOrDefaultAsync(m => m.ProfileID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profile/Create
        [Authorize(Roles = "Patient")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileID,UserName,Age,Email,Phone,City,PostalCode,Image,MemberSince,Role")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        // GET: Profile/Edit/5
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profile == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileID,UserName,Age,Email,Phone,City,PostalCode,Image,MemberSince,Role")] Profile profile)
        {
            if (id != profile.ProfileID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.ProfileID))
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
            return View(profile);
        }

        // GET: Profile/Delete/5
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profile == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .FirstOrDefaultAsync(m => m.ProfileID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profile == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Profile'  is null.");
            }
            var profile = await _context.Profile.FindAsync(id);
            if (profile != null)
            {
                _context.Profile.Remove(profile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(int id)
        {
          return (_context.Profile?.Any(e => e.ProfileID == id)).GetValueOrDefault();
        }
    }
}
