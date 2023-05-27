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
    public class CofeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CofeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cofees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cofees.Include(c => c.Categories);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cofees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cofees == null)
            {
                return NotFound();
            }

            var cofee = await _context.Cofees
                .Include(c => c.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cofee == null)
            {
                return NotFound();
            }

            return View(cofee);
        }

        // GET: Cofees/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Cofees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,RegisterON,Description,ImageURL,CategoryId,CoffeTypeId")] Cofee cofee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cofee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", cofee.CategoryId);
            return View(cofee);
        }

        // GET: Cofees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cofees == null)
            {
                return NotFound();
            }

            var cofee = await _context.Cofees.FindAsync(id);
            if (cofee == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", cofee.CategoryId);
            return View(cofee);
        }

        // POST: Cofees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,RegisterON,Description,ImageURL,CategoryId,CoffeTypeId")] Cofee cofee)
        {
            if (id != cofee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cofee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CofeeExists(cofee.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", cofee.CategoryId);
            return View(cofee);
        }

        // GET: Cofees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cofees == null)
            {
                return NotFound();
            }

            var cofee = await _context.Cofees
                .Include(c => c.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cofee == null)
            {
                return NotFound();
            }

            return View(cofee);
        }

        // POST: Cofees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cofees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cofees'  is null.");
            }
            var cofee = await _context.Cofees.FindAsync(id);
            if (cofee != null)
            {
                _context.Cofees.Remove(cofee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CofeeExists(int id)
        {
          return (_context.Cofees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
