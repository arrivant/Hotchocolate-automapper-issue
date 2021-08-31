using System.Collections.Generic;

#nullable disable

namespace HC_Automapper_Issue.Domains.Models
{
    public partial class Position
    {
        public Position()
        {
            Employments = new HashSet<Employment>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OtherField { get; set; }

        public virtual ICollection<Employment> Employments { get; set; }
    }
}
