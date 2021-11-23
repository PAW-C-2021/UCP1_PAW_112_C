﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_112_C.Models;

namespace UCP1_PAW_112_C.Controllers
{
    public class PenjualsController : Controller
    {
        private readonly MarketContext _context;

        public PenjualsController(MarketContext context)
        {
            _context = context;
        }

        // GET: Penjuals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Penjuals.ToListAsync());
        }

        // GET: Penjuals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penjual = await _context.Penjuals
                .FirstOrDefaultAsync(m => m.IdPenjual == id);
            if (penjual == null)
            {
                return NotFound();
            }

            return View(penjual);
        }

        // GET: Penjuals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Penjuals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPenjual,JenisBarang,UsernamePenjual")] Penjual penjual)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penjual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penjual);
        }

        // GET: Penjuals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penjual = await _context.Penjuals.FindAsync(id);
            if (penjual == null)
            {
                return NotFound();
            }
            return View(penjual);
        }

        // POST: Penjuals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPenjual,JenisBarang,UsernamePenjual")] Penjual penjual)
        {
            if (id != penjual.IdPenjual)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penjual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenjualExists(penjual.IdPenjual))
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
            return View(penjual);
        }

        // GET: Penjuals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penjual = await _context.Penjuals
                .FirstOrDefaultAsync(m => m.IdPenjual == id);
            if (penjual == null)
            {
                return NotFound();
            }

            return View(penjual);
        }

        // POST: Penjuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penjual = await _context.Penjuals.FindAsync(id);
            _context.Penjuals.Remove(penjual);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenjualExists(int id)
        {
            return _context.Penjuals.Any(e => e.IdPenjual == id);
        }
    }
}
