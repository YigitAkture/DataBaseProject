using DatabaseProject.Data;
using DatabaseProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    [Authorize]
    public class CoSupervisorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoSupervisorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.CoSupervisors.OrderBy(a => a.CoSupervisorName).ThenBy(a => a.CoSupervisorSurname).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CoSupervisor coSupervisor)
        {
            if (ModelState.IsValid)
            {
                _context.CoSupervisors.Add(coSupervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(coSupervisor);
        }

        public async Task<IActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSupervisor = await _context.CoSupervisors.FindAsync(id);
            if (coSupervisor == null)
            {
                return NotFound();
            }

            return View(coSupervisor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(string id, CoSupervisor coSupervisor)
        {
            if (id != coSupervisor.CoSupervisorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.CoSupervisors.Update(coSupervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(coSupervisor);
        }

        public async Task<IActionResult> DeleteAsync(string id)
        {
            var coSupervisor = await _context.CoSupervisors.FindAsync(id);
            _context.CoSupervisors.Remove(coSupervisor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
