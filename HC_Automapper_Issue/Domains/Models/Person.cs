using System;

#nullable disable

namespace HC_Automapper_Issue.Domains.Models
{
    public partial class Person
    {
        public int UnitId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte? Sex { get; set; }
        public string Other { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
