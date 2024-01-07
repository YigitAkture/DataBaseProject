using DatabaseProject.Data;
using DatabaseProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    [Authorize]
    public class InstituteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstituteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Institutes.Include(x => x.University).OrderBy(x => x.University.UniversityName).ThenBy(x => x.InstituteName).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["UniversityList"] = GetUniversityList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Institute institute)
        {
            if (!string.IsNullOrWhiteSpace(institute.InstituteName) && institute.UniversityId > 0)
            {
                var university = await _context.Universities.FirstOrDefaultAsync(u => u.UniversityId == institute.UniversityId);
                if (university != null)
                {
                    institute.University = university;
                    _context.Institutes.Add(institute);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(institute);
        }

        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["UniversityList"] = GetUniversityList();

            var institute = await _context.Institutes.FindAsync(id);
            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Institute institute)
        {
            if (id != institute.InstituteId)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(institute.InstituteName) && institute.UniversityId > 0)
            {
                var university = await _context.Universities.FirstOrDefaultAsync(u => u.UniversityId == institute.UniversityId);
                if (university != null)
                {
                    institute.University = university;
                    _context.Institutes.Update(institute);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(institute);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var institute = await _context.Institutes.FindAsync(id);
            _context.Institutes.Remove(institute);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private SelectList GetUniversityList()
        {
            return new SelectList(_context.Universities.OrderBy(u => u.UniversityName), "UniversityId", "UniversityName");
        }
    }
}
