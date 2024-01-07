using System;
using System.Collections.Generic;

namespace DatabaseProject.Data.Models
{
    public partial class Supervisor
    {
        public Supervisor()
        {
            Theses = new HashSet<Thesis>();
        }

        public string SupervisorId { get; set; } = null!;
        public string? SupervisorName { get; set; }
        public string? SupervisorSurname { get; set; }
        public short? SupervisorAge { get; set; }

        public virtual ICollection<Thesis> Theses { get; set; }
    }
}
