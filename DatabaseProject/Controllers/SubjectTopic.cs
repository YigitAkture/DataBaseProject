using DatabaseProject.Data;
using DatabaseProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    [Authorize]
    public class SubjectTopicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectTopicController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.SubjectTopics.OrderBy(u => u.SubjectTopicName).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(SubjectTopic subjectTopic)
        {
            if (ModelState.IsValid)
            {
                _context.SubjectTopics.Add(subjectTopic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(subjectTopic);
        }

        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectTopic = await _context.SubjectTopics.FindAsync(id);
            if (subjectTopic == null)
            {
                return NotFound();
            }

            return View(subjectTopic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, SubjectTopic subjectTopic)
        {
            if (id != subjectTopic.SubjectTopicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.SubjectTopics.Update(subjectTopic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(subjectTopic);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var subjectTopic = await _context.SubjectTopics.FindAsync(id);
            _context.SubjectTopics.Remove(subjectTopic);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
