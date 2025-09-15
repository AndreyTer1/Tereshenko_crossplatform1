using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tereshenko_crossplatform1.Data;
using Tereshenko_crossplatform1.Models;
using Tereshenko_crossplatform1.Data;

namespace Tereshenko_crossplatform1.Controllers
{
    public class CarsController : Controller
    {
        private readonly AppDbContext _db;
        public CarsController(AppDbContext db) => _db = db;

        // READ: Index
        public async Task<IActionResult> Index()
        {
            var cars = await _db.Cars.AsNoTracking().ToListAsync();
            return View(cars);
        }

        // READ: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var car = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        // CREATE: GET
        public IActionResult Create() => View();

        // CREATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Make,Model,Year,Price")] Tereshenko_Car car)
        {
            if (!ModelState.IsValid) return View(car);
            _db.Cars.Add(car);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // UPDATE: GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var car = await _db.Cars.FindAsync(id);
            if (car == null) return NotFound();
            return View(car);
        }

        // UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Year,Price")] Tereshenko_Car car)
        {
            if (id != car.Id) return BadRequest();
            if (!ModelState.IsValid) return View(car);

            try
            {
                _db.Update(car);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Cars.AnyAsync(e => e.Id == car.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // DELETE: GET (confirmation)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var car = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        // DELETE: POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _db.Cars.FindAsync(id);
            if (car != null)
            {
                _db.Cars.Remove(car);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
