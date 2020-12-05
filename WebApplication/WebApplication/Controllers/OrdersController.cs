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
    public class OrdersController : Controller
    {
        private readonly SellingComponentsDBContext context;

        public OrdersController()
        {
            context = new SellingComponentsDBContext();
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var sellingComponentsDBContext = context.Orders.Include(o => o.IdUserNavigation);
            return View(await sellingComponentsDBContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await context.Orders
                .Include(o => o.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(context.UserInformations, "Id", "Address");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUser,OrderDate,TotalCost,DeliveryAddress,DeliveryDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                context.Add(order);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(context.UserInformations, "Id", "Address", order.IdUser);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(context.UserInformations, "Id", "Address", order.IdUser);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,OrderDate,TotalCost,DeliveryAddress,DeliveryDate")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(order);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["IdUser"] = new SelectList(context.UserInformations, "Id", "Address", order.IdUser);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await context.Orders
                .Include(o => o.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await context.Orders.FindAsync(id);
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return context.Orders.Any(e => e.Id == id);
        }
    }
}
