using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using soa_web.Models;

namespace soa_web.Controllers
{
    public class ActivosController : Controller
    {
        private readonly SOA_MedioWebContext _context;

        public ActivosController(SOA_MedioWebContext context)
        {
            _context = context;
        }

        // GET: Activos
        public async Task<IActionResult> Index()
        {
            var sOA_MedioWebContext = _context.Activos.Include(a => a.IdEmpleadoNavigation);
            return View(await sOA_MedioWebContext.ToListAsync());
        }

        // GET: Activos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Activos == null)
            {
                return NotFound();
            }

            var activo = await _context.Activos
                .Include(a => a.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activo == null)
            {
                return NotFound();
            }

            return View(activo);
        }

        // GET: Activos/Create
        public IActionResult Create()
        {
            if (_context.Personas == null)
            {
                return NotFound();
            }

            ViewData["IdEmpleado"] = new SelectList(_context.Personas, "Id", "Id");
            return View();
        }

        // POST: Activos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Date,IdEmpleado")] Activo activo)

        {
            _context.Add(activo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            /*  if (ModelState.IsValid)
              {
                  _context.Add(activo);
                  await _context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
              }

              if (_context.Personas == null)
              {
                  return NotFound();
              }

              ViewData["IdEmpleado"] = new SelectList(_context.Personas, "Id", "Id", activo.IdEmpleado);
              return View(activo);*/
        }

        // GET: Activos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Activos == null)
            {
                return NotFound();
            }

            var activo = await _context.Activos.FindAsync(id);
            if (activo == null)
            {
                return NotFound();
            }

            if (_context.Personas == null)
            {
                return NotFound();
            }

            ViewData["IdEmpleado"] = new SelectList(_context.Personas, "Id", "Id", activo.IdEmpleado);
            return View(activo);
        }

        // POST: Activos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Date,IdEmpleado")] Activo activo)
        {
            if (id != activo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Activos.Any(e => e.Id == activo.Id))
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

            if (_context.Personas == null)
            {
                return NotFound();
            }

            ViewData["IdEmpleado"] = new SelectList(_context.Personas, "Id", "Id", activo.IdEmpleado);
            return View(activo);
        }

        // GET: Activos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Activos == null)
            {
                return NotFound();
            }

            var activo = await _context.Activos
                .Include(a => a.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activo == null)
            {
                return NotFound();
            }

            return View(activo);
        }

        // POST: Activos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Activos == null)
            {
                return Problem("Entity set 'SOA_MedioWebContext.Activos' is null.");
            }

            var activo = await _context.Activos.FindAsync(id);
            if (activo != null)
            {
                _context.Activos.Remove(activo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ActivoExists(int id)
        {
            return (_context.Activos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
