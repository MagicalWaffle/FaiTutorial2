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
    public class RoliController : Controller
    {
        private readonly FAI2_0Context _context;

        public RoliController(FAI2_0Context context)
        {
            _context = context;
        }

        // GET: Roli
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roli.ToListAsync());
        }

        // GET: Roli/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roli = await _context.Roli
                .FirstOrDefaultAsync(m => m.RoliId == id);
            if (roli == null)
            {
                return NotFound();
            }

            return View(roli);
        }

        // GET: Roli/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoliId,Roli1")] Roli roli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roli);
        }

        // GET: Roli/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roli = await _context.Roli.FindAsync(id);
            if (roli == null)
            {
                return NotFound();
            }
            return View(roli);
        }

        // POST: Roli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoliId,Roli1")] Roli roli)
        {
            if (id != roli.RoliId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoliExists(roli.RoliId))
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
            return View(roli);
        }

        // GET: Roli/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roli = await _context.Roli
                .FirstOrDefaultAsync(m => m.RoliId == id);
            if (roli == null)
            {
                return NotFound();
            }

            return View(roli);
        }

        // POST: Roli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roli = await _context.Roli.FindAsync(id);
            _context.Roli.Remove(roli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoliExists(int id)
        {
            return _context.Roli.Any(e => e.RoliId == id);
        }
    }
}
