using System;
using System.Collections.Generic;

namespace DatabaseProject.Data.Models
{
    public partial class Institute
    {
        public Institute()
        {
            Theses = new HashSet<Thesis>();
        }

        public int InstituteId { get; set; }
        public string InstituteName { get; set; } = null!;
        public int UniversityId { get; set; }

        public virtual University University { get; set; } = null!;
        public virtual ICollection<Thesis> Theses { get; set; }
    }
}
