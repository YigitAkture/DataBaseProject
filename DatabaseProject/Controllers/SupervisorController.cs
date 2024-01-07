using DatabaseProject.Data;
using DatabaseProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    [Authorize]
    public class SupervisorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupervisorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Supervisors.OrderBy(a => a.SupervisorName).ThenBy(a => a.SupervisorSurname).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Supervisors.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(supervisor);
        }

        public async Task<IActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisors.FindAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(string id, Supervisor supervisor)
        {
            if (id != supervisor.SupervisorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Supervisors.Update(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(supervisor);
        }

        public async Task<IActionResult> DeleteAsync(string id)
        {
            var supervisor = await _context.Supervisors.FindAsync(id);
            _context.Supervisors.Remove(supervisor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
