using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CofeeBreak3.Data;

namespace CofeeBreak3.Controllers
{
    public class CoffeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoffeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoffeTypes
        public async Task<IActionResult> Index()
        {
              return _context.CoffeTypes != null ? 
                          View(await _context.CoffeTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CoffeTypes'  is null.");
        }

        // GET: CoffeTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CoffeTypes == null)
            {
                return NotFound();
            }

            var coffeType = await _context.CoffeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeType == null)
            {
                return NotFound();
            }

            return View(coffeType);
        }

        // GET: CoffeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoffeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,RegisterON")] CoffeType coffeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffeType);
        }

        // GET: CoffeTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CoffeTypes == null)
            {
                return NotFound();
            }

            var coffeType = await _context.CoffeTypes.FindAsync(id);
            if (coffeType == null)
            {
                return NotFound();
            }
            return View(coffeType);
        }

        // POST: CoffeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,RegisterON")] CoffeType coffeType)
        {
            if (id != coffeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeTypeExists(coffeType.Id))
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
            return View(coffeType);
        }

        // GET: CoffeTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CoffeTypes == null)
            {
                return NotFound();
            }

            var coffeType = await _context.CoffeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeType == null)
            {
                return NotFound();
            }

            return View(coffeType);
        }

        // POST: CoffeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CoffeTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CoffeTypes'  is null.");
            }
            var coffeType = await _context.CoffeTypes.FindAsync(id);
            if (coffeType != null)
            {
                _context.CoffeTypes.Remove(coffeType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeTypeExists(string id)
        {
          return (_context.CoffeTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
