using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class TerritoryAssignment
    {
        public int TerritoryAssignmentId { get; set; }
        public int? TerritoryId { get; set; }
        public int? AssignedTo { get; set; }
        public string AssignedToLong { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public Territory Territory { get; set; }
    }
}
