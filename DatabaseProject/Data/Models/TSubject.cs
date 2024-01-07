using System;
using System.Collections.Generic;

namespace DatabaseProject.Data.Models
{
    public partial class TSubject
    {
        public int Id { get; set; }
        public int? ThesisNo { get; set; }
        public int? SubjectTopicId { get; set; }

        public virtual SubjectTopic? SubjectTopic { get; set; }
        public virtual Thesis? Thesis { get; set; }
    }
}
