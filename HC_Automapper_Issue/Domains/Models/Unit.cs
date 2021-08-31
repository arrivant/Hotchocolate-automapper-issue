using System;
using System.Collections.Generic;

#nullable disable

namespace HC_Automapper_Issue.Domains.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
