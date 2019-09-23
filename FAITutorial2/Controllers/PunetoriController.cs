using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FAITutorial2.Models;
using Microsoft.AspNetCore.Authorization;

namespace FAITutorial2.Controllers
{
    public class PunetoriController : Controller
    {
        private readonly FAI2_0Context _context;

        public PunetoriController(FAI2_0Context context)
        {
            _context = context;
        }

        // GET: Punetori
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var fAI2_0Context = _context.Punetori.Include(p => p.Roli);
            return View(await fAI2_0Context.ToListAsync());
        }
        [Authorize]
        // GET: Punetori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punetori = await _context.Punetori
                .Include(p => p.Roli)
                .FirstOrDefaultAsync(m => m.PunetoriId == id);
            if (punetori == null)
            {
                return NotFound();
            }

            return View(punetori);
        }
        [Authorize]
        // GET: Punetori/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["RoliId"] = new SelectList(_context.Roli, "RoliId", "RoliId");
            return View();
        }

        // POST: Punetori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PunetoriId,Emri,Mbiemri,Gjinia,RoliId,NumriPersonal")] Punetori punetori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(punetori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoliId"] = new SelectList(_context.Roli, "RoliId", "RoliId", punetori.RoliId);
            return View(punetori);
        }

        
        // GET: Punetori/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punetori = await _context.Punetori.FindAsync(id);
            if (punetori == null)
            {
                return NotFound();
            }
            ViewData["RoliId"] = new SelectList(_context.Roli, "RoliId", "RoliId", punetori.RoliId);
            return View(punetori);
        }

        // POST: Punetori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PunetoriId,Emri,Mbiemri,Gjinia,RoliId,NumriPersonal")] Punetori punetori)
        {
            if (id != punetori.PunetoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(punetori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PunetoriExists(punetori.PunetoriId))
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
            ViewData["RoliId"] = new SelectList(_context.Roli, "RoliId", "RoliId", punetori.RoliId);
            return View(punetori);
        }

        // GET: Punetori/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punetori = await _context.Punetori
                .Include(p => p.Roli)
                .FirstOrDefaultAsync(m => m.PunetoriId == id);
            if (punetori == null)
            {
                return NotFound();
            }

            return View(punetori);
        }

        // POST: Punetori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var punetori = await _context.Punetori.FindAsync(id);
            _context.Punetori.Remove(punetori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PunetoriExists(int id)
        {
            return _context.Punetori.Any(e => e.PunetoriId == id);
        }
    }
}
