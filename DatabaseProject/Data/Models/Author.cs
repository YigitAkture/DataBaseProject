using System;
using System.Collections.Generic;

namespace DatabaseProject.Data.Models
{
    public partial class Author
    {
        public Author()
        {
            Theses = new HashSet<Thesis>();
        }

        public string AuthorId { get; set; } = null!;
        public string? AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public short? AuthorAge { get; set; }

        public virtual ICollection<Thesis> Theses { get; set; }
    }
}
