using System;
using System.Collections.Generic;

namespace DatabaseProject.Data.Models
{
    public partial class SubjectTopic
    {
        public SubjectTopic()
        {
            TSubjects = new HashSet<TSubject>();
        }

        public int SubjectTopicId { get; set; }
        public string SubjectTopicName { get; set; } = null!;

        public virtual ICollection<TSubject> TSubjects { get; set; }
    }
}
