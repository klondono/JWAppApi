using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class TerritoryActivity
    {
        public int FieldServiceActivityId { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Notes { get; set; }
        public string HouseholderFirstName { get; set; }
        public string HouseholderLastName { get; set; }
        public string HouseholderPhoneNumber { get; set; }
        public bool UpdateTerritory { get; set; }
        public int AddressId { get; set; }
        public string FieldServiceSymbol { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? UserAdded { get; set; }
        public int? UserModified { get; set; }
        public string UserAddedLong { get; set; }
        public string UserModifiedLong { get; set; }

        public Address Address { get; set; }
        public FieldServiceSymbol FieldServiceSymbolNavigation { get; set; }
    }
}
