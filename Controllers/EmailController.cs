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
    public class EmailController : Controller
    {
        private readonly AppDbContext _context;

        public EmailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Email
        public async Task<IActionResult> Index()
        {
              return _context.Emails != null ? 
                          View(await _context.Emails.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Emails'  is null.");
        }

        // GET: Email/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Emails == null)
            {
                return NotFound();
            }

            var email = await _context.Emails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: Email/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Email/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titel,Beschreibung,Gesendet")] Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(email);
        }

        // GET: Email/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Emails == null)
            {
                return NotFound();
            }

            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: Email/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titel,Beschreibung,Gesendet")] Email email)
        {
            if (id != email.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.Id))
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
            return View(email);
        }

        // GET: Email/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Emails == null)
            {
                return NotFound();
            }

            var email = await _context.Emails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: Email/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Emails == null)
            {
                return Problem("Entity set 'AppDbContext.Emails'  is null.");
            }
            var email = await _context.Emails.FindAsync(id);
            if (email != null)
            {
                _context.Emails.Remove(email);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailExists(int id)
        {
          return (_context.Emails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
