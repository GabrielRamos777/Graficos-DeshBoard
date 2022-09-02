using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOPAINNOGAIN.Data;
using NOPAINNOGAIN.Models;

namespace NOPAINNOGAIN.Controllers
{
    [Authorize]
    public class AparelhoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AparelhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aparelho
        public async Task<IActionResult> Index()
        {
            return View(await _context.AparelhosGR.ToListAsync());
        }

        // GET: Aparelho/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparelho = await _context.AparelhosGR
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aparelho == null)
            {
                return NotFound();
            }

            return View(aparelho);
        }

        // GET: Aparelho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aparelho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aparelho aparelho)
        {
            if (ModelState.IsValid)
            {
                aparelho.ID = Guid.NewGuid();
                _context.Add(aparelho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aparelho);
        }

        // GET: Aparelho/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparelho = await _context.AparelhosGR.FindAsync(id);
            if (aparelho == null)
            {
                return NotFound();
            }
            return View(aparelho);
        }

        // POST: Aparelho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Aparelho aparelho)
        {
            if (id != aparelho.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aparelho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AparelhoExists(aparelho.ID))
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
            return View(aparelho);
        }

        // GET: Aparelho/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparelho = await _context.AparelhosGR
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aparelho == null)
            {
                return NotFound();
            }

            return View(aparelho);
        }

        // POST: Aparelho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var aparelho = await _context.AparelhosGR.FindAsync(id);
            _context.AparelhosGR.Remove(aparelho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AparelhoExists(Guid id)
        {
            return _context.AparelhosGR.Any(e => e.ID == id);
        }
    }
}
