using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using System.Diagnostics;
using WebApp.Models;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Data.SqlClient;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly d03adb48Context _context;

        public HomeController(d03adb48Context context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Home()
        {
            return _context.Homes != null ?
                        View(await _context.Homes.Select(h => h.TableName).Distinct().ToListAsync()) :
                        Problem("Entity set 'd03adb48Context.Homes'  is null.");
        }

        // GET: Home/Details/5
        public ActionResult<DataSet> Index(string name)
        {
 
            MySqlConnection connection = new MySqlConnection("server=hcwilli.at;database=d03adb48;user=d03adb48;password=k8J3CMGz7sL68rJW;SslMode=none;");
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            connection.Open();
#warning injection
            MySqlCommand command = new MySqlCommand($"SELECT * FROM {name} LIMIT 20 OFFSET 0",connection); 
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            connection.Close();
            ViewBag.name=name;
            return View(dataset);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Key,TableName,ColumnName")] Home home)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(home);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Homes == null)
            {
                return NotFound();
            }

            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            return View(home);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Key,TableName,ColumnName")] Home home)
        {
            if (id != home.Key)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.Key))
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
            return View(home);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Homes == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .FirstOrDefaultAsync(m => m.Key == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Homes == null)
            {
                return Problem("Entity set 'd03adb48Context.Homes'  is null.");
            }
            var home = await _context.Homes.FindAsync(id);
            if (home != null)
            {
                _context.Homes.Remove(home);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(string id)
        {
            return (_context.Homes?.Any(e => e.Key == id)).GetValueOrDefault();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
