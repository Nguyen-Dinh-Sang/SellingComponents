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
    public class ProductsController : Controller
    {
        private readonly SellingComponentsDBContext context;

        public ProductsController()
        {
            context = new SellingComponentsDBContext();
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var sellingComponentsDBContext = context.Products.Include(p => p.IdClassifyNavigation);
            var menu = context.Classifies.ToList();
            foreach(var item in menu)
            {
                Console.WriteLine(item.Id);
            }    
            ViewBag.classify = menu;
            return View(await sellingComponentsDBContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult Index(int Id,String searchString, int PageNumber = 1)
        {
            IEnumerable<Product> listProDucts;
            IEnumerable<Combo> listCombo;
            var sellingComponentsDBContext = context.Products.Include(p => p.IdClassifyNavigation);
            var combo = context.Combos;
            var catalog = context.Catalogs;
            Console.WriteLine("id là " + Id);
            ViewBag.PageNumber = PageNumber;
            ViewBag.TotalPages = Math.Ceiling(sellingComponentsDBContext.Count() / 6.0);
            ViewBag.Id = Id;
            
                if(!String.IsNullOrEmpty(searchString))
                {
                    listProDucts = sellingComponentsDBContext.Where(t=>t.ProductName.Contains(searchString));
                    listCombo = combo.Where(t => t.ComboName.Contains(searchString));
                    ViewBag.TotalPages = Math.Ceiling(listProDucts.Count() / 6.0);
                    ViewBag.searchString = searchString;
                }
                else
                {
                    listProDucts = sellingComponentsDBContext;
                    listCombo = combo;
                }
               
            var menu = context.Classifies.ToList();
            foreach (var item in menu)
            {
                Console.WriteLine(item.Id);
            }
            ViewBag.classify = menu;
            if(listCombo != null)
            {
                ViewBag.combo = listCombo.Skip((PageNumber - 1) * 6).Take(6).ToList();
            }
            else
            {
                ViewBag.combo = null;
            }

            ViewBag.catalog_menu = catalog;
            return View(listProDucts.Skip((PageNumber - 1) * 6).Take(6).ToList());
        }
        public IActionResult SanPham( int Id , int PageNumber = 1)
        {
            IEnumerable<Product> listProDucts;
            var sellingComponentsDBContext = context.Products.Include(p => p.IdClassifyNavigation);
            var catalog = context.Catalogs;
            ViewBag.PageNumber = PageNumber;
            ViewBag.Id = Id;
            var menu = context.Classifies.ToList();
            ViewBag.classify = menu;
            ViewBag.catalog_menu = catalog;
            listProDucts = sellingComponentsDBContext.Where(i => i.IdClassify == Id);
                ViewBag.TotalPages = Math.Ceiling(listProDucts.Count() / 6.0);
            return View(listProDucts.Skip((PageNumber - 1) * 6).Take(6).ToList());
            
            }
        public IActionResult Combo(int Id, int PageNumber = 1)
        {
            IEnumerable<Combo> listCombo;
            var sellingComponentsDBContext = context.Products.Include(p => p.IdClassifyNavigation);
            var catalog = context.Catalogs;
            var combo = context.Combos.Include(c => c.IdCatalogNavigation);
            ViewBag.PageNumber = PageNumber;
            ViewBag.Id = Id;
            var menu = context.Classifies.ToList();
            ViewBag.classify = menu;
            ViewBag.catalog_menu = catalog;
            listCombo = combo.Where(i => i.IdCatalog == Id);
            ViewBag.TotalPages = Math.Ceiling(listCombo.Count() / 6.0);
            return View(listCombo.Skip((PageNumber - 1) * 6).Take(6).ToList());
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products
                .Include(p => p.IdClassifyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["IdClassify"] = new SelectList(context.Classifies, "Id", "ClassifyDetail");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Amount,Price,Detail,IdClassify,DateCreated")] Product product)
        {
            if (ModelState.IsValid)
            {
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClassify"] = new SelectList(context.Classifies, "Id", "ClassifyDetail", product.IdClassify);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["IdClassify"] = new SelectList(context.Classifies, "Id", "ClassifyDetail", product.IdClassify);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Amount,Price,Detail,IdClassify,DateCreated")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(product);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["IdClassify"] = new SelectList(context.Classifies, "Id", "ClassifyDetail", product.IdClassify);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products
                .Include(p => p.IdClassifyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await context.Products.FindAsync(id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return context.Products.Any(e => e.Id == id);
        }
    }
}
