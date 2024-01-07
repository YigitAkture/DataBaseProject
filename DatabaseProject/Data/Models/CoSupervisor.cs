using System;
using System.Collections.Generic;

namespace DatabaseProject.Data.Models
{
    public partial class CoSupervisor
    {
        public CoSupervisor()
        {
            Theses = new HashSet<Thesis>();
        }

        public string CoSupervisorId { get; set; } = null!;
        public string CoSupervisorName { get; set; } = null!;
        public string CoSupervisorSurname { get; set; } = null!;
        public short CoSupervisorAge { get; set; }

        public virtual ICollection<Thesis> Theses { get; set; }
    }
}
