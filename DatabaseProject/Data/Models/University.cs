using System;
using System.Collections.Generic;

namespace DatabaseProject.Data.Models
{
    public partial class University
    {
        public University()
        {
            Institutes = new HashSet<Institute>();
            Theses = new HashSet<Thesis>();
        }

        public int UniversityId { get; set; }
        public string UniversityName { get; set; } = null!;
        public string UniversityAddress { get; set; } = null!;

        public virtual ICollection<Institute> Institutes { get; set; }
        public virtual ICollection<Thesis> Theses { get; set; }
    }
}
