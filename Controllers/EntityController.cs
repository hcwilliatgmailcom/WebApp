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
    public class EntityController : Controller
    {
        private readonly AppDbContext _context;

        public EntityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Entity
        public async Task<IActionResult> Index()
        {
              return _context.Entities != null ? 
                          View(await _context.Entities.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Entities'  is null.");
        }

        // GET: Entity/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Entities == null)
            {
                return NotFound();
            }

            var entity = await _context.Entities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Entity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Entity entity)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw($"CREATE TABLE IF NOT EXISTS `{entity.Id}` (`Id` INT(11) NOT NULL AUTO_INCREMENT, PRIMARY KEY (`Id`)) ENGINE = InnoDB AUTO_INCREMENT = 2 DEFAULT CHARACTER SET = utf8mb4;");

                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: Entity/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Entities == null)
            {
                return NotFound();
            }

            var entity = await _context.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // POST: Entity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] Entity entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(entity.Id))
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
            return View(entity);
        }

        // GET: Entity/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Entities == null)
            {
                return NotFound();
            }

            var entity = await _context.Entities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: Entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Entities == null)
            {
                return Problem("Entity set 'AppDbContext.Entities'  is null.");
            }
            var entity = await _context.Entities.FindAsync(id);
            if (entity != null)
            {
                 _context.Database.ExecuteSqlRaw($"DROP TABLE `{entity.Id}`;");

            }
            
 
            return RedirectToAction(nameof(Index));
        }

        private bool EntityExists(string id)
        {
          return (_context.Entities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
