using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phase_three_final_project.Models;

namespace Phase_three_final_project.Controllers
{
    public class DescriptionController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DescriptionController()
        {
            _context = new ApplicationDBContext();
        }

        // GET: Description
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Description.Include(d => d.Product);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Description/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Description
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DescriptionId == id);
            if (description == null)
            {
                return NotFound();
            }

            return View(description);
        }

        // GET: Description/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name");
            return View();
        }

        // POST: Description/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescriptionId,OS,Processor,Memory,HardDrive,ProductId")] Description description)
        {
            if (ModelState.IsValid)
            {
                _context.Add(description);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name", description.ProductId);
            return View(description);
        }

        // GET: Description/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Description.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name", description.ProductId);
            return View(description);
        }

        // POST: Description/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescriptionId,OS,Processor,Memory,HardDrive,ProductId")] Description description)
        {
            if (id != description.DescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(description);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescriptionExists(description.DescriptionId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Name", description.ProductId);
            return View(description);
        }

        // GET: Description/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Description
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DescriptionId == id);
            if (description == null)
            {
                return NotFound();
            }

            return View(description);
        }

        // POST: Description/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var description = await _context.Description.FindAsync(id);
            _context.Description.Remove(description);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescriptionExists(int id)
        {
            return _context.Description.Any(e => e.DescriptionId == id);
        }
    }
}
