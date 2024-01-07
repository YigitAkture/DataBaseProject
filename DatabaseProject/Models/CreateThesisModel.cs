using DatabaseProject.Data.Models;

namespace DatabaseProject.Models
{
    public class CreateThesisModel
    {
        public string Title { get; set; } = null!;
        public string Abstract { get; set; } = null!;
        public string AuthorId { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int UniversityId { get; set; }
        public int InstitueId { get; set; }
        public int NumPages { get; set; }
        public string Language { get; set; } = null!;
        public DateTime SubmissionDate { get; set; }
        public string? SupervisorId { get; set; }
        public string? CoSupervisorId { get; set; }
        public string Keywords { get; set; }
        public virtual ICollection<int> TSubjects { get; set; }
    }
}
