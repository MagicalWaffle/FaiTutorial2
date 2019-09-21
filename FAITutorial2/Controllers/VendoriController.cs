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
    public class VendoriController : Controller
    {
        private readonly FAI2_0Context _context;

        public VendoriController(FAI2_0Context context)
        {
            _context = context;
        }

        // GET: Vendori
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendori.ToListAsync());
        }

        // GET: Vendori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendori = await _context.Vendori
                .FirstOrDefaultAsync(m => m.VendoriId == id);
            if (vendori == null)
            {
                return NotFound();
            }

            return View(vendori);
        }

        // GET: Vendori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendoriId,Emri,Lokacioni,NrKontaktues,BankAccount")] Vendori vendori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendori);
        }

        // GET: Vendori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendori = await _context.Vendori.FindAsync(id);
            if (vendori == null)
            {
                return NotFound();
            }
            return View(vendori);
        }

        // POST: Vendori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendoriId,Emri,Lokacioni,NrKontaktues,BankAccount")] Vendori vendori)
        {
            if (id != vendori.VendoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendoriExists(vendori.VendoriId))
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
            return View(vendori);
        }

        // GET: Vendori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendori = await _context.Vendori
                .FirstOrDefaultAsync(m => m.VendoriId == id);
            if (vendori == null)
            {
                return NotFound();
            }

            return View(vendori);
        }

        // POST: Vendori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendori = await _context.Vendori.FindAsync(id);
            _context.Vendori.Remove(vendori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendoriExists(int id)
        {
            return _context.Vendori.Any(e => e.VendoriId == id);
        }
    }
}
