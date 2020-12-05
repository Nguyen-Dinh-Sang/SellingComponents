using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ComboesController : Controller
    {
        private readonly SellingComponentsDBContext context;

        public ComboesController()
        {
            context = new SellingComponentsDBContext();
        }

        // GET: Comboes
        public async Task<IActionResult> Index()
        {
            var sellingComponentsDBContext = context.Combos.Include(c => c.IdCatalogNavigation);
            return View(await sellingComponentsDBContext.ToListAsync());
        }

        // GET: Comboes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combo = await context.Combos
                .Include(c => c.IdCatalogNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }

        // GET: Comboes/Create
        public IActionResult Create()
        {
            ViewData["IdCatalog"] = new SelectList(context.Catalogs, "Id", "CatalogDetails");
            return View();
        }

        // POST: Comboes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ComboName,ComboDetails,TotalCost,Price,IdCatalog,DateCreated")] Combo combo)
        {
            if (ModelState.IsValid)
            {
                context.Add(combo);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCatalog"] = new SelectList(context.Catalogs, "Id", "CatalogDetails", combo.IdCatalog);
            return View(combo);
        }

        // GET: Comboes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combo = await context.Combos.FindAsync(id);
            if (combo == null)
            {
                return NotFound();
            }
            ViewData["IdCatalog"] = new SelectList(context.Catalogs, "Id", "CatalogDetails", combo.IdCatalog);
            return View(combo);
        }

        // POST: Comboes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ComboName,ComboDetails,TotalCost,Price,IdCatalog,DateCreated")] Combo combo)
        {
            if (id != combo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(combo);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComboExists(combo.Id))
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
            ViewData["IdCatalog"] = new SelectList(context.Catalogs, "Id", "CatalogDetails", combo.IdCatalog);
            return View(combo);
        }

        // GET: Comboes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combo = await context.Combos
                .Include(c => c.IdCatalogNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }

        // POST: Comboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var combo = await context.Combos.FindAsync(id);
            context.Combos.Remove(combo);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComboExists(int id)
        {
            return context.Combos.Any(e => e.Id == id);
        }
    }
}
