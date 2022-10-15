using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;

namespace App.Controllers
{
    public class EmailPersonController : Controller
    {
        private readonly AppDbContext _context;

        public EmailPersonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EmailPerson
        public async Task<IActionResult> Index()
        {
              return _context.EmailPersonen != null ? 
                          View(await _context.EmailPersonen.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.EmailPersonen'  is null.");
        }

        // GET: EmailPerson/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmailPersonen == null)
            {
                return NotFound();
            }

            var emailPerson = await _context.EmailPersonen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailPerson == null)
            {
                return NotFound();
            }

            return View(emailPerson);
        }

        // GET: EmailPerson/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailPerson/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Person,Email")] EmailPerson emailPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailPerson);
        }

        // GET: EmailPerson/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmailPersonen == null)
            {
                return NotFound();
            }

            var emailPerson = await _context.EmailPersonen.FindAsync(id);
            if (emailPerson == null)
            {
                return NotFound();
            }
            return View(emailPerson);
        }

        // POST: EmailPerson/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Person,Email")] EmailPerson emailPerson)
        {
            if (id != emailPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailPersonExists(emailPerson.Id))
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
            return View(emailPerson);
        }

        // GET: EmailPerson/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmailPersonen == null)
            {
                return NotFound();
            }

            var emailPerson = await _context.EmailPersonen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailPerson == null)
            {
                return NotFound();
            }

            return View(emailPerson);
        }

        // POST: EmailPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmailPersonen == null)
            {
                return Problem("Entity set 'AppDbContext.EmailPersonen'  is null.");
            }
            var emailPerson = await _context.EmailPersonen.FindAsync(id);
            if (emailPerson != null)
            {
                _context.EmailPersonen.Remove(emailPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailPersonExists(int id)
        {
          return (_context.EmailPersonen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
