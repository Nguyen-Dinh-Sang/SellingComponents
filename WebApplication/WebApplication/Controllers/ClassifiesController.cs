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
    public class ClassifiesController : Controller
    {
        private readonly SellingComponentsDBContext context;

        public ClassifiesController()
        {
            context = new SellingComponentsDBContext();
        }

        // GET: Classifies
        public async Task<IActionResult> Index()
        {
            return View(await context.Classifies.ToListAsync());
        }

        // GET: Classifies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classify = await context.Classifies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classify == null)
            {
                return NotFound();
            }

            return View(classify);
        }

        // GET: Classifies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classifies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassifyName,ClassifyDetail,DateCreated")] Classify classify)
        {
            if (ModelState.IsValid)
            {
                context.Add(classify);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classify);
        }

        // GET: Classifies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classify = await context.Classifies.FindAsync(id);
            if (classify == null)
            {
                return NotFound();
            }
            return View(classify);
        }

        // POST: Classifies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassifyName,ClassifyDetail,DateCreated")] Classify classify)
        {
            if (id != classify.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(classify);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassifyExists(classify.Id))
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
            return View(classify);
        }

        // GET: Classifies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classify = await context.Classifies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classify == null)
            {
                return NotFound();
            }

            return View(classify);
        }

        // POST: Classifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classify = await context.Classifies.FindAsync(id);
            context.Classifies.Remove(classify);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassifyExists(int id)
        {
            return context.Classifies.Any(e => e.Id == id);
        }
    }
}
