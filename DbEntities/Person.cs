using System;
using System.Collections.Generic;

namespace JWAppApi.DbEntities
{
    public partial class Person
    {
        public Person()
        {
            PersonServicePrivilegeLink = new HashSet<PersonServicePrivilegeLink>();
            TerritoryAddressLink = new HashSet<TerritoryAddressLink>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string FormattedName { get; set; }
        public DateTime? BaptismDate { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? UserAdded { get; set; }
        public int? UserModified { get; set; }
        public int? CongregationId { get; set; }
        public int? AddressId { get; set; }

        public Address Address { get; set; }
        public Congregation Congregation { get; set; }
        public ICollection<PersonServicePrivilegeLink> PersonServicePrivilegeLink { get; set; }
        public ICollection<TerritoryAddressLink> TerritoryAddressLink { get; set; }
    }
}
