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
    public class UserInformationsController : Controller
    {
        private readonly SellingComponentsDBContext context;

        public UserInformationsController()
        {
            context = new SellingComponentsDBContext();
        }

        // GET: UserInformations
        public async Task<IActionResult> Index()
        {
            var sellingComponentsDBContext = context.UserInformations.Include(u => u.IdRoleNavigation);
            return View(await sellingComponentsDBContext.ToListAsync());
        }

        // GET: UserInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInformation = await context.UserInformations
                .Include(u => u.IdRoleNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInformation == null)
            {
                return NotFound();
            }

            return View(userInformation);
        }

        // GET: UserInformations/Create
        public IActionResult Create()
        {
            ViewData["IdRole"] = new SelectList(context.Roles, "Id", "Role1");
            return View();
        }

        // POST: UserInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,FullName,Sex,PhoneNumber,Email,Brithday,Address,JoinDate,IdRole")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                context.Add(userInformation);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRole"] = new SelectList(context.Roles, "Id", "Role1", userInformation.IdRole);
            return View(userInformation);
        }

        // GET: UserInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInformation = await context.UserInformations.FindAsync(id);
            if (userInformation == null)
            {
                return NotFound();
            }
            ViewData["IdRole"] = new SelectList(context.Roles, "Id", "Role1", userInformation.IdRole);
            return View(userInformation);
        }

        // POST: UserInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,FullName,Sex,PhoneNumber,Email,Brithday,Address,JoinDate,IdRole")] UserInformation userInformation)
        {
            if (id != userInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(userInformation);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInformationExists(userInformation.Id))
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
            ViewData["IdRole"] = new SelectList(context.Roles, "Id", "Role1", userInformation.IdRole);
            return View(userInformation);
        }

        // GET: UserInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInformation = await context.UserInformations
                .Include(u => u.IdRoleNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInformation == null)
            {
                return NotFound();
            }

            return View(userInformation);
        }

        // POST: UserInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInformation = await context.UserInformations.FindAsync(id);
            context.UserInformations.Remove(userInformation);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInformationExists(int id)
        {
            return context.UserInformations.Any(e => e.Id == id);
        }
    }
}
