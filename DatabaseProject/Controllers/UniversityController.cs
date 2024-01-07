using DatabaseProject.Data;
using DatabaseProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    [Authorize]
    public class UniversityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UniversityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Universities.OrderBy(u => u.UniversityName).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(University university)
        {
            if (ModelState.IsValid)
            {
                _context.Universities.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(university);
        }

        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, University university)
        {
            if (id != university.UniversityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Universities.Update(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(university);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var university = await _context.Universities.FindAsync(id);
            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
