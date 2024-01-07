using System;
using System.Collections.Generic;

namespace DatabaseProject.Data.Models
{
    public partial class Keyword
    {
        public int KeywordId { get; set; }
        public string KeywordName { get; set; } = null!;
        public int? ThesisNo { get; set; }

        public virtual Thesis? Thesis { get; set; }
    }
}
