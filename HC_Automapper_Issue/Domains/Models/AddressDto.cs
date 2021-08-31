using System;

#nullable disable

namespace HC_Automapper_Issue.Domains.Models
{
    public partial class AddressDto
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string PostalPlace { get; set; }
        public Guid Guid { get; set; }

        public virtual UnitDto Unit { get; set; }
    }
}
