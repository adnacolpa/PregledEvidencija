using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PregledEvidencija.Data;
using PregledEvidencija.Models;

namespace PregledEvidencija.Controllers
{
    public class InspekcijskoTijeloesController : Controller
    {
        private readonly PEContext _context;

        public InspekcijskoTijeloesController(PEContext context)
        {
            _context = context;
        }

        // GET: InspekcijskoTijeloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InspekcijskoTijelos.ToListAsync());
        }

        // GET: InspekcijskoTijeloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspekcijskoTijelo = await _context.InspekcijskoTijelos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inspekcijskoTijelo == null)
            {
                return NotFound();
            }

            return View(inspekcijskoTijelo);
        }

        // GET: InspekcijskoTijeloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InspekcijskoTijeloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naziv,Inspektorat,Nadleznost,KontaktOsoba")] InspekcijskoTijelo inspekcijskoTijelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspekcijskoTijelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspekcijskoTijelo);
        }

        // GET: InspekcijskoTijeloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspekcijskoTijelo = await _context.InspekcijskoTijelos.FindAsync(id);
            if (inspekcijskoTijelo == null)
            {
                return NotFound();
            }
            return View(inspekcijskoTijelo);
        }

        // POST: InspekcijskoTijeloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Inspektorat,Nadleznost,KontaktOsoba")] InspekcijskoTijelo inspekcijskoTijelo)
        {
            if (id != inspekcijskoTijelo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspekcijskoTijelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspekcijskoTijeloExists(inspekcijskoTijelo.ID))
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
            return View(inspekcijskoTijelo);
        }

        // GET: InspekcijskoTijeloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspekcijskoTijelo = await _context.InspekcijskoTijelos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inspekcijskoTijelo == null)
            {
                return NotFound();
            }

            return View(inspekcijskoTijelo);
        }

        // POST: InspekcijskoTijeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inspekcijskoTijelo = await _context.InspekcijskoTijelos.FindAsync(id);
            _context.InspekcijskoTijelos.Remove(inspekcijskoTijelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspekcijskoTijeloExists(int id)
        {
            return _context.InspekcijskoTijelos.Any(e => e.ID == id);
        }
    }
}
