using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_112_C.Models;

namespace UCP1_PAW_112_C.Controllers
{
    public class PenyuplaisController : Controller
    {
        private readonly MarketContext _context;

        public PenyuplaisController(MarketContext context)
        {
            _context = context;
        }

        // GET: Penyuplais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Penyuplais.ToListAsync());
        }

        // GET: Penyuplais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyuplai = await _context.Penyuplais
                .FirstOrDefaultAsync(m => m.IdSupplier == id);
            if (penyuplai == null)
            {
                return NotFound();
            }

            return View(penyuplai);
        }

        // GET: Penyuplais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Penyuplais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSupplier,UsernameSupplier,JenisBarang")] Penyuplai penyuplai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penyuplai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penyuplai);
        }

        // GET: Penyuplais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyuplai = await _context.Penyuplais.FindAsync(id);
            if (penyuplai == null)
            {
                return NotFound();
            }
            return View(penyuplai);
        }

        // POST: Penyuplais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSupplier,UsernameSupplier,JenisBarang")] Penyuplai penyuplai)
        {
            if (id != penyuplai.IdSupplier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penyuplai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenyuplaiExists(penyuplai.IdSupplier))
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
            return View(penyuplai);
        }

        // GET: Penyuplais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penyuplai = await _context.Penyuplais
                .FirstOrDefaultAsync(m => m.IdSupplier == id);
            if (penyuplai == null)
            {
                return NotFound();
            }

            return View(penyuplai);
        }

        // POST: Penyuplais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penyuplai = await _context.Penyuplais.FindAsync(id);
            _context.Penyuplais.Remove(penyuplai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenyuplaiExists(int id)
        {
            return _context.Penyuplais.Any(e => e.IdSupplier == id);
        }
    }
}
