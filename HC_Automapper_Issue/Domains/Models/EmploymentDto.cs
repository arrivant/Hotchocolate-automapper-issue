using System;

#nullable disable

namespace HC_Automapper_Issue.Domains.Models
{
    public partial class EmploymentDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }

        public virtual PositionDto Position { get; set; }
    }
}
