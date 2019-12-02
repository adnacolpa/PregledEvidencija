using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PregledEvidencija.Data;
using PregledEvidencija.Models;
using PregledEvidencija.ViewModels;

namespace PregledEvidencija.Controllers
{
    public class InspekcijskaKontrolasController : Controller
    {
        private readonly PEContext _context;

        public InspekcijskaKontrolasController(PEContext context)
        {
            _context = context;
        }

        // GET: InspekcijskaKontrolas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InspekcijskaKontrolas
                .Include(x => x.KontrolisaniProizvod)
                .Include(x=>x.NadleznoTijelo).ToListAsync());
        }

        // GET: InspekcijskaKontrolas/Filter
        public async Task<IActionResult> Filter(int? id)
        {
            SelectListItem NadleznoTijeloID = new SelectListItem();
            List<SelectListItem> nadleznoTijeloList = new List<SelectListItem>();

            foreach (InspekcijskoTijelo tijelo in _context.InspekcijskoTijelos)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = tijelo.Naziv;
                sli.Value = tijelo.ID.ToString();

                nadleznoTijeloList.Add(sli);
            }
            ViewBag.NadleznaTijela = nadleznoTijeloList;
            if (id == null)
            {
                return View("~/Views/InspekcijskaKontrolas/Pregled.cshtml", await _context.InspekcijskaKontrolas
                .Include(x => x.KontrolisaniProizvod)
                .Include(x => x.NadleznoTijelo).ToListAsync());
            }

            return View("~/Views/InspekcijskaKontrolas/Pregled.cshtml", await _context.InspekcijskaKontrolas
                .Include(x => x.KontrolisaniProizvod)
                .Include(x => x.NadleznoTijelo).ToListAsync());
        }

        // GET: InspekcijskaKontrolas/Pregled
        public async Task<IActionResult> Pregled()
        {
            SelectListItem NadleznoTijeloID = new SelectListItem();
            List<SelectListItem> nadleznoTijeloList = new List<SelectListItem>();

            foreach (InspekcijskoTijelo tijelo in _context.InspekcijskoTijelos)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = tijelo.Naziv;
                sli.Value = tijelo.ID.ToString();

                nadleznoTijeloList.Add(sli);
            }
            ViewBag.NadleznaTijela = nadleznoTijeloList;

            return View(await _context.InspekcijskaKontrolas
                .Include(x => x.KontrolisaniProizvod)
                .Include(x => x.NadleznoTijelo).ToListAsync());
        }

        // GET: InspekcijskaKontrolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspekcijskaKontrola = await _context.InspekcijskaKontrolas
                .Include(x => x.KontrolisaniProizvod)
                .Include(x => x.NadleznoTijelo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inspekcijskaKontrola == null)
            {
                return NotFound();
            }

            return View(inspekcijskaKontrola);
        }

        // GET: InspekcijskaKontrolas/Create
        public IActionResult Create()
        {
            InspekcijskaKontrolaViewModel vm = new InspekcijskaKontrolaViewModel();
            List<SelectListItem> proizvodList = new List<SelectListItem>();
            List<SelectListItem> nadleznoTijeloList = new List<SelectListItem>();

            foreach (Proizvod proizvod in _context.Proizvods)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = proizvod.Naziv;
                sli.Value = proizvod.ID.ToString();

                proizvodList.Add(sli);
            }
            foreach (InspekcijskoTijelo nadlezno in _context.InspekcijskoTijelos)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = nadlezno.Naziv;
                sli.Value = nadlezno.ID.ToString();

                nadleznoTijeloList.Add(sli);
            }
            vm.DatumKontrole = DateTime.Now;
            

            vm.ProizvodList = proizvodList;
            vm.TijeloList = nadleznoTijeloList;

            return View(vm);
            
        }

        // POST: InspekcijskaKontrolas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DatumKontrole,RezultatiKontrole,ProizvodSiguran,ProizvodID,NadleznoTijeloID")] InspekcijskaKontrolaViewModel kontrolaVM)
        {
            if (ModelState.IsValid)
            {
                InspekcijskaKontrola kontrola = new InspekcijskaKontrola();
                kontrola.KontrolisaniProizvod = _context.Proizvods.FirstOrDefault(c => c.ID == kontrolaVM.ProizvodID);
                kontrola.DatumKontrole = kontrolaVM.DatumKontrole;
                kontrola.ProizvodSiguran = kontrolaVM.ProizvodSiguran;
                kontrola.RezultatiKontrole = kontrolaVM.RezultatiKontrole;
                kontrola.NadleznoTijelo = _context.InspekcijskoTijelos.FirstOrDefault(c => c.ID == kontrolaVM.NadleznoTijeloID);

                _context.Add(kontrola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kontrolaVM);
        }

        // GET: InspekcijskaKontrolas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InspekcijskaKontrolaViewModel vm = new InspekcijskaKontrolaViewModel();
            List<SelectListItem> proizvodList = new List<SelectListItem>();
            List<SelectListItem> nadleznoTijeloList = new List<SelectListItem>();

            foreach (Proizvod proizvod in _context.Proizvods)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = proizvod.Naziv;
                sli.Value = proizvod.ID.ToString();

                proizvodList.Add(sli);
            }
            foreach (InspekcijskoTijelo nadlezno in _context.InspekcijskoTijelos)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = nadlezno.Naziv;
                sli.Value = nadlezno.ID.ToString();

                nadleznoTijeloList.Add(sli);
            }
            vm.DatumKontrole = DateTime.Now;
            vm.ProizvodList = proizvodList;
            vm.TijeloList = nadleznoTijeloList;

            return View(vm);
        }

        // POST: InspekcijskaKontrolas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DatumKontrole,RezultatiKontrole,ProizvodSiguran,ProizvodID,NadleznoTijeloID")] InspekcijskaKontrolaViewModel kontrolaVM)
        {
           
            if (ModelState.IsValid)
            {
                InspekcijskaKontrola kontrola = new InspekcijskaKontrola();
                kontrola.KontrolisaniProizvod = _context.Proizvods.FirstOrDefault(c => c.ID == kontrolaVM.ProizvodID);
                kontrola.DatumKontrole = kontrolaVM.DatumKontrole;
                kontrola.ProizvodSiguran = kontrolaVM.ProizvodSiguran;
                kontrola.RezultatiKontrole = kontrolaVM.RezultatiKontrole;
                kontrola.NadleznoTijelo = _context.InspekcijskoTijelos.FirstOrDefault(c => c.ID == kontrolaVM.NadleznoTijeloID);

                _context.Add(kontrola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kontrolaVM);
        }

        // GET: InspekcijskaKontrolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspekcijskaKontrola = await _context.InspekcijskaKontrolas
                .Include(x => x.KontrolisaniProizvod)
                .Include(x => x.NadleznoTijelo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inspekcijskaKontrola == null)
            {
                return NotFound();
            }

            return View(inspekcijskaKontrola);
        }

        // POST: InspekcijskaKontrolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inspekcijskaKontrola = await _context.InspekcijskaKontrolas.FindAsync(id);
            _context.InspekcijskaKontrolas.Remove(inspekcijskaKontrola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspekcijskaKontrolaExists(int id)
        {
            return _context.InspekcijskaKontrolas.Any(e => e.ID == id);
        }
    }
}
