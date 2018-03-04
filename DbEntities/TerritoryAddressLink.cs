using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class TerritoryAddressLink
    {
        public int TerritoryAddressLinkId { get; set; }
        public int? TerritoryId { get; set; }
        public int? AddressId { get; set; }
        public bool? IsActive { get; set; }
        public string HouseholderFirstName { get; set; }
        public string HouseholderLastName { get; set; }
        public string HouseholderPhoneNumber { get; set; }
        public int? PersonId { get; set; }

        public Address Address { get; set; }
        public Person Person { get; set; }
        public Territory Territory { get; set; }
    }
}
