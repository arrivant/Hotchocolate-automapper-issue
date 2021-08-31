using System;
using System.Collections.Generic;

#nullable disable

namespace HC_Automapper_Issue.Domains.Models
{
    public partial class UnitDto
    {
        public UnitDto()
        {
            Addresses = new HashSet<AddressDto>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }

        public virtual PersonDto Person { get; set; }
        public virtual ICollection<AddressDto> Addresses { get; set; }
    }
}
