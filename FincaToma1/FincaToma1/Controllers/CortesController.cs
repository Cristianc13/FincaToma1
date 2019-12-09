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
    public class CortesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CortesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cortes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Corte.Include(c => c.Empleado).Include(c => c.PrecioLata).Include(c => c.Ubicacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cortes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corte = await _context.Corte
                .Include(c => c.Empleado)
                .Include(c => c.PrecioLata)
                .Include(c => c.Ubicacion)
                .FirstOrDefaultAsync(m => m.IDC == id);
            if (corte == null)
            {
                return NotFound();
            }

            return View(corte);
        }

        // GET: Cortes/Create
        public IActionResult Create()
        {
            ViewData["IDE"] = new SelectList(_context.Empleado, "IDE", "IDE");
            ViewData["IDPL"] = new SelectList(_context.PrecioLata, "IDPL", "IDPL");
            ViewData["IDU"] = new SelectList(_context.Ubicacion, "IDU", "IDU");
            return View();
        }

        // POST: Cortes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDC,FechaCorte,LatasCortadas,SubTotal,IDE,IDU,IDPL")] Corte corte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDE"] = new SelectList(_context.Empleado, "IDE", "IDE", corte.IDE);
            ViewData["IDPL"] = new SelectList(_context.PrecioLata, "IDPL", "IDPL", corte.IDPL);
            ViewData["IDU"] = new SelectList(_context.Ubicacion, "IDU", "IDU", corte.IDU);
            return View(corte);
        }

        // GET: Cortes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corte = await _context.Corte.FindAsync(id);
            if (corte == null)
            {
                return NotFound();
            }
            ViewData["IDE"] = new SelectList(_context.Empleado, "IDE", "IDE", corte.IDE);
            ViewData["IDPL"] = new SelectList(_context.PrecioLata, "IDPL", "IDPL", corte.IDPL);
            ViewData["IDU"] = new SelectList(_context.Ubicacion, "IDU", "IDU", corte.IDU);
            return View(corte);
        }

        // POST: Cortes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDC,FechaCorte,LatasCortadas,SubTotal,IDE,IDU,IDPL")] Corte corte)
        {
            if (id != corte.IDC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorteExists(corte.IDC))
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
            ViewData["IDE"] = new SelectList(_context.Empleado, "IDE", "IDE", corte.IDE);
            ViewData["IDPL"] = new SelectList(_context.PrecioLata, "IDPL", "IDPL", corte.IDPL);
            ViewData["IDU"] = new SelectList(_context.Ubicacion, "IDU", "IDU", corte.IDU);
            return View(corte);
        }

        // GET: Cortes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corte = await _context.Corte
                .Include(c => c.Empleado)
                .Include(c => c.PrecioLata)
                .Include(c => c.Ubicacion)
                .FirstOrDefaultAsync(m => m.IDC == id);
            if (corte == null)
            {
                return NotFound();
            }

            return View(corte);
        }

        // POST: Cortes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corte = await _context.Corte.FindAsync(id);
            _context.Corte.Remove(corte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorteExists(int id)
        {
            return _context.Corte.Any(e => e.IDC == id);
        }
    }
}
