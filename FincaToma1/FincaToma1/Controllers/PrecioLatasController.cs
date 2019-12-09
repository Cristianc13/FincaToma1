using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FincaToma1.Data;
using FincaToma1.Models;

namespace FincaToma1.Controllers
{
    public class PrecioLatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrecioLatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrecioLatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrecioLata.ToListAsync());
        }

        // GET: PrecioLatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioLata = await _context.PrecioLata
                .FirstOrDefaultAsync(m => m.IDPL == id);
            if (precioLata == null)
            {
                return NotFound();
            }

            return View(precioLata);
        }

        // GET: PrecioLatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrecioLatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDPL,Temporada,PrecioPL")] PrecioLata precioLata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precioLata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(precioLata);
        }

        // GET: PrecioLatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioLata = await _context.PrecioLata.FindAsync(id);
            if (precioLata == null)
            {
                return NotFound();
            }
            return View(precioLata);
        }

        // POST: PrecioLatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDPL,Temporada,PrecioPL")] PrecioLata precioLata)
        {
            if (id != precioLata.IDPL)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precioLata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecioLataExists(precioLata.IDPL))
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
            return View(precioLata);
        }

        // GET: PrecioLatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precioLata = await _context.PrecioLata
                .FirstOrDefaultAsync(m => m.IDPL == id);
            if (precioLata == null)
            {
                return NotFound();
            }

            return View(precioLata);
        }

        // POST: PrecioLatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var precioLata = await _context.PrecioLata.FindAsync(id);
            _context.PrecioLata.Remove(precioLata);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecioLataExists(int id)
        {
            return _context.PrecioLata.Any(e => e.IDPL == id);
        }
    }
}
