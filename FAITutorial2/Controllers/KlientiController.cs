using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FAITutorial2.Models;

namespace FAITutorial2.Controllers
{
    public class KlientiController : Controller
    {
        private readonly FAI2_0Context _context;

        public KlientiController(FAI2_0Context context)
        {
            _context = context;
        }

        // GET: Klienti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klienti.ToListAsync());
        }

        // GET: Klienti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienti = await _context.Klienti
                .FirstOrDefaultAsync(m => m.KlientiId == id);
            if (klienti == null)
            {
                return NotFound();
            }

            return View(klienti);
        }

        // GET: Klienti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klienti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlientiId,Emri,Mbiemri,NumriTelefonit,Email")] Klienti klienti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klienti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klienti);
        }

        // GET: Klienti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienti = await _context.Klienti.FindAsync(id);
            if (klienti == null)
            {
                return NotFound();
            }
            return View(klienti);
        }

        // POST: Klienti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlientiId,Emri,Mbiemri,NumriTelefonit,Email")] Klienti klienti)
        {
            if (id != klienti.KlientiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klienti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientiExists(klienti.KlientiId))
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
            return View(klienti);
        }

        // GET: Klienti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienti = await _context.Klienti
                .FirstOrDefaultAsync(m => m.KlientiId == id);
            if (klienti == null)
            {
                return NotFound();
            }

            return View(klienti);
        }

        // POST: Klienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klienti = await _context.Klienti.FindAsync(id);
            _context.Klienti.Remove(klienti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientiExists(int id)
        {
            return _context.Klienti.Any(e => e.KlientiId == id);
        }
    }
}
