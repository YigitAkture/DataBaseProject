using DatabaseProject.Data;
using DatabaseProject.Data.Models;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    [Authorize]
    public class ThesisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThesisController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ViewData["AuthorList"] = await GetAuthorListAsync();
            ViewData["UniversityList"] = await GetUniversityListAsync();
            ViewData["SupervisorList"] = await GetSupervisorListAsync();
            ViewData["CoSupervisorList"] = await GetCoSupervisorListAsync();
            ViewData["SubjectTopicList"] = await GetSubjectTopicListAsync();

            return View();
        }

        public async Task<JsonResult> GetIntitutesByUniversityAsync(int universityId)
        {
            var instituteList = await _context.Institutes.Where(x => x.UniversityId == universityId).OrderBy(x => x.InstituteName).Select(x => new { Text = x.InstituteName, Value = x.InstituteId.ToString() }).ToListAsync();
            instituteList.Insert(0, new { Text = "Please Choose", Value = "" });
            return Json(instituteList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CreateThesisModel thesis)
        {
            if (ModelState.IsValid)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == thesis.AuthorId);
                var university = await _context.Universities.FirstOrDefaultAsync(x => x.UniversityId == thesis.UniversityId);
                var institute = await _context.Institutes.FirstOrDefaultAsync(x => x.InstituteId == thesis.InstitueId);
                var supervisor = await _context.Supervisors.FirstOrDefaultAsync(x => x.SupervisorId == thesis.SupervisorId);
                var coSupervisor = await _context.CoSupervisors.FirstOrDefaultAsync(x => x.CoSupervisorId == thesis.CoSupervisorId);

                var newThesis = new Data.Models.Thesis
                {
                    Title = thesis.Title,
                    Abstract = thesis.Abstract,
                    AuthorId = author.AuthorId,
                    Type = thesis.Type,
                    UniversityId = university.UniversityId,
                    InstitueId = institute.InstituteId,
                    NumPages = thesis.NumPages,
                    Language = thesis.Language,
                    SubmissionDate = DateTime.UtcNow,
                    Author = author,
                    University = university,
                    Institute = institute
                };

                if (supervisor != null)
                {
                    newThesis.Supervisor = supervisor;
                    newThesis.SupervisorId = supervisor.SupervisorId;
                }
                if (coSupervisor != null)
                {
                    newThesis.CoSupervisor = coSupervisor;
                    newThesis.CoSupervisorId = coSupervisor.CoSupervisorId;
                }

                _context.Theses.Add(newThesis);
                await _context.SaveChangesAsync();

                var lastKeywordId = await _context.Keywords.OrderByDescending(x => x.KeywordId).Select(x => x.KeywordId).FirstAsync();
                var keywordList = thesis.Keywords.Split(";").ToList();
                var keywords = new List<Keyword>();
                int keywordIndex = lastKeywordId;
                foreach (var keyword in keywordList)
                {
                    keywordIndex++;
                    keywords.Add(new Keyword { KeywordId = keywordIndex, KeywordName = keyword , ThesisNo = newThesis.ThesisNo });
                }
                _context.Keywords.AddRange(keywords);

                var lastSubjectId = await _context.TSubjects.OrderByDescending(x => x.Id).Select(x => x.Id).FirstAsync();
                var tSubjects = new List<TSubject>();
                foreach (var subject in thesis.TSubjects)
                {
                    lastSubjectId++;
                    tSubjects.Add(new TSubject { Id = lastSubjectId, ThesisNo = newThesis.ThesisNo, SubjectTopicId = subject });
                }
                _context.TSubjects.AddRange(tSubjects);
                await _context.SaveChangesAsync();


                return RedirectToAction("Success");
            }

            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        private async Task<SelectList> GetAuthorListAsync()
        {
            var authorsItems = await _context.Authors.OrderBy(x => x.AuthorName).ThenBy(x => x.AuthorSurname).Select(x => new SelectListItem { Text = x.AuthorName + " " + x.AuthorSurname, Value = x.AuthorId }).ToListAsync();
            authorsItems.Insert(0, new SelectListItem { Text = "Please Choose", Value = "" });

            return new SelectList(authorsItems, "Value", "Text");
        }

        private async Task<SelectList> GetSupervisorListAsync()
        {
            var supervisorItems = await _context.Supervisors.OrderBy(x => x.SupervisorName).ThenBy(x => x.SupervisorSurname).Select(x => new SelectListItem { Text = x.SupervisorName + " " + x.SupervisorSurname, Value = x.SupervisorId }).ToListAsync();
            supervisorItems.Insert(0, new SelectListItem { Text = "Please Choose", Value = "" });

            return new SelectList(supervisorItems, "Value", "Text");
        }

        private async Task<SelectList> GetCoSupervisorListAsync()
        {
            var coSupervisorItems = await _context.CoSupervisors.OrderBy(x => x.CoSupervisorName).ThenBy(x => x.CoSupervisorSurname).Select(x => new SelectListItem { Text = x.CoSupervisorName + " " + x.CoSupervisorSurname, Value = x.CoSupervisorId }).ToListAsync();
            coSupervisorItems.Insert(0, new SelectListItem { Text = "Please Choose", Value = "" });

            return new SelectList(coSupervisorItems, "Value", "Text");
        }

        private async Task<SelectList> GetUniversityListAsync()
        {
            var universityItems = await _context.Universities.OrderBy(x => x.UniversityName).Select(x => new SelectListItem { Text = x.UniversityName, Value = x.UniversityId.ToString() }).ToListAsync();
            universityItems.Insert(0, new SelectListItem { Text = "Please Choose", Value = "" });

            return new SelectList(universityItems, "Value", "Text");
        }
        private async Task<SelectList> GetSubjectTopicListAsync()
        {
            var subjectTopicItems = await _context.SubjectTopics.OrderBy(x => x.SubjectTopicName).Select(x => new SelectListItem { Text = x.SubjectTopicName, Value = x.SubjectTopicId.ToString() }).ToListAsync();

            return new SelectList(subjectTopicItems, "Value", "Text");
        }
    }
}
