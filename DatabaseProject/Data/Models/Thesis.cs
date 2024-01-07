using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Data.Models
{
    public partial class Thesis
    {
        public Thesis()
        {
            Keywords = new HashSet<Keyword>();
            TSubjects = new HashSet<TSubject>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ThesisNo { get; set; }
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

        public virtual Author Author { get; set; } = null!;
        public virtual CoSupervisor? CoSupervisor { get; set; }
        public virtual Institute Institute { get; set; } = null!;
        public virtual Supervisor? Supervisor { get; set; }
        public virtual University University { get; set; } = null!;
        public virtual ICollection<Keyword> Keywords { get; set; }
        public virtual ICollection<TSubject> TSubjects { get; set; }
    }
}
