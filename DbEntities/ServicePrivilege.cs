using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class ServicePrivilege
    {
        public ServicePrivilege()
        {
            PersonServicePrivilegeLink = new HashSet<PersonServicePrivilegeLink>();
        }

        public int ServicePrivilegeId { get; set; }
        public string ServicePrivilegeName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? UserAdded { get; set; }
        public int? UserModified { get; set; }

        public ICollection<PersonServicePrivilegeLink> PersonServicePrivilegeLink { get; set; }
    }
}
