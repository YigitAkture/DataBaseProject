using DatabaseProject.Data;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    public class ScanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly int pageSize = 5;

        public ScanController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(string University, string Institute, string Language, string Author, string Keyword, string ThesisNo, string ThesisName, string ThesisType, string YearMin, string YearMax, int pageNo = 1)
        {
            var selectedThesisType = HttpContext.Request.Query["ThesisType"].ToString();
            var selectedLanguage = HttpContext.Request.Query["Language"].ToString();

            ViewData["ThesisTypes"] = await _context.Theses.OrderBy(t => t.Type).Select(t => new SelectListItem { Value = t.Type, Text = t.Type, Selected = selectedThesisType.Equals(t.Type) }).Distinct().ToListAsync();
            ViewData["Languages"] = await _context.Theses.OrderBy(t => t.Language).Select(l => new SelectListItem { Value = l.Language, Text = l.Language, Selected = selectedLanguage.Equals(l.Language) }).Distinct().ToListAsync();

            var scanPageModel = new ScanPageModel();

            var theses = _context.Theses.AsQueryable();

            if (HttpContext.Request.Query.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(University))
                {
                    theses = theses.Where(t => t.University.UniversityName.Contains(University));
                }
                if (!string.IsNullOrWhiteSpace(Institute))
                {
                    theses = theses.Where(t => t.Institute.InstituteName.Contains(Institute));
                }
                if (!string.IsNullOrWhiteSpace(Language))
                {
                    theses = theses.Where(t => t.Language.Contains(Language));
                }
                if (!string.IsNullOrWhiteSpace(Author))
                {
                    theses = theses.Where(t => t.Author.AuthorName.Contains(Author) || t.Author.AuthorSurname.Contains(Author));
                }
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    theses = theses.Where(t => t.Keywords.Any(x => x.KeywordName.Contains(Keyword)));
                }
                if (!string.IsNullOrWhiteSpace(ThesisNo))
                {
                    theses = theses.Where(t => t.ThesisNo.ToString().Contains(ThesisNo));
                }
                if (!string.IsNullOrWhiteSpace(ThesisName))
                {
                    theses = theses.Where(t => t.Title.Contains(ThesisName));
                }
                if (!string.IsNullOrWhiteSpace(ThesisType))
                {
                    theses = theses.Where(t => t.Type.Contains(ThesisType));
                }
                if (!string.IsNullOrWhiteSpace(YearMin))
                {
                    theses = theses.Where(t => t.SubmissionDate.Year >= Convert.ToInt32(YearMin));
                }
                if (!string.IsNullOrWhiteSpace(YearMax))
                {
                    theses = theses.Where(t => t.SubmissionDate.Year <= Convert.ToInt32(YearMax));
                }
            }

            scanPageModel.TotalPages = (int)Math.Ceiling(theses.Count() / (double)pageSize);
            scanPageModel.PageIndex = pageNo;
            scanPageModel.ThesisList = await theses.Select(t => new Thesis
            {
                ThesisNo = t.ThesisNo,
                ThesisName = t.Title,
                Author = t.Author.AuthorName + " " + t.Author.AuthorSurname,
                University = t.University.UniversityName,
                Institute = t.Institute.InstituteName,
                Language = t.Language,
                Type = t.Type,
                Year = t.SubmissionDate.Year,
                Subjects = t.TSubjects.Select(ts => ts.SubjectTopic.SubjectTopicName).ToList()
            }).OrderBy(t => t.ThesisNo).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToListAsync();

            return View(scanPageModel);
        }

        public async Task<IActionResult> DetailAsync(int thesisNo)
        {
            var thesis = await _context.Theses.Include(x => x.Author).Include(x => x.Supervisor).Include(x => x.CoSupervisor)
                                                .Include(x => x.University).Include(x => x.Institute).Include(x => x.Keywords)
                                                .Include(x => x.TSubjects).ThenInclude(x => x.SubjectTopic).FirstOrDefaultAsync(x => x.ThesisNo == thesisNo);
            return View(thesis);
        }
    }
}
