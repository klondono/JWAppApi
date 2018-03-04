using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class PersonServicePrivilegeLink
    {
        public int PersonServicePrivilegeLinkId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? UserAdded { get; set; }
        public int? UserModified { get; set; }
        public int? PersonId { get; set; }
        public int? ServicePrivilegeId { get; set; }

        public Person Person { get; set; }
        public ServicePrivilege ServicePrivilege { get; set; }
    }
}
