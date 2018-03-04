using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class Territory
    {
        public Territory()
        {
            TerritoryAddressLink = new HashSet<TerritoryAddressLink>();
            TerritoryAssignment = new HashSet<TerritoryAssignment>();
        }

        public int TerritoryId { get; set; }
        public int TerritoryNumber { get; set; }
        public string TerritoryLocation { get; set; }
        public string TerritoryDescription { get; set; }
        public string TerritoryMapLink { get; set; }
        public int? CurrentlyAssigned { get; set; }
        public string CurrentlyAssignedLong { get; set; }
        public DateTime? AssignedOn { get; set; }
        public DateTime? LastPreached { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? UserAdded { get; set; }
        public int? UserModified { get; set; }
        public string UserAddedLong { get; set; }
        public string UserModifiedLong { get; set; }
        public int? CongregationId { get; set; }

        public Congregation Congregation { get; set; }
        public ICollection<TerritoryAddressLink> TerritoryAddressLink { get; set; }
        public ICollection<TerritoryAssignment> TerritoryAssignment { get; set; }
    }
}
